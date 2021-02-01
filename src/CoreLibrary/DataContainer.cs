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
        private Settings _settings = new();
        public Settings Setting
        {
            get => _settings;
            set => SetProperty(ref _settings, value);
        }

        public ICounter Counter { get; } = new Counter();
    }
}
