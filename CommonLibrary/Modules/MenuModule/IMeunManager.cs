namespace CommonLibrary.Modules.MenuModule
{
    public interface IMeunManager
    {
        MenuItem[] MenuList { get; }

        MenuItem SelectedMenu { get; }

        void ChangeView();
    }
}
