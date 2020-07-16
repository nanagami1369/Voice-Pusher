using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace CommonUILibrary.Behaviors
{
    public class InsertTextBoxBehavior : Behavior<TextBox>
    {
        public static DependencyProperty SetFlagProperty
            = DependencyProperty.Register(
                nameof(SetFlag),
                typeof(bool),
                typeof(InsertTextBoxBehavior),
                new PropertyMetadata(false, (sender, e) =>
                {
                    var behavior = (InsertTextBoxBehavior)sender;
                    behavior.Insert(e);
                }));

        public bool SetFlag
        {
            get => (bool)GetValue(SetFlagProperty);
            set => SetValue(SetFlagProperty, value);
        }

        private void Insert(DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                AssociatedObject.SelectedText = InsertText;
                AssociatedObject.SelectionStart += AssociatedObject.SelectionLength;
                AssociatedObject.SelectionLength = 0;
            }
        }

        public static DependencyProperty InsertTextProperty
            = DependencyProperty.Register(
                nameof(InsertText),
                typeof(string),
                typeof(InsertTextBoxBehavior),
                new PropertyMetadata(""));

        public string InsertText
        {
            get => (string)GetValue(InsertTextProperty);
            set => SetValue(InsertTextProperty, value);
        }
    }
}
