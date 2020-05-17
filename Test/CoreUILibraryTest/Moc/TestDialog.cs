using CommonLibrary;

namespace CoreUILibrary.Moc
{
    class TestDialog : IDialog
    {
        public string ShowedTitle { get; private set; }
        public string ShowedMessage { get; private set; }
        public void ShowMessage(string title, string message)
        {
            ShowedMessage = message;
        }
    }
}
