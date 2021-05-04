using AutoMapper;
using Ioasys.IMDb.Api.Services;
using Ioasys.IMDb.Api.ViewModels;
using Ioasys.IMDb.Domain.Interfaces;
using Ioasys.IMDb.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ioasys.IMDb.Api.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/administradores")]
    public class AdministradorController : MainController
    {
        private readonly IAdministradorRepository _repository;
        private readonly IAdministradorService _service;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public AdministradorController(
            IAdministradorRepository repository,
            IMapper mapper,
            IUsuarioRepository usuarioRepository,
            TokenService tokenService,
            IAdministradorService service,
            INotificador notificador) : base(notificador)
        {
            _repository = repository;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet("teste")]
        public ActionResult Teste([FromQuery] string nome)
        {
            return Ok($"O na QueryString = {nome}");
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> Login(LoginUserViewModel loginViewModel)
        {
            var administrador = await _repository
                .ObterAdministradorLogin(loginViewModel.Login, loginViewModel.Senha);

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

        [HttpPut("usuario/ativar-desativar/{id:guid}")]        
        public async Task<ActionResult<UsuarioViewModel>> DesativarUsuario(Guid id, [FromQuery] bool ativar )
        {
            var usuario = await _usuarioRepository.ObterUsuarioPor(id);

            if (usuario == null) return NotFound();

            await _usuarioRepository.AlterarEstadoAtivo(usuario, ativar);

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
        [ProducesResponseType(typeof(UsuarioViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioViewModel>> Adicionar(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Adicionar(_mapper.Map<Administrador>(usuarioViewModel));

            return CustomResponse(usuarioViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> Atualizar(Guid id, UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Atualizar(_mapper.Map<Administrador>(usuarioViewModel));

            return CustomResponse(usuarioViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> Excluir(Guid id)
        {
            var usuarioViewModel = await ObterAdministradorPorId(id);

            if (usuarioViewModel == null) return NotFound();

            await _service.Remover(id);

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
