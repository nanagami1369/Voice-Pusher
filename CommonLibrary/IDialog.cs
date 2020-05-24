using System;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface IDialog
    {
        void ShowMessage(string title, string message);

        string OpenFolder(string title, string defaultFolder);
    }
}
