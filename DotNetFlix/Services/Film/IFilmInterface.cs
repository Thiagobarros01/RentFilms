using DotNetFlix.Dto.Rental;
using DotNetFlix.Models;

namespace DotNetFlix.Services.Film
{
    public interface IFilmInterface
    {
        Task<ResponseModel<FilmModel>> ListarInfoFilme(int id);
        Task<ResponseModel<List<FilmModel>>> ListarFilmes();
        Task<ResponseModel<List<FilmModel>>> ListarFilmesPorGenero(string gender);
        





    }
}
