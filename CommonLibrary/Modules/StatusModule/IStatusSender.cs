namespace CommonLibrary.Modules.StatusModule
{
    public interface IStatusSender
    {
        void Send(StatusLevel level, string message);
    }
}
