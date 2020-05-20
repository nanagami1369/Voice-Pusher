using CoreUILibrary.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace CoreUILibrary
{
    public class CoreUILibraryModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("StatusBarRegion", typeof(StatusBarView));
            regionManager.RegisterViewWithRegion("MenubarRegion", typeof(MenuBarView));
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(VoiceEditorCharacterLibraryView));
            regionManager.RegisterViewWithRegion("VoiceEditorRegion", typeof(NotSelectCharacterView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<VoiceEditorCharacterLibraryView>();
            containerRegistry.RegisterForNavigation<CharacterEditorCharacterLibraryView>();
            containerRegistry.RegisterForNavigation<OtherMenuView>();
        }
    }
}
