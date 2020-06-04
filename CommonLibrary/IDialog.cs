using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface IDialog
    {
        Task ShowMessageAsync(string title, string message);

        Task<bool> ShowConfirmationMessageAsync(
            string title, string message, string okButtonMessage = "はい", string noButtonMessage = "いいえ");

        Task<string> OpenFolderAsync();
    }
}
