using System;
using System.Windows;
using CommonLibrary;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CommonUILibrary.Models
{
    public class Dialog : IDialog
    {
        public void ShowMessage(string title, string message)
        {
            MessageBox.Show(message, title);
        }

        public string OpenFolder(string title, string defaultFolder = "")
        {
            if (string.IsNullOrEmpty(defaultFolder))
            {
                defaultFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }

            var folderDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true, Title = title, DefaultDirectory = defaultFolder
            };

            if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                return folderDialog.FileName;
            }

            return null;
        }
    }
}
