using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBookNet.Domain
{
    public class Recipe
    {
        [Key]
        [Column(TypeName = "Guid")]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
        [Required]
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public string Description { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Steps { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Ingredients { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [Required]
        public User User { get; set; }

        public string ImagePath { get; set; }
        
        public IFormFile Image { get; set; }

    }
}
