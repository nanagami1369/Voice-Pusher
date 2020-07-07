
namespace CommonLibrary.Modules.CharacterLibraryModule
{
    public interface ITryJsonToCharacterConverter
    {
        bool TryConvert(string officeName, string json, out Character character);
    }
}
