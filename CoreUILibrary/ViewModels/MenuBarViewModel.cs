using CommonLibrary;
using Prism.Mvvm;

namespace CoreUILibrary.ViewModels
{
	public class MenuBarViewModel : BindableBase
	{
		public MenuItem[] MenuBar { get; }
		public MenuBarViewModel()
		{
			MenuBar = Config.MenuItem;
		}
	}
}
