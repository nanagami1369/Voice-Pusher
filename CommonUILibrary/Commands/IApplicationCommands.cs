using Prism.Commands;

namespace CommonUILibrary.Commands
{
    public interface IApplicationCommands
    {
        CompositeCommand SetFocusCommand { get; }

        CompositeCommand SelectMenuCommand { get; }
        CompositeCommand SpeakCommand { get; }
        CompositeCommand SaveCommand { get; }
    }
}
