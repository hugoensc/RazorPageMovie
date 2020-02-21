using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPageMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public String Title { get; set; }

        [Display(Name = "Release Data")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public String Genre { get; set; }

        [Column (TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public String Rating { get; set; }
    }
}