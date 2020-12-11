using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary;
using CommonLibrary.Modules.CharacterLibraryModule;
using CommonLibrary.Modules.MenuModule;
using CommonLibrary.Modules.StatusModule;
using CommonUILibrary.Models;
using Prism.Mvvm;

namespace CoreUILibrary.Models
{
    public class CharacterLibraryPresenter : BindableBase, ICharacterLibraryPresenter
    {
        private readonly IStatusSender _statusSender;
        private readonly ICharacterLibraryGateway _gateway;
        private readonly ICharacterLibraryViewSelectable _viewSelectable;
        private readonly IMenuContainerReader _menuContainer;

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private string _searchWord;
        public string SearchWord
        {
            get => _searchWord;
            set => SetProperty(ref _searchWord, value);
        }

        private ObservableCollection<Character> _originalLibrary;
        private ObservableCollection<Character> OriginalLibrary
        {
            get => _originalLibrary;
            set
            {
                var sortedLibrary = value.OrderBy(character => character.Name);
                _originalLibrary = new ObservableCollection<Character>(sortedLibrary);
                SelectedLibrary = new ObservableCollection<Character>(sortedLibrary);
            }
        }
        private ObservableCollection<Character> _selectedLibrary;

        public ObservableCollection<Character> SelectedLibrary
        {
            get => _selectedLibrary;
            set => SetProperty(ref _selectedLibrary, value);
        }

        public void SearchCharacter(string query)
        {
            var originalCharacterLibrary = OriginalLibrary;
            if (string.IsNullOrEmpty(query))
            {
                SelectedLibrary = new ObservableCollection<Character>(originalCharacterLibrary);
                ResetSelector();
                return;
            }
            var searchedLibrary = new ObservableCollection<Character>();
            searchedLibrary.AddRange(originalCharacterLibrary.Where(item => item.Name == query));
            searchedLibrary.AddRange(originalCharacterLibrary.Where(item => item.Reading.StartsWith(query)));
            SelectedLibrary = searchedLibrary;
            ResetSelector();
        }

        private void OpenView(Action<Character> selectable)
        {
            ResetSelector();
            if (Index == -1)
            {
                _statusSender.Send(StatusLevel.Error, "キャラクターが選択されておりません");
                return;
            }
            var selectedCharacter = SelectedLibrary[Index];
            selectable(selectedCharacter);
            _statusSender.Send(
                StatusLevel.Log, $"キャラクターが選択されました：{selectedCharacter.Name}");
            SearchWord = string.Empty;
            SelectedLibrary = OriginalLibrary;
            var selectedCharacterIndex = SelectedLibrary.ToList().FindIndex(c => c.Name == selectedCharacter.Name);
            Index = selectedCharacterIndex;
        }

        public void OpenEditorView()
        {
            var menuName = _menuContainer.Read().Name;
            //
            var voiceEditorMenuName = Config.MenuItem[0].Name;
            var characterEditorMenuName = Config.MenuItem[1].Name;
            if (menuName == voiceEditorMenuName)
            {
                OpenView(_viewSelectable.SelectVoiceEditorView);
            }
            else if (menuName == characterEditorMenuName)
            {
                OpenView(_viewSelectable.SelectCharacterEditorView);
            }
        }

        public void ResetView()
        {
            _viewSelectable.SelectNotSelectCharacterView();
        }

        public async Task LoadCharacterAsync()
        {
            if (OriginalLibrary == null || OriginalLibrary.Count == 0)
            {
                IsEnabled = false;
                _statusSender.Send(StatusLevel.Log, "キャラクターの読込中しました");
                OriginalLibrary = new ObservableCollection<Character>(await _gateway.ReadAsync());
                IsEnabled = true;
                _statusSender.Send(StatusLevel.Success, "キャラクターの読込完了しました");
            }
        }

        public CharacterLibraryPresenter(
            IStatusSender statusSender,
            ICharacterLibraryGateway gateway,
            ICharacterLibraryViewSelectable viewSelectable,
            IMenuContainerReader menuContainer
        )
        {
            _statusSender = statusSender;
            _gateway = gateway;
            _viewSelectable = viewSelectable;
            _menuContainer = menuContainer;
            OriginalLibrary = new ObservableCollection<Character>();
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
