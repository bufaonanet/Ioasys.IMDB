using Ioasys.IMDb.Domain.Interfaces;
using Ioasys.IMDb.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Ioasys.IMDb.Domain.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        public UsuarioService(INotificador notificador) : base(notificador)
        {
        }

        public Task Adicionar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
