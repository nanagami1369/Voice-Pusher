using System.Windows.Controls;
using CommonLibrary;
using CommonLibrary.Modules.MenuModule;
using CoreUILibrary.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace CoreUILibrary.ViewModels
{
	public class MenuBarViewModel : BindableBase
	{
        public IMeunManager MeunManager { get; }
        public DelegateCommand ChangeViewCommand { get; }

        public MenuBarViewModel(IMeunManager meunManager)
		{
            MeunManager = meunManager;
            ChangeViewCommand = new DelegateCommand(MeunManager.ChangeView);
        }
	}
}
