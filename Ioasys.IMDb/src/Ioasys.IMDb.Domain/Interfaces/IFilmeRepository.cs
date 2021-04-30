using Ioasys.IMDb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ioasys.IMDb.Domain.Interfaces
{
    public interface IFilmeRepository : IRepository<Filme>
    {
        Task<Filme> ObterFilmePor(Guid id);
        Task<List<Filme>> ObterTodosFilmes();      
    }
}
