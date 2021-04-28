namespace Ioasys.IMDb.Domain.Models
{
    public abstract class Pessoa : Entity
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public TiposAcesso NivelAcesso { get; set; }
    }
}
