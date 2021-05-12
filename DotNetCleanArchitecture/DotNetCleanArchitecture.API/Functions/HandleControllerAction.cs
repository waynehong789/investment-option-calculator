using DotNetCleanArchitecture.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Application.Models;
using Shared.Core.Entities;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCleanArchitecture.API.Functions
{
    public static class HandleControllerAction
    {
        public static async Task<JsonResult> Execute<T>(BaseController controller, AuthRequest<T> request)
        {
            if (controller.HttpContext.Items.TryGetValue("User", out var userHeader))
            {
                var stringUser = JsonConvert.SerializeObject(userHeader);
                request.User = JsonConvert.DeserializeObject<User>(stringUser);
            }

            var result = await controller._mediator.Send(request);

            return HandleResponse.Execute(result, controller);
        }
    }
}
