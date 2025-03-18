using Lab5.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Controllers
{
    public class ErrorController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public ErrorController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            var originalPath = feature?.OriginalPath ?? "Unknown";

            var viewModel = new ErrorViewModel
            {
                StatusCode = statusCode,
                ErrorMessage = $"The page you requested ({originalPath}) could not be found.",
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View("Error", viewModel);
        }

        [Route("Error")]
        public IActionResult GeneralError()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var errorMessage = exceptionFeature?.Error.Message ?? "An unexpected error occurred.";

            var viewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorMessage = GetCustomErrorMessage(errorMessage)
            };

            return View("Error", viewModel);
        }

        private string GetCustomErrorMessage(string errorMessage)
        {
            switch (_env.EnvironmentName)
            {
                case "Development":
                    return $"[DEV MODE] Detailed Error: {errorMessage}";

                case "Staging":
                    return "This is a staging environment. An error occurred, and our team is investigating.";

                case "Production":
                    return "Oops! Something went wrong. Please try again later or contact support.";

                case "Testing":
                    return "Testing environment error. If you see this message, please report it.";

                default:
                    return "An unexpected error occurred. Please try again.";
            }
        }
    }
}
