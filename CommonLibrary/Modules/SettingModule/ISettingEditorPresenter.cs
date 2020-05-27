using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CommonUILibrary.Setting;

namespace CommonLibrary.Modules.SettingModule
{
    public interface ISettingEditorPresenter
    {
        bool IsEnabled { get; set; }
        List<Encoding> EncodeList { get; }

        IEnumerable<ScriptOutPutMode> ScriptOutPutModeList { get; }

        Task SelectOutPutDirectoryPathAsync();
        Task LoadSettingAsync();
    }
}
