using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface IDialog
    {
        Task ShowMessageAsync(string title, string message);

        Task<string> OpenFolderAsync();
    }
}
