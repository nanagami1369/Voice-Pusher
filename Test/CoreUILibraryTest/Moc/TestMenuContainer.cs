
using CommonLibrary.Modules.MenuModule;
using CommonUILibrary.Models;
using Unity;

namespace CoreUILibrary.Moc
{
    internal class TestMenuContainer : IMenuContainerReader, IMenuContainerRegister
    {

        public void Register(MenuItem menu)
        {
            SelectedMenu = menu;
        }

        public MenuItem SelectedMenu { get; private set; }

        public MenuItem Read()
        {
            return SelectedMenu;
        }
    }
}
