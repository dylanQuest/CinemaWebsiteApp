using System.ComponentModel.DataAnnotations;

namespace RP1.Models.Models
{
    //model class for booking, each model will be a table in the DB. Defines keys and fields within the table
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SeatAmount { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //this tickets list is a reference navigation property, or a Foreign key
        //tickets will contain a single Booking reference as a booking may have many tickets but a ticket will have 1 booking
        public List<Ticket> Tickets { get; set; }
    }
}
