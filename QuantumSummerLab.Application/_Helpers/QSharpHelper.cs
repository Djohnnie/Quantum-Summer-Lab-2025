using QsharpBridge;
using System.Text.Json;

namespace QuantumSummerLab.Application.Helpers;

public interface IQSharpHelper
{
    QSharpFeedback Verify(string verificationTemplate, string solution, string expectedOutput);
}

public class QSharpHelper : IQSharpHelper
{
    private const int _shots = 1;

    public QSharpFeedback Verify(string verificationTemplate, string solution, string expectedOutput)
    {
        var qsharpSource = verificationTemplate.Replace("<<SOLVE>>", solution);

        var executionOptions = ExecutionOptions.FromShots(_shots);
        var resultShots = GlobalQsharpBridge.RunQsWithOptions(qsharpSource, executionOptions);

        var isValid = true;

        var feedbackMessages = new List<QSharpFeedbackMessage>();

        for (var i = 0; i < _shots; i++)
        {
            isValid = resultShots[i].result == expectedOutput ? isValid : false;
            if (resultShots[i].messages != null)
            {
                foreach (var message in resultShots[i].messages)
                {
                    var feedbackMessage = JsonSerializer.Deserialize<QSharpFeedbackMessage>(message, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (feedbackMessage != null)
                    {
                        isValid = isValid && feedbackMessage.Valid;
                        feedbackMessages.Add(feedbackMessage);
                    }
                }
            }
        }

        return new QSharpFeedback
        {
            IsValid = isValid,
            Messages = feedbackMessages
        };
    }
}

public class QSharpFeedback
{
    public bool IsValid { get; set; }
    public List<QSharpFeedbackMessage> Messages { get; set; } = new List<QSharpFeedbackMessage>();
}

public class QSharpFeedbackMessage
{
    public bool Valid { get; set; }
    public string Message { get; set; }
}