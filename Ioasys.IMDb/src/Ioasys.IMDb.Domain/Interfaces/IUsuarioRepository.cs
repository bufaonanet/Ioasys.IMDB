using Ioasys.IMDb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ioasys.IMDb.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterUsuarioPor(Guid id);
        Task<List<Usuario>> ObterTodosUsuariosAtivos();
        Task DesativarUsuario(Usuario usuario);
    }
}
