namespace Ioasys.IMDb.Domain.Models
{
    public class Usuario : Pessoa
    {
        public Voto Voto { get; set; }
        public Usuario()
        {
            Ativo = true;
            NivelAcesso = TiposAcesso.user;
        }
    }
}
