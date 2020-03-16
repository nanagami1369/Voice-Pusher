using CommonUILibrary.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace CommonUILibrary
{
    public class CommonUILibraryModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("StatusBarRegion", typeof(StatusBarView));
            regionManager.RegisterViewWithRegion("MenubarRegion", typeof(MenuBarView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
