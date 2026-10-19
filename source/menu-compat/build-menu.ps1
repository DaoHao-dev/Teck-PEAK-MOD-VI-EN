param([string]$GameDir='C:/Program Files (x86)/Steam/steamapps/common/PEAK')
$ErrorActionPreference='Stop'
$game=$GameDir
$source=$PSScriptRoot
$original=$PSScriptRoot
$compiler = Join-Path $env:WINDIR 'Microsoft.NET/Framework64/v4.0.30319/csc.exe'
$output = Join-Path $PSScriptRoot 'compat-build'
New-Item -ItemType Directory -Path $output -Force | Out-Null
$compileArgs = @('/nologo','/noconfig','/nostdlib','/target:library','/optimize+','/langversion:5','/utf8output',('/out:'+(Join-Path $output 'PeakTrollMod.dll')))
foreach ($name in @('mscorlib.dll','System.dll','System.Core.dll','netstandard.dll')) { $compileArgs += '/reference:'+(Join-Path $game ('PEAK_Data/Managed/'+$name)) }
[xml]$project = Get-Content -LiteralPath (Join-Path $original 'PeakTrollMod.csproj') -Raw
foreach ($reference in $project.Project.ItemGroup.Reference) {
    if ($reference.HintPath -and $reference.Include -ne 'netstandard') {
        $path = ([string]$reference.HintPath).Replace('$(GameDir)', $game)
        if (Test-Path -LiteralPath $path) { $compileArgs += '/reference:'+$path } else { Write-Output ('Missing original reference: '+$path) }
    }
}
$compileArgs += @(Get-ChildItem -LiteralPath $source -Filter '*.cs' -Recurse | ForEach-Object { $_.FullName })
& $compiler @compileArgs
if ($LASTEXITCODE -ne 0) { throw 'Current-game compatibility build failed' }
