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
    mutable result0Count = 0;
    for i in 1..10
    {
        let result0 = Solve(unitary0);
        result0Count += result0 == 0 ? 1 | 0;
    }
    LogMessage(result0Count == 10, "You have successfully identified the I ⊗ I gate", "You have failed to identify the I ⊗ I gate");
    let numberOfUnitary0 = StopCountingOperation(unitary0);
    LogMessage(numberOfUnitary0 == 20, "You have successfully applied the unitary operation exactly twice while identifying the I ⊗ I gate", $"You have failed to apply the unitary operation exactly twice and applied it {numberOfUnitary0} times while identifying the I ⊗ I gate");

    // Wrap the CNOT12 gate in a unitary operation to be able to check the number of times it was applied.
    let unitary1 = qs => CNOT(qs[0], qs[1]);
    StartCountingOperation(unitary1);
    mutable result1Count = 0;
    for i in 1..10
    {
        let result1 = Solve(unitary1);
        result1Count += result1 == 1 ? 1 | 0;
    }
    LogMessage(result1Count == 10, "You have successfully identified the CNOT12 gate", "You have failed to identify the CNOT12 gate");
    let numberOfUnitary1 = StopCountingOperation(unitary1);
    LogMessage(numberOfUnitary1 == 20, "You have successfully applied the unitary operation exactly twice while identifying the CNOT12 gate", $"You have failed to apply the unitary operation exactly twice and applied it {numberOfUnitary1} times while identifying the CNOT12 gate");

    // Wrap the CNOT21 gate in a unitary operation to be able to check the number of times it was applied.
    let unitary2 = qs => CNOT(qs[1], qs[0]);
    StartCountingOperation(unitary2);
    mutable result2Count = 0;
    for i in 1..10
    {
        let result2 = Solve(unitary2);
        result2Count += result2 == 2 ? 1 | 0;
    }
    LogMessage(result2Count == 10, "You have successfully identified the CNOT21 gate", "You have failed to identify the CNOT21 gate");
    let numberOfUnitary2 = StopCountingOperation(unitary2);
    LogMessage(numberOfUnitary2 == 20, "You have successfully applied the unitary operation exactly twice while identifying the CNOT21 gate", $"You have failed to apply the unitary operation exactly twice and applied it {numberOfUnitary2} times while identifying the CNOT21 gate");

    // Wrap the SWAP gate in a unitary operation to be able to check the number of times it was applied.
    let unitary3 = qs => SWAP(qs[0], qs[1]);
    StartCountingOperation(unitary3);
    mutable result3Count = 0;
    for i in 1..10
    {
        let result3 = Solve(unitary3);
        result3Count += result3 == 3 ? 1 | 0;
    }
    LogMessage(result3Count == 10, "You have successfully identified the SWAP gate", "You have failed to identify the SWAP gate");
    let numberOfUnitary3 = StopCountingOperation(unitary3);
    LogMessage(numberOfUnitary3 == 20, "You have successfully applied the unitary operation exactly twice while identifying the SWAP gate", $"You have failed to apply the unitary operation exactly twice and applied it {numberOfUnitary3} times while identifying the SWAP gate");

    // Return true if the I ⊗ I gate was identified as 0, the CNOT12 gate as 1, the CNOT21 gate as 2, the SWAP gate as 3, and all unitary operations were applied exactly twice.
    return result0Count == 10 and numberOfUnitary0 == 20 and result1Count == 10 and numberOfUnitary1 == 20 and result2Count == 10 and numberOfUnitary2 == 20 and result3Count == 10 and numberOfUnitary3 == 20;
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
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Db252ZXJ0LlJlc3VsdEFycmF5QXNJbnQ7CmltcG9ydCBTdGQuQXJpdGhtZXRpYy4qOwppbXBvcnQgU3RkLkNhbm9uLio7CmltcG9ydCBTdGQuRGlhZ25vc3RpY3MuKjsKaW1wb3J0IFN0ZC5NYXRoLio7CmltcG9ydCBTdGQuTWVhc3VyZW1lbnQuKjsKCm9wZXJhdGlvbiBNYWluKCkgOiBCb29sCnsKICAgIC8vIFdyYXAgdGhlIEkg4oqXIEkgZ2F0ZSBpbiBhIHVuaXRhcnkgb3BlcmF0aW9uIHRvIGJlIGFibGUgdG8gY2hlY2sgdGhlIG51bWJlciBvZiB0aW1lcyBpdCB3YXMgYXBwbGllZC4KICAgIGxldCB1bml0YXJ5MCA9IHFzID0+IEFwcGx5VG9FYWNoKEksIHFzKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24odW5pdGFyeTApOwogICAgbXV0YWJsZSByZXN1bHQwQ291bnQgPSAwOwogICAgZm9yIGkgaW4gMS4uMTAKICAgIHsKICAgICAgICBsZXQgcmVzdWx0MCA9IFNvbHZlKHVuaXRhcnkwKTsKICAgICAgICByZXN1bHQwQ291bnQgKz0gcmVzdWx0MCA9PSAwID8gMSB8IDA7CiAgICB9CiAgICBMb2dNZXNzYWdlKHJlc3VsdDBDb3VudCA9PSAxMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBpZGVudGlmaWVkIHRoZSBJIOKKlyBJIGdhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IHRoZSBJIOKKlyBJIGdhdGUiKTsKICAgIGxldCBudW1iZXJPZlVuaXRhcnkwID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkwKTsKICAgIExvZ01lc3NhZ2UobnVtYmVyT2ZVbml0YXJ5MCA9PSAyMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBhcHBsaWVkIHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIHdoaWxlIGlkZW50aWZ5aW5nIHRoZSBJIOKKlyBJIGdhdGUiLCAkIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSBhbmQgYXBwbGllZCBpdCB7bnVtYmVyT2ZVbml0YXJ5MH0gdGltZXMgd2hpbGUgaWRlbnRpZnlpbmcgdGhlIEkg4oqXIEkgZ2F0ZSIpOwoKICAgIC8vIFdyYXAgdGhlIENOT1QxMiBnYXRlIGluIGEgdW5pdGFyeSBvcGVyYXRpb24gdG8gYmUgYWJsZSB0byBjaGVjayB0aGUgbnVtYmVyIG9mIHRpbWVzIGl0IHdhcyBhcHBsaWVkLgogICAgbGV0IHVuaXRhcnkxID0gcXMgPT4gQ05PVChxc1swXSwgcXNbMV0pOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBtdXRhYmxlIHJlc3VsdDFDb3VudCA9IDA7CiAgICBmb3IgaSBpbiAxLi4xMAogICAgewogICAgICAgIGxldCByZXN1bHQxID0gU29sdmUodW5pdGFyeTEpOwogICAgICAgIHJlc3VsdDFDb3VudCArPSByZXN1bHQxID09IDEgPyAxIHwgMDsKICAgIH0KICAgIExvZ01lc3NhZ2UocmVzdWx0MUNvdW50ID09IDEwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgdGhlIENOT1QxMiBnYXRlIiwgIllvdSBoYXZlIGZhaWxlZCB0byBpZGVudGlmeSB0aGUgQ05PVDEyIGdhdGUiKTsKICAgIGxldCBudW1iZXJPZlVuaXRhcnkxID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkxKTsKICAgIExvZ01lc3NhZ2UobnVtYmVyT2ZVbml0YXJ5MSA9PSAyMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBhcHBsaWVkIHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIHdoaWxlIGlkZW50aWZ5aW5nIHRoZSBDTk9UMTIgZ2F0ZSIsICQiWW91IGhhdmUgZmFpbGVkIHRvIGFwcGx5IHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIGFuZCBhcHBsaWVkIGl0IHtudW1iZXJPZlVuaXRhcnkxfSB0aW1lcyB3aGlsZSBpZGVudGlmeWluZyB0aGUgQ05PVDEyIGdhdGUiKTsKCiAgICAvLyBXcmFwIHRoZSBDTk9UMjEgZ2F0ZSBpbiBhIHVuaXRhcnkgb3BlcmF0aW9uIHRvIGJlIGFibGUgdG8gY2hlY2sgdGhlIG51bWJlciBvZiB0aW1lcyBpdCB3YXMgYXBwbGllZC4KICAgIGxldCB1bml0YXJ5MiA9IHFzID0+IENOT1QocXNbMV0sIHFzWzBdKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24odW5pdGFyeTIpOwogICAgbXV0YWJsZSByZXN1bHQyQ291bnQgPSAwOwogICAgZm9yIGkgaW4gMS4uMTAKICAgIHsKICAgICAgICBsZXQgcmVzdWx0MiA9IFNvbHZlKHVuaXRhcnkyKTsKICAgICAgICByZXN1bHQyQ291bnQgKz0gcmVzdWx0MiA9PSAyID8gMSB8IDA7CiAgICB9CiAgICBMb2dNZXNzYWdlKHJlc3VsdDJDb3VudCA9PSAxMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBpZGVudGlmaWVkIHRoZSBDTk9UMjEgZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIENOT1QyMSBnYXRlIik7CiAgICBsZXQgbnVtYmVyT2ZVbml0YXJ5MiA9IFN0b3BDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5Mik7CiAgICBMb2dNZXNzYWdlKG51bWJlck9mVW5pdGFyeTIgPT0gMjAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgYXBwbGllZCB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSB3aGlsZSBpZGVudGlmeWluZyB0aGUgQ05PVDIxIGdhdGUiLCAkIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSBhbmQgYXBwbGllZCBpdCB7bnVtYmVyT2ZVbml0YXJ5Mn0gdGltZXMgd2hpbGUgaWRlbnRpZnlpbmcgdGhlIENOT1QyMSBnYXRlIik7CgogICAgLy8gV3JhcCB0aGUgU1dBUCBnYXRlIGluIGEgdW5pdGFyeSBvcGVyYXRpb24gdG8gYmUgYWJsZSB0byBjaGVjayB0aGUgbnVtYmVyIG9mIHRpbWVzIGl0IHdhcyBhcHBsaWVkLgogICAgbGV0IHVuaXRhcnkzID0gcXMgPT4gU1dBUChxc1swXSwgcXNbMV0pOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5Myk7CiAgICBtdXRhYmxlIHJlc3VsdDNDb3VudCA9IDA7CiAgICBmb3IgaSBpbiAxLi4xMAogICAgewogICAgICAgIGxldCByZXN1bHQzID0gU29sdmUodW5pdGFyeTMpOwogICAgICAgIHJlc3VsdDNDb3VudCArPSByZXN1bHQzID09IDMgPyAxIHwgMDsKICAgIH0KICAgIExvZ01lc3NhZ2UocmVzdWx0M0NvdW50ID09IDEwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgdGhlIFNXQVAgZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIFNXQVAgZ2F0ZSIpOwogICAgbGV0IG51bWJlck9mVW5pdGFyeTMgPSBTdG9wQ291bnRpbmdPcGVyYXRpb24odW5pdGFyeTMpOwogICAgTG9nTWVzc2FnZShudW1iZXJPZlVuaXRhcnkzID09IDIwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGFwcGxpZWQgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgdHdpY2Ugd2hpbGUgaWRlbnRpZnlpbmcgdGhlIFNXQVAgZ2F0ZSIsICQiWW91IGhhdmUgZmFpbGVkIHRvIGFwcGx5IHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIGFuZCBhcHBsaWVkIGl0IHtudW1iZXJPZlVuaXRhcnkzfSB0aW1lcyB3aGlsZSBpZGVudGlmeWluZyB0aGUgU1dBUCBnYXRlIik7CgogICAgLy8gUmV0dXJuIHRydWUgaWYgdGhlIEkg4oqXIEkgZ2F0ZSB3YXMgaWRlbnRpZmllZCBhcyAwLCB0aGUgQ05PVDEyIGdhdGUgYXMgMSwgdGhlIENOT1QyMSBnYXRlIGFzIDIsIHRoZSBTV0FQIGdhdGUgYXMgMywgYW5kIGFsbCB1bml0YXJ5IG9wZXJhdGlvbnMgd2VyZSBhcHBsaWVkIGV4YWN0bHkgdHdpY2UuCiAgICByZXR1cm4gcmVzdWx0MENvdW50ID09IDEwIGFuZCBudW1iZXJPZlVuaXRhcnkwID09IDIwIGFuZCByZXN1bHQxQ291bnQgPT0gMTAgYW5kIG51bWJlck9mVW5pdGFyeTEgPT0gMjAgYW5kIHJlc3VsdDJDb3VudCA9PSAxMCBhbmQgbnVtYmVyT2ZVbml0YXJ5MiA9PSAyMCBhbmQgcmVzdWx0M0NvdW50ID09IDEwIGFuZCBudW1iZXJPZlVuaXRhcnkzID09IDIwOwp9CgpmdW5jdGlvbiBMb2dNZXNzYWdlKGlzVmFsaWQ6IEJvb2wsIHZhbGlkTWVzc2FnZTogU3RyaW5nLCBpbnZhbGlkTWVzc2FnZTogU3RyaW5nKSA6ICgpCnsKICAgIGxldCBtZXNzYWdlID0gIntcInZhbGlkXCI6ICIgKyAoaXNWYWxpZCA/ICJ0cnVlIiB8ICJmYWxzZSIpICsgIiwgXCJtZXNzYWdlXCI6IFwiIiArIChpc1ZhbGlkID8gdmFsaWRNZXNzYWdlIHwgaW52YWxpZE1lc3NhZ2UpICsgIlwifSI7CiAgICBNZXNzYWdlKG1lc3NhZ2UpOwp9Cgo8PFNPTFZFPj4=",
//     ExpectedOutput = "true",
//     ExpectedStates = "",
//     CopilotInstructions = "",
//     Level = 3
// };