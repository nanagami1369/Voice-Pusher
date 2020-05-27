using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommonLibrary;
using CommonLibrary.Modules.CharacterLibraryModule;

namespace UITest.Moc
{
    public class CharacterLibraryGatewayMoc : ICharacterLibraryGateway
    {
        private readonly IDialog _dialog;

        public ICollection<Character> Read()
        {
            return new ObservableCollection<Character>()
            {
                new PartialCharacter("霊夢","れいむ"),
                new PartialCharacter("魔理沙","まりさ"),
                new PartialCharacter("舞", "まい"),
                new PartialCharacter("妖夢", "ようむ"),
            };
        }

        public void Write(Character character)
        {
            _dialog.ShowMessageAsync(
                "モック",
                $"書き込まれるはずのキャラクター{character.Name}"
            );
        }
    }
}
