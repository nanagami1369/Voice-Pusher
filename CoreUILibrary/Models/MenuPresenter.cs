using System.Linq;
using CommonLibrary;
using CommonLibrary.Modules.MenuModule;
using CommonUILibrary.Models;
using Prism.Mvvm;

namespace CoreUILibrary.Models
{
    public class MenuPresenter : BindableBase, IMenuPresenter
    {
        private readonly IViewSelectable _viewSelectable;
        private readonly MenuContainer _container;
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
            _container.Register(SelectedMenu);
        }

        public MenuPresenter(IViewSelectable viewSelectable, MenuContainer container)
        {
            _viewSelectable = viewSelectable;
            MenuList = Config.MenuItem;
            SelectedMenu = MenuList.FirstOrDefault();
            _container = container;
            _container.Register(SelectedMenu);
        }

        #region keyboardActions

        public bool TryChangeMenu(int index)
        {
            if (0 > index || index >= MenuList.Length)
            {
                return false;
            }
            string viewName = MenuList[index].ViewName;
            _viewSelectable.ChangeContentView(viewName);
            SelectedMenu = MenuList[index];
            return true;
        }

        #endregion
    }
}
