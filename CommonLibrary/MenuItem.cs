namespace CommonLibrary
{
    public class MenuItem
    {
        public string Name { get; }
        public string IconName { get; }


        public MenuItem(string name, string iconName)
        {
            Name = name;
            IconName = iconName;
        }
    }
}
