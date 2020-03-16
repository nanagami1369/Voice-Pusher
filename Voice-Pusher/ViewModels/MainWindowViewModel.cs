using CommonLibrary;
using Prism.Commands;
using Prism.Mvvm;

namespace Voice_Pusher.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = Config.Title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public MainWindowViewModel()
        {

        }
    }
}
