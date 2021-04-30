using System;

namespace Ioasys.IMDb.Domain.Models
{
    public class Voto : Entity
    {
        public Nota Nota { get; set; }

        public Guid FilmeId { get; set; }
        public Filme Filme { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }

    public enum Nota
    {
        pessimo = 0,
        ruim = 1,
        bom = 2,
        otimo = 3,
        mereceOscar
    }




}
