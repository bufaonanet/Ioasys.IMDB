using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ioasys.IMDb.Api.ViewModels
{
    public class FilmeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter de {2} a {1} caracteres!", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter de {2} a {1} caracteres!", MinimumLength = 2)]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter de {2} a {1} caracteres!", MinimumLength = 2)]
        public string Direto { get; set; }

        public IEnumerable<VotoViewModel> Votos { get; set; }
    }
}
