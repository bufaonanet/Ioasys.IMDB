using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ioasys.IMDb.Api.ViewModels;
using Ioasys.IMDb.Domain.Interfaces;
using Ioasys.IMDb.Domain.Models;

namespace Ioasys.IMDb.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/filmes")]
    public class FilmesController : MainController
    {
        private readonly IFilmeRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public FilmesController(
            IFilmeRepository repository, 
            IUsuarioRepository usuarioRepository, 
            IMapper mapper)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FilmeViewModel>> ObterTodos()
        {
            var usuarios = await ObterTodosFilmes();
            return usuarios;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FilmeViewModel>> ObterPorId(Guid id)
        {
            var filme = await ObterFilmePorId(id);

            if (filme == null) return NotFound();

            return CustomResponse(filme);
        }

        [Authorize(Roles = "admin")]
        [HttpPost()]
        public async Task<ActionResult<FilmeViewModel>> Adicionar(FilmeViewModel filmeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _repository.Adicionar(_mapper.Map<Filme>(filmeViewModel));

            return CustomResponse(filmeViewModel);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FilmeViewModel>> Atualizar(Guid id, FilmeViewModel filmeViewModel)
        {
            if (id != filmeViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _repository.Atualizar(_mapper.Map<Filme>(filmeViewModel));

            return CustomResponse(filmeViewModel);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FilmeViewModel>> Excluir(Guid id)
        {
            var filmeViewModel = await ObterFilmePorId(id);

            if (filmeViewModel == null) return NotFound();

            await _repository.Remover(id);

            return CustomResponse(filmeViewModel);
        }

        private async Task<IEnumerable<FilmeViewModel>> ObterTodosFilmes()
        {
            return _mapper.Map<IEnumerable<FilmeViewModel>>(await _repository.ObterTodosFilmes());
        }

        private async Task<FilmeViewModel> ObterFilmePorId(Guid id)
        {
            return _mapper.Map<FilmeViewModel>(await _repository.ObterFilmePor(id));
        }



    }
}
