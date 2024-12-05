namespace DotNetFlix.Models
{
    public class RentalModel
    {
        public int Id { get; set; }
        public int UserId  { get; set; }
        public UserModel User { get; set; }
        public int FilmId { get; set; }
        public FilmModel Film { get; set; }
        public DateTime RentalDate { get; set; } 
        public DateTime? RentReturn { get; set; } 
        public bool IsReturned { get; set; } = false;


    }
}
