namespace PL.Models.DTO
{
    public class Editorial
    {
        public int IdEditorial { get; set; }

        public string Nombre { get; set; }

        public List<Models.DTO.Editorial> Editoriales { get; set; }

        public Models.DTO.Ciudad Ciudad { get; set; }
    }
}
