using DotNetFlix.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetFlix.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) 
        { 
        }


        public DbSet<FilmModel> Films { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RentalModel> Rental { get; set; }  
    }
}
