using System;
using System.Collections.Generic;

namespace RunGroopWebApp.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();
}
