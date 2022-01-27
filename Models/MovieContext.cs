using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class MovieContext : DbContext
    {   
        //Constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // seed 3 database entries
            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Category = "Action/Adventure",
                    Title = "How to Train Your Dragon",
                    Year = 2010,
                    Director = "Chris Sanders",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new Movie
                {
                    MovieId = 2,
                    Category = "Action/Adventure",
                    Title = "Rogue One: A Star Wars Story",
                    Year = 2016,
                    Director = "Gareth Edwards",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new Movie
                {
                    MovieId = 3,
                    Category = "Action/Adventure",
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
                );
        }
    }
}
