using CommonUILibrary.Models;
using Prism.Regions;

namespace CommonUILibrary.ViewSelectable
{
    public class OtherMenuViewSelectable : IOtherMenuViewSelectable
    {
        private readonly IRegionManager _regionManager;

        public void SelectAboutView()
        {
            _regionManager.RequestNavigate("OtherContentRegion", "AboutView");
        }

        public void SelectKeyboardShortcutView()
        {
            _regionManager.RequestNavigate("OtherContentRegion", "HotKeyEditorView");
        }

        public void SelectSettingEditorView()
        {
            _regionManager.RequestNavigate("OtherContentRegion", "SettingEditorView");
        }

        public void SelectUsedLibraryView()
        {
            _regionManager.RequestNavigate("OtherContentRegion", "UsedLibraryView");
        }

        public OtherMenuViewSelectable(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}
