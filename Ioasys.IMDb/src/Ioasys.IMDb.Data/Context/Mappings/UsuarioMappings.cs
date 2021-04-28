using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ioasys.IMDb.Domain.Models;

namespace Ioasys.IMDb.Data.Context.Mappings
{
    public class UsuarioMappings : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
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

            builder.ToTable("Usuarios");
        }
    }
}
