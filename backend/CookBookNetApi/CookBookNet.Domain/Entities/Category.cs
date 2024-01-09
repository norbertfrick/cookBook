using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace CookBookNet.Domain
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Description { get; set; }

        public string Picture { get; set; }


    }
}
