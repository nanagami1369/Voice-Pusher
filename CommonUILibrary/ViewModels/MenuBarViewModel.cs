using CommonLibrary;
using Prism.Commands;
using Prism.Mvvm;

namespace CommonUILibrary.ViewModels
{
    public class MenuBarViewModel : BindableBase
    {
        public MenuItem[] MenuBar { get; }
        public MenuBarViewModel()
        {
            MenuBar = Config.MenuItem;
        }
    }
}
