namespace CommonLibrary.Modules.StatusModule
{
    public class Status
    {
        public string Message { get; private set; }
        public StatusLevel Level { get; private set; }

        public Status(StatusLevel level, string message)
        {
            Message = message;
            Level = level;
        }
    }
}
