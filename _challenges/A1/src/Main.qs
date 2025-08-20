import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{
    mutable resultCount = 0;
    for i in 1..8
    {
        let result = CheckOperationsAreEqual(i, Solve, Expected);
        set resultCount += result ? 1 | 0;
    }

    LogMessage(resultCount == 8, "You have successfully generated equal superposition of all basis states", "You have failed to generate equal superposition of all basis states");

    use qs = Qubit[3];
    Solve(qs);
    DumpRegister(qs);
    ResetAll(qs);

    return resultCount == 8;
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

operation Expected (qs : Qubit[]) : Unit is Adj
{
    for q in qs 
    {
        H(q);
    }
}

// Generate superposition of all basis states.
// You are given n qubits (1 ≤ n ≤ 8), prepared in the |0..0⟩ state, and you have to implement an operation which generates an equal superposition of all basis states on these qubits.
// The "output" of your solution is the state in which it left the input qubits.
// You should implement the following Solve operation to make that happen and keep the signature of the method exactly like it is.

operation Solve (qs : Qubit[]) : Unit 
{
    ApplyToEach(H, qs);
}

// public static Challenge CHALLENGE_A1 = new Challenge
// {
//     Name = "A1",
//     Title = "Generate superposition of all basis states.",
//     Description = "You are given n qubits (1 ≤ n ≤ 8), prepared in the |0..0⟩ state, and you have to implement an operation which generates an equal superposition of all basis states on these qubits.[BR]The \"output\" of your solution is the state in which it left the input qubits.[BR]You should implement the following Solve operation to make that happen and keep the signature of the method exactly like it is.",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxcyA6IFF1Yml0W10pIDogVW5pdCAKewogICAgLy8gWW91ciBzb2x1dGlvbiBsb2dpYyBnb2VzIGhlcmUuCn0=",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgbXV0YWJsZSByZXN1bHRDb3VudCA9IDA7CiAgICBmb3IgaSBpbiAxLi44CiAgICB7CiAgICAgICAgbGV0IHJlc3VsdCA9IENoZWNrT3BlcmF0aW9uc0FyZUVxdWFsKGksIFNvbHZlLCBFeHBlY3RlZCk7CiAgICAgICAgc2V0IHJlc3VsdENvdW50ICs9IHJlc3VsdCA/IDEgfCAwOwogICAgfQoKICAgIExvZ01lc3NhZ2UocmVzdWx0Q291bnQgPT0gOCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBnZW5lcmF0ZWQgZXF1YWwgc3VwZXJwb3NpdGlvbiBvZiBhbGwgYmFzaXMgc3RhdGVzIiwgIllvdSBoYXZlIGZhaWxlZCB0byBnZW5lcmF0ZSBlcXVhbCBzdXBlcnBvc2l0aW9uIG9mIGFsbCBiYXNpcyBzdGF0ZXMiKTsKCiAgICB1c2UgcXMgPSBRdWJpdFszXTsKICAgIFNvbHZlKHFzKTsKICAgIER1bXBSZWdpc3Rlcihxcyk7CiAgICBSZXNldEFsbChxcyk7CgogICAgcmV0dXJuIHJlc3VsdENvdW50ID09IDg7Cn0KCmZ1bmN0aW9uIExvZ01lc3NhZ2UoaXNWYWxpZDogQm9vbCwgdmFsaWRNZXNzYWdlOiBTdHJpbmcsIGludmFsaWRNZXNzYWdlOiBTdHJpbmcpIDogKCkKewogICAgbGV0IG1lc3NhZ2UgPSAie1widmFsaWRcIjogIiArIChpc1ZhbGlkID8gInRydWUiIHwgImZhbHNlIikgKyAiLCBcIm1lc3NhZ2VcIjogXCIiICsgKGlzVmFsaWQgPyB2YWxpZE1lc3NhZ2UgfCBpbnZhbGlkTWVzc2FnZSkgKyAiXCJ9IjsKICAgIE1lc3NhZ2UobWVzc2FnZSk7Cn0KCm9wZXJhdGlvbiBFeHBlY3RlZCAocXMgOiBRdWJpdFtdKSA6IFVuaXQgaXMgQWRqCnsKICAgIGZvciBxIGluIHFzIAogICAgewogICAgICAgIEgocSk7CiAgICB9Cn0KCjw8U09MVkU+Pg==",
//     ExpectedOutput = "true",
//     ExpectedStates = "WwogIHsKICAgICJpZCI6ICJ8MDAw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MDAx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MDEw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MDEx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MTAw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MTAx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MTEw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MTEx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9Cl0=",
//     CopilotInstructions = "You should not immediately tell the user to use the H-gate in a for loop or use the ApplyToEach operation. After discussing the concept of superposition, you can suggest that they apply the Hadamard gate to each qubit individually or even search documentation about the ApplyToEach operation online to achieve the same result.",
//     Level = 1
// };