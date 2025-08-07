import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{
    // Wrap the H gate in a unitary operation to be able to check the number of times it was applied.
    let unitary1 = q => H(q);
    StartCountingOperation(unitary1);
    let i = Solve(unitary1);
    LogMessage(i == 0, "You have successfully identified the H-gate", "You have failed to identify the H-gate");
    let numberOfUnitary1 = StopCountingOperation(unitary1);
    LogMessage(numberOfUnitary1 == 2, "You have successfully applied the unitary operation exactly twice", $"You have failed to apply the unitary operation exactly twice and applied it {numberOfUnitary1} times");

    // Wrap the X gate in a unitary operation to be able to check the number of times it was applied.
    let unitary2 = q => X(q);
    StartCountingOperation(unitary2);
    let x = Solve(unitary2);
    LogMessage(x == 1, "You have successfully identified the X-gate", "You have failed to identify the X-gate");
    let numberOfUnitary2 = StopCountingOperation(unitary2);
    LogMessage(numberOfUnitary2 == 2, "You have successfully applied the unitary operation exactly twice", $"You have failed to apply the unitary operation exactly twice and applied it {numberOfUnitary2} times");

    // Return true if the H gate was identified as 0 and the X gate as 1, and both unitary operations were applied exactly twice.
    return i == 0 and numberOfUnitary1 == 2 and x == 1 and numberOfUnitary2 == 2;
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

// Distinguish H from X
// You are given an operation that implements a single-qubit unitary transformation: either the Hadamard gate (H gate) or the bit-flip gate (X gate).
// Your task is to perform necessary operations and measurements to figure out which unitary it was and to return 0 if it was the H gate or 1 if it was the X gate.
// You are allowed to apply the given operation exactly twice.
// You have to implement an operation which takes a single-qubit operation as an input and returns an integer. The operation should have the following signature:

operation Solve (unitary : (Qubit => Unit)) : Int
{
    use q = Qubit();

    unitary(q);
    Z(q);
    unitary(q);

    return MResetZ(q) == Zero ? 1 | 0;
}

// public static Challenge CHALLENGE_B2 = new Challenge
// {
//     Name = "B2",
//     Title = "",
//     Description = "",
//     SolutionTemplate = "",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "",
//     ExpectedOutput = "",
//     Level = 2
// };