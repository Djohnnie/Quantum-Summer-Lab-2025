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
// You are given an operation that implements a two-qubit unitary transformation: either the identity (I ⊗ I gate), the CNOT gate (either with the first qubit as control and the second qubit as target or vice versa) or the SWAP gate.
// Your task is to perform necessary operations and measurements to figure out which unitary it was and to return:
// 0 if it was the I ⊗ I gate,
// 1 if it was the CNOT12 gate,
// 2 if it was the CNOT21 gate,
// 3 if it was the SWAP gate.
// You are allowed to apply the given operation exactly twice.
// You have to implement an operation which takes a two-qubit operation unitary as an input and returns an integer. The operation unitary will accept an array of qubits as input, but it will fail if the array is empty or has one or more than two qubits. Your code should have the following signature:

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
//     Title = "Distinguish I, CNOTs and SWAP",
//     Description = "You are given an operation that implements a two-qubit unitary transformation: either the identity (I ⊗ I gate), the CNOT gate (either with the first qubit as control and the second qubit as target or vice versa) or the SWAP gate.[BR]Your task is to perform necessary operations and measurements to figure out which unitary it was and to return:[BR]0 if it was the I ⊗ I gate,[BR]1 if it was the CNOT12 gate,[BR]2 if it was the CNOT21 gate,[BR]3 if it was the SWAP gate.[BR]You are allowed to apply the given operation exactly twice.[BR]You have to implement an operation which takes a two-qubit operation unitary as an input and returns an integer. The operation unitary will accept an array of qubits as input, but it will fail if the array is empty or has one or more than two qubits. Your code should have the following signature:",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlICh1bml0YXJ5IDogKFF1Yml0W10gPT4gVW5pdCkpIDogSW50CnsKICAgIC8vIFlvdXIgc29sdXRpb24gbG9naWMgZ29lcyBoZXJlLgp9",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Db252ZXJ0LlJlc3VsdEFycmF5QXNJbnQ7CmltcG9ydCBTdGQuQXJpdGhtZXRpYy4qOwppbXBvcnQgU3RkLkNhbm9uLio7CmltcG9ydCBTdGQuRGlhZ25vc3RpY3MuKjsKaW1wb3J0IFN0ZC5NYXRoLio7CmltcG9ydCBTdGQuTWVhc3VyZW1lbnQuKjsKCm9wZXJhdGlvbiBNYWluKCkgOiBCb29sCnsKICAgIC8vIFdyYXAgdGhlIEkg4oqXIEkgZ2F0ZSBpbiBhIHVuaXRhcnkgb3BlcmF0aW9uIHRvIGJlIGFibGUgdG8gY2hlY2sgdGhlIG51bWJlciBvZiB0aW1lcyBpdCB3YXMgYXBwbGllZC4KICAgIGxldCB1bml0YXJ5MCA9IHFzID0+IEFwcGx5VG9FYWNoKEksIHFzKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24odW5pdGFyeTApOwogICAgbGV0IHJlc3VsdDAgPSBTb2x2ZSh1bml0YXJ5MCk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDAgPT0gMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBpZGVudGlmaWVkIHRoZSBJIOKKlyBJIGdhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IHRoZSBJIOKKlyBJIGdhdGUiKTsKICAgIGxldCBudW1iZXJPZlVuaXRhcnkwID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkwKTsKICAgIExvZ01lc3NhZ2UobnVtYmVyT2ZVbml0YXJ5MCA9PSAyLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGFwcGxpZWQgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgdHdpY2UiLCAkIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSBhbmQgYXBwbGllZCBpdCB7bnVtYmVyT2ZVbml0YXJ5MH0gdGltZXMiKTsKCiAgICAvLyBXcmFwIHRoZSBDTk9UMTIgZ2F0ZSBpbiBhIHVuaXRhcnkgb3BlcmF0aW9uIHRvIGJlIGFibGUgdG8gY2hlY2sgdGhlIG51bWJlciBvZiB0aW1lcyBpdCB3YXMgYXBwbGllZC4KICAgIGxldCB1bml0YXJ5MSA9IHFzID0+IENOT1QocXNbMF0sIHFzWzFdKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24odW5pdGFyeTEpOwogICAgbGV0IHJlc3VsdDEgPSBTb2x2ZSh1bml0YXJ5MSk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDEgPT0gMSwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBpZGVudGlmaWVkIHRoZSBDTk9UMTIgZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIENOT1QxMiBnYXRlIik7CiAgICBsZXQgbnVtYmVyT2ZVbml0YXJ5MSA9IFN0b3BDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBMb2dNZXNzYWdlKG51bWJlck9mVW5pdGFyeTEgPT0gMiwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBhcHBsaWVkIHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIiwgJCJZb3UgaGF2ZSBmYWlsZWQgdG8gYXBwbHkgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgdHdpY2UgYW5kIGFwcGxpZWQgaXQge251bWJlck9mVW5pdGFyeTB9IHRpbWVzIik7CgogICAgLy8gV3JhcCB0aGUgQ05PVDIxIGdhdGUgaW4gYSB1bml0YXJ5IG9wZXJhdGlvbiB0byBiZSBhYmxlIHRvIGNoZWNrIHRoZSBudW1iZXIgb2YgdGltZXMgaXQgd2FzIGFwcGxpZWQuCiAgICBsZXQgdW5pdGFyeTIgPSBxcyA9PiBDTk9UKHFzWzFdLCBxc1swXSk7CiAgICBTdGFydENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkyKTsKICAgIGxldCByZXN1bHQyID0gU29sdmUodW5pdGFyeTIpOwogICAgTG9nTWVzc2FnZShyZXN1bHQyID09IDIsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgaWRlbnRpZmllZCB0aGUgQ05PVDIxIGdhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IHRoZSBDTk9UMjEgZ2F0ZSIpOwogICAgbGV0IG51bWJlck9mVW5pdGFyeTIgPSBTdG9wQ291bnRpbmdPcGVyYXRpb24odW5pdGFyeTIpOwogICAgTG9nTWVzc2FnZShudW1iZXJPZlVuaXRhcnkyID09IDIsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgYXBwbGllZCB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSIsICQiWW91IGhhdmUgZmFpbGVkIHRvIGFwcGx5IHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIGFuZCBhcHBsaWVkIGl0IHtudW1iZXJPZlVuaXRhcnkyfSB0aW1lcyIpOwoKICAgIC8vIFdyYXAgdGhlIFNXQVAgZ2F0ZSBpbiBhIHVuaXRhcnkgb3BlcmF0aW9uIHRvIGJlIGFibGUgdG8gY2hlY2sgdGhlIG51bWJlciBvZiB0aW1lcyBpdCB3YXMgYXBwbGllZC4KICAgIGxldCB1bml0YXJ5MyA9IHFzID0+IFNXQVAocXNbMF0sIHFzWzFdKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24odW5pdGFyeTMpOwogICAgbGV0IHJlc3VsdDMgPSBTb2x2ZSh1bml0YXJ5Myk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDMgPT0gMywgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBpZGVudGlmaWVkIHRoZSBTV0FQIGdhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IHRoZSBTV0FQIGdhdGUiKTsKICAgIGxldCBudW1iZXJPZlVuaXRhcnkzID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkzKTsKICAgIExvZ01lc3NhZ2UobnVtYmVyT2ZVbml0YXJ5MyA9PSAyLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGFwcGxpZWQgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgdHdpY2UiLCAkIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSBhbmQgYXBwbGllZCBpdCB7bnVtYmVyT2ZVbml0YXJ5M30gdGltZXMiKTsKCiAgICAvLyBSZXR1cm4gdHJ1ZSBpZiB0aGUgSSDiipcgSSBnYXRlIHdhcyBpZGVudGlmaWVkIGFzIDAsIHRoZSBDTk9UMTIgZ2F0ZSBhcyAxLCB0aGUgQ05PVDIxIGdhdGUgYXMgMiwgdGhlIFNXQVAgZ2F0ZSBhcyAzLCBhbmQgYWxsIHVuaXRhcnkgb3BlcmF0aW9ucyB3ZXJlIGFwcGxpZWQgZXhhY3RseSB0d2ljZS4KICAgIHJldHVybiByZXN1bHQwID09IDAgYW5kIG51bWJlck9mVW5pdGFyeTAgPT0gMiBhbmQgcmVzdWx0MSA9PSAxIGFuZCBudW1iZXJPZlVuaXRhcnkxID09IDIgYW5kIHJlc3VsdDIgPT0gMiBhbmQgbnVtYmVyT2ZVbml0YXJ5MiA9PSAyIGFuZCByZXN1bHQzID09IDMgYW5kIG51bWJlck9mVW5pdGFyeTMgPT0gMjsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKPDxTT0xWRT4+",
//     ExpectedOutput = "true",
//     CopilotInstructions = "",
//     Level = 3
// };