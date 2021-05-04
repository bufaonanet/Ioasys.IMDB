using AutoMapper;
using Ioasys.IMDb.Api.Services;
using Ioasys.IMDb.Api.ViewModels;
using Ioasys.IMDb.Domain.Interfaces;
using Ioasys.IMDb.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ioasys.IMDb.Api.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/usuarios")]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public UsuarioController(
            IUsuarioRepository repository,
            IMapper mapper, 
            TokenService tokenService,
            INotificador notificador) : base(notificador)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> Login(LoginUserViewModel loginViewModel)
        {
            var administrador = await _repository
                .ObterUsuarioLogin(loginViewModel.Login, loginViewModel.Senha);

            if (administrador == null)
                return NotFound(new { message = "Login ou senha inválida" });

            var tokenGerado = _tokenService.GerarToken(administrador);

            loginViewModel.Senha = string.Empty;

            return new
            {
                user = loginViewModel,
                token = tokenGerado
            };
        }


        [HttpGet]
        public async Task<IEnumerable<UsuarioViewModel>> ObterTodos()
        {
            var usuarios = await ObterTodosUsuarios();
            return usuarios;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> ObterPorId(Guid id)
        {
            var usuario = await ObterUsuarioPorId(id);

            if (usuario == null) return NotFound();

            return CustomResponse(usuario);
        }

        [HttpPost()]
        public async Task<ActionResult<UsuarioViewModel>> Adicionar(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _repository.Adicionar(_mapper.Map<Usuario>(usuarioViewModel));

            return CustomResponse(usuarioViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> Atualizar(Guid id, UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _repository.Atualizar(_mapper.Map<Usuario>(usuarioViewModel));

            return CustomResponse(usuarioViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> Excluir(Guid id)
        {
            var usuarioViewModel = await ObterUsuarioPorId(id);

            if (usuarioViewModel == null) return NotFound();

            await _repository.Remover(id);

            return CustomResponse(usuarioViewModel);
        }

        private async Task<IEnumerable<UsuarioViewModel>> ObterTodosUsuarios()
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(await _repository.ObterTodosUsuariosAtivos());
        }

        private async Task<UsuarioViewModel> ObterUsuarioPorId(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await _repository.ObterUsuarioPor(id));
        }


    }
}
