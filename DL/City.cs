using System;
using System.Collections.Generic;

namespace DL;

public partial class City
{
    public int IdCity { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<Editorial> Editorials { get; set; } = new List<Editorial>();
}
