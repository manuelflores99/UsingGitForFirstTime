using System;
using System.Collections.Generic;

namespace DL;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string Titulo { get; set; }

    public string Autor { get; set; }

    public string Isbn { get; set; }

    public DateTime AnioPublicacion { get; set; }

    public int? IdEditorial { get; set; }

    public virtual Editorial IdEditorialNavigation { get; set; }
}
