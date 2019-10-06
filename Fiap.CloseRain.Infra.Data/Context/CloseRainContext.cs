using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Fiap.CloseRain.Infra.Data.Context
{
    public class CloseRainContext : DbContext
    {
        public CloseRainContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IncidenteMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new RegiaoMapping());
            modelBuilder.ApplyConfiguration(new TweetMapping());
        }

        public DbSet<Incidente> Incidente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Regiao> Regiao { get; set; }
        public DbSet<Tweeteds> Tweets { get; set; }
    }
}
