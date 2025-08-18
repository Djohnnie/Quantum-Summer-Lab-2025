using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public class QSharpVerificationFunction
    {
        private readonly ILogger<QSharpVerificationFunction> _logger;

        public QSharpVerificationFunction(ILogger<QSharpVerificationFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(QSharpVerificationFunction))]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}