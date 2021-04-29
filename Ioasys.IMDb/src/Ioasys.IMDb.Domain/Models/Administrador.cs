namespace Ioasys.IMDb.Domain.Models
{
    public class Administrador : Pessoa
    {
        public Administrador()
        {
            Ativo = true;
            NivelAcesso = TiposAcesso.admin;
        }
    }
}
