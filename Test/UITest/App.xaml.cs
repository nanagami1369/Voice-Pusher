using System.Windows;
using CommonLibrary;
using CommonLibrary.Modules.CharacterLibraryModule;
using CommonLibrary.Modules.MenuModule;
using CommonLibrary.Modules.StatusModule;
using CommonLibrary.Modules.SettingModule;
using CommonUILibrary.Commands;
using CommonUILibrary.Models;
using CoreUILibrary.Models;
using Prism.Ioc;
using Prism.Modularity;
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
            //設定の初期化
            var settingRegistry = Container.Resolve<ISettingRegistry>();
            var setting = settingRegistry.Read(Config.SettingFileName, Config.SettingFileEncode);
            var settingManager = Container.Resolve<ISettingContainer>();
            settingManager.Register(setting);
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ISettingRegistry, SettingRegistry>();
            containerRegistry.Register<ISettingContainer, SettingContainer>();
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
            containerRegistry.Register<IStatusSender, StatusCommunication>();
            containerRegistry.Register<ICharacterLibraryPresenter, CharacterLibraryPresenter>();
            containerRegistry.Register<IMenuPresenter, MenuPresenter>();
            containerRegistry.Register<IDialog, Dialog>();
            containerRegistry.RegisterSingleton<ICharacterLibraryGateway, CharacterLibraryGatewayMoc>();
            containerRegistry.Register<IViewSelectable, ViewSelectable>();
            containerRegistry.RegisterForNavigation<PartialView>("PartialVoiceEditorView");
            containerRegistry.RegisterForNavigation<PartialView>("PartialCharacterEditorView");
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CoreUILibrary.CoreUILibraryModule>();
        }
    }
}
