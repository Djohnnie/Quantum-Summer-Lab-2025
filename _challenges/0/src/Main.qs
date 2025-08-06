import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{    
    let result1 = CheckOperationsAreEqual(1, x => Solve(x[0], Zero), x => Expected(x[0], Zero));
    let result2 = CheckOperationsAreEqual(1, x => Solve(x[0], One), x => Expected(x[0], One));

    return result1 and result2;
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
// You should implement the following Solve method to make that happen and keep the signature of the method exactly like it is.
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
//     Description = "You are given a single qubit, prepared in the |0⟩ state, and a Result with a possible Zero or One value.[BR]Make sure to change the qubit state and leave it in a |0⟩ or |1⟩ state that corresponds with the provided Result value.[BR]You should implement the following Solve method to make that happen and keep the signature of the method exactly like it is.[BR]Go ahead and copy/paste the following template in your Q# project in Visual Studio Code to start working on the solution.",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxIDogUXViaXQsIGV4cGVjdGVkUmVzdWx0IDogUmVzdWx0KSA6IFVuaXQKewogICAgLy8gWW91ciBzb2x1dGlvbiBsb2dpYyBnb2VzIGhlcmUuCn0=",
//     ExampleDescription = "Below, you can find a possible solution and additionally, just for reference, the code that will be executed internally to validate the submitted solution.[BR]You should only submit the Solve operation with your implemented solution, or in this example case, a copy from the provided solution below.",
//     ExampleCode = "b3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIHVzZSBxID0gUXViaXQoKTsKCiAgICBTb2x2ZShxLCBaZXJvKTsKICAgIGxldCBiMSA9IE0ocSk7CiAgICBSZXNldChxKTsKCiAgICBTb2x2ZShxLCBPbmUpOwogICAgbGV0IGIyID0gTShxKTsKICAgIFJlc2V0KHEpOwoKICAgIHJldHVybiBiMSA9PSBaZXJvIGFuZCBiMiA9PSBPbmU7Cn0KCm9wZXJhdGlvbiBTb2x2ZSAocSA6IFF1Yml0LCBleHBlY3RlZFJlc3VsdCA6IFJlc3VsdCkgOiBVbml0CnsKICAgIGlmKGV4cGVjdGVkUmVzdWx0ID09IE9uZSkgewogICAgICAgIFgocSk7CiAgICB9Cn0=",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIGxldCByZXN1bHQxID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCBaZXJvKSwgeCA9PiBFeHBlY3RlZCh4WzBdLCBaZXJvKSk7CiAgICBsZXQgcmVzdWx0MiA9IENoZWNrT3BlcmF0aW9uc0FyZUVxdWFsKDEsIHggPT4gU29sdmUoeFswXSwgT25lKSwgeCA9PiBFeHBlY3RlZCh4WzBdLCBPbmUpKTsKCiAgICByZXR1cm4gcmVzdWx0MSBhbmQgcmVzdWx0MjsKfQoKb3BlcmF0aW9uIEV4cGVjdGVkIChxIDogUXViaXQsIGV4cGVjdGVkUmVzdWx0IDogUmVzdWx0KSA6IFVuaXQgaXMgQWRqCnsKICAgIGlmKGV4cGVjdGVkUmVzdWx0ID09IE9uZSkgewogICAgICAgIFgocSk7CiAgICB9Cn0KCjw8U09MVkU+Pg==",
//     ExpectedOutput = "true",
//     Level = 0
// };