using CoreLibrary.SettingModels;
using CoreLibrary.StatusModels;
using Prism.Mvvm;

namespace CoreLibrary
{
    public class DataContainer : BindableBase, IDataContainer
    {
        private Status? _currentStatus;

        public Status? CurrentStatus
        {
            get => _currentStatus;
            set => SetProperty(ref _currentStatus, value);
        }
        public Settings Setting { get; set; } = new();
    }
}
