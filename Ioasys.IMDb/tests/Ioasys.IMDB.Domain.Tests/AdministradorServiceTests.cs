using Ioasys.IMDb.Domain.Interfaces;
using Ioasys.IMDb.Domain.Services;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ioasys.IMDB.Domain.Tests
{
    [Collection(nameof(AdministradorCollection))]
    public class AdministradorServiceTests
    {
        readonly AdministradorFixture _administradorFixture;

        public AdministradorServiceTests(AdministradorFixture administradorFixture)
        {
            _administradorFixture = administradorFixture;
        }

        [Fact(DisplayName = "Adicioanr Administrador Válido")]
        [Trait("Categoria", "Administrador Service")]
        public async Task Adicionar_AdministradorValido_DeveAdicionarComSucesso()
        {
            // Arrange
            var administrador = _administradorFixture.GerarAdministradorValido();

            var mocker = new AutoMocker();
            var AdministradorService = mocker.CreateInstance<AdministradorService>();

            // Act
            await AdministradorService.Adicionar(administrador);

            // Assert
            Assert.True(administrador.EhValido());
            mocker.GetMock<IAdministradorRepository>().Verify(r => r.Adicionar(administrador), Times.Once);
        }

        [Fact(DisplayName = "Adicioanr Administrador Inválido")]
        [Trait("Categoria", "Administrador Service")]
        public async Task Adicionar_AdministradorInvalido_NaoDeveAdicionar()
        {
            // Arrange
            var administrador = _administradorFixture.GerarAdministradorInvalido();

            var mocker = new AutoMocker();
            var AdministradorService = mocker.CreateInstance<AdministradorService>();

            // Act
            await AdministradorService.Adicionar(administrador);

            // Assert
            Assert.False(administrador.EhValido());
            Assert.NotEmpty(administrador.ValidationResult.Errors);
            mocker.GetMock<IAdministradorRepository>().Verify(r => r.Adicionar(administrador), Times.Never);
        }


    }
}
