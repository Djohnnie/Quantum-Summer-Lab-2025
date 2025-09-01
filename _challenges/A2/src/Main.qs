import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{
    // Wrap the I gate in a unitary operation to be able to check the number of times it was applied.
    let unitary1 = q => I(q);
    StartCountingOperation(unitary1);
    mutable result1Count = 0;
    for i in 1..10
    {
        let result1 = Solve(unitary1);
        set result1Count += result1 == 0 ? 1 | 0;
    }
    LogMessage(result1Count == 10, "You have successfully identified the I-gate", "You have failed to identify the I-gate");
    let numberOfUnitary1 = StopCountingOperation(unitary1);
    LogMessage(numberOfUnitary1 == 10, "You have successfully applied the unitary operation exactly once while identifying the I-gate", $"You have failed to apply the unitary operation exactly once and applied it {numberOfUnitary1} times while identifying the I-gate");

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
    LogMessage(numberOfUnitary2 == 10, "You have successfully applied the unitary operation exactly once while identifying the X-gate", $"You have failed to apply the unitary operation exactly once and applied it {numberOfUnitary2} times while identifying the X-gate");

    // Return true if the I gate was identified as 0 and the X gate as 1, and both unitary operations were applied exactly once.
    return result1Count == 10 and numberOfUnitary1 == 10 and result2Count == 10 and numberOfUnitary2 == 10;
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

// Distinguish I from X
// You are given an operation that implements a single-qubit unitary transformation: either the identity gate (I gate) or the bit-flip gate (X gate).
// Your task is to perform necessary operations and/or measurements to figure out which unitary it was and to return 0 if it was the I gate or 1 if it was the X gate.
// You are allowed to apply the given operation exactly once.
// You have to implement an operation which takes a single-qubit operation as an input and returns an integer. The operation should have the following signature:

operation Solve (unitary : (Qubit => Unit)) : Int
{
    use q = Qubit();
    unitary(q);
    return MResetZ(q) == One ? 1 | 0;
}

// public static Challenge CHALLENGE_A2 = new Challenge
// {
//     Name = "A2",
//     Title = "Distinguish I from X",
//     Description = "You are given an operation that implements a single-qubit unitary transformation: either the identity gate (I gate) or the bit-flip gate (X gate).[BR]Your task is to perform necessary operations and/or measurements to figure out which unitary it was and to return 0 if it was the I gate or 1 if it was the X gate.[BR]You are allowed to apply the given operation exactly once.[BR]You have to implement an operation which takes a single-qubit operation as an input and returns an integer. The operation should have the following signature:",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlICh1bml0YXJ5IDogKFF1Yml0ID0+IFVuaXQpKSA6IEludAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgLy8gV3JhcCB0aGUgSSBnYXRlIGluIGEgdW5pdGFyeSBvcGVyYXRpb24gdG8gYmUgYWJsZSB0byBjaGVjayB0aGUgbnVtYmVyIG9mIHRpbWVzIGl0IHdhcyBhcHBsaWVkLgogICAgbGV0IHVuaXRhcnkxID0gcSA9PiBJKHEpOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBtdXRhYmxlIHJlc3VsdDFDb3VudCA9IDA7CiAgICBmb3IgaSBpbiAxLi4xMAogICAgewogICAgICAgIGxldCByZXN1bHQxID0gU29sdmUodW5pdGFyeTEpOwogICAgICAgIHNldCByZXN1bHQxQ291bnQgKz0gcmVzdWx0MSA9PSAwID8gMSB8IDA7CiAgICB9CiAgICBMb2dNZXNzYWdlKHJlc3VsdDFDb3VudCA9PSAxMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBpZGVudGlmaWVkIHRoZSBJLWdhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IHRoZSBJLWdhdGUiKTsKICAgIGxldCBudW1iZXJPZlVuaXRhcnkxID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkxKTsKICAgIExvZ01lc3NhZ2UobnVtYmVyT2ZVbml0YXJ5MSA9PSAxMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBhcHBsaWVkIHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IG9uY2Ugd2hpbGUgaWRlbnRpZnlpbmcgdGhlIEktZ2F0ZSIsICQiWW91IGhhdmUgZmFpbGVkIHRvIGFwcGx5IHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IG9uY2UgYW5kIGFwcGxpZWQgaXQge251bWJlck9mVW5pdGFyeTF9IHRpbWVzIHdoaWxlIGlkZW50aWZ5aW5nIHRoZSBJLWdhdGUiKTsKCiAgICAvLyBXcmFwIHRoZSBYIGdhdGUgaW4gYSB1bml0YXJ5IG9wZXJhdGlvbiB0byBiZSBhYmxlIHRvIGNoZWNrIHRoZSBudW1iZXIgb2YgdGltZXMgaXQgd2FzIGFwcGxpZWQuCiAgICBsZXQgdW5pdGFyeTIgPSBxID0+IFgocSk7CiAgICBTdGFydENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkyKTsKICAgIG11dGFibGUgcmVzdWx0MkNvdW50ID0gMDsKICAgIGZvciBpIGluIDEuLjEwCiAgICB7CiAgICAgICAgbGV0IHJlc3VsdDIgPSBTb2x2ZSh1bml0YXJ5Mik7CiAgICAgICAgc2V0IHJlc3VsdDJDb3VudCArPSByZXN1bHQyID09IDEgPyAxIHwgMDsKICAgIH0KICAgIExvZ01lc3NhZ2UocmVzdWx0MkNvdW50ID09IDEwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgdGhlIFgtZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIFgtZ2F0ZSIpOwogICAgbGV0IG51bWJlck9mVW5pdGFyeTIgPSBTdG9wQ291bnRpbmdPcGVyYXRpb24odW5pdGFyeTIpOwogICAgTG9nTWVzc2FnZShudW1iZXJPZlVuaXRhcnkyID09IDEwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGFwcGxpZWQgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgb25jZSB3aGlsZSBpZGVudGlmeWluZyB0aGUgWC1nYXRlIiwgJCJZb3UgaGF2ZSBmYWlsZWQgdG8gYXBwbHkgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgb25jZSBhbmQgYXBwbGllZCBpdCB7bnVtYmVyT2ZVbml0YXJ5Mn0gdGltZXMgd2hpbGUgaWRlbnRpZnlpbmcgdGhlIFgtZ2F0ZSIpOwoKICAgIC8vIFJldHVybiB0cnVlIGlmIHRoZSBJIGdhdGUgd2FzIGlkZW50aWZpZWQgYXMgMCBhbmQgdGhlIFggZ2F0ZSBhcyAxLCBhbmQgYm90aCB1bml0YXJ5IG9wZXJhdGlvbnMgd2VyZSBhcHBsaWVkIGV4YWN0bHkgb25jZS4KICAgIHJldHVybiByZXN1bHQxQ291bnQgPT0gMTAgYW5kIG51bWJlck9mVW5pdGFyeTEgPT0gMTAgYW5kIHJlc3VsdDJDb3VudCA9PSAxMCBhbmQgbnVtYmVyT2ZVbml0YXJ5MiA9PSAxMDsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKPDxTT0xWRT4+",
//     ExpectedOutput = "true",
//     ExpectedStates = "",
//     CopilotInstructions = "",
//     Level = 1
// };