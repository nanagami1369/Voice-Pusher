using System.Text;
using Prism.Mvvm;

namespace Voice_Pusher.ViewModels
{
    public class SettingEditorViewModel : BindableBase
    {
        public SettingEditorViewModel()
        {
            // Shift-Jisを使えるようにする
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var shiftJis = Encoding.GetEncoding(932);
            var utf8 = new UTF8Encoding(false);
            EncodingList = new[] {shiftJis, utf8};
        }

        public Encoding[] EncodingList { get; }
    }
}
