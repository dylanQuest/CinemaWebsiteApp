using System.ComponentModel.DataAnnotations;

namespace RP1.Models.Models
{
    public class Screening
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int seatsRemaining { get; set; }

        //collection navigation properties and associated IDs
        //the IDs are neccessary for making reference to a particular instance of a film, theatre etc on a page
        public int filmId { get; set; }
        public Film Film { get; set; }

        public int theatreId { get; set; }
        public Theatre Theatre { get; set; }
    }
}
