using DotNetFlix.Models;
using DotNetFlix.Dto.Rental;
namespace DotNetFlix.Services.Rental
{
    public interface IRentalInterface
    {
        public Task<ResponseModel<RentalDemostrarDto>> AlugarFilme(int FilmId, int UserId);
        public Task<ResponseModel<RentalModel>> AssociarNota (RentalAssociarNotaDto rentalDto);

    }
}
