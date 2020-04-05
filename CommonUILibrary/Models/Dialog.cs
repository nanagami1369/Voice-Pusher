using CommonLibrary;
using System.Windows;

namespace CommonUILibrary.Models
{
    public class Dialog : IDialog
    {
        public void ShowMessage(string title, string message)
        {
            MessageBox.Show(message, title);
        }
    }
}
