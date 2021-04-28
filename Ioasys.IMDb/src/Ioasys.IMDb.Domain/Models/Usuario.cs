namespace Ioasys.IMDb.Domain.Models
{
    public class Usuario : Pessoa
    {
        public Usuario()
        {
            NivelAcesso = TiposAcesso.user;
        }
    }
}
