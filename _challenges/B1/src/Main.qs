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

    use (q1, q2) = (Qubit(), Qubit());
    Solve(q1, 1);
    Solve(q2, -1);
    DumpRegister([q1, q2]);
    ResetAll([q1, q2]);

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
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIGxldCByZXN1bHQxID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCAxKSwgeCA9PiBFeHBlY3RlZCh4WzBdLCAxKSk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDEsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIHRoZSB8K+KfqSBzdGF0ZSBmb3Igc2lnbiAxIiwgIllvdSBoYXZlIGZhaWxlZCB0byBnZW5lcmF0ZSB0aGUgfCvin6kgc3RhdGUgZm9yIHNpZ24gMSIpOwoKICAgIHVzZSBxMSA9IFF1Yml0KCk7CiAgICBTb2x2ZShxMSwgMSk7CiAgICBEdW1wUmVnaXN0ZXIoW3ExXSk7CiAgICBSZXNldChxMSk7CgogICAgbGV0IHJlc3VsdDIgPSBDaGVja09wZXJhdGlvbnNBcmVFcXVhbCgxLCB4ID0+IFNvbHZlKHhbMF0sIC0xKSwgeCA9PiBFeHBlY3RlZCh4WzBdLCAtMSkpOwogICAgTG9nTWVzc2FnZShyZXN1bHQyLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGdlbmVyYXRlZCB0aGUgfC3in6kgc3RhdGUgZm9yIHNpZ24gLTEiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGdlbmVyYXRlIHRoZSB8LeKfqSBzdGF0ZSBmb3Igc2lnbiAtMSIpOwoKICAgIHVzZSBxMiA9IFF1Yml0KCk7CiAgICBTb2x2ZShxMiwgLTEpOwogICAgRHVtcFJlZ2lzdGVyKFtxMl0pOwogICAgUmVzZXQocTIpOwoKICAgIHJldHVybiByZXN1bHQxIGFuZCByZXN1bHQyOwp9CgpmdW5jdGlvbiBMb2dNZXNzYWdlKGlzVmFsaWQ6IEJvb2wsIHZhbGlkTWVzc2FnZTogU3RyaW5nLCBpbnZhbGlkTWVzc2FnZTogU3RyaW5nKSA6ICgpCnsKICAgIGxldCBtZXNzYWdlID0gIntcInZhbGlkXCI6ICIgKyAoaXNWYWxpZCA/ICJ0cnVlIiB8ICJmYWxzZSIpICsgIiwgXCJtZXNzYWdlXCI6IFwiIiArIChpc1ZhbGlkID8gdmFsaWRNZXNzYWdlIHwgaW52YWxpZE1lc3NhZ2UpICsgIlwifSI7CiAgICBNZXNzYWdlKG1lc3NhZ2UpOwp9CgpvcGVyYXRpb24gRXhwZWN0ZWQgKHEgOiBRdWJpdCwgc2lnbiA6IEludCkgOiBVbml0IGlzIEFkagp7CiAgICBpZihzaWduIDwgMCkKICAgIHsKICAgICAgICBYKHEpOwogICAgfQoKICAgIEgocSk7Cn0KCjw8U09MVkU+Pg==",
//     ExpectedOutput = "true",
//     ExpectedStates = "",
//     CopilotInstructions = "",
//     Level = 2
// };