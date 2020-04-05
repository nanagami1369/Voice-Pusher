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
            regionManager.RegisterViewWithRegion("CharacterLibraryRegion", typeof(CharacterLibraryView));
            regionManager.RegisterViewWithRegion("VoiceEditorRegion", typeof(NotSelectCharacterView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
