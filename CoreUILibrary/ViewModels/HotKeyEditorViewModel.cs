using System;
using System.Threading.Tasks;
using CommonUILibrary.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace CoreUILibrary.ViewModels
{
    public class HotKeyEditorViewModel : BindableBase, IConfirmNavigationRequest, IRegionMemberLifetime
    {
        public IHotKeyPresenter HotKey { get; }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand LoadCommand { get; }

        public bool KeepAlive => false;

        public async Task<bool> LendConfirmNavigationRequestAsync()
        {
            return await HotKey.ConfirmationSaveAsync();
        }

        public void LendOnNavigatedTo() { }

        public void LendOnNavigatedFrom()
        {
            HotKey.Reset();
        }

        public HotKeyEditorViewModel(IHotKeyPresenter hotKey)
        {
            HotKey = hotKey;
            SaveCommand = new DelegateCommand(async () => { await HotKey.SaveAsync(); });
            LoadCommand = new DelegateCommand(async () => { await HotKey.LoadAsync(); });
        }

        public async void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            var isMove = await HotKey.ConfirmationSaveAsync();
            continuationCallback(isMove);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            HotKey.Reset();
        }
    }
}
