﻿using System;
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
    }
}
