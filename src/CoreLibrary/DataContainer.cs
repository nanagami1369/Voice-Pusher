using CoreLibrary.CharacterModels;
using CoreLibrary.SettingModels;
using CoreLibrary.StatusModels;
using Prism.Mvvm;

namespace CoreLibrary
{
    public class DataContainer : BindableBase, IDataContainer
    {
        private ICharacterLibrary? _characterLibrary;
        private Status? _currentStatus;

        public Status? CurrentStatus
        {
            get => _currentStatus;
            set => SetProperty(ref _currentStatus, value);
        }

        public SettingsManager SettingsManager { get; } = new();

        public ICounter Counter { get; } = new Counter();

        public ICharacterLibrary? CharacterLibrary
        {
            get => _characterLibrary;
            set => SetProperty(ref _characterLibrary, value);
        }
    }
}
