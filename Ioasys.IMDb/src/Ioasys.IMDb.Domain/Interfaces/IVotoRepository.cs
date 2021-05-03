using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ioasys.IMDb.Domain.Models;

namespace Ioasys.IMDb.Domain.Interfaces
{
    public interface IVotoRepository : IRepository<Voto>
    {     
        Task<List<Voto>> ObterVotosDoFilmes(Guid filmeId);
    }
}
