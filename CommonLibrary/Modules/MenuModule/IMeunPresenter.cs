namespace CommonLibrary.Modules.MenuModule
{
    public interface IMeunPresenter
    {
        MenuItem[] MenuList { get; }

        MenuItem SelectedMenu { get; }

        void ChangeView();

        #region keyboardActions
        bool TryChangeMenu(int index);
        #endregion
    }
}
