using System;
using System.Text;
using CoreLibrary.JsonConverter;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace CoreLibrary.SettingModels
{
    public class Settings : BindableBase
    {
        private string _nameScript = "{Number}_{Name}_{Script}";
        private string _outputDirectoryPath = "";

        private Encoding _outputEncode = new UTF8Encoding(false);
        private static string UserDesktop => Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        public string OutputDirectoryPath
        {
            get => string.IsNullOrEmpty(_outputDirectoryPath)
                ? UserDesktop
                : _outputDirectoryPath;
            set => SetProperty(ref _outputDirectoryPath, value);
        }

        [JsonConverter(typeof(EncodingConverter))]
        public Encoding OutputEncode
        {
            get => _outputEncode;
            set => SetProperty(ref _outputEncode, value);
        }

        public string NameScript
        {
            get => _nameScript;
            set => SetProperty(ref _nameScript, value);
        }
    }
}
