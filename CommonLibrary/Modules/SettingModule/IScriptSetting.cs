using System.Text;
using CommonUILibrary.Setting;

namespace CommonLibrary.Modules.SettingModule
{
    public interface IScriptSetting
    {
        Encoding CsvEncode { get; set; }
        ScriptOutPutMode OutputMode { get; set; }
    }
}
