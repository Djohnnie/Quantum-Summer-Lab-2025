import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{    
    let result0 = CheckOperationsAreEqual(2, x => Solve(x, 0), x => Expected(x, 0));
    LogMessage(result0, "You have successfully generated the |B0⟩ = 1/√2 (|00⟩ + |11⟩) for index 0", "You have failed to generate the |B0⟩ = 1/√2 (|00⟩ + |11⟩) state for index 0");
    
    let result1 = CheckOperationsAreEqual(2, x => Solve(x, 1), x => Expected(x, 1));
    LogMessage(result1, "You have successfully generated the |B1⟩ = 1/√2 (|00⟩ - |11⟩) for index 1", "You have failed to generate the |B1⟩ = 1/√2 (|00⟩ - |11⟩) state for index 1");

    let result2 = CheckOperationsAreEqual(2, x => Solve(x, 2), x => Expected(x, 2));
    LogMessage(result2, "You have successfully generated the |B2⟩ = 1/√2 (|01⟩ + |10⟩) for index 2", "You have failed to generate the |B2⟩ = 1/√2 (|01⟩ + |10⟩) state for index 2");

    let result3 = CheckOperationsAreEqual(2, x => Solve(x, 3), x => Expected(x, 3));
    LogMessage(result3, "You have successfully generated the |B3⟩ = 1/√2 (|01⟩ - |10⟩) for index 3", "You have failed to generate the |B3⟩ = 1/√2 (|01⟩ - |10⟩) state for index 3");

    return result0 and result1 and result2 and result3;
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

operation Expected (qs : Qubit[], index : Int) : Unit is Adj
{
    // Put the first qubit in superposition.
    H(qs[0]);

    // If the result should be |00⟩ - |11⟩ or |01⟩ - |10⟩, we need to apply the Z-gate to alter the sign.
    if(index % 2 == 1)
    {
        Z(qs[0]);
    }
    
    // Apply the CNOT gate to entangle the qubits.
    CNOT(qs[0], qs[1]);
    
    // If the result should be |01⟩ + |10⟩ or |01⟩ - |10⟩, we need to apply the X-gate to the second qubit.
    if(index / 2 == 1)
    {
        X(qs[1]);
    }
}

// Generate Bell state.
// You are given two qubits in state |00⟩ and an integer index. Your task is to create one of the Bell states on them according to the index:
// 0: |B0⟩ = 1/√2 (|00⟩ + |11⟩)
// 1: |B1⟩ = 1/√2 (|00⟩ - |11⟩)
// 2: |B2⟩ = 1/√2 (|01⟩ + |10⟩)
// 3: |B3⟩ = 1/√2 (|01⟩ - |10⟩)

operation Solve (qs : Qubit[], index : Int) : Unit
{
    H(qs[0]);

    if(index % 2 == 1)
    {
        Z(qs[0]);
    }
    
    CNOT(qs[0], qs[1]);
    
    if(index / 2 == 1)
    {
        X(qs[1]);
    }
}

// public static Challenge CHALLENGE_B3 = new Challenge
// {
//     Name = "B3",
//     Title = "",
//     Description = "",
//     SolutionTemplate = "",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "",
//     ExpectedOutput = "",
//     Level = 2
// };