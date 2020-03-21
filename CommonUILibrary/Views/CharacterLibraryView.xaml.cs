using System.Windows.Controls;
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace CommonUILibrary.Views
{
    /// <summary>
    /// Interaction logic for CharacterLibraryView
    /// </summary>
    public partial class CharacterLibraryView : UserControl
    {
        public CharacterLibraryView()
        {
            InitializeComponent();
            CharacterLibrary.ItemsSource = Enumerable.Range(1,100);
        }
    }
}
