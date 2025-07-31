operation Main() : Bool
{    
    use q = Qubit();

    Solve(q, Zero);
    let b1 = M(q);
    Reset(q);

    Solve(q, One);
    let b2 = M(q);
    Reset(q);

    return b1 == Zero and b2 == One;
}

operation Solve (q : Qubit, expectedResult : Result) : Unit
{
    if(expectedResult == One) {
        X(q);
    }
}