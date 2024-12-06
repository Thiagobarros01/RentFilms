using DotNetFlix.Models;

namespace DotNetFlix.Services.Film
{
    public interface IFilmInterface
    {
        Task<ResponseModel<FilmModel>> ListarInfoLivro(int id);
        Task<ResponseModel<List<FilmModel>>> ListarFilmes();
        Task<ResponseModel<List<FilmModel>>> ListarFilmesPorGenero(string genero);
        Task<ResponseModel<FilmModel>> AlugarFilme(int id);
    }
}
