using CookBookNet.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Domain.Services
{
    public class ImageHandlerService : IImageHandlerService
    {
        public IFormFile GetImage(string imageName)
        {
            throw new NotImplementedException();
        }

        public string SaveImage(string imageName, IFormFile image)
        {
            throw new NotImplementedException();
        }
    }
}
