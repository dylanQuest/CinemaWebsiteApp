using System.ComponentModel.DataAnnotations;

namespace RP1.Models.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? TypeName { get; set; }
        [Required]
        public double Cost { get; set; }
        
        //collection navigation property
        public List<Ticket> Tickets { get; set; }
    }
}
