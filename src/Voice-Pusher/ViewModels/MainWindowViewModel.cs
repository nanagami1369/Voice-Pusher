using System.Linq;
using CoreLibrary;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Voice_Pusher.Model;

namespace Voice_Pusher.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private bool _isDebugView;

        private HamburgerMenuItem? _selectedButtomMenuItem;
        private HamburgerMenuItem? _selectedMenuItem;
        private string _title = "Prism Application";

        public MainWindowViewModel(IRegionManager regionManager, IDataContainer container)
        {
            _regionManager = regionManager;
            Container = container;
            _selectedMenuItem = MenuItems.First();
            LoadedCommand = new DelegateCommand(Loaded);
            UnloadedCommand = new DelegateCommand(Unloaded);
            MenuItemInvokedCommand = new DelegateCommand(MenuItemInvoked);
            ButtomMenuItemInvokedCommand = new DelegateCommand(ButtomMenuItemInvoked);
            MenuItemKeyInvokedCommand = new DelegateCommand<string?>(MenuItemKeyInvoked);
            ButtomMenuItemKeyInvokedCommand = new DelegateCommand<string?>(ButtomMenuItemKeyInvoked);
            ChangeIsDebugViewCommand = new DelegateCommand(ChangeIsDebugView);
        }

        public bool IsDebugView
        {
            get => _isDebugView;
            set => SetProperty(ref _isDebugView, value);
        }

        public DelegateCommand ChangeIsDebugViewCommand { get; }

        private IRegionNavigationService? _navigationService { get; set; }
        private IRegionManager _regionManager { get; }
        public IDataContainer Container { get; }

        public DelegateCommand LoadedCommand { get; }
        public DelegateCommand UnloadedCommand { get; }

        public DelegateCommand MenuItemInvokedCommand { get; }

        public DelegateCommand ButtomMenuItemInvokedCommand { get; }
        public DelegateCommand<string?> MenuItemKeyInvokedCommand { get; }
        public DelegateCommand<string?> ButtomMenuItemKeyInvokedCommand { get; }

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

        private void ChangeIsDebugView()
        {
            IsDebugView = !IsDebugView;
        }

        public void MenuItemKeyInvoked(string? pageKey)
        {
            if (pageKey is null)
            {
                return;
            }

            var menuItem = MenuItems.FirstOrDefault(i => i.PageKey == pageKey);
            if (menuItem is null)
            {
                return;
            }

            SelectedMenuItem = menuItem;
            SelectedButtomMenuItem = null;
        }

        public void ButtomMenuItemKeyInvoked(string? pageKey)
        {
            if (pageKey is null)
            {
                return;
            }

            var menuItem = ButtomMenuItems.FirstOrDefault(i => i.PageKey == pageKey);
            if (menuItem is null)
            {
                return;
            }

            SelectedMenuItem = null;
            SelectedButtomMenuItem = menuItem;
        }

        private void Loaded()
        {
            _navigationService = _regionManager.Regions[Regions.Main].NavigationService;
            _navigationService.Navigated += OnNavigated;
            // MainAriaの初期化
            MenuItemInvoked();
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
