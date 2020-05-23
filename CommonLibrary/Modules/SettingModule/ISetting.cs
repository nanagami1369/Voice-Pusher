namespace CommonLibrary.Modules.SettingModule
{
    public interface ISetting
    {
        ICommonSetting Common { get; }
        IScriptSetting Script { get; }
    }
}
