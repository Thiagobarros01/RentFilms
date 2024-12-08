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
                    IsReturned = false
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
                    IsReturned = novoAluguel.IsReturned
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
    }
}
