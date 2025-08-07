import Std.Convert.ResultArrayAsInt;
import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{
    // Wrap the I ⊗ I gate in a unitary operation to be able to check the number of times it was applied.
    let unitary0 = qs => ApplyToEach(I, qs);
    StartCountingOperation(unitary0);
    let result0 = Solve(unitary0);
    LogMessage(result0 == 0, "You have successfully identified the I ⊗ I gate", "You have failed to identify the I ⊗ I gate");
    let numberOfUnitary0 = StopCountingOperation(unitary0);
    LogMessage(numberOfUnitary0 == 2, "You have successfully applied the unitary operation exactly twice", $"You have failed to apply the unitary operation exactly twice and applied it {numberOfUnitary0} times");

    // Wrap the CNOT12 gate in a unitary operation to be able to check the number of times it was applied.
    let unitary1 = qs => CNOT(qs[0], qs[1]);
    StartCountingOperation(unitary1);
    let result1 = Solve(unitary1);
    LogMessage(result1 == 1, "You have successfully identified the CNOT12 gate", "You have failed to identify the CNOT12 gate");
    let numberOfUnitary1 = StopCountingOperation(unitary1);
    LogMessage(numberOfUnitary1 == 2, "You have successfully applied the unitary operation exactly twice", $"You have failed to apply the unitary operation exactly twice and applied it {numberOfUnitary0} times");

    // Wrap the CNOT21 gate in a unitary operation to be able to check the number of times it was applied.
    let unitary2 = qs => CNOT(qs[1], qs[0]);
    StartCountingOperation(unitary2);
    let result2 = Solve(unitary2);
    LogMessage(result2 == 2, "You have successfully identified the CNOT21 gate", "You have failed to identify the CNOT21 gate");
    let numberOfUnitary2 = StopCountingOperation(unitary2);
    LogMessage(numberOfUnitary2 == 2, "You have successfully applied the unitary operation exactly twice", $"You have failed to apply the unitary operation exactly twice and applied it {numberOfUnitary2} times");

    // Wrap the SWAP gate in a unitary operation to be able to check the number of times it was applied.
    let unitary3 = qs => SWAP(qs[0], qs[1]);
    StartCountingOperation(unitary3);
    let result3 = Solve(unitary3);
    LogMessage(result3 == 3, "You have successfully identified the SWAP gate", "You have failed to identify the SWAP gate");
    let numberOfUnitary3 = StopCountingOperation(unitary3);
    LogMessage(numberOfUnitary3 == 2, "You have successfully applied the unitary operation exactly twice", $"You have failed to apply the unitary operation exactly twice and applied it {numberOfUnitary3} times");

    // Return true if the I ⊗ I gate was identified as 0, the CNOT12 gate as 1, the CNOT21 gate as 2, the SWAP gate as 3, and all unitary operations were applied exactly twice.
    return result0 == 0 and numberOfUnitary0 == 2 and result1 == 1 and numberOfUnitary1 == 2 and result2 == 2 and numberOfUnitary2 == 2 and result3 == 3 and numberOfUnitary3 == 2;
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

// Distinguish I, CNOTs and SWAP
// TODO
// 0 if it was the I ⊗ I gate,
// 1 if it was the CNOT12 gate,
// 2 if it was the CNOT21 gate,
// 3 if it was the SWAP gate.

operation Solve (unitary : (Qubit[] => Unit)) : Int
{
    // Prepare four qubits in the |0000⟩ state.
    use qs = Qubit[4];

    // Prepare the |0110⟩ state by applying the X gate to the second and third qubit.
    ApplyToEach(X, qs[1..2]);

    // Apply the two-qubit unitary transformation twice.
    // First, apply it to the first two qubits, then to the last two qubits.
    unitary(qs[0..1]);
    unitary(qs[2..3]);

    // Measure the first and last qubits.
    let b1 = MResetZ(qs[0]);
    let b2 = MResetZ(qs[3]);

    // Reset the qubits.
    MResetEachZ(qs);

    // Return an integer based on the measurement results using the little-endian format.
    return ResultArrayAsInt([b2, b1]);
}

// public static Challenge CHALLENGE_C2 = new Challenge
// {
//     Name = "C2",
//     Title = "",
//     Description = "",
//     SolutionTemplate = "",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "",
//     ExpectedOutput = "",
//     Level = 2
// };