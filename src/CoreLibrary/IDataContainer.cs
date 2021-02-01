using CoreLibrary.StatusModels;

namespace CoreLibrary
{
    public interface IDataContainer
    {
        public Status? CurrentStatus { get; set; }

        public ICounter Counter { get; }
    }
}
