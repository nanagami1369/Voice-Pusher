using System.Threading.Tasks;
using CommonLibrary;
using CommonLibrary.Modules.MenuModule;
using CommonLibrary.Modules.SettingModule;
using CommonLibrary.Modules.StatusModule;
using CommonUILibrary.Commands;
using CommonUILibrary.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace UITest.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IStatusSender _statusSender;
        private readonly ISettingContainer _settingManager;
        private readonly IDialog _dialog;
        private readonly IMenuContainerReader _menuContainer;
        private string _title = "UTest";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private ISetting Setting => _settingManager.Read();

        private async Task ShowSettingAsync()
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
            await _dialog.ShowMessageAsync("設定内容", settingString);
        }

        public DelegateCommand ShowSettingCommand { get; }

        private async Task ShowMenuAsync()
        {
            var menuName = _menuContainer.Read().Name;
            await _dialog.ShowMessageAsync("メニューの画面", menuName);
        }
        public DelegateCommand ShowMenuCommand { get; }

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

        public IHotKeyContainer HotKeyContainer { get; }

        private async Task ShowHotKeysAsync()
        {
            await _dialog.ShowMessageAsync("hotKeys", HotKeyContainer.Value.ToString());
        }
        public DelegateCommand ShowHotKeysCommand { get; }


        private IApplicationCommands _applicationCommands;
        public IApplicationCommands ApplicationCommands
        {
            get => _applicationCommands;
            set => SetProperty(ref _applicationCommands, value);
        }

        public MainWindowViewModel(
            IStatusSender statusSender,
            ISettingContainer settingManager,
            IDialog dialog,
            IMenuContainerReader menuContainer,
            IHotKeyContainer hotKeyContainer,
            IApplicationCommands applicationCommands)
        {
            _statusSender = statusSender;
            _settingManager = settingManager;
            _dialog = dialog;
            _menuContainer = menuContainer;
            HotKeyContainer = hotKeyContainer;
            ApplicationCommands = applicationCommands;
            ShowSettingCommand = new DelegateCommand(async () => await ShowSettingAsync());
            ShowMenuCommand = new DelegateCommand(async () => await ShowMenuAsync());
            ChangeStatusBarCommand = new DelegateCommand(ChangeStatusBar);
            ShowHotKeysCommand = new DelegateCommand(async () => await ShowHotKeysAsync());
        }
    }
}
