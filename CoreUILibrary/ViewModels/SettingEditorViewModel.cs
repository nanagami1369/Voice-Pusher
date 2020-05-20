using CommonLibrary;
using Prism.Mvvm;

namespace CoreUILibrary.ViewModels
{
    public class SettingEditorViewModel : BindableBase
    {
        public string Title => Config.Title;
        public SettingEditorViewModel()
        {

        }
    }
}
