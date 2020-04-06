﻿using CommonLibrary.Modules.CharacterLibraryModule;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonUILibrary.ViewModels
{
    public class CharacterEditorCharacterLibraryViewModel : BindableBase
    {
        public ICharacterLibraryPresenter CharacterLibrary { get; }

        public DelegateCommand SelectCharacterCommand { get; }

        public DelegateCommand<string> SearchCharacterCommand { get; }

        #region keyboardActions

        public DelegateCommand UpCharacterLibraryCommand { get; }
        public DelegateCommand DownCharacterLibraryCommand { get; }
        public DelegateCommand ResetSelectorCommand { get; }
        public DelegateCommand SetFocusCommand { get; }

        #endregion

        public CharacterEditorCharacterLibraryViewModel(ICharacterLibraryPresenter characterLibrary)
        {
            CharacterLibrary = characterLibrary;
            SelectCharacterCommand = new DelegateCommand(CharacterLibrary.OpenCharacterEditorView);
            SearchCharacterCommand = new DelegateCommand<string>(CharacterLibrary.SearchCharacter);
            UpCharacterLibraryCommand = new DelegateCommand(CharacterLibrary.UpCharacterLibrary);
            DownCharacterLibraryCommand = new DelegateCommand(CharacterLibrary.DownCharacterLibrary);
            ResetSelectorCommand = new DelegateCommand(CharacterLibrary.ResetSelector);
            SetFocusCommand = new DelegateCommand(CharacterLibrary.SetFocus);
        }
    }
}
