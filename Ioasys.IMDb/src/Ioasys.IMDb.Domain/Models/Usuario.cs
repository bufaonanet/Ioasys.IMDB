using System.Collections.Generic;

namespace Ioasys.IMDb.Domain.Models
{
    public class Usuario : Pessoa
    {
        public List<Voto> Votos { get; set; }
        public Usuario()
        {
            Ativo = true;
            NivelAcesso = TiposAcesso.user;
        }
    }
}
