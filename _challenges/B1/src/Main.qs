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
//     Description = "",
//     SolutionTemplate = "",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "",
//     ExpectedOutput = "",
//     Level = 0
// };