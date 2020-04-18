using CommonLibrary.Modules.StatusModule;
using Prism.Commands;
using Prism.Mvvm;

namespace UITest.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IStatusSender _statusSender;
        private string _title = "UTest";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

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

        public MainWindowViewModel(IStatusSender statusSender)
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

        {
            _statusSender = statusSender;
            ChangeStatusBarCommand = new DelegateCommand(ChangeStatusBar);
            ChangeCharacterEditorCommand = new DelegateCommand(ChangeCharacterEditor);
        }
    }
}
