using System.Windows;
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
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<VoiceEditorPage, VoiceEditorViewModel>(PageKeys.VoiceEditor);
            containerRegistry.RegisterForNavigation<CharacterEditorPage, CharacterEditorViewModel>(
                PageKeys.CharacterEditor);
        }
    }
}
