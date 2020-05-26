
using CommonLibrary.Modules.MenuModule;
using CommonUILibrary.Models;
using Unity;

namespace CoreUILibrary.Moc
{
    internal class TestMenuContainer : MenuContainer, IMenuContainer
    {
        public TestMenuContainer() : base(new TestContainer())
        {

        }

        public new void Register(MenuItem menu)
        {
            SelectedMenu = menu;
        }

        public MenuItem SelectedMenu { get; private set; }

        public new MenuItem Read()
        {
            return SelectedMenu;
        }
    }
}
