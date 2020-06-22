using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using CommonUILibrary.Setting;

namespace CommonLibrary.Modules.SettingModule
{
    public interface ISettingEditorPresenter
    {
        bool IsEnabled { get; set; }
        List<Encoding> EncodeList { get; }

        string RenamedNameExample { get; }

        IEnumerable<ScriptOutPutMode> ScriptOutPutModeList { get; }

        Task SelectOutPutDirectoryPathAsync();
        void Naming();
        void AddNameScript(string script);
        Task LoadSettingAsync();
    }
}
