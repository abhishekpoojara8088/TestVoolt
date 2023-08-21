using Voolt.DataAccess.Entity;

namespace Voolt.BusinessLogic.IBusinessLogic
{
    public interface IVooltLogic
    {
        Task<bool> CreatePageBlock(string key);
        Task<PageBlockModel> GetPageBlock(string key);
        Task<bool> UpdatePageBlock(string key, string sectionID, string blockValue);
        Task<bool> DeletePageBlock(string key, string sectionID);
    }
}
