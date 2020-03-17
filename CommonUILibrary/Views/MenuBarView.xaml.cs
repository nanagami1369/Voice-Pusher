using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace CommonUILibrary
{
    /// <summary>
    /// Interaction logic for MenuBarView
    /// </summary>
    public partial class MenuBarView : UserControl
    {
        public MenuBarView()
        {
            InitializeComponent();
            var data = Enumerable.Range(1, 6).Select(s => s.ToString()).ToList();
            List.ItemsSource = new ObservableCollection<string>(data);
        }
    }
}
