namespace CommonLibrary.Modules.SettingModule
{
    public interface ISettingContainer
    {
        void Register(ISetting setting);

        ISetting Read();
    }
}
