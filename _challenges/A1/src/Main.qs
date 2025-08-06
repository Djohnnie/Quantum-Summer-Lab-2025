import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{
    let result = CheckOperationsAreEqual(8, Solve, Expected);

    LogMessage(result, "You have successfully generated equal superposition of all basis states", "You have failed to generate equal superposition of all basis states");

    return result;
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
// You are given N qubits (1 ≤ N ≤ 8), prepared in the |0..0⟩ state, and you have to implement an operation which generates an equal superposition of all basis states on these qubits.
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
//     Description = "You are given N qubits (1 ≤ N ≤ 8), prepared in the |0..0⟩ state, and you have to implement an operation which generates an equal superposition of all basis states on these qubits.[BR]The \"output\" of your solution is the state in which it left the input qubits.[BR]You should implement the following Solve operation to make that happen and keep the signature of the method exactly like it is.",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxcyA6IFF1Yml0W10pIDogVW5pdCAKewogICAgLy8gWW91ciBzb2x1dGlvbiBsb2dpYyBnb2VzIGhlcmUuCn0=",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgbGV0IHJlc3VsdCA9IENoZWNrT3BlcmF0aW9uc0FyZUVxdWFsKDgsIFNvbHZlLCBFeHBlY3RlZCk7CgogICAgTG9nTWVzc2FnZShyZXN1bHQsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIGVxdWFsIHN1cGVycG9zaXRpb24gb2YgYWxsIGJhc2lzIHN0YXRlcyIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gZ2VuZXJhdGUgZXF1YWwgc3VwZXJwb3NpdGlvbiBvZiBhbGwgYmFzaXMgc3RhdGVzIik7CgogICAgcmV0dXJuIHJlc3VsdDsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKb3BlcmF0aW9uIEV4cGVjdGVkIChxcyA6IFF1Yml0W10pIDogVW5pdCBpcyBBZGoKewogICAgZm9yIHEgaW4gcXMgCiAgICB7CiAgICAgICAgSChxKTsKICAgIH0KfQoKPDxTT0xWRT4+",
//     ExpectedOutput = "true",
//     Level = 0
// };