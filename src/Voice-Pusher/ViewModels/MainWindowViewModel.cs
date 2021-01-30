using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Voice_Pusher.Model;

namespace Voice_Pusher.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private HamburgerMenuItem? _selectedButtomMenuItem;

        private HamburgerMenuItem? _selectedMenuItem;
        private string _title = "Prism Application";

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _selectedMenuItem = MenuItems.First();
            LoadedCommand = new DelegateCommand(Loaded);
            UnloadedCommand = new DelegateCommand(Unloaded);
            MenuItemInvokedCommand = new DelegateCommand(MenuItemInvoked);
            ButtomMenuItemInvokedCommand = new DelegateCommand(ButtomMenuItemInvoked);
        }

        private IRegionNavigationService? _navigationService { get; set; }
        private IRegionManager _regionManager { get; }

        public DelegateCommand LoadedCommand { get; }
        public DelegateCommand UnloadedCommand { get; }

        public DelegateCommand MenuItemInvokedCommand { get; }

        public DelegateCommand ButtomMenuItemInvokedCommand { get; }


        public HamburgerMenuItem? SelectedMenuItem
        {
            get => _selectedMenuItem;
            set => SetProperty(ref _selectedMenuItem, value);
        }

        public HamburgerMenuItem? SelectedButtomMenuItem
        {
            get => _selectedButtomMenuItem;
            set => SetProperty(ref _selectedButtomMenuItem, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public HamburgerMenuItem[] MenuItems { get; } =
        {
            new("ボイスエディタ", PageKeys.VoiceEditor, "VolumeUp"),
            new("キャラクタエディタ", PageKeys.CharacterEditor, "AddressBook")
        };

        public HamburgerMenuItem[] ButtomMenuItems { get; } = {new("設定", PageKeys.SettingEditor, "Cog")};

        private void Loaded()
        {
            _navigationService = _regionManager.Regions[Regions.Main].NavigationService;
            _navigationService.Navigated += OnNavigated;
            SelectedMenuItem = MenuItems.First();
        }

        private void Unloaded()
        {
            if (_navigationService is not null)
            {
                _navigationService.Navigated -= OnNavigated;
            }

            _regionManager.Regions.Remove(Regions.Main);
        }


        private void RequestNavigate(string? target)
        {
            if (_navigationService is null)
            {
                return;
            }

            if (_navigationService.CanNavigate(target))
            {
                _navigationService.RequestNavigate(target);
            }
        }

        private void MenuItemInvoked()
        {
            RequestNavigate(SelectedMenuItem?.PageKey);
        }

        private void ButtomMenuItemInvoked()
        {
            RequestNavigate(SelectedButtomMenuItem?.PageKey);
        }

        private void OnNavigated(object? sender, RegionNavigationEventArgs e)
        {
            var selectedMenuItem = MenuItems.FirstOrDefault(i => e.Uri.ToString() == i.PageKey);
            if (selectedMenuItem is not null)
            {
                SelectedMenuItem = selectedMenuItem;
                SelectedButtomMenuItem = null;
                return;
            }

            var selectedButtomItem = ButtomMenuItems.FirstOrDefault(i => e.Uri.ToString() == i.PageKey);
            if (selectedMenuItem is not null)
            {
                SelectedMenuItem = null;
                SelectedButtomMenuItem = selectedMenuItem;
            }
        }
    }
}
