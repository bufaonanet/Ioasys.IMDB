using Ioasys.IMDb.Domain.Models.Validations;

namespace Ioasys.IMDb.Domain.Models
{
    public class Administrador : Pessoa
    {
        public Administrador()
        {
            Ativo = true;
            NivelAcesso = TiposAcesso.admin;
        }

        public bool EhValido()
        {
            ValidationResult = new AdministradorValidation().Validate(this);
            return ValidationResult.IsValid;
        }


    }
}
