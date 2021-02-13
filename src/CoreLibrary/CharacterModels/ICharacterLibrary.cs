using System.Collections.ObjectModel;

namespace CoreLibrary.CharacterModels
{
    public interface ICharacterLibrary
    {
        ObservableCollection<Character> OriginalLibrary { get; set; }

        public void AddCharacter(Character character);
    }
}
