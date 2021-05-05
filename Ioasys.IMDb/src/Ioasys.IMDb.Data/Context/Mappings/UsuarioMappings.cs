using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ioasys.IMDb.Domain.Models;

namespace Ioasys.IMDb.Data.Context.Mappings
{
    public class UsuarioMappings : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(a => a.Id);

            builder.Property(d => d.Nome)
                 .IsRequired()
                 .HasColumnType("varchar(200)");

            builder.Property(d => d.Login)
                 .IsRequired()
                 .HasColumnType("varchar(200)");

            builder.Property(d => d.Senha)
                .IsRequired()
                .HasColumnType("varchar(100)");

            //alimentando com  dados iniciais
            builder.HasData(new Usuario
            {
                Nome = "Usuário de teste",
                Login = "user",
                Senha = "123456"
            }
            );
        }        
    }
}
