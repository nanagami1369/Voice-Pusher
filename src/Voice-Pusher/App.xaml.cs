using System.IO;
using System.Threading.Tasks;
using System.Windows;
using CoreLibrary;
using CoreLibrary.SettingModels;
using Newtonsoft.Json;
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
        public int InitialCounter { get; set; }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnInitialized()
        {
            var container = Container.Resolve<IDataContainer>();
            if (InitialSettings is not null)
            {
                container.SettingsManager.Init(InitialSettings);
            }

            container.Counter.Init(InitialCounter);
            base.OnInitialized();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<VoiceEditorPage, VoiceEditorViewModel>(PageKeys.VoiceEditor);
            containerRegistry.RegisterForNavigation<CharacterEditorPage, CharacterEditorViewModel>(
                PageKeys.CharacterEditor);
            containerRegistry
                .RegisterForNavigation<SettingEditorPage, SettingEditorViewModel>(PageKeys.SettingEditor);
            containerRegistry.RegisterSingleton<IDataContainer, DataContainer>();
            containerRegistry.Register<IDialog, Dialog>();
        }

        private async Task<T> FileRead<T>(string fileName, T defaultItem)
        {
            var repository = new JsonRepository<T>(fileName);
            try
            {
                if (File.Exists(repository.FullPath))
                {
                    return await repository.ReadAsync();
                }

                return defaultItem;
            }
            catch (JsonReaderException)
            {
                return defaultItem;
            }
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            InitialSettings = await FileRead(Config.SettingFileName, new Settings());
            InitialCounter = await FileRead(Config.CounterFileName, 0);
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            var container = Container.Resolve<IDataContainer>();
            container.Counter.Dispose();
            container.SettingsManager.Dispose();
            base.OnExit(e);
        }
    }
}
