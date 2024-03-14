using System.ComponentModel.DataAnnotations;

namespace RP1.Models.Models
{
    public class Theatre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TheatreNum { get; set; }
        [Required]
        public int Capacity { get; set; }
        
        public List<Screening> Screenings { get; set; }
    }
}
