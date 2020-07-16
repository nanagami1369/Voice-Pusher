using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommonLibrary;
using CommonLibrary.Modules.CharacterLibraryModule;
using CommonLibrary.Modules.SettingModule;
using CommonLibrary.Modules.StatusModule;
using CommonUILibrary.Setting;
using Prism.Mvvm;

namespace CoreUILibrary.Models
{
    public class SettingEditorPresenter : BindableBase, ISettingEditorPresenter, INotifyDataErrorInfo
    {
        private readonly IStatusSender _statusSender;
        private readonly IDialog _dialog;
        private readonly ISettingRegistry _registry;
        private readonly ISettingContainer _container;
        private readonly IFileNameConverter _fileNameConverter;

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

        public string RenamedNameExample
        {
            get
            {
                if (NameScript == null)
                {
                    return string.Empty;
                }
                return _fileNameConverter.Naming(TestCharacter, "こんにちは", NameScript, 0) + ".wav";
            }
        }

        private string _nameScript;

        [RegularExpression("^[^\\\\/:*?\"<>|]*$", ErrorMessage = "使用出来ない文字列が含まれてます[\\/:*?\"<>|]")]
        public string NameScript
        {
            get => _nameScript;
            set
            {
                SetProperty(ref _nameScript, value);
                EditedSetting.Common.NameScript = value;
                ValidateProperty(value);
                if (!Regex.IsMatch(value, "[\\\\/:*?\"<>|]"))
                {
                    WriterAndRegisterSettingAsync();
                };
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

        private Character TestCharacter { get; }

        public void Naming()
        {
            RaisePropertyChanged(nameof(RenamedNameExample));
        }

        private string _insertText;
        public string InsertText
        {
            get => _insertText;
            set => SetProperty(ref _insertText, value);
        }
        private bool _insertMacroSetFlag;
        public bool InsertMacroSetFlag
        {
            get => _insertMacroSetFlag;
            set => SetProperty(ref _insertMacroSetFlag, value);
        }

        private void SetFlag()
        {
            InsertMacroSetFlag = true;
            InsertMacroSetFlag = false;
        }


        public void AddNameScript(string script)
        {
            InsertText = script;
            SetFlag();
        }



        public async Task LoadSettingAsync()
        {
            _statusSender.Send(StatusLevel.Log, "読込中");
            IsEnabled = false;
            var setting = await _registry.ReadAsync(Config.SettingFileName, Config.ApplicationFileEncode)
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

        #region Error
        private readonly ErrorsContainer<string> _errors;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public IEnumerable GetErrors(string propertyName) => _errors.GetErrors(propertyName);
        public bool HasErrors => _errors.HasErrors;

        private void OnErrorsChanged([CallerMemberName] string propertyName = null)
            => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        protected void ValidateProperty(object value, [CallerMemberName] string propertyName = null)
        {
            var context = new ValidationContext(this)
            {
                MemberName = propertyName
            };
            var validationErrors = new List<ValidationResult>();
            if (!Validator.TryValidateProperty(value, context, validationErrors))
            {
                _errors.SetErrors(propertyName, validationErrors.Select(error => error.ErrorMessage));
            }
            else
            {
                _errors.ClearErrors(propertyName);
            }
        }
        #endregion


        public SettingEditorPresenter(
            ISettingRegistry settingRegistry,
            IStatusSender statusSender,
            IDialog dialog,
            IFileNameConverter fileNameConverter,
            ISettingContainer container
        )
        {
            _statusSender = statusSender;
            _dialog = dialog;
            _registry = settingRegistry;
            _fileNameConverter = fileNameConverter;
            _container = container;

            _errors = new ErrorsContainer<string>(OnErrorsChanged);
            // Shift-Jisを使えるようにする
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            EncodeList = new List<Encoding> { Encoding.GetEncoding(932), new UTF8Encoding(false) };

            ScriptOutPutModeList = Enum.GetValues(typeof(ScriptOutPutMode)).Cast<ScriptOutPutMode>();
            var testVoiceActor = new PartialVoiceActor("Haruka Desktop", "SAP", 0);
            TestCharacter = new PartialCharacter("Haruka", "ハルカ", testVoiceActor);
        }

        private async void WriterAndRegisterSettingAsync()
        {
            _container.Register(EditedSetting);
            await _registry.WriterAsync(EditedSetting, Config.SettingFileName, Config.ApplicationFileEncode)
                .ConfigureAwait(false);
        }
    }
}
