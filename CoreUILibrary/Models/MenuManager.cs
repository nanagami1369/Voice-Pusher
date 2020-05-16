using System.Linq;
using CommonLibrary;
using CommonLibrary.Modules.MenuModule;
using Prism.Mvvm;

namespace CoreUILibrary.Models
{
    public class MenuManager : BindableBase, IMeunManager
    {
        private readonly IViewSelectable _viewSelectable;
        public MenuItem[] MenuList { get; }

        private MenuItem _selectedMenu;
        public MenuItem SelectedMenu
        {
            get => _selectedMenu;
            set => SetProperty(ref _selectedMenu, value);
        }

        public void ChangeView()
        {
            _viewSelectable.ChangeContentView(SelectedMenu.ViewName);
        }

        public MenuManager(IViewSelectable viewSelectable)
        {
            _viewSelectable = viewSelectable;
            MenuList = Config.MenuItem;
            SelectedMenu = MenuList.FirstOrDefault();
        }
    }
}
