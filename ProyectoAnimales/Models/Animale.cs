using System;
using System.Collections.Generic;

namespace ProyectoAnimales.Models;

public partial class Animale
{
    public int AnimalId { get; set; }

    public string? Nombre { get; set; }

    public string? Especie { get; set; }

    public int? Edad { get; set; }

    public int? PropietarioId { get; set; }

    public virtual Propietario? Propietario { get; set; }
}
