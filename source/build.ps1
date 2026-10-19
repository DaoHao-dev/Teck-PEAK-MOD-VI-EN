$ErrorActionPreference = 'Stop'
$output = Join-Path $PSScriptRoot 'dist'
New-Item -ItemType Directory -Path $output -Force | Out-Null
$compiler = Join-Path $env:WINDIR 'Microsoft.NET/Framework64/v4.0.30319/csc.exe'
$argsList = @('/nologo','/target:winexe','/main:TeckPeak','/platform:anycpu','/optimize+','/utf8output',('/out:'+(Join-Path $output 'Teck-PEAK.exe')),('/win32manifest:'+(Join-Path $PSScriptRoot 'app.manifest')),('/win32icon:'+(Join-Path $PSScriptRoot 'assets/teck.ico')),'/reference:System.Windows.Forms.dll','/reference:System.Drawing.dll','/reference:System.Core.dll','/reference:System.Web.Extensions.dll','/reference:System.IO.Compression.dll','/reference:System.IO.Compression.FileSystem.dll')
$argsList += '/resource:'+(Join-Path $PSScriptRoot 'assets/famicom-real.png')+',peak.shell'
$argsList += '/resource:'+(Join-Path $PSScriptRoot 'assets/peak-header.jpg')+',peak.art'
$argsList += '/resource:'+(Join-Path $PSScriptRoot 'assets/teck.ico')+',peak.icon'
$argsList += '/resource:'+(Join-Path $PSScriptRoot 'mod-catalog.json')+',peak.catalog'
$argsList += Join-Path $PSScriptRoot 'PeakInstaller.cs'
$argsList += Join-Path $PSScriptRoot 'PeakLauncher.cs'
$argsList += Join-Path $PSScriptRoot 'PeakTests.cs'
& $compiler @argsList
if ($LASTEXITCODE -ne 0) { throw 'Compilation failed' }
$packages = Join-Path $output 'packages'
New-Item -ItemType Directory -Path $packages -Force | Out-Null
$catalog = Get-Content -LiteralPath (Join-Path $PSScriptRoot 'mod-catalog.json') -Raw -Encoding UTF8 | ConvertFrom-Json
foreach ($pkg in $catalog.Packages) { if ($pkg.Id -ne 'BepInEx-BepInExPack') { Copy-Item -LiteralPath (Join-Path (Join-Path $PSScriptRoot 'packages') $pkg.File) -Destination (Join-Path $packages $pkg.File) -Force } }
Copy-Item -LiteralPath (Join-Path $PSScriptRoot 'mod-catalog.json') -Destination (Join-Path $output 'mod-catalog.json') -Force
Get-FileHash -LiteralPath (Join-Path $output 'Teck-PEAK.exe') -Algorithm SHA256
# This script only compiles. Scan the output before running previews or tests.
