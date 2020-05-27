using System.Windows.Controls;
using System.Windows.Interactivity;

namespace CommonUILibrary.Behaviors
{
    public class AutoScrollBehavior : Behavior<ListBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += SelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= SelectionChanged;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AssociatedObject.ScrollIntoView(AssociatedObject.SelectedItem);
        }

    }
}
