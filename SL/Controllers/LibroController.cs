using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Models;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            Result result = new Result();
            var task = BL.Libro.GetAll();
            result.Success = task.Success;
            result.Message = task.Message;
            result.Data = task.Libros;

            if(task.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
