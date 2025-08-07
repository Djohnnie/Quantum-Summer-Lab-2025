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

// Generate GHZ state.
// Your task is to create Greenberger–Horne–Zeilinger (GHZ) state on N qubits (1 ≤ N ≤ 8) in zero |0..0⟩ state.

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
//     Title = "",
//     Description = "",
//     SolutionTemplate = "",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "",
//     ExpectedOutput = "",
//     Level = 0
// };