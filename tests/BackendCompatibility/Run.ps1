[CmdletBinding()]
param(
    [string] $GameBackendDir = 'D:\SteamLibrary\steamapps\common\The Scroll Of Taiwu\Backend'
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$repoRoot = (Resolve-Path -LiteralPath (Join-Path $PSScriptRoot '..\..')).Path
$backendPath = (Resolve-Path -LiteralPath $GameBackendDir).Path
$validationDir = Join-Path $repoRoot '.validation'
$optimizationDir = Join-Path $validationDir 'optimization'
$diagnosticsDir = Join-Path $validationDir 'diagnostics'
New-Item -ItemType Directory -Path $validationDir -Force | Out-Null

Push-Location -LiteralPath $repoRoot
try {
    # Build isolated copies; do not replace the distributable plugins or touch game saves.
    & dotnet build 'TaiwuOptimzation/src/TaiwuOptimization.Backend.csproj' -c Release --nologo -v minimal "-p:GameBackendDir=$backendPath" "-p:ModPluginDir=$optimizationDir"
    if ($LASTEXITCODE -ne 0) { throw 'Optimization build failed.' }
    & dotnet build 'TaiwuDiagnostics/src/TaiwuDiagnostics.Backend.csproj' -c Release --nologo -v minimal "-p:GameBackendDir=$backendPath" "-p:ModPluginDir=$diagnosticsDir"
    if ($LASTEXITCODE -ne 0) { throw 'Diagnostics build failed.' }
    & dotnet run --project $PSScriptRoot -c Release "-p:GameBackendDir=$backendPath" -- $backendPath `
        (Join-Path $repoRoot 'TaiwuOptimzation/Plugins/zlib-ng2.dll') `
        (Join-Path $optimizationDir 'TaiwuOptimization.dll') `
        (Join-Path $diagnosticsDir 'TaiwuDiagnostics.dll') |
        Tee-Object -FilePath (Join-Path $validationDir 'patch-audit.log')
    if ($LASTEXITCODE -ne 0) { throw 'Backend compatibility audit failed; see .validation/patch-audit.log.' }
}
finally {
    Pop-Location
}
