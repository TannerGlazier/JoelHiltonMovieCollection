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
        public DbSet<Category>Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                 new Category { CategoryId=1, CategoryName="Action/Adventure"}, 
                 new Category { CategoryId=2, CategoryName="Comedy"},
                 new Category { CategoryId=3, CategoryName="Drama"},
                 new Category { CategoryId=4, CategoryName="Family"},
                 new Category { CategoryId=5, CategoryName="Horror/Suspense"},
                 new Category { CategoryId=6, CategoryName="Miscellaneous"},
                 new Category { CategoryId=7, CategoryName="Television"},
                 new Category { CategoryId=8, CategoryName="VHS"}
            );

            // seed 3 database entries
            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    CategoryId = 4,
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
                    CategoryId = 1,
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
                    CategoryId = 1,
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
