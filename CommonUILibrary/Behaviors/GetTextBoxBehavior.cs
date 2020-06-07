using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace CommonUILibrary.Behaviors
{
    public class GetTextBoxBehavior : Behavior<TextBox>
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

        private void SelectionChanged(object sender, RoutedEventArgs e)
        {
            SelectedText = AssociatedObject.SelectedText;
            Cursor = AssociatedObject.SelectionStart;
        }

        public static DependencyProperty SelectedTextProperty
            = DependencyProperty.Register(
                nameof(SelectedText),
                typeof(string),
                typeof(GetTextBoxBehavior),
                new PropertyMetadata()
            );

        public string SelectedText
        {
            get => (string)GetValue(SelectedTextProperty);
            set => SetValue(SelectedTextProperty, value);
        }

        public static DependencyProperty CursorProperty
            = DependencyProperty.Register(
                nameof(Cursor),
                typeof(int),
                typeof(GetTextBoxBehavior),
                new PropertyMetadata()
            );

        public int Cursor
        {
            get => (int)GetValue(CursorProperty);
            set => SetValue(CursorProperty, value);
        }
    }
}
