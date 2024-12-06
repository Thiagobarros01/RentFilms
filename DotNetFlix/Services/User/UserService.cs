using DotNetFlix.Models;

namespace DotNetFlix.Services.User
{
    public class UserService : IUserInterface
    {
        public Task<ResponseModel<UserModel>> AlugarFilme(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UserModel>>> AssociarNotaFilmeAlugado()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UserModel>>> ListarFilmes()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UserModel>>> ListarFilmesPorGenero(string genero)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<UserModel>> ListarInfoLivro(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UserModel>>> VisualizarFilmesAlugados()
        {
            throw new NotImplementedException();
        }
    }
}
