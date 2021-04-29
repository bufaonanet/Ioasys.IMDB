namespace Ioasys.IMDb.Domain.Models
{
    public class Usuario : Pessoa
    {
        public Usuario()
        {
            Ativo = true;
            NivelAcesso = TiposAcesso.user;
        }
    }
}
