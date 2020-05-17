using System.Windows;
using CommonLibrary.Modules.StatusModule;
using CoreUILibrary.Models;
using Prism.Ioc;
using Prism.Modularity;
using Voice_Pusher.Views;

namespace Voice_Pusher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IStatusSender, StatusCommunication>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CoreUILibrary.CoreUILibraryModule>();
        }
    }
}
