using System;
using System.Collections.Generic;

namespace ProyectoAnimales.Models;

public partial class Propietario
{
    public int PropietarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Ciudad { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Animale> Animales { get; set; } = new List<Animale>();
}
