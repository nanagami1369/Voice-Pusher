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
            regionManager.RegisterViewWithRegion("VoiceEditorCharacterLibraryRegion", typeof(VoiceEditorCharacterLibraryView));
            regionManager.RegisterViewWithRegion("CharacterEditorCharacterLibraryRegion", typeof(CharacterEditorCharacterLibraryView));
            regionManager.RegisterViewWithRegion("VoiceEditorRegion", typeof(NotSelectCharacterView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
