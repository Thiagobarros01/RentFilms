using DotNetFlix.Dto.Rental;
using DotNetFlix.Models;
using DotNetFlix.Services.Rental;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotNetFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalInterface _rentalInterface;
        
        public RentalController(IRentalInterface rentalInterface)
        {
            _rentalInterface = rentalInterface;
        }

        [HttpPost("AlugarFilme{IdFilm}/{IdUser}")]
        public async Task<ActionResult<ResponseModel<RentalModel>>> AlugarFilme(int IdFilm,int IdUser)
        {
            var AlugarFilme = await _rentalInterface.AlugarFilme(IdFilm, IdUser);
            return Ok(AlugarFilme);
        }

        [HttpPut("AssociarNota")]
        public async Task<ActionResult<ResponseModel<RentalModel>>> AssociarNota(RentalAssociarNotaDto associarDto)
        {
            var AlugarFilme = await _rentalInterface.AssociarNota(associarDto);
            return Ok(AlugarFilme);
        }

        [HttpGet("ListarFilmesAlugados")]
        public async Task<ActionResult<ResponseModel<RentalModel>>> ListarFilmesAlugados(int id)
        {
            var aluguel = await _rentalInterface.ListarFilmesAlugados(id);
            return Ok(aluguel);
        }
    }
}
