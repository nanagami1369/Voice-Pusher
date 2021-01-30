$ProjectRootDir = "$PSScriptRoot/../"
# プロジェクトのディレクトリへ移動
Push-Location $ProjectRootDir
# フォーマット
xstyler.exe -r -d ./ -c .\Settings.XamlStyler
jb cleanupcode --exclude="**/*.xaml" .\Voice-Pusher.sln
# 元のディレクトリへ
Pop-Location
