using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CommonLibrary;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using WinRT;

namespace CommonUILibrary.Models
{
    public class Dialog : IDialog
    {
        public async Task ShowMessageAsync(string title, string message)
        {
            MessageDialog messageBox = new MessageDialog(message, title);
            var window = messageBox.As<IInitializeWithWindow>();
            window.Initialize(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
            await messageBox.ShowAsync();
        }

        public async Task<bool> ShowConfirmationMessageAsync(
            string title,
            string message,
            string okButtonMessage = "はい",
            string noButtonMessage = "いいえ")
        {
            var messageBox = new MessageDialog(message, title);
            messageBox.Commands.Add(new UICommand(okButtonMessage, null, true));
            messageBox.Commands.Add(new UICommand(noButtonMessage, null, false));
            messageBox.DefaultCommandIndex = 1;
            messageBox.CancelCommandIndex = 1;
            var window = messageBox.As<IInitializeWithWindow>();
            window.Initialize(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
            var selectedCommand = await messageBox.ShowAsync();
            var messageBoxResult = (bool)selectedCommand.Id;
            return messageBoxResult;
        }

        public async Task<string> OpenFolderAsync()
        {
            var folderPicker = new FolderPicker()
            {
                SuggestedStartLocation = PickerLocationId.Desktop,
                FileTypeFilter = { "*" },
            };
            var window = folderPicker.As<IInitializeWithWindow>();
            window.Initialize(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
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
        private interface IInitializeWithWindow
        {
            void Initialize(IntPtr hwnd);
        }

    }

}
