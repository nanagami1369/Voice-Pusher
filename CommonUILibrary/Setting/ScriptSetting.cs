using System.Text;
using CommonLibrary.Modules.SettingModule;
using Newtonsoft.Json;

namespace CommonUILibrary.Setting
{
    public class ScriptSetting : IScriptSetting
    {
        [JsonConverter(typeof(EncodingConverter))]
        public Encoding CsvEncode { get; set; }

        public ScriptOutPutMode OutputMode { get; set; }
    }
}
