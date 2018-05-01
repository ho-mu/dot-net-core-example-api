using Microsoft.EntityFrameworkCore;

namespace MovieApi.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<MovieClass> Movies { get; set; }

    }
}