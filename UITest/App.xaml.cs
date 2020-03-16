using Prism.Ioc;
using UITest.Views;
using System.Windows;
using CommonLibrary;
using Prism.Modularity;

namespace UITest
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
            moduleCatalog.AddModule<CommonUILibrary.CommonUILibraryModule>();
        }
    }
}
