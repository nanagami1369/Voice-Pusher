namespace CoreLibrary.StatusModels
{
    public class Status
    {
        public Status(StatusLevel level, string message)
        {
            Message = message;
            Level = level;
        }

        public string Message { get; }
        public StatusLevel Level { get; }
    }
}
