namespace Voolt.DataAccess.Entity
{
    public class Header
    {
        public int id { get; set; }
        public int blockOrder { get; set; }
        public string businessName { get; set; }
        public string logo { get; set; }
        public List<NavigationMenu> navigationMenu { get; set; }
        public CTAButton cTAButton { get; set; }

        public class NavigationMenu
        {
            public string displayName { get; set; }
            public string url { get; set; }
            public List<SubMenu> subMenus { get; set; }
        }

        public class SubMenu
        {
            public string displayName { get; set; }
            public string url { get; set; }
        }
    }
}

