using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ioasys.IMDb.Domain.Models;

namespace Ioasys.IMDb.Domain.Interfaces
{
    public interface IAdministradorRepository: IRepository<Administrador>
    {
        Task<Administrador> ObterAdministradorPor(Guid id);
        Task<List<Administrador>> ObterTodosAdministradores(Guid id);
        Task DesativarAdministrador(Administrador administrador);
        Task<Administrador> ObterAdministradorLogin(string login, string senha);
    }
}
