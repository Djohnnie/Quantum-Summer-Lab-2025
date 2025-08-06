import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{
    let unitary1 = q => I(q);
    StartCountingOperation(unitary1);
    let i = Solve(unitary1);
    LogMessage(i == 0, "You have successfully identified the I-gate", "You have failed to identify the I-gate");
    let numberOfUnitary1 = StopCountingOperation(unitary1);
    LogMessage(numberOfUnitary1 == 1, "You have successfully applied the unitary operation exactly once", "You have failed to apply the unitary operation exactly once");

    let unitary2 = q => X(q);
    StartCountingOperation(unitary2);
    let x = Solve(unitary2);
    LogMessage(x == 1, "You have successfully identified the X-gate", "You have failed to identify the X-gate");
    let numberOfUnitary2 = StopCountingOperation(unitary2);
    LogMessage(numberOfUnitary1 == 1, "You have successfully applied the unitary operation exactly once", "You have failed to apply the unitary operation exactly once");

    return i == 0 and numberOfUnitary1 == 1 and x == 1 and numberOfUnitary2 == 1;
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

// Distinguish I from X
// You are given an operation that implements a single-qubit unitary transformation: either the identity gate (I gate) or the bit-flip gate (X gate).
// Your task is to perform necessary operations and measurements to figure out which unitary it was and to return 0 if it was the I gate or 1 if it was the X gate.
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
//     Description = "You are given an operation that implements a single-qubit unitary transformation: either the identity gate (I gate) or the bit-flip gate (X gate).[BR]Your task is to perform necessary operations and measurements to figure out which unitary it was and to return 0 if it was the I gate or 1 if it was the X gate.[BR]You are allowed to apply the given operation exactly once.[BR]You have to implement an operation which takes a single-qubit operation as an input and returns an integer. The operation should have the following signature:",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlICh1bml0YXJ5IDogKFF1Yml0ID0+IFVuaXQpKSA6IEludAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgbGV0IHVuaXRhcnkxID0gcSA9PiBJKHEpOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBsZXQgaSA9IFNvbHZlKHVuaXRhcnkxKTsKICAgIExvZ01lc3NhZ2UoaSA9PSAwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgdGhlIEktZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIEktZ2F0ZSIpOwogICAgbGV0IG51bWJlck9mVW5pdGFyeTEgPSBTdG9wQ291bnRpbmdPcGVyYXRpb24odW5pdGFyeTEpOwogICAgTG9nTWVzc2FnZShudW1iZXJPZlVuaXRhcnkxID09IDEsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgYXBwbGllZCB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSBvbmNlIiwgIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSBvbmNlIik7CgogICAgbGV0IHVuaXRhcnkyID0gcSA9PiBYKHEpOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5Mik7CiAgICBsZXQgeCA9IFNvbHZlKHVuaXRhcnkyKTsKICAgIExvZ01lc3NhZ2UoeCA9PSAxLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgdGhlIFgtZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIFgtZ2F0ZSIpOwogICAgbGV0IG51bWJlck9mVW5pdGFyeTIgPSBTdG9wQ291bnRpbmdPcGVyYXRpb24odW5pdGFyeTIpOwogICAgTG9nTWVzc2FnZShudW1iZXJPZlVuaXRhcnkxID09IDEsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgYXBwbGllZCB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSBvbmNlIiwgIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSBvbmNlIik7CgogICAgcmV0dXJuIGkgPT0gMCBhbmQgbnVtYmVyT2ZVbml0YXJ5MSA9PSAxIGFuZCB4ID09IDEgYW5kIG51bWJlck9mVW5pdGFyeTIgPT0gMTsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKPDxTT0xWRT4+",
//     ExpectedOutput = "true",
//     Level = 0
// };