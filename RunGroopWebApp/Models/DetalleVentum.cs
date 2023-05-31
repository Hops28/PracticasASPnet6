using System;
using System.Collections.Generic;

namespace RunGroopWebApp.Models;

public partial class DetalleVentum
{
    public int IdDetalleVenta { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int? CantidadProducto { get; set; }

    public decimal PrecioVenta { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Ventum IdVentaNavigation { get; set; } = null!;
}
