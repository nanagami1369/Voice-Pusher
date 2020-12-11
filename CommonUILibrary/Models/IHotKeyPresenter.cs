using System.Threading.Tasks;

namespace CommonUILibrary.Models
{
    public interface IHotKeyPresenter
    {
        public HotKeySet EditHotKeySet { get; set; }

        bool IsEnabled { get; set; }

        public Task<bool> ConfirmationSaveAsync();

        Task LoadAsync();
        Task SaveAsync();

        void Reset();
    }
}
