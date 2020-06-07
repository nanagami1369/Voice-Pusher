using System.Windows;
using System.Windows.Controls;

namespace CommonUILibrary.Behaviors
{
    public class SetTextBoxBehavior : DependencyObject
    {
        public static DependencyProperty CursorProperty
            = DependencyProperty.RegisterAttached(
                "Cursor",
                typeof(int),
                typeof(SetTextBoxBehavior),
                new PropertyMetadata(0, OnSetCursorPropertyChanged)
            );

        public static void SetCursor(DependencyObject obj, int value)
            => obj.SetValue(CursorProperty, value);

        public static int GetCursor(DependencyObject obj)
            => (int)obj.GetValue(CursorProperty);

        private static void OnSetCursorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uie = (TextBox)d;
            uie.SelectionStart = (int)e.NewValue;
            uie.SelectionLength = 0;
        }

        public static DependencyProperty SelectedTextProperty
            = DependencyProperty.RegisterAttached(
                "SelectedText",
                typeof(string),
                typeof(SetTextBoxBehavior),
                new PropertyMetadata("", OnSetSelectedTextPropertyChanged)
            );

        public static void SetSelectedText(DependencyObject obj, string value)
            => obj.SetValue(SelectedTextProperty, value);

        public static string GetSelectedText(DependencyObject obj)
            => (string)obj.GetValue(SelectedTextProperty);

        private static void OnSetSelectedTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uie = (TextBox)d;
            if (e.NewValue != null)
            {
                uie.SelectedText = (string)e.NewValue;
            }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.RegisterAttached(
                "Text",
                typeof(string),
                typeof(SetTextBoxBehavior),
                new PropertyMetadata("", OnSetTextPropertyChanged)
                );

        public static string GetText(DependencyObject obj)
        {
            return (string)obj.GetValue(TextProperty);
        }

        public static void SetText(DependencyObject obj, string value)
        {
            obj.SetValue(TextProperty, value);
        }

        private static void OnSetTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uie = (TextBox)d;
            uie.SelectAll();
            uie.SelectedText = (string)e.NewValue ?? "";
            uie.SelectionLength = 0;
        }
    }
}
