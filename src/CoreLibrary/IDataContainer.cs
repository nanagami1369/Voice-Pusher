using CoreLibrary.SettingModels;
using CoreLibrary.StatusModels;

namespace CoreLibrary
{
    public interface IDataContainer
    {
        public Status? CurrentStatus { get; set; }
        public Settings Setting { get; set; }

        public ICounter Counter { get; }
    }
}
