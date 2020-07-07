using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CommonLibrary;

namespace CoreUILibrary.Moc
{
    class TestDialog : IDialog
    {
        public string ShowedTitle { get; private set; }
        public string ShowedMessage { get; private set; }
        public async Task ShowMessageAsync(string title, string message)
        {
            ShowedMessage = message;
        }

        public Task<string> OpenFolderAsync()
        {
            return null;
        }

        public Task<bool> ShowConfirmationMessageAsync(string title, string message, string okButtonMessage = "はい", string noButtonMessage = "いいえ")
        {
            throw new System.NotImplementedException();
        }
    }
}
