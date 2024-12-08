using System.Text.Json.Serialization;

namespace DotNetFlix.Models
{
    public class UserModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public ICollection<RentalModel> Rental { get; set; }


    }
}
