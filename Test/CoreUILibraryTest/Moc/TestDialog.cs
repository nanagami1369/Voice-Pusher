using System.Threading.Tasks;
using CommonLibrary;

namespace CoreUILibrary.Moc
{
    class TestDialog : IDialog
    {
        public string ShowedTitle { get; private set; }
        public string ShowedMessage { get; private set; }
        public Task ShowMessageAsync(string title, string message)
        {
            ShowedMessage = message;
            // テストでは非同期である必要は無いので暫定でこのようにする。
            // テストで問題がでれば修正する。
            return Task.Run(() => { });
        }

        public Task<string> OpenFolderAsync()
        {
            return null;
        }
    }
}
