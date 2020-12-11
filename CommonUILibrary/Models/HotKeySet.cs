using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Input;
using Prism.Mvvm;

namespace CommonUILibrary.Models
{
    public class HotKeySet : BindableBase, IEquatable<HotKeySet>
    {
        public Dictionary<string, string> HotKeySetInfo { get; } = new Dictionary<string, string>()
        {
            {nameof(Speak),"ボイスを再生する" },
            {nameof(Save),"保存する" },
            {nameof(SearchCharacter),"キャラクターを検索する" },
            {nameof(Menu1),"上から１番目のメニューを選択する" },
            {nameof(Menu2),"上から２番目のメニューを選択する" },
            {nameof(Menu3),"上から３番目のメニューを選択する" },
            {nameof(Menu4),"上から４番目のメニューを選択する" }
        };

        private HotKey _speak = new HotKey(Key.F5, ModifierKeys.None);
        public HotKey Speak
        {
            get => _speak;
            set => SetProperty(ref _speak, value);
        }

        private HotKey _save = new HotKey(Key.S, ModifierKeys.Control);
        public HotKey Save
        {
            get => _save;
            set => SetProperty(ref _save, value);
        }

        private HotKey _searchCharacter = new HotKey(Key.F, ModifierKeys.Control);
        public HotKey SearchCharacter
        {
            get => _searchCharacter;
            set => SetProperty(ref _searchCharacter, value);
        }

        private HotKey _menu1 = new HotKey(Key.D1, ModifierKeys.Alt);
        public HotKey Menu1
        {
            get => _menu1;
            set => SetProperty(ref _menu1, value);
        }
        private HotKey _menu2 = new HotKey(Key.D2, ModifierKeys.Alt);
        public HotKey Menu2
        {
            get => _menu2;
            set => SetProperty(ref _menu2, value);
        }
        private HotKey _menu3 = new HotKey(Key.D3, ModifierKeys.Alt);
        public HotKey Menu3
        {
            get => _menu3;
            set => SetProperty(ref _menu3, value);
        }
        private HotKey _menu4 = new HotKey(Key.D4, ModifierKeys.Alt);
        public HotKey Menu4
        {
            get => _menu4;
            set => SetProperty(ref _menu4, value);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var hotKeySetPropertys = GetType().GetProperties();
            foreach (var property in hotKeySetPropertys)
            {
                if (property.PropertyType == typeof(HotKey))
                {
                    var hotKey = (HotKey)property.GetValue(this);
                    sb.Append(property.Name).Append(" : ").Append(hotKey.ToString()).Append('\n');
                }
            }
            return sb.ToString();
        }

        public bool Equals([AllowNull] HotKeySet other)
        {
            if (other == this)
            {
                return true;
            }
            if (other == null)
            {
                return false;
            }
            var hotKeySetPropertys = GetType().GetProperties();
            for (int index = 0; index < hotKeySetPropertys.Length; index++)
            {
                if (hotKeySetPropertys[index].PropertyType == typeof(HotKey))
                {
                    var thisHotKey = (HotKey)hotKeySetPropertys[index].GetValue(this);
                    var otherHotKey = (HotKey)hotKeySetPropertys[index].GetValue(other);
                    if (!thisHotKey.Equals(otherHotKey))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
