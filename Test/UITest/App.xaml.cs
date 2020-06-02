using System.Windows;
using CommonLibrary;
using CommonLibrary.Modules;
using CommonLibrary.Modules.CharacterLibraryModule;
using CommonLibrary.Modules.MenuModule;
using CommonLibrary.Modules.SettingModule;
using CommonLibrary.Modules.StatusModule;
using CommonUILibrary.Commands;
using CommonUILibrary.Models;
using CommonUILibrary.ViewSelectable;
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
            containerRegistry.Register<ISettingEditorPresenter, SettingEditorPresenter>();
            containerRegistry.Register<IMenuPresenter, MenuPresenter>();
            containerRegistry.Register<IMenuContainerRegister, MenuContainer>();
            containerRegistry.Register<IMenuContainerReader, MenuContainer>();
            containerRegistry.Register<IMenuViewSelectable, MenuViewSelectable>();
            containerRegistry.Register<IDialog, Dialog>();
            containerRegistry.Register<ISpeaker, Speaker>();
            containerRegistry.Register<IRecorder, Recorder>();
            containerRegistry.Register<IFileNameConverter, FileNameConverter>();
            containerRegistry.RegisterSingleton<ICharacterLibraryGateway, CharacterLibraryGatewayMoc>();
            containerRegistry.Register<ICharacterLibraryViewSelectable, CharacterLibraryViewSelectable>();
            containerRegistry.RegisterForNavigation<PartialView>("PartialVoiceEditorView");
            containerRegistry.RegisterForNavigation<PartialView>("PartialCharacterEditorView");
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CoreUILibrary.CoreUILibraryModule>();
            moduleCatalog.AddModule<SAP.SAPModule>();
        }
    }
}
