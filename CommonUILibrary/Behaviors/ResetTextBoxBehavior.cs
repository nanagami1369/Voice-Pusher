using System.Windows;
using System.Windows.Controls;

namespace CommonUILibrary.Behaviors
{
    public class ResetTextBoxBehavior
    {
        public static readonly DependencyProperty ResetFlagProperty =
            DependencyProperty.RegisterAttached(
                "ResetFlag", typeof(bool), typeof(ResetTextBoxBehavior),
                new UIPropertyMetadata(false, OnResetFlagPropertyChanged));

        public static bool GetResetFlag(DependencyObject obj)
            => (bool)obj.GetValue(ResetFlagProperty);


        public static void SetResetFlag(DependencyObject obj, bool value)
            => obj.SetValue(ResetFlagProperty, value);


        private static void OnResetFlagPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                var textBox = (TextBox)d;
                textBox.SelectAll();
                textBox.SelectedText = "";
            }
        }
    }
}
