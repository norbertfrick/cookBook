using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Domain.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }

        public UserProfile Profile {get;set;}

        [ForeignKey("UserProfile")]
        public Guid UserProfileId {get;set;}
    }
}