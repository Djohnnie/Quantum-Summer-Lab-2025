using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using QuantumSummerLab.Processor.Helpers;
using FromBodyAttribute = Microsoft.Azure.Functions.Worker.Http.FromBodyAttribute;

namespace QuantumSummerLab.Processor;

public class QSharpVerificationFunction
{
    private readonly IQSharpHelper _qsharpHelper;
    private readonly ILogger<QSharpVerificationFunction> _logger;

    public QSharpVerificationFunction(
        IQSharpHelper qsharpHelper,
        ILogger<QSharpVerificationFunction> logger)
    {
        _qsharpHelper = qsharpHelper;
        _logger = logger;
    }

    [Function(nameof(QSharpVerificationFunction))]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest request,
        [FromBody] QSharpRequest body)
    {
        try
        {
            var result = _qsharpHelper.Verify(body);
            return new OkObjectResult(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing the Q# verification request.");
            //return new OkObjectResult(ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}