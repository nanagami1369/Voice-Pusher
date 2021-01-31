using System.IO;
using System.Windows;
using CoreLibrary;
using CoreLibrary.SettingModels;
using Prism.Ioc;
using Voice_Pusher.Model;
using Voice_Pusher.ViewModels;
using Voice_Pusher.Views;

namespace Voice_Pusher
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public Settings? InitialSettings { get; set; }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnInitialized()
        {
            var container = Container.Resolve<IDataContainer>();
            if (InitialSettings is null)
            {
                return;
            }

            container.Setting = InitialSettings;
            base.OnInitialized();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<VoiceEditorPage, VoiceEditorViewModel>(PageKeys.VoiceEditor);
            containerRegistry.RegisterForNavigation<CharacterEditorPage, CharacterEditorViewModel>(
                PageKeys.CharacterEditor);
            containerRegistry
                .RegisterForNavigation<SettingEditorPage, CharacterEditorViewModel>(PageKeys.SettingEditor);
            containerRegistry.RegisterSingleton<IDataContainer, DataContainer>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            var repository = new JsonRepository<Settings>(Config.SettingFileName);
            if (File.Exists(repository.FullPath))
            {
                InitialSettings = await repository.ReadAsync();
            }
            else
            {
                InitialSettings = new Settings();
                await repository.WriterAsync(new Settings());
            }

            base.OnStartup(e);
        }
    }
}
