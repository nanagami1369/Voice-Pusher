using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using Newtonsoft.Json;

namespace CommonUILibrary.Models
{
    public class HotKeyConverter : JsonConverter<HotKey>
    {
        private class RowHotKey : IHotKey
        {
            public Key Key { get; set; }
            public ModifierKeys ModifierKeys { get; set; }
        }

        public override HotKey ReadJson(JsonReader reader, Type objectType, [AllowNull] HotKey existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            var rowHotKey = serializer.Deserialize<RowHotKey>(reader);
            return new HotKey(rowHotKey.Key, rowHotKey.ModifierKeys);
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] HotKey value, JsonSerializer serializer)
        {
            throw new NotSupportedException("このコンバーターはシリアライズには対応してません");
        }
    }
}
