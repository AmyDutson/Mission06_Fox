using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmCollection.Models
{
    public class Submission
    {
        [Key]
        [Required]
        public int SubmissionId { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        public string Director { get; set; }

        public string Rating { get; set; }

        [Required]
        public int Edited { get; set; }

        public string LentTo { get; set; }

        [Required]
        public int CopiedToPlex { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }

    }
}
