namespace BookInventoryProject.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Publisher { get; set; }

        public DateTime PublishedDate { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
    }
}