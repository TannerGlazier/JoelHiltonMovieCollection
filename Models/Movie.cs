using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    // Create a movie class based on the input fields
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Please enter a movie Title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please enter the year the movie released")]
        public int Year { get; set; }
        [Required(ErrorMessage ="Please enter the movie's Director")]
        public string Director { get; set; }
        [Required(ErrorMessage ="Please enter the movie's Rating")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25)]
        public string Notes { get; set; }
        
        //build a foregin key relationship for categories
        [Required(ErrorMessage ="Please enter a movie Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
