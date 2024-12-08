using DotNetFlix.Models;

namespace DotNetFlix.Dto.Rental
{
    public class RentalDemostrarDto
    {
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? RentReturn { get; set; }
        
        public int? note { get; set; }  

    }
}
