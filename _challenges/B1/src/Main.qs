import Std.Diagnostics.*;

operation Main() : Bool
{    
    let result1 = CheckOperationsAreEqual(1, x => Solve(x[0], 1), x => Expected(x[0], 1));
    let result2 = CheckOperationsAreEqual(1, x => Solve(x[0], -1), x => Expected(x[0], -1));

    return result1 and result2;
}

// Generate |+⟩ state or |-⟩ state.
// You have to implement an operation which takes a qubit and an integer as an input and has no output.
// The "output" of your solution is the state in which it left the input qubit.

operation Solve (q : Qubit, sign : Int) : Unit
{
    if(sign < 0)
    {
        X(q);
    }

    H(q);
}

operation Expected (q : Qubit, sign : Int) : Unit is Adj
{
    if(sign < 0)
    {
        X(q);
    }

    H(q);
}