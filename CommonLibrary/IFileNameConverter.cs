using CommonLibrary.Modules.CharacterLibraryModule;

namespace CommonLibrary
{
    public interface IFileNameConverter
    {
        string Naming(Character character, string script, string nameScript, int count = 0);
    }
}
