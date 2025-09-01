import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{
    // Wrap the H gate in a unitary operation to be able to check the number of times it was applied.
    let unitary1 = q => H(q);
    StartCountingOperation(unitary1);
    mutable result1Count = 0;
    for i in 1..10
    {
        let result1 = Solve(unitary1);
        set result1Count += result1 == 0 ? 1 | 0;
    }    
    LogMessage(result1Count == 10, "You have successfully identified the H-gate", "You have failed to identify the H-gate");
    let numberOfUnitary1 = StopCountingOperation(unitary1);
    LogMessage(numberOfUnitary1 == 20, "You have successfully applied the unitary operation exactly twice while identifying the H-gate", $"You have failed to apply the unitary operation exactly twice and applied it {numberOfUnitary1} times while identifying the H-gate");

    // Wrap the X gate in a unitary operation to be able to check the number of times it was applied.
    let unitary2 = q => X(q);
    StartCountingOperation(unitary2);
    mutable result2Count = 0;
    for i in 1..10
    {
        let result2 = Solve(unitary2);
        set result2Count += result2 == 1 ? 1 | 0;
    }
    LogMessage(result2Count == 10, "You have successfully identified the X-gate", "You have failed to identify the X-gate");
    let numberOfUnitary2 = StopCountingOperation(unitary2);
    LogMessage(numberOfUnitary2 == 20, "You have successfully applied the unitary operation exactly twice while identifying the X-gate", $"You have failed to apply the unitary operation exactly twice and applied it {numberOfUnitary2} times while identifying the X-gate");

    // Return true if the H gate was identified as 0 and the X gate as 1, and both unitary operations were applied exactly twice.
    return result1Count == 10 and numberOfUnitary1 == 20 and result2Count == 10 and numberOfUnitary2 == 20;
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

// Distinguish H from X
// You are given an operation that implements a single-qubit unitary transformation: either the Hadamard gate (H gate) or the bit-flip gate (X gate).
// Your task is to perform necessary operations and measurements to figure out which unitary it was and to return 0 if it was the H gate or 1 if it was the X gate.
// You are allowed to apply the given operation exactly twice.
// You have to implement an operation which takes a single-qubit operation as an input and returns an integer. The operation should have the following signature:

operation Solve (unitary : (Qubit => Unit)) : Int
{
    use q = Qubit();

    unitary(q);
    Z(q);
    unitary(q);

    return MResetZ(q) == Zero ? 1 | 0;
}

// public static Challenge CHALLENGE_B2 = new Challenge
// {
//     Name = "B2",
//     Title = "Distinguish H from X",
//     Description = "You are given an operation that implements a single-qubit unitary transformation: either the Hadamard gate (H gate) or the bit-flip gate (X gate).[BR]Your task is to perform necessary operations and measurements to figure out which unitary it was and to return 0 if it was the H gate or 1 if it was the X gate.[BR]You are allowed to apply the given operation exactly twice.[BR]You have to implement an operation which takes a single-qubit operation as an input and returns an integer. The operation should have the following signature:",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlICh1bml0YXJ5IDogKFF1Yml0ID0+IFVuaXQpKSA6IEludAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgLy8gV3JhcCB0aGUgSCBnYXRlIGluIGEgdW5pdGFyeSBvcGVyYXRpb24gdG8gYmUgYWJsZSB0byBjaGVjayB0aGUgbnVtYmVyIG9mIHRpbWVzIGl0IHdhcyBhcHBsaWVkLgogICAgbGV0IHVuaXRhcnkxID0gcSA9PiBIKHEpOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBtdXRhYmxlIHJlc3VsdDFDb3VudCA9IDA7CiAgICBmb3IgaSBpbiAxLi4xMAogICAgewogICAgICAgIGxldCByZXN1bHQxID0gU29sdmUodW5pdGFyeTEpOwogICAgICAgIHNldCByZXN1bHQxQ291bnQgKz0gcmVzdWx0MSA9PSAwID8gMSB8IDA7CiAgICB9ICAgIAogICAgTG9nTWVzc2FnZShyZXN1bHQxQ291bnQgPT0gMTAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgaWRlbnRpZmllZCB0aGUgSC1nYXRlIiwgIllvdSBoYXZlIGZhaWxlZCB0byBpZGVudGlmeSB0aGUgSC1nYXRlIik7CiAgICBsZXQgbnVtYmVyT2ZVbml0YXJ5MSA9IFN0b3BDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBMb2dNZXNzYWdlKG51bWJlck9mVW5pdGFyeTEgPT0gMjAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgYXBwbGllZCB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSB3aGlsZSBpZGVudGlmeWluZyB0aGUgSC1nYXRlIiwgJCJZb3UgaGF2ZSBmYWlsZWQgdG8gYXBwbHkgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgdHdpY2UgYW5kIGFwcGxpZWQgaXQge251bWJlck9mVW5pdGFyeTF9IHRpbWVzIHdoaWxlIGlkZW50aWZ5aW5nIHRoZSBILWdhdGUiKTsKCiAgICAvLyBXcmFwIHRoZSBYIGdhdGUgaW4gYSB1bml0YXJ5IG9wZXJhdGlvbiB0byBiZSBhYmxlIHRvIGNoZWNrIHRoZSBudW1iZXIgb2YgdGltZXMgaXQgd2FzIGFwcGxpZWQuCiAgICBsZXQgdW5pdGFyeTIgPSBxID0+IFgocSk7CiAgICBTdGFydENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkyKTsKICAgIG11dGFibGUgcmVzdWx0MkNvdW50ID0gMDsKICAgIGZvciBpIGluIDEuLjEwCiAgICB7CiAgICAgICAgbGV0IHJlc3VsdDIgPSBTb2x2ZSh1bml0YXJ5Mik7CiAgICAgICAgc2V0IHJlc3VsdDJDb3VudCArPSByZXN1bHQyID09IDEgPyAxIHwgMDsKICAgIH0KICAgIExvZ01lc3NhZ2UocmVzdWx0MkNvdW50ID09IDEwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgdGhlIFgtZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIFgtZ2F0ZSIpOwogICAgbGV0IG51bWJlck9mVW5pdGFyeTIgPSBTdG9wQ291bnRpbmdPcGVyYXRpb24odW5pdGFyeTIpOwogICAgTG9nTWVzc2FnZShudW1iZXJPZlVuaXRhcnkyID09IDIwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGFwcGxpZWQgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgdHdpY2Ugd2hpbGUgaWRlbnRpZnlpbmcgdGhlIFgtZ2F0ZSIsICQiWW91IGhhdmUgZmFpbGVkIHRvIGFwcGx5IHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIGFuZCBhcHBsaWVkIGl0IHtudW1iZXJPZlVuaXRhcnkyfSB0aW1lcyB3aGlsZSBpZGVudGlmeWluZyB0aGUgWC1nYXRlIik7CgogICAgLy8gUmV0dXJuIHRydWUgaWYgdGhlIEggZ2F0ZSB3YXMgaWRlbnRpZmllZCBhcyAwIGFuZCB0aGUgWCBnYXRlIGFzIDEsIGFuZCBib3RoIHVuaXRhcnkgb3BlcmF0aW9ucyB3ZXJlIGFwcGxpZWQgZXhhY3RseSB0d2ljZS4KICAgIHJldHVybiByZXN1bHQxQ291bnQgPT0gMTAgYW5kIG51bWJlck9mVW5pdGFyeTEgPT0gMjAgYW5kIHJlc3VsdDJDb3VudCA9PSAxMCBhbmQgbnVtYmVyT2ZVbml0YXJ5MiA9PSAyMDsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKPDxTT0xWRT4+",
//     ExpectedOutput = "true",
//     ExpectedStates = "",
//     CopilotInstructions = "",
//     Level = 2
// };