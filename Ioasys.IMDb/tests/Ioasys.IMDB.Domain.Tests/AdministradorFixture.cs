using Bogus;
using Bogus.DataSets;
using Ioasys.IMDb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ioasys.IMDB.Domain.Tests
{
    [CollectionDefinition(nameof(AdministradorCollection))]
    public class AdministradorCollection : ICollectionFixture<AdministradorFixture>
    {
    }

    public class AdministradorFixture
    {
        public Administrador GerarAdministradorValido()
        {
            return GerarAdministradoresValidos(1, true).FirstOrDefault();
        }

        public Administrador GerarAdministradorInvalido()
        {
            return new Administrador
            {
                Id = Guid.Empty,
                Nome = "",
                Login = "",
                Senha = ""
            };
        }

        public IEnumerable<Administrador> GerarAdministradoresValidos()
        {
            var administradores = new List<Administrador>();

            administradores.AddRange(GerarAdministradoresValidos(5, true).ToList());

            return administradores;
        }

        public IEnumerable<Administrador> GerarAdministradoresValidos(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();        

            var administradores = new Faker<Administrador>("pt_BR")
                .CustomInstantiator(a => new Administrador
                {
                    Nome = a.Name.FirstName(genero),
                    Ativo = ativo,
                    Login = $"@{a.Name.FirstName(genero)}",
                    Senha = "123456"
                });

            return administradores.Generate(quantidade);
        }


    }
}
