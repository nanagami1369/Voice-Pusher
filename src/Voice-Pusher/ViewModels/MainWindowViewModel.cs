using System.Linq;
using Prism.Mvvm;

namespace Voice_Pusher.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private HamburgerMenuItem? _selectedButtomMenuItem;

        private HamburgerMenuItem? _selectedMenuItem;
        private string _title = "Prism Application";

        public MainWindowViewModel()
        {
            _selectedMenuItem = MenuItems.First();
        }


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
            new("ボイスエディタ", "", "VolumeUp"),
            new("キャラクタエディタ", "", "AddressBook")
        };

        public HamburgerMenuItem[] ButtomMenuItems { get; } = {new("設定", "", "Cog")};
    }
}
