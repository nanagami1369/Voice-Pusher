using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace Voice_Pusher.Views.AttachedProperties
{
    internal class InsertTextForTextBoxProperty : Behavior<TextBox>
    {
        public static DependencyProperty SetFlagProperty
            = DependencyProperty.Register(
                nameof(SetFlag),
                typeof(bool),
                typeof(InsertTextForTextBoxProperty),
                new PropertyMetadata(false, (sender, e) =>
                {
                    var behavior = (InsertTextForTextBoxProperty)sender;
                    behavior.Insert(e);
                }));

        public static DependencyProperty InsertTextProperty
            = DependencyProperty.Register(
                nameof(InsertText),
                typeof(string),
                typeof(InsertTextForTextBoxProperty),
                new PropertyMetadata(""));

        public bool SetFlag
        {
            get => (bool)GetValue(SetFlagProperty);
            set => SetValue(SetFlagProperty, value);
        }

        public string InsertText
        {
            get => (string)GetValue(InsertTextProperty);
            set => SetValue(InsertTextProperty, value);
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
    }
}
