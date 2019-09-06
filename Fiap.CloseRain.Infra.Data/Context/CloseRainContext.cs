using Fiap.CloseRain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.CloseRain.Infra.Data.Context
{
    public class CloseRainContext : DbContext
    {
        public CloseRainContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Contato>().HasKey(e => e.IdContato);
            modelBuilder.Entity<Incidente>().HasKey(e => e.IdIncidente);
            modelBuilder.Entity<Regiao>().HasKey(e => e.IdRegiao);
            modelBuilder.Entity<Usuario>().HasKey(e => e.IdUsuario);

        }

        public DbSet<Incidente> Incidente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Regiao> Regiao { get; set; }
    }
}
