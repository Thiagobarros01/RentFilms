using DotNetFlix.Data;
using DotNetFlix.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetFlix.Services.Film
{
    public class FilmService : IFilmInterface
    {

        private readonly AppDbContext _context;
        public FilmService(AppDbContext context)
        {
            _context = context;
        }
        public Task<ResponseModel<FilmModel>> AlugarFilme(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<FilmModel>>> ListarFilmes()
        { 
                ResponseModel<List<FilmModel>> resposta = new ResponseModel<List<FilmModel>>();

                try
                {
                    var filmes = await _context.Films.ToListAsync();
                    if( filmes == null)
                {
                    resposta.Mensagem = "Não há filmes para mostrar!";
                    resposta.Status = true;
                    return resposta;
                }
                    resposta.Mensagem = "Filmes encontrados!";
                    resposta.Status = true;
                    resposta.Dados = filmes;
                    return resposta;

                }
                catch (Exception e)
                {
                    resposta.Mensagem = e.Message;
                    resposta.Status = false;
                    return resposta;
                }

        }

        public Task<ResponseModel<List<FilmModel>>> ListarFilmesPorGenero(string genero)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<FilmModel>> ListarInfoLivro(int id)
        {
            throw new NotImplementedException();
        }
    }
}
