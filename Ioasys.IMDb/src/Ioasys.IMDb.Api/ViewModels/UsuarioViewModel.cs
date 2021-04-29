using System;
using System.ComponentModel.DataAnnotations;

namespace Ioasys.IMDb.Api.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter de {2} a {1} caracteres!", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter de {2} a {1} caracteres!", MinimumLength = 2)]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter de {2} a {1} caracteres!", MinimumLength = 6)]
        public string Senha { get; set; }      
    }
}
