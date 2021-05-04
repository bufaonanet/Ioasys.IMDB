using Ioasys.IMDb.Domain.Interfaces;
using Ioasys.IMDb.Domain.Models;
using Ioasys.IMDb.Domain.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ioasys.IMDb.Domain.Services
{
    public class AdministradorService : BaseService, IAdministradorService
    {
        private readonly IAdministradorRepository _administradorRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public AdministradorService(
            IAdministradorRepository administradorRepository,
            IUsuarioRepository usuarioRepository,
            INotificador notificador) : base(notificador)
        {
            _administradorRepository = administradorRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task Adicionar(Administrador administrador)
        {
            if (!ExecutarValidacao(new AdministradorValidation(), administrador)) return;

            if (_administradorRepository.Buscar(a => a.Login == administrador.Login).Result.Any())
            {
                Notificar("Já existe um Administrador com esse Login");
                return;
            }

            await _administradorRepository.Adicionar(administrador);
        }

        public async Task Atualizar(Administrador administrador)
        {
            if (!ExecutarValidacao(new AdministradorValidation(), administrador)) return;

            if (_administradorRepository.Buscar(a => a.Login == administrador.Login && a.Id != administrador.Id).Result.Any())
            {
                Notificar("Já existe um Administrador com esse Login");
                return;
            }

            await _administradorRepository.Atualizar(administrador);
        }

        public async Task Remover(Guid id)
        {
            await _administradorRepository.Remover(id);
        }
        public void Dispose()
        {
            _administradorRepository?.Dispose();
            _usuarioRepository?.Dispose();
        }
    }
}
