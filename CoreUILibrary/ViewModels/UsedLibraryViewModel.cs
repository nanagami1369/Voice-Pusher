using CommonUILibrary.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace CoreUILibrary.ViewModels
{
    public class UsedLibraryViewModel : BindableBase
    {
        public IUsedLibraryPresenter UsedLibrary { get; }

        public DelegateCommand<string> OpenLicenseCommand { get; }
        public DelegateCommand ReadLicenseCommand { get; }


        public UsedLibraryViewModel(IUsedLibraryPresenter usedLibrary)
        {
            UsedLibrary = usedLibrary;
            OpenLicenseCommand = new DelegateCommand<string>(UsedLibrary.OpenLicense);
            ReadLicenseCommand = new DelegateCommand(async () => { await UsedLibrary.ReadAsync(); });
        }
    }
}
