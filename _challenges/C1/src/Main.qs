import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{
    mutable resultCounter = 0;

    for i in 1..8
    {
        let result = CheckOperationsAreEqual(i, Solve, Expected);
        set resultCounter += result ? 1 | 0;
    }

    LogMessage(resultCounter == 8, "You have successfully generated the GHZ state", "You have failed to generate the GHZ state");

    use qs = Qubit[8];
    Solve(qs);
    DumpRegister(qs);
    ResetAll(qs);

    return resultCounter == 8;
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
//     Tldr = "You should implement the empty Solve operation below and prepare the Greenberger–Horne–Zeilinger (GHZ) on the provided qubits.",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxcyA6IFF1Yml0W10pIDogVW5pdAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgbXV0YWJsZSByZXN1bHRDb3VudGVyID0gMDsKCiAgICBmb3IgaSBpbiAxLi44CiAgICB7CiAgICAgICAgbGV0IHJlc3VsdCA9IENoZWNrT3BlcmF0aW9uc0FyZUVxdWFsKGksIFNvbHZlLCBFeHBlY3RlZCk7CiAgICAgICAgc2V0IHJlc3VsdENvdW50ZXIgKz0gcmVzdWx0ID8gMSB8IDA7CiAgICB9CgogICAgTG9nTWVzc2FnZShyZXN1bHRDb3VudGVyID09IDgsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIHRoZSBHSFogc3RhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGdlbmVyYXRlIHRoZSBHSFogc3RhdGUiKTsKCiAgICB1c2UgcXMgPSBRdWJpdFs4XTsKICAgIFNvbHZlKHFzKTsKICAgIER1bXBSZWdpc3Rlcihxcyk7CiAgICBSZXNldEFsbChxcyk7CgogICAgcmV0dXJuIHJlc3VsdENvdW50ZXIgPT0gODsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKb3BlcmF0aW9uIEV4cGVjdGVkIChxcyA6IFF1Yml0W10pIDogVW5pdCBpcyBBZGoKewogICAgSChxc1swXSk7CiAgICBmb3IgaSBpbiAxIC4uIExlbmd0aChxcykgLSAxCiAgICB7CiAgICAgICAgQ05PVChxc1swXSwgcXNbaV0pOwogICAgfQp9Cgo8PFNPTFZFPj4=",
//     ExpectedOutput = "true",
//     ExpectedStates = "WwogIHsKICAgICJpZCI6ICJ8MDAwMDAwMDDin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjcwNzEsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwxMTExMTExMeKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuNzA3MSwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfQpd",
//     CopilotInstructions = "",
//     Level = 3
// };