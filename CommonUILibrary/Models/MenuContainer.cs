using CommonLibrary.Modules.MenuModule;
using Unity;

namespace CommonUILibrary.Models
{
    public class MenuContainer : IMenuContainerReader, IMenuContainerRegister
    {
        private readonly IUnityContainer _container;
        public void Register(MenuItem menu)
        {
            _container.RegisterInstance(menu);
        }

        public MenuItem Read()
        {
            return _container.Resolve<MenuItem>();
        }

        public MenuContainer(IUnityContainer container)
        {
            _container = container;
        }
    }
}
