using MahApps.Metro.Controls;
using Prism.Regions;
using Voice_Pusher.Model;

namespace Voice_Pusher.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            RegionManager.SetRegionName(HamburgerMenuContentAria, Regions.Main);
            RegionManager.SetRegionManager(HamburgerMenuContentAria, regionManager);
        }
    }
}
