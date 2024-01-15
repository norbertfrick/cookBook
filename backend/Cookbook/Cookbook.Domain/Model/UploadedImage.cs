using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Domain.Model
{
    public class UploadedImage
    {
        public Guid Id { get; set; }

        public string FilePath { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}