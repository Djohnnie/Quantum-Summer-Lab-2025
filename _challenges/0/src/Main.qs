import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{ 
    let result1 = CheckOperationsAreEqual(1, x => Solve(x[0], Zero), x => Expected(x[0], Zero));
    mutable result1Count = 0;
    for i in 1..10
    {
        use q = Qubit();
        Solve(q, Zero);
        set result1Count += MResetZ(q) == Zero ? 1 | 0;
    }
    LogMessage(result1 and result1Count == 10, "You have successfully prepared the |0⟩ state", "You have failed to prepare the |0⟩ state");

    let result2 = CheckOperationsAreEqual(1, x => Solve(x[0], One), x => Expected(x[0], One));
    mutable result2Count = 0;
    for i in 1..10
    {
        use q = Qubit();
        Solve(q, One);
        set result2Count += MResetZ(q) == One ? 1 | 0;
    }
    LogMessage(result2 and result2Count == 10, "You have successfully prepared the |1⟩ state", "You have failed to prepare the |1⟩ state");

    return result1 and result1Count == 10 and result2 and result2Count == 10;
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

operation Expected (q : Qubit, expectedResult : Result) : Unit is Adj
{
    if(expectedResult == One) {
        X(q);
    }
}

// Example Challenge: Prepare |0⟩ or |1⟩
// You are given a single qubit, prepared in the |0⟩ state, and a Result with a possible Zero or One value.
// Make sure to change the qubit state and leave it in a |0⟩ or |1⟩ state that corresponds with the provided Result value.
// You should implement the following Solve operation to make that happen and keep the signature of the operation exactly like it is.
// Go ahead and copy/paste the following template in your Q# project in Visual Studio Code to start working on the solution.

operation Solve (q : Qubit, expectedResult : Result) : Unit
{
    if(expectedResult == One) {
        X(q);
    }
}

// public static Challenge CHALLENGE_0 = new Challenge
// {
//     Name = "0",
//     Title = "Example Challenge: Prepare |0⟩ or |1⟩",
//     Description = "You are given a single qubit, prepared in the |0⟩ state, and a Result with a possible Zero or One value.[BR]Make sure to change the qubit state and leave it in a |0⟩ or |1⟩ state that corresponds with the provided Result value.[BR]You should implement the following Solve operation to make that happen and keep the signature of the operation exactly like it is.[BR]Go ahead and copy/paste the following template in your Q# project in Visual Studio Code to start working on the solution.",
//     Tldr = "You should implement the empty Solve operation below and prepare a |0⟩ or |1⟩ quantum state depending on the provided expectedResult value.",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxIDogUXViaXQsIGV4cGVjdGVkUmVzdWx0IDogUmVzdWx0KSA6IFVuaXQKewogICAgLy8gWW91ciBzb2x1dGlvbiBsb2dpYyBnb2VzIGhlcmUuCn0=",
//     ExampleDescription = "Below, you can find a possible solution and additionally, just for reference, the code that will be executed internally to validate the submitted solution.[BR]You should only submit the Solve operation with your implemented solution, or in this example case, a copy from the provided solution below.",
//     ExampleCode = "b3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIHVzZSBxID0gUXViaXQoKTsKCiAgICBTb2x2ZShxLCBaZXJvKTsKICAgIGxldCBiMSA9IE0ocSk7CiAgICBSZXNldChxKTsKCiAgICBTb2x2ZShxLCBPbmUpOwogICAgbGV0IGIyID0gTShxKTsKICAgIFJlc2V0KHEpOwoKICAgIHJldHVybiBiMSA9PSBaZXJvIGFuZCBiMiA9PSBPbmU7Cn0KCm9wZXJhdGlvbiBTb2x2ZSAocSA6IFF1Yml0LCBleHBlY3RlZFJlc3VsdCA6IFJlc3VsdCkgOiBVbml0CnsKICAgIGlmKGV4cGVjdGVkUmVzdWx0ID09IE9uZSkgewogICAgICAgIFgocSk7CiAgICB9Cn0=",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAKICAgIGxldCByZXN1bHQxID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCBaZXJvKSwgeCA9PiBFeHBlY3RlZCh4WzBdLCBaZXJvKSk7CiAgICBtdXRhYmxlIHJlc3VsdDFDb3VudCA9IDA7CiAgICBmb3IgaSBpbiAxLi4xMAogICAgewogICAgICAgIHVzZSBxID0gUXViaXQoKTsKICAgICAgICBTb2x2ZShxLCBaZXJvKTsKICAgICAgICBzZXQgcmVzdWx0MUNvdW50ICs9IE1SZXNldFoocSkgPT0gWmVybyA/IDEgfCAwOwogICAgfQogICAgTG9nTWVzc2FnZShyZXN1bHQxIGFuZCByZXN1bHQxQ291bnQgPT0gMTAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgcHJlcGFyZWQgdGhlIHww4p+pIHN0YXRlIiwgIllvdSBoYXZlIGZhaWxlZCB0byBwcmVwYXJlIHRoZSB8MOKfqSBzdGF0ZSIpOwoKICAgIGxldCByZXN1bHQyID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCBPbmUpLCB4ID0+IEV4cGVjdGVkKHhbMF0sIE9uZSkpOwogICAgbXV0YWJsZSByZXN1bHQyQ291bnQgPSAwOwogICAgZm9yIGkgaW4gMS4uMTAKICAgIHsKICAgICAgICB1c2UgcSA9IFF1Yml0KCk7CiAgICAgICAgU29sdmUocSwgT25lKTsKICAgICAgICBzZXQgcmVzdWx0MkNvdW50ICs9IE1SZXNldFoocSkgPT0gT25lID8gMSB8IDA7CiAgICB9CiAgICBMb2dNZXNzYWdlKHJlc3VsdDIgYW5kIHJlc3VsdDJDb3VudCA9PSAxMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBwcmVwYXJlZCB0aGUgfDHin6kgc3RhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIHByZXBhcmUgdGhlIHwx4p+pIHN0YXRlIik7CgogICAgcmV0dXJuIHJlc3VsdDEgYW5kIHJlc3VsdDFDb3VudCA9PSAxMCBhbmQgcmVzdWx0MiBhbmQgcmVzdWx0MkNvdW50ID09IDEwOwp9CgpmdW5jdGlvbiBMb2dNZXNzYWdlKGlzVmFsaWQ6IEJvb2wsIHZhbGlkTWVzc2FnZTogU3RyaW5nLCBpbnZhbGlkTWVzc2FnZTogU3RyaW5nKSA6ICgpCnsKICAgIGxldCBtZXNzYWdlID0gIntcInZhbGlkXCI6ICIgKyAoaXNWYWxpZCA/ICJ0cnVlIiB8ICJmYWxzZSIpICsgIiwgXCJtZXNzYWdlXCI6IFwiIiArIChpc1ZhbGlkID8gdmFsaWRNZXNzYWdlIHwgaW52YWxpZE1lc3NhZ2UpICsgIlwifSI7CiAgICBNZXNzYWdlKG1lc3NhZ2UpOwp9CgpvcGVyYXRpb24gRXhwZWN0ZWQgKHEgOiBRdWJpdCwgZXhwZWN0ZWRSZXN1bHQgOiBSZXN1bHQpIDogVW5pdCBpcyBBZGoKewogICAgaWYoZXhwZWN0ZWRSZXN1bHQgPT0gT25lKSB7CiAgICAgICAgWChxKTsKICAgIH0KfQoKPDxTT0xWRT4+",
//     ExpectedOutput = "true",
//     ExpectedStates = "",
//     CopilotInstructions = "Challenge 0 is an example challenge that demonstrates how to use this platform to solve challenges. You can help the user in any way you can.",
//     Level = 0
// };