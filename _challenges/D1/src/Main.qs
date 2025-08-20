import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{    
    let result = CheckOperationsAreEqual(8, Solve, Expected);
    LogMessage(result, "You have successfully generated the GHZ state", "You have failed to generate the GHZ state");
    
    return result;
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

operation Expected (qs : Qubit[]) : Unit is Adj
{
    H(qs[0]);
    for i in 1 .. Length(qs) - 1
    {
        CNOT(qs[0], qs[i]);
    }
}

// Generate GHZ state
// Your task is to create Greenberger–Horne–Zeilinger (GHZ) state on N qubits (1 ≤ N ≤ 8) in zero |0..0⟩ state.
// The GHZ state is defined as |GHZ⟩ = 1/√2 (|0..0⟩ + |1..1⟩).
// You have to implement an operation which takes an array of N qubits and you need to create the GHZ state on them. The operation should have the following signature:

operation Solve (qs : Qubit[]) : Unit
{
    H(qs[0]);
    for i in 1 .. Length(qs) - 1
    {
        CNOT(qs[0], qs[i]);
    }
}

// public static Challenge CHALLENGE_C1 = new Challenge
// {
//     Name = "C1",
//     Title = "Generate GHZ state",
//     Description = "Your task is to create Greenberger–Horne–Zeilinger (GHZ) state on N qubits (1 ≤ N ≤ 8) in zero |0..0⟩ state.[BR]The GHZ state is defined as |GHZ⟩ = 1/√2 (|0..0⟩ + |1..1⟩).[BR]You have to implement an operation which takes an array of N qubits and you need to create the GHZ state on them. The operation should have the following signature:",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxcyA6IFF1Yml0W10pIDogVW5pdAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIGxldCByZXN1bHQgPSBDaGVja09wZXJhdGlvbnNBcmVFcXVhbCg4LCBTb2x2ZSwgRXhwZWN0ZWQpOwogICAgTG9nTWVzc2FnZShyZXN1bHQsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIHRoZSBHSFogc3RhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGdlbmVyYXRlIHRoZSBHSFogc3RhdGUiKTsKICAgIAogICAgcmV0dXJuIHJlc3VsdDsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKb3BlcmF0aW9uIEV4cGVjdGVkIChxcyA6IFF1Yml0W10pIDogVW5pdCBpcyBBZGoKewogICAgSChxc1swXSk7CiAgICBmb3IgaSBpbiAxIC4uIExlbmd0aChxcykgLSAxCiAgICB7CiAgICAgICAgQ05PVChxc1swXSwgcXNbaV0pOwogICAgfQp9Cgo8PFNPTFZFPj4=",
//     ExpectedOutput = "true",
//     ExpectedStates = "",
//     CopilotInstructions = "",
//     Level = 3
// };