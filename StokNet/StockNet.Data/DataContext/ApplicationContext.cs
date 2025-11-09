using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockNet.Domain.Entities;

namespace StockNet.Data.DataContext
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Negocio> Negocios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CategoriaProducto> CategoriasProductos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetallesCompra { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }
        public DbSet<CostoFijo> CostosFijos { get; set; }
        public DbSet<MateriaPrima> materiaPrimas { get; set; }
        public DbSet<CategoriaMateriaPrima> CategoriasMateriaPrima { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.Negocio)
                .WithOne(n => n.ApplicationUser)
                .HasForeignKey<Negocio>(n => n.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Negocio)
                .WithMany(n => n.Clientes)
                .HasForeignKey(c => c.NegocioId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
