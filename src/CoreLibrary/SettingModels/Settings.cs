using System;
using System.Text;

namespace CoreLibrary.SettingModels
{
    public class Settings
    {
        private static string UserDesktop => Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        private string _outputDirectoryPath = "";

        public string OutputDirectoryPath
        {
            get => string.IsNullOrEmpty(_outputDirectoryPath)
                ? UserDesktop
                : _outputDirectoryPath;
            set => _outputDirectoryPath = value;
        }

        public Encoding OutputEncode { get; set; } = new UTF8Encoding(false);

        public string NameScript { get; set; } = "{Number}_{Name}_{Script}";
    }
}
