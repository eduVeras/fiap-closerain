using System;
using System.Collections.Generic;
using System.Text;
using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Base;

namespace Fiap.CloseRain.Application.Applications
{
    public class UsuarioApplication : BaseApplication<Usuario, int>, IUsuarioApplication
    {
        public UsuarioApplication(IBaseRepository<Usuario, int> baseRepository) : base(baseRepository)
        {
        }

        public bool Autenticar(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
