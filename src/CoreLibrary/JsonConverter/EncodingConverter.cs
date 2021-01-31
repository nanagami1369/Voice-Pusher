using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Newtonsoft.Json;

#nullable disable
namespace CoreLibrary.JsonConverter
{
    internal class EncodingConverter : JsonConverter<Encoding>
    {
        public EncodingConverter()
        {
            // Shift-Jisを使えるようにする
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public override Encoding ReadJson(JsonReader reader, Type objectType, [AllowNull] Encoding existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            var codePage = int.Parse(reader.Value.ToString());
            // UTF8は、BOM無しとして常に扱う。
            if (codePage == 65001)
            {
                return new UTF8Encoding(false);
            }

            try
            {
                var encode = Encoding.GetEncoding(codePage);
                return encode;
            }
            catch (NotSupportedException)
            {
                throw new JsonSerializationException($"サポートされていない文字コードです：{codePage}");
            }
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] Encoding value, JsonSerializer serializer)
        {
            var codePage = value.CodePage;
            writer.WriteValue(codePage);
        }
    }
}
#nullable enable
