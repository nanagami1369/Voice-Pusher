using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using Prism.Commands;
using Prism.Mvvm;
using Voice_Pusher.Model;

namespace Voice_Pusher.ViewModels
{
    public class SettingEditorViewModel : BindableBase
    {
        public SettingEditorViewModel(IDataContainer container, IDialog dialog)
        {
            Container = container;
            Dialog = dialog;
            // Shift-Jisを使えるようにする
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var shiftJis = Encoding.GetEncoding(932);
            var utf8 = new UTF8Encoding(false);
            EncodingList = new[] {shiftJis, utf8};
            OpenDirectoryPickerCommand
                = new DelegateCommand(async () => { await OpenDirectoryPicker(); });
            InsertTemplateCommand = new DelegateCommand<string?>(InsertTemplate);
        }

        public TextInserter TemplateInserterForNameScript { get; } = new();

        public DelegateCommand<string?> InsertTemplateCommand { get; }
        public IDataContainer Container { get; }

        public Encoding[] EncodingList { get; }
        private IDialog Dialog { get; }
        public DelegateCommand OpenDirectoryPickerCommand { get; }

        public void InsertTemplate(string? template)
        {
            if (template is not null)
            {
                TemplateInserterForNameScript.Insert(template);
            }
        }

        private async Task OpenDirectoryPicker()
        {
            var outputDirectoryPath = await Dialog.OpenFolderAsync();
            if (outputDirectoryPath is not null)
            {
                Container.SettingsManager.OutputDirectoryPathCache.Value = outputDirectoryPath;
            }
        }
    }
}
