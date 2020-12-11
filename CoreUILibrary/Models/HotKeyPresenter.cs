using System.Threading.Tasks;
using CommonLibrary;
using CommonLibrary.Modules.StatusModule;
using CommonUILibrary.Models;
using Prism.Mvvm;

namespace CoreUILibrary.Models
{
    public class HotKeyPresenter : BindableBase, IHotKeyPresenter
    {
        private readonly IHotKeyRegistry _registry;
        private readonly IStatusSender _statusSender;
        private readonly IDialog _dialog;

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private IHotKeyContainer Container { get; set; }

        private HotKeySet _editHotKeySet;
        public HotKeySet EditHotKeySet
        {
            get => _editHotKeySet;
            set => SetProperty(ref _editHotKeySet, value);
        }

        public async Task LoadAsync()
        {
            IsEnabled = false;
            EditHotKeySet = await _registry.ReadAsync(Config.HotKeyFileName, Config.ApplicationFileEncode);
            _statusSender.Send(StatusLevel.Success, "キーボードショートカットの設定ファイルを読み込みました");
            IsEnabled = true;
        }

        public async Task SaveAsync()
        {
            Container.Value = EditHotKeySet;
            await _registry.WriterAsync(Container.Value, Config.HotKeyFileName, Config.ApplicationFileEncode);
            _statusSender.Send(StatusLevel.Success, "キーボードショートカットを更新しました");
        }

        public async Task<bool> ConfirmationSaveAsync()
        {
            if (Container.Value.Equals(EditHotKeySet))
            {
                return true;
            }
            return await _dialog.ShowConfirmationMessageAsync(
                                "変更が保存されていません",
                                "キーボードショートカットが保存されていません\nこのまま画面を移動しますか？",
                                "保存しないで移動", "いいえ");
        }

        public void Reset()
        {
            var hotKeySetPropertys = typeof(HotKeySet).GetType().GetProperties();
            for (int index = 0; index < hotKeySetPropertys.Length; index++)
            {
                if (hotKeySetPropertys[index].PropertyType == typeof(HotKey))
                {
                    var containerHotKey = (HotKey)hotKeySetPropertys[index].GetValue(Container);
                    hotKeySetPropertys[index].SetValue(EditHotKeySet, containerHotKey);
                }
            }

        }

        public HotKeyPresenter(
            IHotKeyRegistry registry,
            IHotKeyContainer container,
            IStatusSender statusSender,
            IDialog dialog)
        {
            _registry = registry;
            Container = container;
            _statusSender = statusSender;
            _dialog = dialog;
        }
    }
}
