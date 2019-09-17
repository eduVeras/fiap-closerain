using System.Linq;
using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Repository;
using Fiap.CloseRain.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.CloseRain.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(CloseRainContext context) : base(context)
        {
        }

        public async Task<bool> Autenticar(Usuario usuario)
        {
            var userExists = await DbSet.Where(w => w.Email == usuario.Email && w.Senha == usuario.Senha).ToListAsync();

            return userExists.Any();
        }

        
    }
}
