using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("v1/[Controller]")]
    public class CriminalCodeController : Controller
    {
        [HttpPost]
        [Route("include")]
        public ActionResult<dynamic> IncludeCriminalCode([FromBody] CriminalCode criminalCodeReceived, [FromServices] ICriminalCodeService criminalCodeService)
        {
            criminalCodeService.IncludeCriminalCode(criminalCodeReceived);
            return "OK";
        }
        [HttpPost]
        [Route("get")]
        public ActionResult<dynamic> GetCriminalCode([FromBody] CriminalCodeFilter criminalCodeFilter, [FromServices] ICriminalCodeService criminalCodeService)
        {
            return criminalCodeService.GetSortedCriminalCodes(criminalCodeFilter);
        }
        [HttpPost]
        [Route("update")]
        public ActionResult<dynamic> UpdateCriminalCode([FromBody] CriminalCode criminalCode, [FromServices] ICriminalCodeService criminalCodeService)
        {
            if (criminalCode != null)
            {
                return NotFound("Wrong Model Sent!");
            }
            bool success = criminalCodeService.UpdateCriminalCode(criminalCode);
            return success ? "Updated!" : NotFound("Couldn't update that CriminalCode!");
        }
        [HttpGet]
        [Route("get/{id:int}")]
        public ActionResult<dynamic> GetCriminalCodeById(int id, [FromServices] ICriminalCodeService criminalCodeService)
        {
            CriminalCode? criminalCode = criminalCodeService.GetCriminalCodeById(id);
            if (criminalCode == null)
            {
                return NotFound("Can't find any criminalCode in respect with that ID");
            }
            return criminalCode;
        }
        [HttpGet]
        [Route("remove/{id:int}")]
        public ActionResult<dynamic> RemoveCriminalCodeById(int id, [FromServices] ICriminalCodeService criminalCodeService)
        {
            bool success = criminalCodeService.RemoveCriminalCode(id);
            return success ? "Removed!" : NotFound("Couldn't remove that CriminalCode!");
        }
    }
}