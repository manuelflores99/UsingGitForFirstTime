using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static (bool Success, string Message, List<ML.Libro> Libros) GetAll()
        {
            try
            {
                using(DL.AppDbContext context = new DL.AppDbContext())
                {
                    List<ML.Libro> libros = new List<ML.Libro>();
                    var results = (from lib in context.Libros
                                   join edi in context.Editorials on lib.IdEditorial equals edi.IdEditorial
                                   select new
                                   {
                                       IdLibro = lib.IdLibro,
                                       Titulo = lib.Titulo,
                                       Autor = lib.Autor,
                                       Isbn = lib.Isbn,
                                       AnioPublicacion = lib.AnioPublicacion,
                                       IdEditorial = edi.IdEditorial,
                                       NombreEditorial = edi.Nombre
                                   }
                                   );

                    if(results != null)
                    {
                        foreach(var item in results)
                        {
                            ML.Libro libro = new ML.Libro
                            {
                                IdLibro = item.IdLibro,
                                Titulo = item.Titulo,
                                Autor = item.Autor,
                                Isbn = item.Isbn,
                                AnioPublicacion = item.AnioPublicacion,
                                Editorial = new ML.Editorial
                                {
                                    IdEditorial = item.IdEditorial,
                                    Nombre = item.NombreEditorial
                                }
                            };
                        }
                        return (true, null, libros);
                    }
                    else
                    {
                        return (true, "No hay datos", libros);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrio un error al realizar la operación: " + ex.Message, null);
            }
        }
    }
}
