using Dominio.Entidades;
using Infraestructura.Repositorios.EntityFramework.config;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorios.EntityFramework
{
    public class StellarMindsContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<ObjetoCeleste> ObjetosCelestes { get; set; }
        public DbSet<AuditoriaPrestamo> AuditoriasPrestamo { get; set; }
        public DbSet<Observacion> Observaciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Initial Catalog=StellarMinds; Integrated Security=True;");


            //db somee
            //optionsBuilder.UseSqlServer(@"Server=obligatorioDB.mssql.somee.com; Database=obligatorioDB; user id=FausEstudiante_SQLLogin_1;pwd=ehccwatown;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

            modelBuilder.ApplyConfiguration(new EquipoConfiguration());
            modelBuilder.ApplyConfiguration(new EquipoCamaraConfiguration());
            modelBuilder.ApplyConfiguration(new EquipoMonturaConfiguration());
            modelBuilder.ApplyConfiguration(new EquipoOcularConfiguration());
            modelBuilder.ApplyConfiguration(new EquipoTelescopioConfiguration());

            modelBuilder.ApplyConfiguration(new PrestamoConfiguration());
            modelBuilder.ApplyConfiguration(new ObjetoCelesteConfiguration());
            modelBuilder.ApplyConfiguration(new AuditoriaPrestamoConfiguration());

            modelBuilder.ApplyConfiguration(new ObservacionConfiguration());
        }
    }
}