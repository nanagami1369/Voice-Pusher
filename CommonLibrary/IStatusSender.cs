namespace CommonLibrary
{
    public interface IStatusSender
    {
        void Send(StatusLevel level, string message);
    }
}
