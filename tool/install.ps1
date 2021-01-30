$toolDir = "$env:USERPROFILE\.dotnet\tools"
if (!(Test-Path "$toolDir/jb.exe")) {
    dotnet tool install -g JetBrains.ReSharper.GlobalTools
}
if (!(Test-Path "$toolDir/xstyler.exe")) {
    dotnet tool install --global XamlStyler.Console
}
