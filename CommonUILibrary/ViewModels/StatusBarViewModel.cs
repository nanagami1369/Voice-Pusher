using CommonLibrary;
using Prism.Mvvm;

namespace CommonUILibrary.ViewModels
{
    public class StatusBarViewModel : BindableBase
    {
        private readonly StatusCommunication _statusCommunication;

        private Status _status;
        public Status Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }



        public StatusBarViewModel(StatusCommunication statusCommunication)
        {
            _statusCommunication = statusCommunication;
            _statusCommunication.Receive(status => Status = status);
        }
    }
}
