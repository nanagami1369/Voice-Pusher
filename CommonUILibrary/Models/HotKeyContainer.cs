using Prism.Mvvm;

namespace CommonUILibrary.Models
{
    public class HotKeyContainer : BindableBase, IHotKeyContainer
    {
        private HotKeySet _value;

        public HotKeySet Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }
    }
}
