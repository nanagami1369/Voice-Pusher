using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;
using CommonLibrary.Modules.SettingModule;
using CommonLibrary.Modules.StatusModule;
using CommonUILibrary.Setting;
using Prism.Mvvm;
using System.Linq;

namespace CoreUILibrary.Models
{
    public class SettingEditorPresenter : BindableBase, ISettingEditorPresenter
    {
        private readonly IStatusSender _statusSender;
        private readonly IDialog _dialog;
        private readonly ISettingRegistry _registry;
        private readonly ISettingContainer _container;

        #region SettingProperty

        private ISetting EditedSetting { get; set; }

        public List<Encoding> EncodeList { get; }

        private string _outPutDirectoryPath;

        public string OutPutDirectoryPath
        {
            get => _outPutDirectoryPath;
            set
            {
                SetProperty(ref _outPutDirectoryPath, value);
                EditedSetting.Common.OutPutDirectoryPath = value;
                WriterAndRegisterSettingAsync();
            }
        }

        private Encoding _outputTextEncode;

        public Encoding OutPutTextEncode
        {
            get => _outputTextEncode;
            set
            {
                SetProperty(ref _outputTextEncode, value);
                EditedSetting.Common.OutPutTextEncode = value;
                WriterAndRegisterSettingAsync();
            }
        }

        private bool _isLogWriter;

        public bool IsLogWrite
        {
            get => _isLogWriter;
            set
            {
                SetProperty(ref _isLogWriter, value);
                EditedSetting.Common.IsLogWrite = value;
                WriterAndRegisterSettingAsync();
            }
        }

        private string _nameScript;

        public string NameScript
        {
            get => _nameScript;
            set
            {
                SetProperty(ref _nameScript, value);
                EditedSetting.Common.NameScript = value;
                WriterAndRegisterSettingAsync();
            }
        }

        private Encoding _csvEncoding;

        public Encoding CsvEncode
        {
            get => _csvEncoding;
            set
            {
                SetProperty(ref _csvEncoding, value);
                EditedSetting.Script.CsvEncode = value;
                WriterAndRegisterSettingAsync();
            }
        }


        public IEnumerable<ScriptOutPutMode> ScriptOutPutModeList { get; }

        private ScriptOutPutMode _scriptOutPutMode;

        public ScriptOutPutMode ScriptOutputMode
        {
            get => _scriptOutPutMode;
            set
            {
                SetProperty(ref _scriptOutPutMode, value);
                EditedSetting.Script.OutputMode = value;
                WriterAndRegisterSettingAsync();
            }
        }

        #endregion

        public async Task SelectOutPutDirectoryPathAsync()
        {
            OutPutDirectoryPath =
                await _dialog.OpenFolderAsync() ?? OutPutDirectoryPath;
        }

        private bool _isEnabled;

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public async Task LoadSettingAsync()
        {
            _statusSender.Send(StatusLevel.Log, "読込中");
            IsEnabled = false;
            var setting = await _registry.ReadAsync(Config.SettingFileName, Config.SettingFileEncode)
                .ConfigureAwait(false);
            EditedSetting = setting;
            OutPutDirectoryPath = setting.Common.OutPutDirectoryPath;
            var outputTextEncode = setting.Common.OutPutTextEncode;
            OutPutTextEncode = EncodeList.Find(encode => encode.CodePage == outputTextEncode.CodePage);
            NameScript = setting.Common.NameScript;
            IsLogWrite = setting.Common.IsLogWrite;
            var csvEncode = setting.Script.CsvEncode;
            CsvEncode = EncodeList.Find(encode => encode.CodePage == csvEncode.CodePage);
            ScriptOutputMode = setting.Script.OutputMode;
            IsEnabled = true;
            _statusSender.Send(StatusLevel.Success, "設定の読み込みが完了しました");
        }

        public SettingEditorPresenter(
            ISettingRegistry settingRegistry,
            IStatusSender statusSender,
            IDialog dialog,
            ISettingContainer container
        )
        {
            _statusSender = statusSender;
            _dialog = dialog;
            _registry = settingRegistry;
            _container = container;

            // Shift-Jisを使えるようにする
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            EncodeList = new List<Encoding> { Encoding.GetEncoding(932), new UTF8Encoding(false) };

            ScriptOutPutModeList = Enum.GetValues(typeof(ScriptOutPutMode)).Cast<ScriptOutPutMode>();
        }

        private async void WriterAndRegisterSettingAsync()
        {
            _container.Register(EditedSetting);
            await _registry.WriterAsync(EditedSetting, Config.SettingFileName, Config.SettingFileEncode)
                .ConfigureAwait(false);
        }
    }
}
