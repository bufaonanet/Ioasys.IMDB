namespace Ioasys.IMDb.Domain.Models
{
    public class Administrador : Pessoa
    {
        public Administrador()
        {
            NivelAcesso = TiposAcesso.admin;
        }
    }
}
