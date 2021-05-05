using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
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

        public async Task<PagedResult<Filme>> ObterTodosFilmes(int pageSize, int pageIndex, string query)
        {
            var sql = @$"SELECT * FROM [filmes]
                         WHERE (@Nome is null OR [nome] LIKE '%' + @Nome + '%')
                         ORDER BY [nome]
                         OFFSET {pageSize * (pageIndex - 1)} ROWS 
                         FETCH NEXT {pageSize} ROWS ONLY
                         SELECT COUNT([id]) FROM [filmes]
                         WHERE(@Nome is null OR [nome] LIKE '%' + @Nome + '%')";

            var multi = await _db.Database
                .GetDbConnection()
                .QueryMultipleAsync(sql, new { Nome = query });

            var filmes = multi.Read<Filme>();
            var total = multi.Read<int>().FirstOrDefault();

            return new PagedResult<Filme>
            {
                List = filmes,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalResults = total,
                Query = query
            };
        }
    }
}
