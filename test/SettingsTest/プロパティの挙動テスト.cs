using System;
using CoreLibrary.SettingModels;
using Xunit;

namespace SettingsTest
{
    public class プロパティの挙動テスト
    {
        [Fact]
        public void ファイルパスが存在する場合にファイルパスを返すか()
        {
            var settings = new Settings
            {
                OutputDirectoryPath = @"C:\"
            };
            Assert.Equal(@"C:\", settings.OutputDirectoryPath);
        }

        [Fact]
        public void ファイルパスが存在しない場合にディスクトップのパスを返すか()
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var settings = new Settings
            {
                OutputDirectoryPath = @""
            };
            Assert.Equal(desktopPath, settings.OutputDirectoryPath);
        }
    }
}
