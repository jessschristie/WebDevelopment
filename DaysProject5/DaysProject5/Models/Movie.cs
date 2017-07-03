using System;
using System.ComponentModel.DataAnnotations;

namespace DaysProject5.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "Weekend Revenue")]
        [Range(0, 1000,
        ErrorMessage = "Value must be greater than 0")]
        public double WeekendRevenue { get; set; }

        [Display(Name = "Gross Revenue")]
        public double GrossRevenue { get; set; }
        [Required]
        public DateTime Release { get; set; }
        public bool Recommended { get; set; }
    }
}