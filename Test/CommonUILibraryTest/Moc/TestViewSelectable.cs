﻿using CommonLibrary;
using CommonLibrary.Modules.CharacterLibraryModule;

namespace CommonUILibrary.Moc
{
    public class TestViewSelectable : IViewSelectable
    {
        public ICharacter SetedCharacter { get; private set; }
        public string SelectView { get; private set; }

        public void SelectCharacterEditorView(ICharacter character)
        {
            SetedCharacter = character;
            SelectView = "Character";
        }

        public void SelectVoiceEditorView(ICharacter character)
        {
            SetedCharacter = character;
            SelectView = "Voice";
        }
    }
}
