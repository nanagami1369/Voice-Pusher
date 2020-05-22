using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommonLibrary;
using CommonLibrary.Modules.CharacterLibraryModule;
using CommonLibrary.Modules.StatusModule;
using Prism.Mvvm;

namespace CoreUILibrary.Models
{
    public class CharacterLibraryPresenter : BindableBase, ICharacterLibraryPresenter
    {
        private readonly IStatusSender _statusSender;
        private readonly ICharacterLibraryGateway _gateway;
        private readonly IViewSelectable _viewSelectable;

        private string _searchWord;
        public string SearchWord
        {
            get => _searchWord;
            set => SetProperty(ref _searchWord, value);
        }

        private ObservableCollection<ICharacter> _originalLibrary;
        private ObservableCollection<ICharacter> OriginalLibrary
        {
            get => _originalLibrary;
            set
            {
                _originalLibrary = value;
                SelectedLibrary = value;
            }
        }
        private ObservableCollection<ICharacter> _selectedLibrary;

        public ObservableCollection<ICharacter> SelectedLibrary
        {
            get => _selectedLibrary;
            set => SetProperty(ref _selectedLibrary, value);
        }

        public void SearchCharacter(string query)
        {
            var originalCharacterLibrary = OriginalLibrary;
            if (string.IsNullOrEmpty(query))
            {
                SelectedLibrary = new ObservableCollection<ICharacter>(originalCharacterLibrary);
                ResetSelector();
                return;
            }
            var searchedLibrary = new ObservableCollection<ICharacter>();
            searchedLibrary.AddRange(originalCharacterLibrary.Where(item => item.Name == query));
            searchedLibrary.AddRange(originalCharacterLibrary.Where(item => item.Reading.StartsWith(query)));
            SelectedLibrary = searchedLibrary;
            ResetSelector();
        }

        private void OpenView(Action<ICharacter> selectable)
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

        public void OpenVoiceEditorView()
        {
            OpenView(_viewSelectable.SelectVoiceEditorView);
        }

        public void OpenCharacterEditorView()
        {
            OpenView(_viewSelectable.SelectCharacterEditorView);
        }

        public CharacterLibraryPresenter(
            IStatusSender statusSender,
            ICharacterLibraryGateway gateway,
            IViewSelectable viewSelectable
        )
        {
            _statusSender = statusSender;
            _gateway = gateway;
            _viewSelectable = viewSelectable;

            OriginalLibrary = new ObservableCollection<ICharacter>(_gateway.Read());
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
