namespace Voice_Pusher
{
    public class HamburgerMenuItem
    {
        public HamburgerMenuItem(string name, string pagekey,string iconName)
        {
            Name = name;
            PageKey = pagekey;
            IconName = iconName;
        }

        public string Name { get; }
        public string PageKey { get; }
        public string IconName { get; }
    }
}
