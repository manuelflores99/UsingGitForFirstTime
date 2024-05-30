namespace PL.Models.DTO
{
    public class Libro
    {
        public int IdLibro { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Isbn { get; set; }

        public DateTime AnioPublicacion { get; set; }

        public Editorial Editorial { get; set; }
        public Ciudad Ciudad { get; set; }
        public List<Models.DTO.Libro> Libros { get; set; }
    }
}
