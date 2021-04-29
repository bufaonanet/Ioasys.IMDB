using Ioasys.IMDb.Domain.Models;
using System.Threading.Tasks;

namespace Ioasys.IMDb.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task DesativarUsuario(Usuario usuario);
    }
}
