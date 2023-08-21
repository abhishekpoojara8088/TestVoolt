
namespace Voolt.DataAccess.Entity
{
    public class PageBlockModel
    {
        public List<Header> header { get; set; } = new List<Header>();
        public List<Hero> hero { get; set; } = new List<Hero>();
        public List<Services> services { get; set; } = new List<Services>();
    }
}
