using Microsoft.AspNetCore.Authorization;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("v1/[Controller]")]
    public class CriminalCodeController : Controller
    {
        /// <summary>
        /// Includes a Criminal Code into the database
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "Name": "Criminal Code Name",
        ///        "Description": "Criminal Code Description",
        ///        "Penalty": "Criminal Code Penalty",
        ///        "PrisonTime": "Criminal Code Prison Time",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns OK</response>
        [HttpPost]
        [Route("include")]
        [Authorize]
        public ActionResult<dynamic> IncludeCriminalCode([FromBody] CriminalCode criminalCodeReceived, [FromServices] ICriminalCodeService criminalCodeService, [FromServices] ITokenService tokenService)
        {
            string accessToken = Request.Headers["Authorization"].ToString().Remove(0, 7);
            int? updateId = tokenService.GetUserIdByToken(accessToken);
            if (updateId == null)
            {
                return NotFound("Can this happen?");
            }
            criminalCodeReceived.UpdateUserId = updateId;
            criminalCodeReceived.CreateDate = DateTime.Now;
            criminalCodeService.IncludeCriminalCode(criminalCodeReceived);
            return "OK";
        }
        /// <summary>
        /// Get Paginated, Sorted and Filtered Criminal Codes from the database
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "Page": "Actual Page",
        ///        "Rows": "Desired Rows per Page",
        ///        "Way": "true or false for ascending or descending",
        ///        "OrderId": "Order Field",
        ///        "FilterId": "Filter Field",
        ///        "Filter": "Content to filter",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns List of Criminal Codes</response>
        [HttpPost]
        [Route("get")]
        [Authorize]
        public ActionResult<dynamic> GetCriminalCode([FromBody] CriminalCodeFilter criminalCodeFilter, [FromServices] ICriminalCodeService criminalCodeService)
        {
            return criminalCodeService.GetSortedCriminalCodes(criminalCodeFilter);
        }
        /// <summary>
        /// Update an existing Criminal Code
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="404">Failed or Not Found</response>
        [HttpPost]
        [Route("update")]
        [Authorize]
        public ActionResult<dynamic> UpdateCriminalCode([FromBody] CriminalCode criminalCodeReceived, [FromServices] ICriminalCodeService criminalCodeService, [FromServices] ITokenService tokenService)
        {
            if (criminalCodeReceived == null)
            {
                return NotFound("Wrong Model Sent!");
            }
            string accessToken = Request.Headers["Authorization"].ToString().Remove(0, 7);
            int? updateId = tokenService.GetUserIdByToken(accessToken);
            if (updateId == null)
            {
                return NotFound("Can this happen?");
            }
            criminalCodeReceived.UpdateUserId = updateId;
            criminalCodeReceived.UpdateDate = DateTime.Now;
            bool success = criminalCodeService.UpdateCriminalCode(criminalCodeReceived);
            return success ? "Updated!" : NotFound("Couldn't update that CriminalCode!");
        }
        /// <summary>
        /// Get an Criminal Code by Id
        /// </summary>
        /// <parameter name="id"></parameter>
        /// <response code="200">Success</response>
        /// <response code="404">Failed or Not Found</response>
        [HttpGet]
        [Route("get/{id:int}")]
        [Authorize]
        public ActionResult<dynamic> GetCriminalCodeById(int id, [FromServices] ICriminalCodeService criminalCodeService)
        {
            CriminalCode? criminalCode = criminalCodeService.GetCriminalCodeById(id);
            if (criminalCode == null)
            {
                return NotFound("Can't find any criminalCode in respect with that ID");
            }
            return criminalCode;
        }
        /// <summary>
        /// Remove an Criminal Code by Id
        /// </summary>
        /// <parameter name="id"></parameter>
        /// <response code="200">Success</response>
        /// <response code="404">Failed or Not Found</response>
        [HttpGet]
        [Route("remove/{id:int}")]
        [Authorize]
        public ActionResult<dynamic> RemoveCriminalCodeById(int id, [FromServices] ICriminalCodeService criminalCodeService)
        {
            bool success = criminalCodeService.RemoveCriminalCode(id);
            return success ? "Removed!" : NotFound("Couldn't remove that CriminalCode!");
        }
    }
}