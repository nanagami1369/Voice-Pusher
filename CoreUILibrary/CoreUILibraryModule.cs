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
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(CharacterLibraryView));
            regionManager.RegisterViewWithRegion("VoiceEditorRegion", typeof(NotSelectCharacterView));
            regionManager.RegisterViewWithRegion("OtherContentRegion", typeof(SettingEditorView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CharacterLibraryView>();
            containerRegistry.RegisterForNavigation<NotSelectCharacterView>();
            containerRegistry.RegisterForNavigation<OtherMenuView>();
            containerRegistry.RegisterForNavigation<SettingEditorView>();
            containerRegistry.RegisterForNavigation<AboutView>();
        }
    }
}
