using System.Threading.Tasks;
using Ioasys.IMDb.Domain.Interfaces;
using Ioasys.IMDb.Domain.Models;

namespace Ioasys.IMDb.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IMDbContext db) : base(db) { }

        public async Task DesativarUsuario(Usuario usuario)
        {
            usuario.Ativo = false;

            _db.Usuarios.Update(usuario);
            await SaveChanges();
        }
    }
}
