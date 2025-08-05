import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{    
    let result = CheckOperationsAreEqual(8, Solve, Expected);

    return result;
}

operation Expected (qs : Qubit[]) : Unit is Adj
{
    for q in qs 
    {
        H(q);
    }
}

// Generate superposition of all basis states.
// You are given N qubits (1 ≤ N ≤ 8), prepared in the |0..0⟩ state, and you have to implement an operation which generates a superposition of all basis states on these qubits.
// The "output" of your solution is the state in which it left the input qubits.

operation Solve (qs : Qubit[]) : Unit 
{
    ApplyToEach(H, qs);
}