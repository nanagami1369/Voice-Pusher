using CommonUILibrary.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace CoreUILibrary.ViewModels
{
    public class UsedLibraryViewModel : BindableBase
    {
        public IUsedLibraryPresenter UsedLibrary { get; }

        public DelegateCommand<string> OpenLicenceCommand { get; }
        public DelegateCommand ReadLicenceCommand { get; }


        public UsedLibraryViewModel(IUsedLibraryPresenter usedLibrary)
        {
            UsedLibrary = usedLibrary;
            OpenLicenceCommand = new DelegateCommand<string>(UsedLibrary.OpenLicence);
            ReadLicenceCommand = new DelegateCommand(async () => { await UsedLibrary.ReadAsync(); });
        }
    }
}
