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
    LogMessage(numberOfUnitary1 == 10, "You have successfully applied the unitary operation exactly once", $"You have failed to apply the unitary operation exactly once and applied it {numberOfUnitary1} times");

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
    LogMessage(numberOfUnitary2 == 10, "You have successfully applied the unitary operation exactly once", $"You have failed to apply the unitary operation exactly once and applied it {numberOfUnitary2} times");

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
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgLy8gV3JhcCB0aGUgSSBnYXRlIGluIGEgdW5pdGFyeSBvcGVyYXRpb24gdG8gYmUgYWJsZSB0byBjaGVjayB0aGUgbnVtYmVyIG9mIHRpbWVzIGl0IHdhcyBhcHBsaWVkLgogICAgbGV0IHVuaXRhcnkxID0gcSA9PiBJKHEpOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBtdXRhYmxlIHJlc3VsdDFDb3VudCA9IDA7CiAgICBmb3IgaSBpbiAxLi4xMAogICAgewogICAgICAgIGxldCByZXN1bHQxID0gU29sdmUodW5pdGFyeTEpOwogICAgICAgIHNldCByZXN1bHQxQ291bnQgKz0gcmVzdWx0MSA9PSAwID8gMSB8IDA7CiAgICB9CiAgICBMb2dNZXNzYWdlKHJlc3VsdDFDb3VudCA9PSAxMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBpZGVudGlmaWVkIHRoZSBJLWdhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IHRoZSBJLWdhdGUiKTsKICAgIGxldCBudW1iZXJPZlVuaXRhcnkxID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkxKTsKICAgIExvZ01lc3NhZ2UobnVtYmVyT2ZVbml0YXJ5MSA9PSAxMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBhcHBsaWVkIHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IG9uY2UiLCAkIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSBvbmNlIGFuZCBhcHBsaWVkIGl0IHtudW1iZXJPZlVuaXRhcnkxfSB0aW1lcyIpOwoKICAgIC8vIFdyYXAgdGhlIFggZ2F0ZSBpbiBhIHVuaXRhcnkgb3BlcmF0aW9uIHRvIGJlIGFibGUgdG8gY2hlY2sgdGhlIG51bWJlciBvZiB0aW1lcyBpdCB3YXMgYXBwbGllZC4KICAgIGxldCB1bml0YXJ5MiA9IHEgPT4gWChxKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24odW5pdGFyeTIpOwogICAgbXV0YWJsZSByZXN1bHQyQ291bnQgPSAwOwogICAgZm9yIGkgaW4gMS4uMTAKICAgIHsKICAgICAgICBsZXQgcmVzdWx0MiA9IFNvbHZlKHVuaXRhcnkyKTsKICAgICAgICBzZXQgcmVzdWx0MkNvdW50ICs9IHJlc3VsdDIgPT0gMSA/IDEgfCAwOwogICAgfQogICAgTG9nTWVzc2FnZShyZXN1bHQyQ291bnQgPT0gMTAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgaWRlbnRpZmllZCB0aGUgWC1nYXRlIiwgIllvdSBoYXZlIGZhaWxlZCB0byBpZGVudGlmeSB0aGUgWC1nYXRlIik7CiAgICBsZXQgbnVtYmVyT2ZVbml0YXJ5MiA9IFN0b3BDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5Mik7CiAgICBMb2dNZXNzYWdlKG51bWJlck9mVW5pdGFyeTIgPT0gMTAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgYXBwbGllZCB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSBvbmNlIiwgJCJZb3UgaGF2ZSBmYWlsZWQgdG8gYXBwbHkgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgb25jZSBhbmQgYXBwbGllZCBpdCB7bnVtYmVyT2ZVbml0YXJ5Mn0gdGltZXMiKTsKCiAgICAvLyBSZXR1cm4gdHJ1ZSBpZiB0aGUgSSBnYXRlIHdhcyBpZGVudGlmaWVkIGFzIDAgYW5kIHRoZSBYIGdhdGUgYXMgMSwgYW5kIGJvdGggdW5pdGFyeSBvcGVyYXRpb25zIHdlcmUgYXBwbGllZCBleGFjdGx5IG9uY2UuCiAgICByZXR1cm4gcmVzdWx0MUNvdW50ID09IDEwIGFuZCBudW1iZXJPZlVuaXRhcnkxID09IDEwIGFuZCByZXN1bHQyQ291bnQgPT0gMTAgYW5kIG51bWJlck9mVW5pdGFyeTIgPT0gMTA7Cn0KCmZ1bmN0aW9uIExvZ01lc3NhZ2UoaXNWYWxpZDogQm9vbCwgdmFsaWRNZXNzYWdlOiBTdHJpbmcsIGludmFsaWRNZXNzYWdlOiBTdHJpbmcpIDogKCkKewogICAgbGV0IG1lc3NhZ2UgPSAie1widmFsaWRcIjogIiArIChpc1ZhbGlkID8gInRydWUiIHwgImZhbHNlIikgKyAiLCBcIm1lc3NhZ2VcIjogXCIiICsgKGlzVmFsaWQgPyB2YWxpZE1lc3NhZ2UgfCBpbnZhbGlkTWVzc2FnZSkgKyAiXCJ9IjsKICAgIE1lc3NhZ2UobWVzc2FnZSk7Cn0KCjw8U09MVkU+Pg==",
//     ExpectedOutput = "true",
//     ExpectedStates = "",
//     CopilotInstructions = "",
//     Level = 1
// };