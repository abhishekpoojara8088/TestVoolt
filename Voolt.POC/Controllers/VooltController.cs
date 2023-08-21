using Microsoft.AspNetCore.Mvc;
using Voolt.BusinessLogic.IBusinessLogic;
using Voolt.DataAccess.Entity;

//Used the async/await and task thread as per the best practices,
//Might be currently it will give some warning because we are not using DB as of now.

namespace Voolt.POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VooltController : ControllerBase
    {
        private readonly IVooltLogic _vooltLogic;

        public VooltController(IVooltLogic vooltLogic)
        {
            _vooltLogic = vooltLogic;
        }

        #region Page Block CRUD Operation

        #region Create Page Block
        // POST api
        [HttpPost("createpageblock")]
        public async Task<IActionResult> CreatePageBlock([FromBody] string key)
        {
            var pageBlock = await _vooltLogic.CreatePageBlock(key);
            if (pageBlock)
                return Ok();
            else
                return BadRequest();
        }
        #endregion

        #region Get Page Block
        // GET api
        [HttpGet("getpageblock/{key}")]
        public async Task<PageBlockModel> GetPageBlock(string key)
        {
            return await _vooltLogic.GetPageBlock(key);
        }
        #endregion

        #region Update Page Block
        // PUT api
        [HttpPut("updatepageblock")]
        public async Task<IActionResult> UpdatePageBlock(string key, string sectionID, [FromBody] string blockValue)
        {

            var pageBlock = await _vooltLogic.UpdatePageBlock(key, sectionID, blockValue);
            if (pageBlock)
                return Ok();
            else
                return BadRequest();
        }
        #endregion

        #region Delete Page Block
        // DELETE api
        [HttpDelete("deletepageblock")]
        public async Task<IActionResult> DeletePageBlock(string key, string? sectionID)
        {
            var pageBlock = await _vooltLogic.DeletePageBlock(key, sectionID);
            if (pageBlock)
                return Ok();
            else
                return BadRequest();
        }
        #endregion

        #endregion
    }
}
