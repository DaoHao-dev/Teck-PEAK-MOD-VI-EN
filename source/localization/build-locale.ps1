param([string]$GameDir='C:/Program Files (x86)/Steam/steamapps/common/PEAK')
$ErrorActionPreference='Stop'
$compiler=Join-Path $env:WINDIR 'Microsoft.NET/Framework64/v4.0.30319/csc.exe'
$build=Join-Path $PSScriptRoot 'locale-build'
New-Item -ItemType Directory -Path $build -Force | Out-Null
$compileArgs=@('/nologo','/noconfig','/nostdlib','/target:library','/optimize+','/langversion:5','/utf8output',('/out:'+(Join-Path $build 'TeckPeakLocale.dll')))
foreach($name in @('mscorlib','System','System.Core','netstandard','UnityEngine','UnityEngine.CoreModule','UnityEngine.IMGUIModule','UnityEngine.InputLegacyModule','UnityEngine.TextRenderingModule')){
 $compileArgs+='/reference:'+(Join-Path $GameDir ('PEAK_Data/Managed/'+$name+'.dll'))
}
$compileArgs+='/reference:'+(Join-Path $GameDir 'BepInEx/core/BepInEx.dll')
$compileArgs+='/reference:'+(Join-Path $GameDir 'BepInEx/core/0Harmony.dll')
$compileArgs+='/resource:'+(Join-Path $PSScriptRoot 'translations.txt')+',teck.translations'
$compileArgs+=Join-Path $PSScriptRoot 'LocaleDictionary.cs'
$compileArgs+=Join-Path $PSScriptRoot 'TeckPeakLocale.cs'
& $compiler @compileArgs
if($LASTEXITCODE -ne 0){throw 'Localization compilation failed'}
