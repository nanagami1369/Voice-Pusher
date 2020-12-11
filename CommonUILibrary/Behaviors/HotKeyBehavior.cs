using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using CommonUILibrary.Models;

namespace CommonUILibrary.Behaviors
{
    public class HotKeyBehavior : Behavior<TextBox>
    {
        public static DependencyProperty HotKeyProperty
            = DependencyProperty.Register(
                nameof(HotKey),
                typeof(HotKey),
                typeof(HotKeyBehavior),
                new PropertyMetadata(new HotKey(), (d, e) =>
                {
                    var hotKeyContainer = (HotKeyBehavior)d;
                    hotKeyContainer.HotKeyPropertyChanged(e);
                })
            );

        private void HotKeyPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is HotKey key && AssociatedObject != null)
            {
                AssociatedObject.Text = key.ToString();
            }
        }

        public HotKey HotKey
        {
            get => (HotKey)GetValue(HotKeyProperty);
            set => SetValue(HotKeyProperty, value);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            // IME無効化
            InputMethod.SetIsInputMethodSuspended(AssociatedObject, true);
            AssociatedObject.PreviewKeyDown += KeyChanged;
            AssociatedObject.Text = HotKey.ToString();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            // IME有効化
            InputMethod.SetIsInputMethodSuspended(AssociatedObject, false);
            AssociatedObject.PreviewKeyDown += KeyChanged;
        }

        public void KeyChanged(object sender, KeyEventArgs e)
        {
            var key = e.Key == Key.System ? e.SystemKey : e.Key;
            switch (key)
            {
                // 重要なキーを除外
                case Key.Tab:
                case Key.LeftShift:
                case Key.RightShift:
                case Key.LeftCtrl:
                case Key.RightCtrl:
                case Key.LeftAlt:
                case Key.RightAlt:
                case Key.RWin:
                case Key.LWin:
                case Key.Return:
                    return;
            }
            e.Handled = true;
            ModifierKeys modifierKeys = Keyboard.Modifiers;
            HotKey.SetKey(key, modifierKeys);
            AssociatedObject.Text = HotKey.ToString();
        }
    }
}
