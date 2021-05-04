using Ioasys.IMDb.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Ioasys.IMDb.Domain.Interfaces
{
    public interface IAdministradorService : IDisposable
    {
        Task Adicionar(Administrador administrador);
        Task Atualizar(Administrador administrador);
        Task Remover(Guid id);
    }

    public interface IUsuarioService : IDisposable
    {
        Task Adicionar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Remover(Guid id);
    }

    public interface IFilmeService : IDisposable
    {
        Task Adicionar(Filme filme);
        Task Atualizar(Filme filme);
        Task Remover(Guid id);
    }
}
