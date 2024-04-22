using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RP1.Models.Models;
using Type = RP1.Models.Models.Type;

namespace RP1.DataAccess.DataAccess
{
    public class AppDBContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        //database context which is used to interface with DB
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Type>().HasData(
                    new Type
                    {
                        Id = 1,
                        TypeName = "Adult",
                        Cost = 9.99
                    },
                    new Type 
                    { 
                        Id = 2, 
                        TypeName = "Child", 
                        Cost = 4.99 
                    }

                );
            builder.Entity<Theatre>().HasData(
                    new Theatre
                    {
                        Id = 1,
                        TheatreNum = 1,
                        Capacity = 24
                    },
                    new Theatre
                    {
                        Id = 2,
                        TheatreNum = 2,
                        Capacity = 48
                    }

                );

            builder.Entity<Film>().HasData(
                    new Film
                    {
                        Id = 1,
                        FilmName = "Dune 2",
                        Description = "Paul Atreides unites with Chani and the Fremen while seeking revenge against the conspirators who destroyed his family. Facing a choice between the love of his life and the fate of the universe, he must prevent a terrible future only he can foresee.",
                        Duration = 122,
                        ageRating = 16,
                        Trailer = "https://www.youtube.com/embed/U2Qp5pL3ovA",
                        ImageName = "/Images/Films/168dd146-0c24-4e01-9ad0-91bd8455af24.jpg"
                    },
                    new Film
                    {
                        Id = 2,
                        FilmName = "Oppenheimer",
                        Description = "During World War II, Lt. Gen. Leslie Groves Jr. appoints physicist J. Robert Oppenheimer to work on the top-secret Manhattan Project. Oppenheimer and a team of scientists spend years developing and designing the atomic bomb. Their work comes to fruition on July 16, 1945, as they witness the world's first nuclear explosion, forever changing the course of history.",
                        Duration = 145,
                        ageRating = 18,
                        Trailer = "https://www.youtube.com/embed/U2Qp5pL3ovA",
                        ImageName = "/Images/Films/168dd146-0c24-4e01-9ad0-91bd8455af24.jpg"
                    }

                );

            base.OnModelCreating(builder);
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Type> Type { get; set; }
        public DbSet<Booking> Booking { get; set; }

        public DbSet<Ticket> Ticket { get; set; }
    }
}
