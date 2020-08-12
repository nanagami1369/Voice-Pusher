using CommonUILibrary.Models;
using Prism.Regions;

namespace CommonUILibrary.ViewSelectable
{
    public class MenuViewSelectable : IMenuViewSelectable
    {
        private readonly IRegionManager _regionManager;

        public void ChangeContentView(string viewName)
        {
            _regionManager.RequestNavigate("ContentRegion", viewName);
        }

        public MenuViewSelectable(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

    }
}
