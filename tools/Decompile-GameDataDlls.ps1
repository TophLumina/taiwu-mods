<#
.SYNOPSIS
Decompiles all GameData*.dll assemblies under one or more source directories.

.DESCRIPTION
The script calls ILSpy command line tool (ilspycmd) and writes every assembly
to its own output directory:

  backend decompiled/GameData.ArchiveData/GameData/ArchiveData/...

This matches the current "backend decompiled" layout used by this workspace.

.EXAMPLE
.\tools\Decompile-GameDataDlls.ps1 `
  -SourceDirs "D:\SteamLibrary\steamapps\common\The Scroll Of Taiwu\Backend" `
  -OutputDir ".\backend decompiled" `
  -Clean

.EXAMPLE
.\tools\Decompile-GameDataDlls.ps1 `
  -IlspyCmd "C:\Tools\ilspycmd.exe" `
  -SourceDirs ".\GameBackend", ".\ExtraBackendDlls"
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string[]] $SourceDirs,

    [string] $OutputDir = (Join-Path (Split-Path -Parent $PSScriptRoot) "backend decompiled"),

    [string] $IlspyCmd = "ilspycmd",

    [bool] $Recurse = $true,

    [switch] $Clean
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function Resolve-ExistingDirectory {
    param(
        [Parameter(Mandatory = $true)]
        [string] $Path
    )

    $resolved = Resolve-Path -LiteralPath $Path -ErrorAction Stop
    if (-not (Test-Path -LiteralPath $resolved.Path -PathType Container)) {
        throw "Path is not a directory: $Path"
    }

    return $resolved.Path
}

function Resolve-IlspyCommand {
    param(
        [Parameter(Mandatory = $true)]
        [string] $Command
    )

    if (Test-Path -LiteralPath $Command -PathType Leaf) {
        return (Resolve-Path -LiteralPath $Command).Path
    }

    $cmd = Get-Command $Command -ErrorAction SilentlyContinue
    if ($null -eq $cmd) {
        throw @"
Cannot find ILSpy command line tool: $Command

Install it with:
  dotnet tool install --global ilspycmd

Or pass the full path:
  -IlspyCmd "C:\Path\To\ilspycmd.exe"
"@
    }

    return $cmd.Source
}

function Get-GameDataAssemblies {
    param(
        [Parameter(Mandatory = $true)]
        [string[]] $Directories,

        [Parameter(Mandatory = $true)]
        [bool] $Recursive
    )

    $option = if ($Recursive) { [System.IO.SearchOption]::AllDirectories } else { [System.IO.SearchOption]::TopDirectoryOnly }
    $files = New-Object System.Collections.Generic.List[System.IO.FileInfo]

    foreach ($dir in $Directories) {
        $resolvedDir = Resolve-ExistingDirectory -Path $dir
        [System.IO.Directory]::EnumerateFiles($resolvedDir, "GameData*.dll", $option) |
            ForEach-Object {
                $files.Add([System.IO.FileInfo]::new($_))
            }
    }

    return $files |
        Group-Object -Property BaseName |
        ForEach-Object {
            $group = @($_.Group | Sort-Object LastWriteTimeUtc -Descending)
            if ($group.Count -gt 1) {
                Write-Warning ("Found duplicate assembly '{0}', using newest: {1}" -f $_.Name, $group[0].FullName)
            }
            $group[0]
        } |
        Sort-Object BaseName
}

function Remove-AssemblyOutputDirectory {
    param(
        [Parameter(Mandatory = $true)]
        [string] $AssemblyOutputDir,

        [Parameter(Mandatory = $true)]
        [string] $ResolvedOutputRoot
    )

    if (-not (Test-Path -LiteralPath $AssemblyOutputDir -PathType Container)) {
        return
    }

    $fullTarget = [System.IO.Path]::GetFullPath($AssemblyOutputDir)
    $fullRoot = [System.IO.Path]::GetFullPath($ResolvedOutputRoot).TrimEnd('\', '/')
    if (-not $fullTarget.StartsWith($fullRoot + [System.IO.Path]::DirectorySeparatorChar, [System.StringComparison]::OrdinalIgnoreCase)) {
        throw "Refusing to remove directory outside output root: $fullTarget"
    }

    Remove-Item -LiteralPath $AssemblyOutputDir -Recurse -Force
}

$ilspy = Resolve-IlspyCommand -Command $IlspyCmd
$resolvedOutputDir = [System.IO.Path]::GetFullPath((Join-Path (Get-Location) $OutputDir))
New-Item -ItemType Directory -Force -Path $resolvedOutputDir | Out-Null

$assemblies = @(Get-GameDataAssemblies -Directories $SourceDirs -Recursive $Recurse)
if ($assemblies.Count -eq 0) {
    Write-Warning "No GameData*.dll files found."
    return
}

Write-Host ("ILSpy: {0}" -f $ilspy)
Write-Host ("Output: {0}" -f $resolvedOutputDir)
Write-Host ("Assemblies: {0}" -f $assemblies.Count)

$failed = New-Object System.Collections.Generic.List[string]

foreach ($assembly in $assemblies) {
    $assemblyName = [System.IO.Path]::GetFileNameWithoutExtension($assembly.Name)
    $assemblyOutputDir = Join-Path $resolvedOutputDir $assemblyName

    Write-Host ("Decompile {0}" -f $assembly.Name)

    if ($Clean) {
        Remove-AssemblyOutputDirectory -AssemblyOutputDir $assemblyOutputDir -ResolvedOutputRoot $resolvedOutputDir
    }
    New-Item -ItemType Directory -Force -Path $assemblyOutputDir | Out-Null

    & $ilspy `
        --project `
        --nested-directories `
        --disable-updatecheck `
        --outputdir $assemblyOutputDir `
        $assembly.FullName

    if ($LASTEXITCODE -ne 0) {
        $failed.Add($assembly.FullName)
    }
}

if ($failed.Count -gt 0) {
    $list = $failed -join [Environment]::NewLine
    throw "ILSpy failed for $($failed.Count) assembly file(s):$([Environment]::NewLine)$list"
}

Write-Host "Done."
