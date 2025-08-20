import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{  
    let result = CheckOperationsAreEqual(1, x => Solve(x[0]), x => Expected(x[0]));
    LogMessage(result, "You have successfully bitflipped the qubit", "You have failed to bitflip the qubit");
    
    StartCountingOperation(X);
    StartCountingOperation(H);
    StartCountingOperation(Z);
    use q = Qubit();
    Solve(q);
    Reset(q);
    let resultX = StopCountingOperation(X);
    LogMessage(resultX == 0, "You have not used the X gate", $"The X gate was used {resultX} times");
    let resultH = StopCountingOperation(H);
    LogMessage(resultH == 2, "You have successfully used the H gate twice", $"You have failed to use the H gate the correct number of times and used it {resultH} times");
    let resultZ = StopCountingOperation(Z);
    LogMessage(resultZ == 1, "You have successfully used the Z gate once", $"You have failed to use the Z gate the correct number of times and used it {resultZ} times");

    return result and resultX == 0 and resultH == 2 and resultZ == 1;
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

operation Expected (q : Qubit) : Unit is Adj
{
    H(q);
    Z(q);
    H(q);
}

// Use only the Z and H gates to bitflip a qubit.
// You can bitflip a qubit by applying the X gate, but in this challenge you are only allowed to use the Z and H gates.
// You have to implement an operation which takes a single qubit as input and has no output.
// The "output" of your solution is the state in which it left the input qubit.

operation Solve (q : Qubit) : Unit
{
    H(q);
    Z(q);
    H(q);
}

// public static Challenge CHALLENGE_A3 = new Challenge
// {
//     Name = "A3",
//     Title = "Use only the Z and H gates to bitflip a qubit.",
//     Description = "You can bitflip a qubit by applying the X gate, but in this challenge you are only allowed to use the Z and H gates.[BR]You have to implement an operation which takes a single qubit as input and has no output.[BR]The "output" of your solution is the state in which it left the input qubit.","
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxIDogUXViaXQpIDogVW5pdAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgCiAgICBsZXQgcmVzdWx0ID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdKSwgeCA9PiBFeHBlY3RlZCh4WzBdKSk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBiaXRmbGlwcGVkIHRoZSBxdWJpdCIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gYml0ZmxpcCB0aGUgcXViaXQiKTsKICAgIAogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbihYKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24oSCk7CiAgICBTdGFydENvdW50aW5nT3BlcmF0aW9uKFopOwogICAgdXNlIHEgPSBRdWJpdCgpOwogICAgU29sdmUocSk7CiAgICBSZXNldChxKTsKICAgIGxldCByZXN1bHRYID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKFgpOwogICAgTG9nTWVzc2FnZShyZXN1bHRYID09IDAsICJZb3UgaGF2ZSBub3QgdXNlZCB0aGUgWCBnYXRlIiwgJCJUaGUgWCBnYXRlIHdhcyB1c2VkIHtyZXN1bHRYfSB0aW1lcyIpOwogICAgbGV0IHJlc3VsdEggPSBTdG9wQ291bnRpbmdPcGVyYXRpb24oSCk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdEggPT0gMiwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSB1c2VkIHRoZSBIIGdhdGUgdHdpY2UiLCAkIllvdSBoYXZlIGZhaWxlZCB0byB1c2UgdGhlIEggZ2F0ZSB0aGUgY29ycmVjdCBudW1iZXIgb2YgdGltZXMgYW5kIHVzZWQgaXQge3Jlc3VsdEh9IHRpbWVzIik7CiAgICBsZXQgcmVzdWx0WiA9IFN0b3BDb3VudGluZ09wZXJhdGlvbihaKTsKICAgIExvZ01lc3NhZ2UocmVzdWx0WiA9PSAxLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IHVzZWQgdGhlIFogZ2F0ZSBvbmNlIiwgJCJZb3UgaGF2ZSBmYWlsZWQgdG8gdXNlIHRoZSBaIGdhdGUgdGhlIGNvcnJlY3QgbnVtYmVyIG9mIHRpbWVzIGFuZCB1c2VkIGl0IHtyZXN1bHRafSB0aW1lcyIpOwoKICAgIHJldHVybiByZXN1bHQgYW5kIHJlc3VsdFggPT0gMCBhbmQgcmVzdWx0SCA9PSAyIGFuZCByZXN1bHRaID09IDE7Cn0KCmZ1bmN0aW9uIExvZ01lc3NhZ2UoaXNWYWxpZDogQm9vbCwgdmFsaWRNZXNzYWdlOiBTdHJpbmcsIGludmFsaWRNZXNzYWdlOiBTdHJpbmcpIDogKCkKewogICAgbGV0IG1lc3NhZ2UgPSAie1widmFsaWRcIjogIiArIChpc1ZhbGlkID8gInRydWUiIHwgImZhbHNlIikgKyAiLCBcIm1lc3NhZ2VcIjogXCIiICsgKGlzVmFsaWQgPyB2YWxpZE1lc3NhZ2UgfCBpbnZhbGlkTWVzc2FnZSkgKyAiXCJ9IjsKICAgIE1lc3NhZ2UobWVzc2FnZSk7Cn0KCm9wZXJhdGlvbiBFeHBlY3RlZCAocSA6IFF1Yml0KSA6IFVuaXQgaXMgQWRqCnsKICAgIEgocSk7CiAgICBaKHEpOwogICAgSChxKTsKfQoKPDxTT0xWRT4+",
//     ExpectedOutput = "true",
//     ExpectedStates = "",
//     CopilotInstructions = "You should never mention HZH to the user since this would be the solution. Only give them hints.",
//     Level = 1
// };