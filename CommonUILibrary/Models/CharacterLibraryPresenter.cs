using CommonLibrary;
using CommonLibrary.Modules.CharacterLibraryModule;
using CommonLibrary.Modules.StatusModule;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;

namespace CommonUILibrary.Models
{
    public class CharacterLibraryPresenter : BindableBase, ICharacterLibraryPresenter
    {
        private readonly IDialog _dialog;
        private readonly IStatusSender _statusSender;
        private readonly ICharacterLibraryGateway _gateway;

        private ObservableCollection<ICharacter> _selectedLibrary;
        public ObservableCollection<ICharacter> SelectedLibrary
        {
            get => _selectedLibrary;
            set => SetProperty(ref _selectedLibrary, value);
        }

        private ICharacter _selectedCharacter;

        public ICharacter SelectedCharacter
        {
            get => _selectedCharacter;
            set => SetProperty(ref _selectedCharacter, value);
        }

        public void SearchCharacter(string query)
        {
            var originalCharacterLibrary = _gateway.Read();
            if (string.IsNullOrEmpty(query))
            {
                SelectedLibrary = new ObservableCollection<ICharacter>(originalCharacterLibrary);
                return;
            }
            var searchedLibrary = new ObservableCollection<ICharacter>();
            searchedLibrary.AddRange(originalCharacterLibrary.Where(item => item.Name == query));
            searchedLibrary.AddRange(originalCharacterLibrary.Where(item => item.Reading.StartsWith(query)));
            SelectedLibrary = searchedLibrary;
            // ListBoxのセレクターがリセットされるので再設定
            Index = 0;
        }

        public void SelectCharacter()
        {
            _dialog.ShowMessage("モック", $"まだ作ってないよ\n選択中：{SelectedCharacter.Name}");
        }

        public CharacterLibraryPresenter(IStatusSender statusSender, IDialog dialog, ICharacterLibraryGateway gateway)
        {
            _dialog = dialog;
            _statusSender = statusSender;
            _gateway = gateway;
            var originalCharacterLibrary = _gateway.Read();
            SelectedLibrary = new ObservableCollection<ICharacter>(originalCharacterLibrary);
        }

        #region keyboardActions

        private bool _isFocus;

        public bool IsFocus
        {
            get => _isFocus;
            set => SetProperty(ref _isFocus, value);
        }

        private int _index;

        public int Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }


        public void UpCharacterLibrary()
        {
            if (SelectedLibrary == null || SelectedLibrary.Count == 0) return;
            if (Index <= 0)
            {
                Index = SelectedLibrary.Count - 1;
            }
            else
            {
                Index--;
            }
        }

        public void DownCharacterLibrary()
        {
            if (SelectedLibrary == null || SelectedLibrary.Count == 0) return;
            if (Index >= SelectedLibrary.Count - 1)
            {
                Index = 0;
            }
            else
            {
                Index++;
            }
        }

        public void ResetSelector()
        {
            if (SelectedLibrary == null || SelectedLibrary.Count == 0) return;
            if (Index == -1) Index = 0;
        }

        public void SetFocus()
        {
            IsFocus = true;
            IsFocus = false;
        }
    }

    #endregion
}
