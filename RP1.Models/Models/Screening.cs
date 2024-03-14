using System.ComponentModel.DataAnnotations;

namespace RP1.Models.Models
{
    public class Screening
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        //public Cinema TheatreId { get; set; }

        //probably unneeded


        //[Required]

        public DateTime Date { get; set; }
        //[Required]
        public int seatsRemaining { get; set; }
        //[Required]

        //collection navigation properties
        public int filmId { get; set; }
        public Film Film { get; set; }

        public int theatreId { get; set; }
        public Theatre Theatre { get; set; }
    }
}
