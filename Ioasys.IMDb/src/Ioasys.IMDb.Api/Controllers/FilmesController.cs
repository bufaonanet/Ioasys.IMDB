using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ioasys.IMDb.Api.ViewModels;
using Ioasys.IMDb.Domain.Interfaces;
using Ioasys.IMDb.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Ioasys.IMDb.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/filmes")]
    public class FilmesController : MainController
    {
        private readonly IFilmeRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IVotoRepository _votoRepository;
        private readonly IMapper _mapper;

        public FilmesController(
            IFilmeRepository repository,
            IUsuarioRepository usuarioRepository,
            IMapper mapper,
            IVotoRepository votoRepository,
            INotificador notificador) : base(notificador)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _votoRepository = votoRepository;
        }

        [HttpGet()]
        public async Task<PagedResult<Filme>> ObterTodosFilmes(
           [FromQuery] int tamanhoPagina = 6, [FromQuery] int pagina = 1, [FromQuery] string filtroNomeFilme = null)
        {
            return await _repository.ObterTodosFilmes(tamanhoPagina, pagina, filtroNomeFilme);
        }       

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FilmeVisao>> ObterPorId(Guid id)
        {
            var filme = await ObterFilmePorId(id);

            if (filme == null) return NotFound();

            return CustomResponse(filme);
        }

        [Authorize(Roles = "admin")]
        [HttpPost()]
        [ProducesResponseType(typeof(FilmeCadastro), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FilmeCadastro>> Adicionar(FilmeCadastro filmeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _repository.Adicionar(_mapper.Map<Filme>(filmeViewModel));

            return CustomResponse(filmeViewModel);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(FilmeCadastro), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FilmeCadastro>> Atualizar(Guid id, FilmeCadastro filmeViewModel)
        {
            if (id != filmeViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _repository.Atualizar(_mapper.Map<Filme>(filmeViewModel));

            return CustomResponse(filmeViewModel);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(FilmeCadastro), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FilmeCadastro>> Excluir(Guid id)
        {
            var filmeViewModel = await ObterFilmePorId(id);

            if (filmeViewModel == null) return NotFound();

            await _repository.Remover(id);

            return CustomResponse(filmeViewModel);
        }

        [Authorize(Roles = "user")]
        [HttpPost("votar")]
        [ProducesResponseType(typeof(VotoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Votar(VotoViewModel votoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var filme = await ObterFilmePorId(votoViewModel.FilmeId);

            if (filme == null) return NotFound("Filme não cadastrado");

            var usuario = await _usuarioRepository.BuscarPorId(votoViewModel.UsuarioId);

            if (usuario == null) return NotFound("Usuário não cadastrado");

            await _votoRepository.Adicionar(_mapper.Map<Voto>(votoViewModel));

            return CustomResponse(votoViewModel);
        }

        private async Task<FilmeVisao> ObterFilmePorId(Guid id)
        {
            return _mapper.Map<FilmeVisao>(await _repository.ObterFilmePor(id));
        }

    }
}
