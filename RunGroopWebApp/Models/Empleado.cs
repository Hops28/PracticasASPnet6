using System;
using System.Collections.Generic;

namespace RunGroopWebApp.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public string ApellidoEmpleado { get; set; } = null!;

    public string? DireccionEmpleado { get; set; }

    public DateTime? FechaNacEmpleado { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
