using DotNetFlix.Models;

namespace DotNetFlix.Services.User
{
    public interface IUserInterface
    {
        Task<ResponseModel<List<UserModel>>> ListarFilmes();
        Task<ResponseModel<List<UserModel>>> ListarFilmesPorGenero(string genero);
        Task<ResponseModel<UserModel>> ListarInfoLivro(int id);
        Task<ResponseModel<UserModel>> AlugarFilme(int id);
        Task<ResponseModel<List<UserModel>>> AssociarNotaFilmeAlugado();
        Task<ResponseModel<List<UserModel>>> VisualizarFilmesAlugados();

    }
}
