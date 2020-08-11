using CommonLibrary.Modules.MenuModule;

namespace CommonUILibrary.Models
{
    public interface IMenuPresenter
    {
        MenuItem[] MenuList { get; }

        MenuItem SelectedMenu { get; }

        void ChangeView();

        #region keyboardActions
        bool TryChangeMenu(int index);
        #endregion
    }
}
