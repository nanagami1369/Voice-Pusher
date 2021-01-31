using System;
using System.Text;
using CoreLibrary.JsonConverter;
using Newtonsoft.Json;

namespace CoreLibrary.SettingModels
{
    public class Settings
    {
        private string _outputDirectoryPath = "";
        private static string UserDesktop => Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        public string OutputDirectoryPath
        {
            get => string.IsNullOrEmpty(_outputDirectoryPath)
                ? UserDesktop
                : _outputDirectoryPath;
            set => _outputDirectoryPath = value;
        }

        [JsonConverter(typeof(EncodingConverter))]
        public Encoding OutputEncode { get; set; } = new UTF8Encoding(false);

        public string NameScript { get; set; } = "{Number}_{Name}_{Script}";
    }
}
