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

// Example Challenge
// You are given a single qubit, prepared in the |0⟩ state, and a Result with a possible Zero or One value.
// Make sure to change the qubit state and leave it in a state that corresponds with the provided Result value.

operation Solve (q : Qubit, expectedResult : Result) : Unit
{
    if(expectedResult == One) {
        X(q);
    }
}