using CommonLibrary;
using Prism.Mvvm;

namespace CoreUILibrary.ViewModels
{
    public class OtherMenuViewModel : BindableBase
    {
        public string Title => Config.Title;
        public OtherMenuViewModel()
        {

        }
    }
}
