using CommonLibrary;
using CommonLibrary.Modules.SettingModule;
using CommonLibrary.Modules.StatusModule;
using CommonUILibrary.Commands;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using CommonUILibrary.Setting;

namespace UITest.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IStatusSender _statusSender;
        private readonly IRegionManager _regionManager;
        private readonly ISettingContainer _settingManager;
        private readonly IDialog _dialog;
        private string _title = "UTest";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private ISetting Setting => _settingManager.Read();

        private void ShowSetting()
        {
            var setting = Setting;
            var settingString = @$"
  Common:
    OutPutDirectoryPath: {setting.Common.OutPutDirectoryPath},
    OutPutTextEncode: {setting.Common.OutPutTextEncode.CodePage},
    IsLogWrite: {setting.Common.IsLogWrite},
    NameScript: {setting.Common.NameScript}
  ,
  Script:
    CsvEncode: {setting.Script.CsvEncode.CodePage},
    OutputMode: {setting.Script.OutputMode}
";
            _dialog.ShowMessage("設定内容", settingString);
        }

        public DelegateCommand ShowSettingCommand { get; }
        public DelegateCommand ChangeStatusBarCommand { get; }
        private int Counter { get; set; }

        private readonly (StatusLevel, string)[] _statuses = new (StatusLevel, string)[4]
        {
            (StatusLevel.Success, StatusLevel.Success.Text),
            (StatusLevel.Log, StatusLevel.Log.Text),
            (StatusLevel.Warning, StatusLevel.Warning.Text),
            (StatusLevel.Error, StatusLevel.Error.Text),
        };

        public void ChangeStatusBar()
        {
            var (level, message) = _statuses[Counter];
            _statusSender.Send(level, message);
            Counter++;
            if (Counter == _statuses.Length)
            {
                Counter = 0;
            }
        }

        public DelegateCommand ChangeCharacterEditorCommand { get; }

        private bool isCharacterLibrary;
        public void ChangeCharacterEditor()
        {
            if (isCharacterLibrary)
            {
                _regionManager.RequestNavigate("ContentRegion", "VoiceEditorCharacterLibraryView");
                isCharacterLibrary = false;
            }
            else
            {
                _regionManager.RequestNavigate("ContentRegion", "CharacterEditorCharacterLibraryView");
                isCharacterLibrary = true;
            }
        }

        private IApplicationCommands _applicationCommands;
        public IApplicationCommands ApplicationCommands
        {
            get => _applicationCommands;
            set => SetProperty(ref _applicationCommands, value);
        }

        public MainWindowViewModel(IStatusSender statusSender,
            IRegionManager regionManager,
            ISettingContainer settingManager,
            IDialog dialog,
            IApplicationCommands applicationCommands)
        {
            _statusSender = statusSender;
            _regionManager = regionManager;
            _settingManager = settingManager;
            _dialog = dialog;
            ApplicationCommands = applicationCommands;
            ShowSettingCommand = new DelegateCommand(ShowSetting);
            ChangeStatusBarCommand = new DelegateCommand(ChangeStatusBar);
            ChangeCharacterEditorCommand = new DelegateCommand(ChangeCharacterEditor);
        }
    }
}
