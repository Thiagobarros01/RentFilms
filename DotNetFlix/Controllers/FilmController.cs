using DotNetFlix.Models;
using DotNetFlix.Services.Film;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {

        private readonly IFilmInterface _filmInterface;

        public FilmController(IFilmInterface filmInterface)
        {
            _filmInterface = filmInterface;
        }

        [HttpGet("ListarFilmes")]
        public async Task<ActionResult<ResponseModel<List<FilmModel>>>> ListarFilmes()
        {
            var filmes = await _filmInterface.ListarFilmes();
            return Ok(filmes);
        }

        [HttpGet("ListarFilmesPorGenero{gender}")]
        public async Task<ActionResult<ResponseModel<List<FilmModel>>>> ListarFilmesPorGenero(string gender)
        {
            var filmes = await _filmInterface.ListarFilmesPorGenero(gender);
            return Ok(filmes);
        }

        [HttpGet("ListarInfoFilme{id}")]
        public async Task<ActionResult<ResponseModel<FilmModel>>> ListarInfoLivro(int id)
        {
            var filme = await _filmInterface.ListarInfoFilme(id);
            return Ok(filme);
        }


    }
}
