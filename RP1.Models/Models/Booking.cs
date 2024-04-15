using System.ComponentModel.DataAnnotations;

namespace RP1.Models.Models
{
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
        public List<Ticket> Tickets { get; set; }
    }
}
