using CommonLibrary;
using CommonLibrary.Modules.CharacterLibraryModule;
using CommonLibrary.Modules.StatusModule;
using CommonUILibrary.Models;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using UITest.Moc;
using UITest.Views;

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
            containerRegistry.Register<ICharacterLibraryPresenter, CharacterLibraryPresenter>();
            containerRegistry.Register<IDialog, Dialog>();
            containerRegistry.RegisterSingleton<ICharacterLibraryGateway, CharacterLibraryGatewayMoc>();
            containerRegistry.RegisterForNavigation<PartialView>("PartialVoiceEditorView");
            containerRegistry.RegisterForNavigation<PartialView>("PartialCharacterEditorView");
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CommonUILibrary.CommonUILibraryModule>();
        }
    }
}
