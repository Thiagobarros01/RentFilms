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




    }
}
