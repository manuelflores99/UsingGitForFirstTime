using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Ciudad
    {

        public static(bool success, string message,  List<ML.Ciudad>, Exception error) GetAll()
        {
            try
            {
                using(DL.AppDbContext context = new DL.AppDbContext())
                {
                    var query = (from ciudad in context.Cities
                                 select new
                                 {
                                     IdCiudad = ciudad.IdCity,
                                     NombreCiudad = ciudad.Nombre

                                 }).ToList();

                    if(query != null)
                    {
                        List<ML.Ciudad> ciudads = new List<ML.Ciudad>();
                        foreach(var registros in query)
                        {
                            ML.Ciudad ciudad = new ML.Ciudad();
                            ciudad.IdCiudad = registros.IdCiudad;
                            ciudad.NombreCiudad = registros.NombreCiudad;
                            ciudads.Add(ciudad);
                        }
                        return (true, "Registros Encontrados", ciudads, null);
                    }
                    else
                    {
                        return (false, "Registros No Encontrados", null, null);
                    }
                }
            }
            catch(Exception ex)
            {
                return (false, ex.Message,null, ex);
            }

        }
    }
}
