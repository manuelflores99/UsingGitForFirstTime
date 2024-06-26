﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Models;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            Result resultado = new Result();
            var result = BL.Editorial.GetAll();

            resultado.Success = result.success;
            resultado.Message = result.message;
            resultado.Data = result.Item3;

            if (result.success)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest(resultado);
            }
        }



    }
}
