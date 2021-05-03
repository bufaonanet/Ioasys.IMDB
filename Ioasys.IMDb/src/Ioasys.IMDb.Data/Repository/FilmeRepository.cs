using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ioasys.IMDb.Domain.Interfaces;
using Ioasys.IMDb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ioasys.IMDb.Data.Repository
{
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        public FilmeRepository(IMDbContext db) : base(db) { }

        public async Task<Filme> ObterFilmePor(Guid id)
        {
            return await _db.Filmes
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<Filme>> ObterTodosFilmes()
        {
            return await _db.Filmes
                .AsNoTracking()  
                .Include(f => f.Votos)
                .OrderBy(f => f.Nome)
                .ToListAsync();
        }
    }
}
