import Std.Diagnostics.*;

operation Main() : Bool
{  
    let result = CheckOperationsAreEqual(1, x => Solve(x[0]), x => Expected(x[0]));
    
    StartCountingOperation(X);
    StartCountingOperation(H);
    StartCountingOperation(Z);
    use q = Qubit();
    Solve(q);
    Reset(q);
    let resultX = StopCountingOperation(X);
    let resultH = StopCountingOperation(H);
    let resultZ = StopCountingOperation(Z);

    return result and resultX == 0 and resultH == 2 and resultZ == 1;
}

// Use only the Z and H gates to bitflip a qubit.
// You can bitflip a qubit by applying the X gate, but in this challenge you are only allowed to use the Z and H gates.
// You have to implement an operation which takes a single qubit as input and has no output.
// The "output" of your solution is the state in which it left the input qubit.

operation Solve (q : Qubit) : Unit
{
    H(q);
    Z(q);
    H(q);
}

operation Expected (q : Qubit) : Unit is Adj
{
    H(q);
    Z(q);
    H(q);
}