using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmCollection.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int ? CategoryId { get; set; }
        public Category ? Category { get; set; }

        [Required(ErrorMessage = "Please enter a Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a year")]
        [Range(1888, int.MaxValue, ErrorMessage = "The year must be 1888 or higher")]
        public int Year { get; set; }

        public string ? Director { get; set; }

        public string ? Rating { get; set; }

        [Required(ErrorMessage = "Please indicate if it was edited")]
        public int Edited { get; set; }

        public string ? LentTo { get; set; }

        [Required(ErrorMessage = "Please indicate if it was copied to plex")]
        public int CopiedToPlex { get; set; }

        [StringLength(25)]
        public string ? Notes { get; set; }

    }
}
