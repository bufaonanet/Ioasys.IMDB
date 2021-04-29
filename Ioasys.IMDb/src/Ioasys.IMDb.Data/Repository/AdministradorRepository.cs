using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ioasys.IMDb.Domain.Interfaces;
using Ioasys.IMDb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ioasys.IMDb.Data.Repository
{
    public class AdministradorRepository : Repository<Administrador>, IAdministradorRepository
    {
        public AdministradorRepository(IMDbContext db) : base(db) { }

        public async Task DesativarAdministrador(Administrador administrador)
        {
            administrador.Ativo = false;

            _db.Administradores.Update(administrador);
            await SaveChanges();
        }

        public async Task<Administrador> ObterAdministradorPor(Guid id)
        {
            return await _db.Administradores
                .AsNoTracking()                
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Administrador>> ObterTodosAdministradores(Guid id)
        {
            return await _db.Administradores
                .AsNoTracking()
                .OrderBy(a => a.Nome)
                .ToListAsync();
        }
    }
}
