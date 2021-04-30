using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ioasys.IMDb.Domain.Models;

namespace Ioasys.IMDb.Data.Context.Mappings
{
    public class VotoMappings : IEntityTypeConfiguration<Voto>
    {
        public void Configure(EntityTypeBuilder<Voto> builder)
        {
            builder.HasKey(v => v.Id);

            // 1:1 => Voto : Usuario 
            builder.HasOne(v => v.Usuario)
                .WithOne(u => u.Voto)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Votos");
        }
    }
}
