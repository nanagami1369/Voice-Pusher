using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace CommonUILibrary.Behaviors
{
    public class EncircleTextBoxBehavior : Behavior<TextBox>
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
        }


        public static DependencyProperty CursorProperty
            = DependencyProperty.Register(
                nameof(SetOnlyCursor),
                typeof(int),
                typeof(EncircleTextBoxBehavior),
                new PropertyMetadata()
            );

        public int SetOnlyCursor
        {
            get => (int)GetValue(CursorProperty);
            set => SetValue(CursorProperty, value);
        }

        public static DependencyProperty SelectedTextProperty
            = DependencyProperty.Register(
                nameof(SelectedText),
                typeof(string),
                typeof(EncircleTextBoxBehavior),
                new PropertyMetadata()
            );

        public string SelectedText
        {
            get => (string)GetValue(SelectedTextProperty);
            set => SetValue(SelectedTextProperty, value);
        }

        public static DependencyProperty SetFlagProperty
            = DependencyProperty.Register(
                nameof(SetFlag),
                typeof(bool),
                typeof(EncircleTextBoxBehavior),
                new PropertyMetadata((sender, e) =>
                {
                    var behavior = (EncircleTextBoxBehavior)sender;
                    behavior.EncircleText(e);
                })
            );

        public bool SetFlag
        {
            get => (bool)GetValue(SetFlagProperty);
            set => SetValue(SetFlagProperty, value);
        }

        private void EncircleText(DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                AssociatedObject.SelectedText = SelectedText;
                AssociatedObject.SelectionStart += SetOnlyCursor;
                AssociatedObject.SelectionLength = 0;
            }
        }
    }
}
