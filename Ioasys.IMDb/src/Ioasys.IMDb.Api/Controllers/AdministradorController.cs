using AutoMapper;
using Ioasys.IMDb.Api.ViewModels;
using Ioasys.IMDb.Domain.Interfaces;
using Ioasys.IMDb.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ioasys.IMDb.Api.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/administradores")]  
    public class AdministradorController : MainController
    {
        private readonly IAdministradorRepository _repository;
        private readonly IMapper _mapper;

        public AdministradorController(
            IAdministradorRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioViewModel>> ObterTodos()
        {
            var administradores = await ObterTodosAdministradores();
            return administradores;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> ObterPorId(Guid id)
        {
            var administradores = await ObterAdministradorPorId(id);

            if (administradores == null) return NotFound();

            return administradores;
        }

        [HttpPost()]
        public async Task<ActionResult<UsuarioViewModel>> Adicionar(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);         

            await _repository.Adicionar(_mapper.Map<Administrador>(usuarioViewModel));

            return CustomResponse(usuarioViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> Atualizar(Guid id, UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _repository.Atualizar(_mapper.Map<Administrador>(usuarioViewModel));

            return CustomResponse(usuarioViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> Excluir(Guid id)
        {
            var usuarioViewModel = await ObterAdministradorPorId(id);

            if (usuarioViewModel == null) return NotFound();

            await _repository.Remover(id);

            return CustomResponse(usuarioViewModel);
        }



        private async Task<IEnumerable<UsuarioViewModel>> ObterTodosAdministradores()
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(await _repository.ObterTodos());
        }

        private async Task<UsuarioViewModel> ObterAdministradorPorId(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await _repository.ObterAdministradorPor(id));
        }
    }
}
