using AutoMapper;
using Ioasys.IMDb.Api.Services;
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
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public AdministradorController(
            IAdministradorRepository repository,
            IMapper mapper, TokenService tokenService,
            IUsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenService = tokenService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("login")]
        public IActionResult Login(UsuarioViewModel usuarioViewModel)
        {
            var administrador = _mapper.Map<Administrador>(usuarioViewModel);

            if (administrador == null) return NotFound();

            var token = _tokenService.GerarToken(administrador);

            usuarioViewModel.Token = token;

            return CustomResponse(usuarioViewModel);

        }

        [HttpPut("desativar-usuario/{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> DesativarUsuario(Guid id)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPor(id);

            if (usuario == null) return NotFound();

            await _usuarioRepository.AlterarEstadoAtivo(usuario, false);

            return CustomResponse(_mapper.Map<UsuarioViewModel>(usuario));
        }

        [HttpPut("ativar-usuario/{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> AtivarUsuario(Guid id)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPor(id);

            if (usuario == null) return NotFound();

            await _usuarioRepository.AlterarEstadoAtivo(usuario, true);

            return CustomResponse(_mapper.Map<UsuarioViewModel>(usuario));
        }

        [HttpGet("usuarios")]
        public async Task<IEnumerable<UsuarioViewModel>> ObterTodosUsuarios()
        {
            var usuarios = _mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObterTodos());
            return usuarios;
        }

        [HttpGet("usuarios-ativos")]
        public async Task<IEnumerable<UsuarioViewModel>> ObterTodosUsuariosAtivos()
        {
            var usuarios = _mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObterTodosUsuariosAtivos());
            return usuarios;
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

            return CustomResponse(administradores);
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
