using CoreLibrary.SettingModels;
using CoreLibrary.StatusModels;

namespace CoreLibrary
{
    public interface IDataContainer
    {
        public Status? CurrentStatus { get; set; }
        public SettingsManager SettingsManager { get; }

        public ICounter Counter { get; }
    }
}
