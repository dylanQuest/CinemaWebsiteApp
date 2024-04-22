using System.ComponentModel.DataAnnotations;

namespace RP1.Models.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public int bookingId { get; set; }
        public Booking Booking { get; set; }

        //collection navigation properties and associated IDs
        //the IDs are neccessary for making reference to a particular instance of a screening, type etc on a page
        public int typeId { get; set; }
        public Type Type { get; set; }

        public int screeningId { get; set; }
        public Screening Screening { get; set; }
    }
}
