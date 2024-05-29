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

        [HttpGet]
        [Route("GetById/{idLibro}")]
        public IActionResult GetById(int idLibro)
        {
            Result result = new Result();
            var task = BL.Libro.GetById(idLibro);
            result.Success = task.Success;
            result.Message = task.Message;
            result.Data = task.Libro;

            if (task.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] ML.Libro libro)
        {
            Result result = new Result();
            var task = BL.Libro.Add(libro);
            result.Success = task.Success;
            result.Message = task.Message;

            if (task.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] ML.Libro libro)
        {
            Result result = new Result();
            var task = BL.Libro.Update(libro);
            result.Success = task.Success;
            result.Message = task.Message;

            if (task.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete]
        [Route("Delete/{idLibro}")]
        public IActionResult Delete(int idLibro)
        {
            Result result = new Result();
            var task = BL.Libro.Delete(idLibro);
            result.Success = task.Success;
            result.Message = task.Message;

            if (task.Success)
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
