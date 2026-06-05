using System;
using System.Collections.Generic;

namespace VetCareManager.Models;

public partial class Cita
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public string? Descripcion { get; set; }
}
