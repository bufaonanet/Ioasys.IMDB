using System.Collections.Generic;

namespace Ioasys.IMDb.Domain.Models
{
    public class Filme : Entity
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Diretor { get; set; }

        public IEnumerable<Voto> Votos { get; set; }
    }
}
