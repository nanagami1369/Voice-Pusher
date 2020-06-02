namespace CommonLibrary
{
    public interface IFileNameConverter
    {
        string Naming(Voice voice, string nameScript, int count);
    }
}
