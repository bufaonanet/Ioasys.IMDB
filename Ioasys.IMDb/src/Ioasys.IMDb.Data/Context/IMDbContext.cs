using Microsoft.EntityFrameworkCore;
using Ioasys.IMDb.Domain.Models;

namespace Ioasys.IMDb.Data
{
    public class IMDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Voto> Votos { get; set; }
        
        public IMDbContext(DbContextOptions<IMDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Lendo as configurações de mapeamento 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IMDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }       
    }
}
