using Cookbook.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Cookbook.Api.Helpers
{
    public static class ResultFormatter
    {
        public static ObjectResult ToRequestResponse<T>(this RequestResponse<T> response)
        {
            if (!response.IsSuccess)
                return new BadRequestObjectResult(response);
            else if (response.IsSuccess && response.Data is null)
                return new NotFoundObjectResult(response);
            else return new OkObjectResult(response);
        }
    }
}
