using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface IDialog
    {
        Task ShowMessage(string title, string message);

        Task<string> OpenFolderAsync();
    }
}
