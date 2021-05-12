using DotNetCleanArchitecture.API.Controllers;
using DotNetCleanArchitecture.API.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Application.Models;
using System.Collections.Generic;

namespace DotNetCleanArchitecture.API.Functions
{
    public static class HandleResponse
    {
        public static JsonResult Execute<T>(Result<T> result, BaseController controller)
        {
            if (result.Success == false)
            {
                controller.Response.StatusCode = result.StatusCode;

                return new JsonResult(new Response<List<string>>
                {
                    Success = false,
                    StatusCode = result.StatusCode,
                    Message = result.Message,
                    Errors = result.Errors ?? new List<string>()
                });
            }
            else
            {
                return new JsonResult(new Response<T>
                {
                    Success = true,
                    StatusCode = 200,
                    Message = "OK",
                    Payload = result.Payload,
                    Errors = new List<string>()
                });
            }
        }
    }
}
