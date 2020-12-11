using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Windows.Input;
using Prism.Mvvm;

namespace CommonUILibrary.Models
{
    public class HotKey : BindableBase, IHotKey, IEquatable<HotKey>
    {
        private Key _key = Key.None;

        public Key Key
        {
            get => _key;
            private set => SetProperty(ref _key, value);
        }

        private ModifierKeys _modifierKeys = ModifierKeys.None;

        public ModifierKeys ModifierKeys
        {
            get => _modifierKeys;
            private set => SetProperty(ref _modifierKeys, value);
        }

        public void SetKey(Key key, ModifierKeys modifierKeys)
        {
            //バックキーはショートカットの無効化に使用
            if (key == Key.Back)
            {
                Key = Key.None;
                ModifierKeys = ModifierKeys.None;
            }

            if (modifierKeys == ModifierKeys.None)
            {
                // 単体で使用できるキーを設定
                switch (key)
                {
                    case Key.F1:
                    case Key.F2:
                    case Key.F3:
                    case Key.F4:
                    case Key.F5:
                    case Key.F6:
                    case Key.F7:
                    case Key.F8:
                    case Key.F9:
                    case Key.F10:
                    case Key.F11:
                    case Key.F12:
                        Key = key;
                        ModifierKeys = ModifierKeys.None;
                        return;
                    default:
                        // 単体で使用しないキーが、修飾キーとセットでなかった場合Keyを保存しない
                        return;
                }
            }

            Key = key;
            ModifierKeys = modifierKeys;
        }

        public HotKey()
        {
        }

        public HotKey(Key key, ModifierKeys modifierKeys)
        {
            SetKey(key, modifierKeys);
        }

        public override string ToString()
        {
            if (Key == Key.None)
            {
                return "該当なし";
            }

            var keyString = new StringBuilder();
            if ((ModifierKeys & ModifierKeys.Alt) == ModifierKeys.Alt)
            {
                keyString.Append("Alt+");
            }

            if ((ModifierKeys & ModifierKeys.Control) == ModifierKeys.Control)
            {
                keyString.Append("Ctrl+");
            }

            if ((ModifierKeys & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
                keyString.Append("Shift+");
            }

            if ((ModifierKeys & ModifierKeys.Windows) == ModifierKeys.Windows)
            {
                keyString.Append("Windows+");
            }

            keyString.Append(Key);

            return keyString.ToString();
        }

        public bool Equals([AllowNull] HotKey other)
        {
            if (this == other)
            {
                return true;
            }
            if (other == null)
            {
                return false;
            }
            return Key == other.Key && ModifierKeys == other.ModifierKeys;
        }
    }
}
