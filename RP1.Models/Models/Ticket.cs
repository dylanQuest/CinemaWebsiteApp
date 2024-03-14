using System.ComponentModel.DataAnnotations;

namespace RP1.Models.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public int bookingId { get; set; }
        public Booking Booking { get; set; }

        public int typeId { get; set; }
        public Type Type { get; set; }

        public int screeningId { get; set; }
        public Screening Screening { get; set; }
    }
}
