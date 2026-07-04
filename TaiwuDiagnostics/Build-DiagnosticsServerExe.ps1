param(
    [string]$Python = "python"
)

$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $MyInvocation.MyCommand.Path
$script = Join-Path $root "diagnostics_server.py"
$buildRoot = Join-Path $root "build\pyinstaller"

if (-not (Test-Path -LiteralPath $script)) {
    throw "diagnostics_server.py not found: $script"
}

try {
    & $Python -m PyInstaller --version | Out-Null
}
catch {
    throw "PyInstaller is not available for '$Python'. Install it first, for example: $Python -m pip install pyinstaller"
}

& $Python -m PyInstaller `
    --onefile `
    --clean `
    --noconfirm `
    --name TaiwuDiagnostics `
    --distpath $root `
    --workpath $buildRoot `
    --specpath $buildRoot `
    $script

Write-Host "Built $(Join-Path $root 'TaiwuDiagnostics.exe')"
