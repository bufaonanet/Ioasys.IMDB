using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ioasys.IMDb.Domain.Models;
using System.Collections.Generic;

namespace Ioasys.IMDb.Data.Context.Mappings
{
    public class FilmeMappings : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Filmes");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                 .IsRequired()
                 .HasColumnType("varchar(200)");

            builder.Property(f => f.Genero)
                 .IsRequired()
                 .HasColumnType("varchar(200)");

            builder.Property(f => f.Diretor)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1:N => Filme : Votos
            builder.HasMany(f => f.Votos)
                .WithOne(v => v.Filme)
                .HasForeignKey(v => v.FilmeId)
                .OnDelete(DeleteBehavior.Cascade);

            var filmes = FilmesIniciais();
            builder.HasData(filmes);
        }

        private static List<Filme> FilmesIniciais()
        {
            var filmes = new List<Filme> {
                new Filme{ Nome = "O Artista", Genero = "Romance/Drama", Diretor = "Michel Hazanavicius"},
                new Filme{ Nome = "Apocalypse Now", Genero = "Guerra/Drama", Diretor = "Michel Hazanavicius"},
                new Filme{ Nome = "A Rainha", Genero = "Drama/Filme histórico", Diretor = "Stephen Frears"},
                new Filme{ Nome = "127 Horas", Genero = "Drama/Sobrevivência", Diretor = "Danny Boyle"},
                new Filme{ Nome = "Um Homem Sério", Genero = "Comédia/Drama", Diretor = "Ethan Coen, Joel Coen"},
                new Filme{ Nome = "Rain Man", Genero = "Drama/Melodrama", Diretor = "Barry Levinson"},
                new Filme{ Nome = "Gritos e Sussurros", Genero = "Drama/Obra de Época", Diretor = "Ingmar Bergman"},
                new Filme{ Nome = "O Piano", Genero = "Romance/Drama", Diretor = "Michel Hazanavicius"},
                new Filme{ Nome = "O Destino de Uma Nação", Genero = " Guerra/Drama", Diretor = "Joe Wright"},
                new Filme{ Nome = "A Conversação", Genero = "Thriller/Mistério", Diretor = "Francis Ford Coppola"},
                new Filme{ Nome = "Los Angeles - Cidade Proibida", Genero = "Crime/Drama", Diretor = "Ang Lee"},
                new Filme{ Nome = "O Segredo de Brokeback Mountain", Genero = "Romance/Drama", Diretor = "Michel Hazanavicius"}
            };

            return filmes;
        }
    }
}
