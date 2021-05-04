using Ioasys.IMDb.Domain.Interfaces;
using Ioasys.IMDb.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Ioasys.IMDb.Domain.Services
{
    public class FilmeService : BaseService, IFilmeService
    {
        public FilmeService(INotificador notificador) : base(notificador)
        {
        }

        public Task Adicionar(Filme filme)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Filme filme)
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
