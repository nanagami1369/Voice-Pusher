namespace CommonLibrary.Modules.MenuModule
{
    public class MenuItem
    {
        public string Name { get; }
        public string ViewName { get; }
        public string IconName { get;  }

        public MenuItem(string name, string viewName, string iconName)
        {
            Name = name;
            ViewName = viewName;
            IconName = iconName;
        }
    }
}
