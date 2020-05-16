using System.Linq;
using CommonLibrary;
using CommonLibrary.Modules.MenuModule;
using Prism.Mvvm;

namespace CoreUILibrary.Models
{
    public class MeunPresenter : BindableBase, IMeunPresenter
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

        public MeunPresenter(IViewSelectable viewSelectable)
        {
            _viewSelectable = viewSelectable;
            MenuList = Config.MenuItem;
            SelectedMenu = MenuList.FirstOrDefault();
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
