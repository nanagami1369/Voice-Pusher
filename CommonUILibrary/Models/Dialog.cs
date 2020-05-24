using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CommonLibrary;
using Windows.Storage.Pickers;
using Windows.UI.Popups;

namespace CommonUILibrary.Models
{
    public class Dialog : IDialog
    {
        public async Task ShowMessage(string title, string message)
        {
            MessageDialog messageBox = new MessageDialog(message, title);
            ((IInitializeWithWindow)(object)messageBox).Initialize(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
            await messageBox.ShowAsync();
        }

        public async Task<string> OpenFolderAsync()
        {
            var folderPicker = new FolderPicker()
            {
                SuggestedStartLocation = PickerLocationId.Desktop,
                FileTypeFilter = { "*" },
            };
            ((IInitializeWithWindow)(object)folderPicker).Initialize(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
            var folder = await folderPicker.PickSingleFolderAsync();
            if (folder == null)
            {
                return null;
            }
            return folder.Path;

        }


        //UWP関連のAPIにウィンドウハンドルを伝えるのに使う。
        [ComImport]
        [Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IInitializeWithWindow
        {
            void Initialize(IntPtr hwnd);
        }

    }

}
