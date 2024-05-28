using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Editorial
    {
        public int IdEditorial { get; set; }

        public string Nombre { get; set; }

        public List<ML.Editorial> Editoriales { get; set; }

        public ML.Ciudad Ciudad { get; set; }

        

    }
}
