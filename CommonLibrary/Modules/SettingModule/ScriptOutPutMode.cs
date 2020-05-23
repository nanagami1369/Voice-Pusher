using System.ComponentModel;

namespace CommonUILibrary.Setting
{
    public enum ScriptOutPutMode
    {
        [Description("作り直し")]
        Remake,
        [Description("上書き")]
        Override,
    }
}
