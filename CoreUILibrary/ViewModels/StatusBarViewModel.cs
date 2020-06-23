using CommonLibrary;
using CommonLibrary.Modules.StatusModule;
using CoreUILibrary.Models;
using Prism.Mvvm;

namespace CoreUILibrary.ViewModels
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

        public ICounter Counter { get; }


        public StatusBarViewModel(StatusCommunication statusCommunication, ICounter counter)
        {
            Counter = counter;
            _statusCommunication = statusCommunication;
            _statusCommunication.Receive(status => Status = status);
        }
    }
}
