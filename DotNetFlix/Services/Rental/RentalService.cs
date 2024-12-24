using DotNetFlix.Data;
using DotNetFlix.Models;
using Microsoft.EntityFrameworkCore;
using DotNetFlix.Dto.Rental;

namespace DotNetFlix.Services.Rental
{
    public class RentalService : IRentalInterface
    {

        private readonly AppDbContext _context;
        public RentalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<RentalDemostrarDto>> AlugarFilme(int FilmId, int UserId)
        {
            ResponseModel<RentalDemostrarDto> resposta = new ResponseModel<RentalDemostrarDto>();
            try
            {

                // Buscando filme
                var filme = await _context.Films.FirstOrDefaultAsync(f => f.Id == FilmId);
                if (filme == null) {
                    resposta.Mensagem = "Nenhum filme encontrado!";
                    return resposta;
                }

                //Buscando Usuario
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == UserId);
                if (user == null) 
                {
                    resposta.Mensagem = "Filme não existe";
                    return resposta;
                }

                RentalModel novoAluguel = new RentalModel
                {
                    UserId = UserId,
                    FilmId = FilmId,
                    RentalDate = DateTime.Now,
                    
                };

                // Adicionando relacao Aluguel no banco
                _context.Rental.Add(novoAluguel);
                await _context.SaveChangesAsync();

                // Preparando o DTO pra retornar na resposta
                var rentalDto = new RentalDemostrarDto
                {
                    UserId = UserId,
                    FilmId = FilmId,
                    RentalDate = novoAluguel.RentalDate,
                    
                };

                resposta.Status = true;
                resposta.Mensagem = "Filme alugado com Sucesso!";
                resposta.Dados = rentalDto;

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<RentalModel>> AssociarNota(RentalAssociarNotaDto rentaldto)
        {
             ResponseModel<RentalModel> resposta = new ResponseModel<RentalModel>();
            try
            {
                  var user = await _context.Users.FirstOrDefaultAsync(a=>a.Id == rentaldto.UserId);
                    
                  if (user == null)
                {
                    resposta.Mensagem = "usuario nao encontrado!";
                    return resposta;
                }

                  var filme = await _context.Films.FirstOrDefaultAsync(f => f.Id == rentaldto.FilmId);

                if (filme == null)
                {
                    resposta.Mensagem = "filme nao encontrado";
                    return resposta;
                }

             
                var rental = await _context.Rental.FirstOrDefaultAsync(r => r.FilmId == rentaldto.FilmId);

                if (rental == null)
                {
                    resposta.Mensagem = "Este usuário não alugou este filme";
                    return resposta;
                }

               
                rental.note = rentaldto.note;

                await _context.SaveChangesAsync();

                resposta.Dados = rental;
                resposta.Mensagem = "Nota atualizada com sucesso!";
                return resposta;

            }
            
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<RentalDemostrarDto>>> ListarFilmesAlugados(int id)
        {
            ResponseModel<List<RentalDemostrarDto>> resposta = new ResponseModel<List<RentalDemostrarDto>>();

            try
            {
                var filmes = await _context.Rental.Where(f => f.UserId == id).Select(f => new RentalDemostrarDto

                {

                    FilmId = f.FilmId,
                    UserId = f.UserId,
                    note = f.note,
                    RentalDate = f.RentalDate,
                    RentReturn = f.RentReturn,



                }).ToListAsync();

                

                if (filmes.Count() == 0)
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
    }
}
