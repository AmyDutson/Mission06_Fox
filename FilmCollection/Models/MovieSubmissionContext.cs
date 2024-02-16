using Microsoft.EntityFrameworkCore;

namespace FilmCollection.Models
{
    public class MovieSubmissionContext : DbContext
    {
        public MovieSubmissionContext(DbContextOptions<MovieSubmissionContext> options) : base (options) 
        { 
        }

        public DbSet<Submission> Submissions { get; set; }

    }
}
