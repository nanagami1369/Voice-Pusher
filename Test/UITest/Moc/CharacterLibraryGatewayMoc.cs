using CommonLibrary;
using CommonLibrary.Modules.CharacterLibraryModule;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UITest.Moc
{
    public class CharacterLibraryGatewayMoc : ICharacterLibraryGateway
    {
        private readonly IDialog _dialog;

        public ICollection<ICharacter> Read()
        {
            return new ObservableCollection<ICharacter>()
            {
                new PartialCharacter() {Name = "霊夢", Reading = "れいむ"},
                new PartialCharacter() {Name = "魔理沙", Reading = "まりさ"},
                new PartialCharacter() {Name = "妖夢", Reading = "ようむ"},
            };
        }

        public void Write(ICharacter character)
        {
            _dialog.ShowMessage(
                "モック",
                $"書き込まれるはずのキャラクター{character.Name}"
            );
        }
    }
}
