using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RunGroopWebApp.Models;

public partial class PuntoDeVentaContext : DbContext
{
    public PuntoDeVentaContext()
    {
    }

    public PuntoDeVentaContext(DbContextOptions<PuntoDeVentaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACER5750\\SQLEXPRESS;Database=PuntoDeVenta;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__cliente__885457EE93932AF4");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.ApellidoCliente)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DireccionCliente)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacCliente).HasColumnType("date");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__detalleV__BFE2843FE0140626");

            entity.ToTable("detalleVenta");

            entity.Property(e => e.IdDetalleVenta).HasColumnName("idDetalleVenta");
            entity.Property(e => e.CantidadProducto)
                .HasDefaultValueSql("((0))")
                .HasColumnName("cantidadProducto");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("precioVenta");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalleVe__idPro__656C112C");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalleVe__idVen__6477ECF3");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__empleado__5295297CACD0180E");

            entity.ToTable("empleado");

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.ApellidoEmpleado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DireccionEmpleado)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacEmpleado).HasColumnType("date");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__07F4A132377D3AC4");

            entity.ToTable("producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("nombreProducto");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__venta__077D561445B4B597");

            entity.ToTable("venta");

            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.FechaVenta)
                .HasColumnType("date")
                .HasColumnName("fechaVenta");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__venta__idCliente__3D5E1FD2");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__venta__idEmplead__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
