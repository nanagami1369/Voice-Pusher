using CommonLibrary.Modules.StatusModule;

namespace CoreUILibrary.Moc
{
    class TestStatusSender : IStatusSender
    {
        public Status SentMessage { get; private set; }

        public void Send(StatusLevel level, string message)
        {
            SentMessage = new Status(level, message);
        }
    }
}
