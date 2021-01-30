using Prism.Regions;

namespace Voice_Pusher.Model
{
    public static class RegionNavigationServiceExtensions
    {
        public static bool CanNavigate(this IRegionNavigationService navigationService, string? target)
        {
            if (string.IsNullOrEmpty(target))
            {
                return false;
            }

            if (navigationService.Journal.CurrentEntry == null)
            {
                return true;
            }

            return target != navigationService.Journal.CurrentEntry.Uri.ToString();
        }
    }
}
