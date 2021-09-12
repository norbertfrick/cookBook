using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Domain.Interfaces
{
    public interface IImageHandlerService
    {
        public string SaveImage(string imageName, IFormFile image);

        public IFormFile GetImage(string imageName);
    }
}
