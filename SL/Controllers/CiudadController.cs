using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            var result = BL.Ciudad.GetAll();

            if (result.success)
            {
                return Ok(result.Item3);
            }
            else
            {
                return BadRequest(result.message);
            }
        }
    }
}
