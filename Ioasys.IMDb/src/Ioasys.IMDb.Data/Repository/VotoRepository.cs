using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ioasys.IMDb.Domain.Interfaces;
using Ioasys.IMDb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ioasys.IMDb.Data.Repository
{
    public class VotoRepository : Repository<Voto>, IVotoRepository
    {
        public VotoRepository(IMDbContext db) : base(db) { }

        public async Task<List<Voto>> ObterVotosDoFilmes(Guid filmeId)
        {
            return await _db.Votos
                .AsNoTracking()
                .Where(v => v.FilmeId == filmeId)
                .ToListAsync();
        }
    }
}
