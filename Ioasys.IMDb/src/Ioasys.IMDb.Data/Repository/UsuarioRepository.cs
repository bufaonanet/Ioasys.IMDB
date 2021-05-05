using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ioasys.IMDb.Domain.Interfaces;
using Ioasys.IMDb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ioasys.IMDb.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IMDbContext db) : base(db) { }

        public async Task Alterarstatus(Usuario usuario, bool ativo)
        {
            usuario.Ativo = ativo;

            _db.Usuarios.Update(usuario);
            await SaveChanges();
        }

        public async Task<Usuario> ObterUsuarioPor(Guid id)
        {
            return await _db.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Usuario>> ObterTodosUsuariosAtivos()
        {
            return await _db.Usuarios
                .AsNoTracking()
                .Where(u => u.Ativo == true)
                .OrderBy(u => u.Nome)
                .ToListAsync();
        }

        public async Task<List<Usuario>> ObterTodosUsuariosPorStatus(bool status)
        {
            return await _db.Usuarios
                .AsNoTracking()
                .Where(u => u.Ativo == status)
                .OrderBy(u => u.Nome)
                .ToListAsync();
        }

        public async Task<Usuario> ObterUsuarioLogin(string login, string senha)
        {
            return await _db.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Login == login && a.Senha == senha);
        }

        
    }
}
