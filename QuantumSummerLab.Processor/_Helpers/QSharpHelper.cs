using QsharpBridge;
using QuantumSummerLab.Processor.Extensions;
using System.Text.Json;

namespace QuantumSummerLab.Processor.Helpers;

public interface IQSharpHelper
{
    QSharpFeedback Verify(QSharpRequest request);
}

public class QSharpHelper : IQSharpHelper
{
    private const int _shots = 1;

    public QSharpFeedback Verify(QSharpRequest request)
    {
        try
        {
            var verificationTemplate = request.VerificationTemplate.FromBase64String();
            var solution = request.Solution.FromBase64String();
            var expectedOutput = request.ExpectedOutput.FromBase64String();
            var expectedStates = request.ExpectedStates.FromBase64String();

            if (solution.Contains("while"))
            {
                return new QSharpFeedback
                {
                    IsValid = false,
                    Messages = [new QSharpFeedbackMessage { Valid = false, Message = "This challenge does not need a while-loop" }]
                };
            }

            var expectedDeserializedStates = string.IsNullOrEmpty(expectedStates) ? new List<QSharpState>() : JsonSerializer.Deserialize<List<QSharpState>>(expectedStates, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var qsharpSource = verificationTemplate.Replace("<<SOLVE>>", solution);

            var executionOptions = ExecutionOptions.FromShots(_shots);
            var resultShots = GlobalQsharpBridge.RunQsWithOptions(qsharpSource, executionOptions);

            var isValid = true;

            var feedbackMessages = new List<QSharpFeedbackMessage>();

            for (var i = 0; i < _shots; i++)
            {
                var actualOutput = resultShots[i].result;

                isValid = actualOutput == expectedOutput ? isValid : false;

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

                if (resultShots[i].states != null)
                {
                    var actualStates = resultShots[i].states;

                    foreach (var expectedState in expectedDeserializedStates)
                    {
                        var actualState = actualStates.FirstOrDefault(s => s.id == expectedState.Id);
                        if (actualState != null)
                        {
                            var isAmplitudeValid = Math.Abs(actualState.amplitudeReal - expectedState.AmplitudeReal) < 0.00001 &&
                                                   Math.Abs(actualState.amplitudeImaginary - expectedState.AmplitudeImaginary) < 0.00001;
                            if (!isAmplitudeValid)
                            {
                                isValid = false;
                                feedbackMessages.Add(new QSharpFeedbackMessage
                                {
                                    Valid = false,
                                    Message = $"State {expectedState.Id} has incorrect amplitudes: Expected ({expectedState.AmplitudeReal}, {expectedState.AmplitudeImaginary}), Actual ({actualState.amplitudeReal}, {actualState.amplitudeImaginary})"
                                });
                            }
                        }
                        else
                        {
                            isValid = false;
                            feedbackMessages.Add(new QSharpFeedbackMessage
                            {
                                Valid = false,
                                Message = $"Expected state {expectedState.Id} not found in actual states."
                            });
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
        catch (QsException ex)
        {
            return new QSharpFeedback
            {
                IsValid = false,
                Messages = [new QSharpFeedbackMessage { Valid = false, Message = ex.Message switch
                {
                    string a when a.Contains("error: Compile") => "There has been an error compiling your Q# code!",
                    string b when b.Contains("error: Eval") => "There has been an error running your Q# code!",
                    _ => "There has been an unknown error :("
                } }]
            };
        }
        catch
        {
            return new QSharpFeedback
            {
                IsValid = false,
                Messages = [new QSharpFeedbackMessage { Valid = false, Message = "There has been an unknown error :(" }]
            };
        }
    }
}

public class QSharpRequest
{
    public string VerificationTemplate { get; set; }
    public string Solution { get; set; }
    public string ExpectedOutput { get; set; }
    public string ExpectedStates { get; set; }
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

public class QSharpState
{
    public string Id { get; set; }
    public double AmplitudeReal { get; set; }
    public double AmplitudeImaginary { get; set; }
}