operation Main() : Bool
{    
    use q = Qubit();

    Solve(q, Zero);
    let b1 = MResetZ(q);

    Solve(q, One);
    let b2 = MResetZ(q);

    return b1 == Zero and b2 == One;
}

operation Solve (q : Qubit, expectedResult : Result) : Unit
{
    if(expectedResult == One) {
        X(q);
    }
}