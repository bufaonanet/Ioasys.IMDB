using System;
using System.ComponentModel.DataAnnotations;

namespace Ioasys.IMDb.Api.ViewModels
{
    public class VotoViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Range( 0, 4, ErrorMessage = "O campo {0} precisa precisa ser ter o valor de {1} a {2}")]     
        public int Nota { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public Guid FilmeId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public Guid UsuarioId { get; set; }
    }
}
