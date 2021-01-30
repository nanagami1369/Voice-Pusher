using System.Linq;
using CoreLibrary;
using CoreLibrary.StatusModels;
using Prism.Commands;
using Prism.Mvvm;

namespace Voice_Pusher.ViewModels
{
    public class DebugViewModel : BindableBase
    {
        private string _message = "";
        private StatusLevel _selectedStatusLevel;

        public DebugViewModel(IDataContainer container)
        {
            _selectedStatusLevel = StatusLevels.First();
            Container = container;
            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        public IDataContainer Container { get; }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public DelegateCommand SendMessageCommand { get; }

        public StatusLevel SelectedStatusLevel
        {
            get => _selectedStatusLevel;
            set => SetProperty(ref _selectedStatusLevel, value);
        }

        public StatusLevel[] StatusLevels { get; } =
        {
            StatusLevel.Success, StatusLevel.Log, StatusLevel.Warning, StatusLevel.Error
        };

        private void SendMessage()
        {
            Container.CurrentStatus
                = new Status(SelectedStatusLevel, Message);
        }
    }
}
