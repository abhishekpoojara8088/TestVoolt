using Voolt.DataAccess.Entity;

namespace Voolt.DataAccess.IRepositories
{
    public interface IVooltRepository
    {
        Task<bool> CreatePageBlock(string key, PageBlockModel pageBlockModel);
        Task<PageBlockModel> GetPageBlock(string key);
        Task<bool> UpdatePageBlock(string key, string sectionID, string blockValue);
        Task<bool> DeletePageBlock(string key, string sectionID);
    }
}
