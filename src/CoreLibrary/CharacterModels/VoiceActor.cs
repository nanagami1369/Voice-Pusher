namespace CoreLibrary.CharacterModels
{
    public abstract record VoiceActor
    {
        protected VoiceActor(string name, string office, string version)
        {
            Name = name;
            Office = office;
            Version = version;
        }

        public virtual string Name { get; init; }
        public virtual string Office { get; init; }
        public virtual string Version { get; init; }

        // ディスプレイの表示をカスタマイズする
        public abstract override string ToString();
    }
}
