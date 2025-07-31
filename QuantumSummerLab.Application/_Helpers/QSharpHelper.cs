using QsharpBridge;

namespace QuantumSummerLab.Application.Helpers;

public interface IQSharpHelper
{
    bool Verify(string verificationTemplate, string solution, string expectedOutput);
}

public class QSharpHelper : IQSharpHelper
{
    private const int _shots = 100;

    public bool Verify(string verificationTemplate, string solution, string expectedOutput)
    {
        var qsharpSource = verificationTemplate.Replace("<<SOLVE>>", solution);

        var executionOptions = ExecutionOptions.FromShots(_shots);
        var resultShots = GlobalQsharpBridge.RunQsWithOptions(qsharpSource, executionOptions);

        var isValid = true;

        for (var i = 0; i < _shots; i++)
        {
            isValid = resultShots[i].result == expectedOutput ? isValid : false;
        }

        return isValid;
    }
}