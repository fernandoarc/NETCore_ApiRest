using Microsoft.EntityFrameworkCore;
using NetCore_API.Model.Entidades.Bike;

namespace NetCore_API.Model.BD
{
    public class BicicletaContext : DbContext
    {
        public BicicletaContext(DbContextOptions<BicicletaContext> opciones) : base(opciones) { }

        public DbSet<BicicletaCategoria> BicicletaCategoria { get; set; }

        public DbSet<BicicletaMarca> BicicletaMarca { get; set; }

        public DbSet<BicicletaModelo> BicicletaModelo { get; set; }

        public DbSet<Bicicleta> Bicicleta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BicicletaCategoria>(categoria => {
                categoria.ToTable("BicicletaCategoria");
                categoria.HasKey(x => x.IdBicicletaCategoria);
                categoria.Property(x => x.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                categoria.Property(x => x.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<BicicletaMarca>(marca => {
                marca.ToTable("BicicletaMarca");
                marca.HasKey(x => x.IdBicicletaMarca);
                marca.Property(x => x.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<BicicletaModelo>(modelo => {
                modelo.ToTable("BicicletaModelo");
                modelo.HasKey(x => x.IdBicicletaModelo);
                modelo.Property(x => x.Anio)
                    .IsRequired()
                    .IsUnicode(false);
                modelo.Property(x => x.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<BicicletaModelo>()
                .HasOne(x => x.BicicletaCategoria)
                .WithMany(x => x.BicicletaModelo)
                .HasForeignKey(x => x.IdBicicletaCategoria);
            modelBuilder.Entity<BicicletaModelo>()
                .HasOne(x => x.BicicletaMarca)
                .WithMany(x => x.BicicletaModelo)
                .HasForeignKey(x => x.IdBicicletaMarca);
            modelBuilder.Entity<Bicicleta>(bicicleta => {
                bicicleta.ToTable("Bicicleta");
                bicicleta.HasKey(x => x.IdBicicleta);
                bicicleta.Property(x => x.Serial)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
                bicicleta.Property(x => x.Vigente)
                    .IsRequired()
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Bicicleta>()
                .HasOne(x => x.BicicletaModelo)
                .WithMany(x => x.Bicicleta)
                .HasForeignKey(x => x.IdBicicletaModelo);
        }
    }
}