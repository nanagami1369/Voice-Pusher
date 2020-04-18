using Prism.Commands;

namespace CommonUILibrary.Commands
{
    public interface IApplicationCommands
    {
        CompositeCommand SetFocusCommand { get; }
    }
}
