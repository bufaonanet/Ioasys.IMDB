using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ioasys.IMDb.Domain.Models;

namespace Ioasys.IMDb.Data.Context.Mappings
{
    public class FilmeMappings : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                 .IsRequired()
                 .HasColumnType("varchar(200)");

            builder.Property(f => f.Genero)
                 .IsRequired()
                 .HasColumnType("varchar(200)");

            builder.Property(f => f.Direto)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1:N => Filme : Votos
            builder.HasMany(f => f.Votos)
                .WithOne(v => v.Filme)
                .HasForeignKey(v => v.FilmeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Filmes");
        }
    }
}
