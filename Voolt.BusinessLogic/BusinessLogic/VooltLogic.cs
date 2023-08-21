using Voolt.BusinessLogic.IBusinessLogic;
using Voolt.DataAccess.Entity;
using Voolt.DataAccess.IRepositories;

namespace Voolt.BusinessLogic.BusinessLogic
{
    public class VooltLogic : IVooltLogic
    {
        private readonly IVooltRepository _vooltRepository;

        public VooltLogic(IVooltRepository vooltRepository)
        {
            _vooltRepository = vooltRepository;
        }

        #region Page Block CRUD Operation

        #region Create Page Block
        public async Task<bool> CreatePageBlock(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentNullException(nameof(key));

                //As mentioned on the provided DOC like 'data model of all Blocks with default values as an array'
                //and Creating a data model of all partitions with default values as an array & Parameters to pass: key, 
                //because of that here I assigned static sample values into model, If required we can easily make it dynamic in future.

                PageBlockModel pageBlockModel = new PageBlockModel();
                pageBlockModel.header.Add(new Header()
                {
                    id = 1,
                    blockOrder = 1,
                    businessName = "test marketing",
                    logo = "https://www.deskera.com/blog/content/images/size/w2000/2022/01/Untitled-design--13--1.png",
                    navigationMenu =
                        new List<Header.NavigationMenu>()
                                {
                                    new Header.NavigationMenu(){ displayName="About Us",url="~/aboutus.html" },
                                    new Header.NavigationMenu(){ displayName="Services",url="~/services.html" },
                                    new Header.NavigationMenu(){ displayName="Reviews",url="~/reviews.html" },
                                    new Header.NavigationMenu(){ displayName="FAQ",url="~/faq.html" }
                                },
                    cTAButton = new CTAButton() { buttonEvent = "click-to-call", displayStatus = "true", icon = "<i class='fa fa-phone' aria-hidden='true'></i>", text = "555-555-5555" }
                });

                pageBlockModel.hero.Add(new Hero()
                {
                    id = 2,
                    blockOrder = 2,
                    headline = "Brilliantly Crafted Visual Designs",
                    description = "Designing Your Vision Life: Creative Solutions Your Brand",
                    contentAlignement = "center",
                    cTAButton = new CTAButton() { text = "Get In Touch" },
                    heroImage = "https://www.deskera.com/blog/content/images/size/w2000/2022/01/Untitled-design--13--1.png",
                    imageAlignement = "center"
                });

                pageBlockModel.services.Add(new Services()
                {
                    id = 3,
                    blockOrder = 3,
                    headline = "Our Service",
                    serviceCards = new List<Services.ServiceCard>()
                    {
                        new Services.ServiceCard()
                        {
                            cTAButton = new CTAButton(){ text="Learn More" },
                            name = "Logo Design",
                            description = "We specialize in creating unique and creative logos that are prefect for any business or individual. Our experienced team of designe...",
                            image ="https://www.deskera.com/blog/content/images/size/w2000/2022/01/Untitled-design--13--1.png",
                        },
                        new Services.ServiceCard()
                        {
                            cTAButton = new CTAButton(){ text="Learn More" },
                            name = "Website Design",
                            description = "We specialize in creating unique and creative logos that are prefect for any business or individual. Our experienced team of designe...",
                            image ="https://www.deskera.com/blog/content/images/size/w2000/2022/01/Untitled-design--13--1.png"
                        },
                        new Services.ServiceCard()
                        {
                            cTAButton = new CTAButton(){ text="Learn More" },
                            name = "Graphic Design",
                            description = "We specialize in creating unique and creative logos that are prefect for any business or individual. Our experienced team of designe...",
                            image ="https://www.deskera.com/blog/content/images/size/w2000/2022/01/Untitled-design--13--1.png"
                        }
                    }
                });
                return await _vooltRepository.CreatePageBlock(key, pageBlockModel);
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
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentNullException(nameof(key));

                return await _vooltRepository.GetPageBlock(key);
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
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentNullException(nameof(key));

                if (string.IsNullOrEmpty(sectionID))
                    throw new ArgumentNullException(nameof(sectionID));

                if (string.IsNullOrEmpty(blockValue))
                    throw new ArgumentNullException(nameof(blockValue));

                return await _vooltRepository.UpdatePageBlock(key, sectionID, blockValue);
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
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentNullException(nameof(key));

                return await _vooltRepository.DeletePageBlock(key, sectionID);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #endregion
    }
}
