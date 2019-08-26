using Fiap.CloseRain.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fiap.CloseRain.Infra.Data.Context
{
    public class CloseRainContext : DbContext
    {
        public CloseRainContext(DbContextOptions<CloseRainContext> dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }


        public DbSet<Incidente> Incidente { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Regiao> Regiao { get; set; }
    }
}
