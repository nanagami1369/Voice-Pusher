$ProjectRootDir = "$PSScriptRoot/../"
# プロジェクトのディレクトリへ移動
Push-Location $ProjectRootDir
# フォーマット
jb cleanupcode .\Voice-Pusher.sln
# 元のディレクトリへ
Pop-Location
