using System;
using System.Collections.Generic;

namespace RunGroopWebApp.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string ApellidoCliente { get; set; } = null!;

    public string? DireccionCliente { get; set; }

    public DateTime? FechaNacCliente { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
