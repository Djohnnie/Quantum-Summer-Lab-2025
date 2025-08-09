import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{    
    let result1 = CheckOperationsAreEqual(1, x => Solve(x[0], 1), x => Expected(x[0], 1));
    LogMessage(result1, "You have successfully generated the |+⟩ state for sign 1", "You have failed to generate the |+⟩ state for sign 1");

    let result2 = CheckOperationsAreEqual(1, x => Solve(x[0], -1), x => Expected(x[0], -1));
    LogMessage(result2, "You have successfully generated the |-⟩ state for sign -1", "You have failed to generate the |-⟩ state for sign -1");

    return result1 and result2;
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

operation Expected (q : Qubit, sign : Int) : Unit is Adj
{
    if(sign < 0)
    {
        X(q);
    }

    H(q);
}

// Generate |+⟩ state or |-⟩ state.
// You have to implement an operation which takes a qubit that has been prepared in the |0⟩ state and an integer that specifies the desired sign: +1 for the |+⟩ state and -1 for |-⟩ state.
// You should implement the following Solve method to make that happen and keep the signature of the method exactly like it is.

operation Solve (q : Qubit, sign : Int) : Unit
{
    if(sign < 0)
    {
        X(q);
    }

    H(q);
}

// public static Challenge CHALLENGE_B1 = new Challenge
// {
//     Name = "B1",
//     Title = "Generate |+⟩ state or |-⟩ state",
//     Description = "You have to implement an operation which takes a qubit that has been prepared in the |0⟩ state and an integer that specifies the desired sign: +1 for the |+⟩ state and -1 for |-⟩ state.[BR]You should implement the following Solve method to make that happen and keep the signature of the method exactly like it is.",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxIDogUXViaXQsIHNpZ24gOiBJbnQpIDogVW5pdAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIGxldCByZXN1bHQxID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCAxKSwgeCA9PiBFeHBlY3RlZCh4WzBdLCAxKSk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDEsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIHRoZSB8K+KfqSBzdGF0ZSBmb3Igc2lnbiAxIiwgIllvdSBoYXZlIGZhaWxlZCB0byBnZW5lcmF0ZSB0aGUgfCvin6kgc3RhdGUgZm9yIHNpZ24gMSIpOwoKICAgIGxldCByZXN1bHQyID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCAtMSksIHggPT4gRXhwZWN0ZWQoeFswXSwgLTEpKTsKICAgIExvZ01lc3NhZ2UocmVzdWx0MiwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBnZW5lcmF0ZWQgdGhlIHwt4p+pIHN0YXRlIGZvciBzaWduIC0xIiwgIllvdSBoYXZlIGZhaWxlZCB0byBnZW5lcmF0ZSB0aGUgfC3in6kgc3RhdGUgZm9yIHNpZ24gLTEiKTsKCiAgICByZXR1cm4gcmVzdWx0MSBhbmQgcmVzdWx0MjsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKb3BlcmF0aW9uIEV4cGVjdGVkIChxIDogUXViaXQsIHNpZ24gOiBJbnQpIDogVW5pdCBpcyBBZGoKewogICAgaWYoc2lnbiA8IDApCiAgICB7CiAgICAgICAgWChxKTsKICAgIH0KCiAgICBIKHEpOwp9Cgo8PFNPTFZFPj4=",
//     ExpectedOutput = "true",
//     CopilotInstructions = "",
//     Level = 2
// };