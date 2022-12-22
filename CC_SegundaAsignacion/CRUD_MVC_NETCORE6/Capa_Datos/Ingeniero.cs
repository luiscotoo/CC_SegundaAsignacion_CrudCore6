using System;
using System.Collections.Generic;

namespace Capa_Datos;

public partial class Ingeniero
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Edad { get; set; }

    public DateTime? FechaNac { get; set; }

    public decimal? Altura { get; set; }
}
