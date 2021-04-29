using Microsoft.EntityFrameworkCore;
using Ioasys.IMDb.Domain.Models;
using System.Threading.Tasks;
using System.Threading;

namespace Ioasys.IMDb.Data
{
    public class IMDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        
        public IMDbContext(DbContextOptions<IMDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Lendo as configurações de mapeamento 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IMDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }       
    }
}
