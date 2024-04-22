using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RP1.Models.Models;
using Type = RP1.Models.Models.Type;

namespace RP1.DataAccess.DataAccess
{
    public class AppDBContext : IdentityDbContext
    {
        //database context which is used to interface with DB
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Film> Films { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Type> Type { get; set; }
        public DbSet<Booking> Booking { get; set; }

        public DbSet<Ticket> Ticket { get; set; }
    }
}
