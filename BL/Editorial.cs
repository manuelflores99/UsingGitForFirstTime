using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Editorial
    {

        public static (bool success, string message, List<ML.Editorial>, Exception error) GetAll()
        {
            try
            {
                using (DL.AppDbContext context = new DL.AppDbContext())
                {
                    var query = (from editorials in context.Editorials
                                 select new
                                 {
                                     IdEditorial = editorials.IdEditorial,
                                     NombreEditorial = editorials.Nombre,
                                     IdCiudad = editorials.IdCity

                                 }).ToList();

                    if (query != null)
                    {
                        List<ML.Editorial> Editoriales = new List<ML.Editorial>();
                        foreach (var registros in query)
                        {
                            ML.Editorial editorial = new ML.Editorial();
                            editorial.IdEditorial = registros.IdEditorial;
                            editorial.Nombre = registros.NombreEditorial;
                            editorial.Ciudad = new ML.Ciudad();
                            editorial.Ciudad.IdCiudad = registros.IdEditorial;

                            Editoriales.Add(editorial);

                        }
                        return (true, "Registros Encontrados",Editoriales, null);
                    }
                    else
                    {
                        return (false, "Registros No Encontrados", null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }

        }
    }
}
