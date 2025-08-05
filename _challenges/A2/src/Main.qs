operation Main() : Bool
{    
    let i = Solve(I);
    let x = Solve(X);

    return i == 0 and x == 1;
}

// Distinguish I from X
// You are given an operation that implements a single-qubit unitary transformation: either the identity (I gate) or the X gate. The operation will have Adjoint and Controlled variants defined.
// Your task is to perform necessary operations and measurements to figure out which unitary it was and to return 0 if it was the I gate or 1 if it was the X gate.
// You are allowed to apply the given operation and its adjoint/controlled variants exactly once.
// You have to implement an operation which takes a single-qubit operation as an input and returns an integer. Your code should have the following signature:

operation Solve (unitary : (Qubit => Unit is Adj+Ctl)) : Int 
{
    use q = Qubit();
    unitary(q);    
    return MResetZ(q) == One ? 1 | 0;
}