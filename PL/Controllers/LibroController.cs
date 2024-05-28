using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class LibroController : Controller
    {
        public IActionResult Index()
        {
            Models.DTO.Libro libro = new Models.DTO.Libro();
            
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7116/");
                var task = client.GetAsync("Libro/GetAll");

                var taskResult = task.Result;

                if (taskResult.IsSuccessStatusCode)
                {
                    var result = taskResult.Content.ReadAsAsync<Models.Result>();

                    if (result.Result.Success)
                    {
                        if(result.Result.Data != null)
                        {
                            var libros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.DTO.Libro>>(result.Result.Data.ToString());

                            libro.Libros = libros;
                        }
                    }
                }
            }
            return View(libro);
        }
    }
}
