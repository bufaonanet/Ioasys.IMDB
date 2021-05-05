using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ioasys.IMDb.Domain.Models;

namespace Ioasys.IMDb.Data.Context.Mappings
{
    public class AdministradorMappings : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {
            builder.ToTable("Administradores");

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
            builder.HasData(new Administrador
            {
                Nome = "Administrador de teste",
                Login = "admin",
                Senha = "123456"
            }
            );
        }
    }
}
