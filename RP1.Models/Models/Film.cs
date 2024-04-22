using System.ComponentModel.DataAnnotations;

namespace RP1.Models.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FilmName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int ageRating { get; set; }

        public string Trailer { get; set; }

        public string ImageName { get; set; }

        //collection navigation property
        public List<Screening> Screenings { get; set; }
    }
}
