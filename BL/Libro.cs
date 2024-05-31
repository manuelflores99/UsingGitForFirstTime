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
                using (DL.AppDbContext context = new DL.AppDbContext())
                {
                    List<ML.Libro> libros = new List<ML.Libro>();
                    var results = (from lib in context.Libros
                                   join edi in context.Editorials on lib.IdEditorial equals edi.IdEditorial
                                   join cit in context.Cities on edi.IdCity equals cit.IdCity
                                   select new
                                   {
                                       IdLibro = lib.IdLibro,
                                       Titulo = lib.Titulo,
                                       Autor = lib.Autor,
                                       Isbn = lib.Isbn,
                                       AnioPublicacion = lib.AnioPublicacion,
                                       IdEditorial = edi.IdEditorial,
                                       NombreEditorial = edi.Nombre,
                                       Ciudad = cit.Nombre
                                   }
                                   ).ToList();

                    if (results != null && results.Count > 0)
                    {
                        foreach (var item in results)
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
                                },
                                Ciudad = new ML.Ciudad
                                {
                                    NombreCiudad = item.Ciudad
                                }
                            };
                            libros.Add(libro);
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

        public static (bool Success, string Message, ML.Libro Libro) GetById(int idLibro)
        {
            try
            {
                using (DL.AppDbContext context = new DL.AppDbContext())
                {
                    var query = (from lib in context.Libros
                                 join edi in context.Editorials on lib.IdEditorial equals edi.IdEditorial
                                 where lib.IdLibro == idLibro
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
                                 ).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Libro libro = new ML.Libro
                        {
                            IdLibro = query.IdLibro,
                            Titulo = query.Titulo,
                            Autor = query.Autor,
                            Isbn = query.Isbn,
                            AnioPublicacion = query.AnioPublicacion,
                            Editorial = new ML.Editorial
                            {
                                IdEditorial = query.IdEditorial,
                                Nombre = query.NombreEditorial
                            }
                        };
                        return (true, null, libro);
                    }
                    else
                    {
                        ML.Libro libro = new ML.Libro();
                        return (true, "No se encontro el registro", libro);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrio un error al procesar la solicitud: " + ex.Message, null);
            }
        }



        public static (bool Success, string Message) Add(ML.Libro libro)
        {
            try
            {
                using (DL.AppDbContext context = new DL.AppDbContext())
                {
                    DL.Libro copyLibro = new DL.Libro
                    {
                        Titulo = libro.Titulo,
                        Autor = libro.Autor,
                        Isbn = libro.Isbn,
                        AnioPublicacion = libro.AnioPublicacion,
                        IdEditorial = libro.Editorial.IdEditorial
                    };

                    context.Libros.Add(copyLibro);

                    int rowAffected = context.SaveChanges();

                    if (rowAffected > 0)
                    {
                        return (true, null);
                    }
                    else
                    {
                        return (false, "No se logro realizar el registro");
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrio un error al realizar la operación: " + ex.Message);
            }
        }
        public static (bool Success, string Message) Update(ML.Libro libro)
        {
            try
            {
                using (DL.AppDbContext context = new DL.AppDbContext())
                {
                    var query = (from libr in context.Libros
                                 where libr.IdLibro == libro.IdLibro
                                 select libr).FirstOrDefault();

                    if(query != null)
                    {
                        query.Titulo = libro.Titulo;
                        query.IdLibro = libro.IdLibro;
                        query.Titulo = libro.Titulo;
                        query.Autor = libro.Autor;
                        query.Isbn = libro.Isbn;
                        query.AnioPublicacion = libro.AnioPublicacion;
                        query.IdEditorial = libro.Editorial.IdEditorial;

                        context.Libros.Update(query);

                        int rowAffected = context.SaveChanges();

                        if (rowAffected > 0)
                        {
                            return (true, null);
                        }
                        else
                        {
                            return (false, "No se logro realizar el cambio");
                        }
                    }
                    else
                    {
                        return (false, "No se logro realizar el cambio");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrio un error al realizar la operación: " + ex.Message);
            }
        }

        public static (bool Success, string Message) Delete(int idLibro)
        {
            try
            {
                using (DL.AppDbContext context = new DL.AppDbContext())
                {

                    context.Libros.Remove(new DL.Libro { IdLibro = idLibro });

                    int rowAffected = context.SaveChanges();

                    if (rowAffected > 0)
                    {
                        return (true, null);
                    }
                    else
                    {
                        return (false, "No se logro eliminar el registro");
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Ocurrio un error al realizar la operación: " + ex.Message);
            }
        }
    }
}
