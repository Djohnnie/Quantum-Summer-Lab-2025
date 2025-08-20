import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{    
    let result = CheckOperationsAreEqual(2, Solve, Expected);
    //LogMessage(result, "You have successfully generated the GHZ state", "You have failed to generate the GHZ state");
    
    DumpOperation(2,Solve);
    DumpOperation(2,Expected);

    use qs = Qubit[2];
    Solve(qs);
    DumpRegister(qs);
    ResetAll(qs);

    return result;
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

operation Expected (qs : Qubit[]) : Unit is Adj
{
    Ry(2.0 * ArcSin(1.0 / Sqrt(3.0)), qs[0]);
    ApplyControlledOnInt(0, H,[qs[0]], qs[1]);
}

// Generate state |00⟩ + |01⟩ + |10⟩.
// TODO

operation Solve (qs : Qubit[]) : Unit
{
    // Use an extra ancilla qubit to create the desired state.
    use ancilla = Qubit();

    mutable result = Zero;

    repeat
    {
        // Prepare an equal superposition of |000⟩, |010⟩, |100⟩ and |110⟩ states.
        ApplyToEach(H, qs);

        // Apply a controlled X gate to create the desired superposition.
        // |000⟩, |010⟩, |100⟩ and |111⟩
        Controlled X(qs, ancilla);

        set result = MResetZ(ancilla);
    }
    until (result == Zero)
    fixup
    {
        // Reset the ancilla qubit to |0⟩ state.
        ResetAll(qs);
    }
}

// public static Challenge CHALLENGE_C3 = new Challenge
// {
//     Name = "C3",
//     Title = "",
//     Description = "",
//     SolutionTemplate = "",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "",
//     ExpectedOutput = "",
//     ExpectedStates = "",
//     CopilotInstructions = "",
//     Level = 3
// };