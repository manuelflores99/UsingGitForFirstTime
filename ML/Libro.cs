using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    {
        public int IdLibro { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Isbn { get; set; }

        public DateTime AnioPublicacion { get; set; }

        public Editorial Editorial { get; set; }
    }
}
