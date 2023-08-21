using Newtonsoft.Json;
using Voolt.DataAccess.Entity;
using Voolt.DataAccess.IRepositories;

//Usually we are using Repository for the DB related activities like Calling SP & Entity Frame work.
//As of now we don't have anything, so we write File read/write code here.

namespace Voolt.DataAccess.Repositories
{
    public class VooltRepository : IVooltRepository
    {
        #region Page Block CRUD Operation

        #region Create Page Block
        public async Task<bool> CreatePageBlock(string key,PageBlockModel pageBlockModel)
        {
            try
            {
                CreateFile(key, pageBlockModel);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Get Page Block
        public async Task<PageBlockModel> GetPageBlock(string key)
        {
            try
            {
                return JsonConvert.DeserializeObject<PageBlockModel>(File.ReadAllText(@"./PageBlock/" + key + ".json"));
            }
            catch
            {
                return new PageBlockModel();
            }
        }
        #endregion

        #region Update Page Block
        public async Task<bool> UpdatePageBlock(string key, string sectionID, string blockValue)
        {
            try
            {
                var pageBlock = JsonConvert.DeserializeObject<PageBlockModel>(File.ReadAllText(@"./PageBlock/" + key + ".json"));
                if (pageBlock != null && sectionID != null)
                {
                    if (sectionID == "1")
                        pageBlock.header = JsonConvert.DeserializeObject<List<Header>>(blockValue);
                    else if (sectionID == "2")
                        pageBlock.hero = JsonConvert.DeserializeObject<List<Hero>>(blockValue);
                    else if (sectionID == "3")
                        pageBlock.services = JsonConvert.DeserializeObject<List<Services>>(blockValue);
                    else
                        return false;
                }
                CreateFile(key, pageBlock);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Delete Page Block
        public async Task<bool> DeletePageBlock(string key, string sectionID)
        {
            try
            {
                var pageBlock = JsonConvert.DeserializeObject<PageBlockModel>(File.ReadAllText(@"./PageBlock/" + key + ".json"));
                if (pageBlock != null && sectionID != null)
                {
                    if (sectionID == "1")
                        pageBlock.header = null;
                    else if (sectionID == "2")
                        pageBlock.hero = null;
                    else if (sectionID == "3")
                        pageBlock.services = null;
                    else
                        return false;

                    CreateFile(key, pageBlock);
                }
                else if (pageBlock != null && sectionID == null)
                    File.Delete(@"./PageBlock/" + key + ".json");
                else return false;

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #endregion

        #region other
        public void CreateFile(string key, PageBlockModel pageBlock)
        {
            File.WriteAllText(@"./PageBlock/" + key + ".json", JsonConvert.SerializeObject(pageBlock));
        }
        #endregion
    }
}
