﻿using CommonLibrary.Modules.CharacterLibraryModule;
using System.Collections.Generic;

namespace CharacterLibraryTest.Moc
{
    public class TestCharacterLibraryGateway : ICharacterLibraryGateway
    {
        public ICollection<ICharacter> TestLibrary { get; private set; }

        public void SetLibrary(ICollection<ICharacter> library)
        {
            TestLibrary = library;
        }

        public ICollection<ICharacter> Read()
        {
            return TestLibrary;
        }

        public void Write(ICharacter character)
        {
            TestLibrary.Add(character);
        }
    }
}
