namespace CommonLibrary.Modules.MenuModule
{
    public class MenuItem
    {
        public string Name { get; private set; }
        public string ViewName { get; private set; }
        public string IconName { get; private set; }

        public MenuItem Copy()
        {
            return new MenuItem("", "", "")
            {
                Name = this.Name,
                ViewName = this.ViewName,
                IconName = this.IconName,
            };
        }
        public MenuItem(string name, string viewName, string iconName)
        {
            Name = name;
            ViewName = viewName;
            IconName = iconName;
        }
    }
}
