namespace Voice_Pusher
{
    public class HamburgerMenuItem
    {
        public HamburgerMenuItem(string name, string iconName)
        {
            Name = name;
            IconName = iconName;
        }

        public string Name { get; }
        public string IconName { get; }
    }
}
