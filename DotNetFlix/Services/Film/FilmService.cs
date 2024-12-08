using DotNetFlix.Data;
using DotNetFlix.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DotNetFlix.Services.Film
{
    public class FilmService : IFilmInterface
    {

        private readonly AppDbContext _context;
        public FilmService(AppDbContext context)
        {
            _context = context;
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

        public async Task<ResponseModel<List<FilmModel>>> ListarFilmesPorGenero(string gender)
        {
            ResponseModel<List<FilmModel>> resposta = new ResponseModel<List<FilmModel>>();
            try
            {
                var filmes = await _context.Films.Where(f => f.Gender == gender.ToUpper()).ToListAsync();

                Console.WriteLine(filmes);
                if ( filmes.Count() == 0)
                {
                    resposta.Mensagem = "Não tem livros desse gênero";
                    return resposta;
                }

                resposta.Dados = filmes;
                resposta.Mensagem = "Filmes encontrados!";
                resposta.Status= true;
                return resposta;


            }
            catch (Exception e) {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<FilmModel>> ListarInfoFilme(int id)
        {
            ResponseModel<FilmModel> resposta = new ResponseModel<FilmModel>();
            try
            {
                var filme = await _context.Films.FirstOrDefaultAsync(f => f.Id == id);

                
                if (filme == null)
                {
                    resposta.Mensagem = "Nenhum filmes encontrado com este ID";
                    return resposta;
                }

                resposta.Dados = filme;
                resposta.Mensagem = "Filme encontrado!";
                resposta.Status = true;
                return resposta;


            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }

        }
    }
}
