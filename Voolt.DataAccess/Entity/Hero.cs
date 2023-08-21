namespace Voolt.DataAccess.Entity
{
    public class Hero
    {
        public int id { get; set; }
        public int blockOrder { get; set; }
        public string headline { get; set; }
        public string description { get; set; }
        public CTAButton cTAButton { get; set; }
        public string heroImage { get; set; }
        public string imageAlignement{get; set;}
        public string contentAlignement { get; set; }
    }
}
