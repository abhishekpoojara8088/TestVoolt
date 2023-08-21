namespace Voolt.DataAccess.Entity
{
    public  class Services
    {
        public int id { get; set; }
        public int blockOrder { get; set; }
        public string headline { get; set; }
        public List<ServiceCard> serviceCards { get; set; }

        public class ServiceCard
        {
            public string name { get; set; }
            public string description { get; set; }
            public string image { get; set; }
            public CTAButton cTAButton { get; set; }

        }

    }
}
