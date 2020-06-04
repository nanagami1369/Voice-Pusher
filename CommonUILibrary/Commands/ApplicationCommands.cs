using Prism.Commands;

namespace CommonUILibrary.Commands
{
    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand SetFocusCommand { get; } = new CompositeCommand(true);
        public CompositeCommand SelectMenuCommand { get; } = new CompositeCommand(true);

        public CompositeCommand SpeakCommand { get; } = new CompositeCommand(true);
        public CompositeCommand SaveCommand { get; } = new CompositeCommand(true);
    }
}
