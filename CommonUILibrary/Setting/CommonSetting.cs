using System;
using System.Text;
using CommonLibrary.Modules.SettingModule;
using Newtonsoft.Json;

namespace CommonUILibrary.Setting
{
    public class CommonSetting : ICommonSetting
    {
        private string _outPutDirectoryPath;

        /// <summary>
        /// 音声とテキストファイルの出力先を指定する。
        /// 保存先が未入力の場合は、ユーザーのデスクトップを指定する。
        /// </summary>
        public string OutPutDirectoryPath
        {
            get
            {
                if (!string.IsNullOrEmpty(_outPutDirectoryPath))
                {
                    return _outPutDirectoryPath;
                }

                var userDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                _outPutDirectoryPath = userDesktop;

                return _outPutDirectoryPath;
            }
            set => _outPutDirectoryPath = value;
        }

        public Encoding OutPutTextEncode { get; set; }

        public bool IsLogWrite { get; set; }
        public string NameScript { get; set; }
    }
}
