using lr.libs.cash_machine.Models;
using Microsoft.AspNetCore.Mvc;

namespace lr.apps.cash_machine
{
    public static class ControllerExtensions
    {
        public static IActionResult Handle<TResponse, TRequest>(this Controller controller, TRequest request, TResponse response)
            where TResponse : Response
        {
            if (controller.Request.IsAjaxRequest())
            {
                if (response.IsSucceeded)
                {
                    return controller.Json(response);
                }

                return controller.BadRequest(response);
            }

            if (response.IsSucceeded)
            {
                controller.ViewData["Response"] = response;
                return controller.View();
            }

            controller.ViewData["ExceptionMessage"] = response.Message;
            return controller.View(request);
        }
    }
}
