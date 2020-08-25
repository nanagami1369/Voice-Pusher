using System.Windows.Input;

namespace CommonUILibrary.Models
{
    public interface IHotKey
    {
        Key Key { get; }
        ModifierKeys ModifierKeys { get; }
    }
}
