import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{
    mutable resultCounter = 0;

    for i in 1 .. 8
    {
        let result = CheckOperationsAreEqual(i, Solve, Expected);
        set resultCounter += result ? 1 | 0;
    }

    LogMessage(resultCounter == 8, "You have implemented an increment operation successfully", "You have failed to implement an increment operation");

    // Prepare a generalized W-state on 4 qubits.
    use qs = Qubit[4];
    PrepareInitialState(qs);

    // Call the Solve operation to increment the number in the register modulo 2^n.
    Solve(qs);

    // Dump the register to evaluate the results.
    DumpRegister(qs);

    // Reset the qubits to their initial state.
    MResetEachZ(qs);

    return resultCounter == 8;
}

operation PrepareInitialState (qs : Qubit[]) : Unit
{
    let n = Length(qs);

    if( n == 1 )
    {
        X(qs[0]);
    }
    else
    {
        let k = n / 2;

        PrepareInitialState(qs[0..k-1]);

        use a = Qubit();
        H(a);

        for i in 0 .. k - 1
        {
            Controlled SWAP([a], (qs[i], qs[i+k]));
        }

        for i in k .. n - 1
        {
            CNOT(qs[i], a);
        }
    }
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

operation Expected (register : Qubit[]) : Unit is Adj + Ctl
{
    if (Length(register) > 1)
    {
        (Controlled Expected)([register[0]], register[1...]);
    }

    X(register[0]);
}

// Increment
// Implement an operation on a register of n qubits that increments the number written in the register modulo 2^n.
// Your operation should take an array of qubits that encodes an unsigned integer in little-endian format, with the least significant bit written first (corresponding to the array element with index 0).
// The Solve operation should take the input register and change it without measuring it in order to keep the quantum state, but increment the values its state represents.
// For example:
// 1/2(|0001⟩ + |0010⟩ + |0100⟩ + |1000⟩) should be incremented to 1/2(|1001⟩ + |1010⟩ + |1100⟩ + |0100)
// The solve operation should have the following signature:
operation Solve (register : Qubit[]) : Unit is Adj + Ctl
{
    // Only if the register contains at least two qubits
    if (Length(register) > 1)
    {
        // Increment the rest of the number if the least significant bit is 1.
        // This is done by recursively applying the controlled Solve operation to the rest of the register.
        (Controlled Solve)([register[0]], register[1...]);
    }

    // Increment the least significant bit.
    X(register[0]);
}

// public static Challenge CHALLENGE_C3 = new Challenge
// {
//     Name = "C3",
//     Title = "Increment",
//     Description = "Implement an operation on a register of n qubits that increments the number written in the register modulo 2^n.[BR]Your operation should take an array of qubits that encodes an unsigned integer in little-endian format, with the least significant bit written first (corresponding to the array element with index 0).[BR]The Solve operation should take the input register and change it without measuring it in order to keep the quantum state, but increment the values its state represents.[BR]For example:[BR]1/2(|0001⟩ + |0010⟩ + |0100⟩ + |1000⟩) should be incremented to 1/2(|1001⟩ + |1010⟩ + |1100⟩ + |0100)[BR]The solve operation should have the following signature:",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChyZWdpc3RlciA6IFF1Yml0W10pIDogVW5pdCBpcyBBZGogKyBDdGwKewogICAgLy8gWW91ciBzb2x1dGlvbiBsb2dpYyBnb2VzIGhlcmUuCn0=",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgbXV0YWJsZSByZXN1bHRDb3VudGVyID0gMDsKCiAgICBmb3IgaSBpbiAxIC4uIDgKICAgIHsKICAgICAgICBsZXQgcmVzdWx0ID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoaSwgU29sdmUsIEV4cGVjdGVkKTsKICAgICAgICBzZXQgcmVzdWx0Q291bnRlciArPSByZXN1bHQgPyAxIHwgMDsKICAgIH0KCiAgICBMb2dNZXNzYWdlKHJlc3VsdENvdW50ZXIgPT0gOCwgIllvdSBoYXZlIGltcGxlbWVudGVkIGFuIGluY3JlbWVudCBvcGVyYXRpb24gc3VjY2Vzc2Z1bGx5IiwgIllvdSBoYXZlIGZhaWxlZCB0byBpbXBsZW1lbnQgYW4gaW5jcmVtZW50IG9wZXJhdGlvbiIpOwoKICAgIC8vIFByZXBhcmUgYSBnZW5lcmFsaXplZCBXLXN0YXRlIG9uIDQgcXViaXRzLgogICAgdXNlIHFzID0gUXViaXRbNF07CiAgICBQcmVwYXJlSW5pdGlhbFN0YXRlKHFzKTsKCiAgICAvLyBDYWxsIHRoZSBTb2x2ZSBvcGVyYXRpb24gdG8gaW5jcmVtZW50IHRoZSBudW1iZXIgaW4gdGhlIHJlZ2lzdGVyIG1vZHVsbyAyXm4uCiAgICBTb2x2ZShxcyk7CgogICAgLy8gRHVtcCB0aGUgcmVnaXN0ZXIgdG8gZXZhbHVhdGUgdGhlIHJlc3VsdHMuCiAgICBEdW1wUmVnaXN0ZXIocXMpOwoKICAgIC8vIFJlc2V0IHRoZSBxdWJpdHMgdG8gdGhlaXIgaW5pdGlhbCBzdGF0ZS4KICAgIE1SZXNldEVhY2haKHFzKTsKCiAgICByZXR1cm4gcmVzdWx0Q291bnRlciA9PSA4Owp9CgpvcGVyYXRpb24gUHJlcGFyZUluaXRpYWxTdGF0ZSAocXMgOiBRdWJpdFtdKSA6IFVuaXQKewogICAgbGV0IG4gPSBMZW5ndGgocXMpOwoKICAgIGlmKCBuID09IDEgKQogICAgewogICAgICAgIFgocXNbMF0pOwogICAgfQogICAgZWxzZQogICAgewogICAgICAgIGxldCBrID0gbiAvIDI7CgogICAgICAgIFByZXBhcmVJbml0aWFsU3RhdGUocXNbMC4uay0xXSk7CgogICAgICAgIHVzZSBhID0gUXViaXQoKTsKICAgICAgICBIKGEpOwoKICAgICAgICBmb3IgaSBpbiAwIC4uIGsgLSAxCiAgICAgICAgewogICAgICAgICAgICBDb250cm9sbGVkIFNXQVAoW2FdLCAocXNbaV0sIHFzW2kra10pKTsKICAgICAgICB9CgogICAgICAgIGZvciBpIGluIGsgLi4gbiAtIDEKICAgICAgICB7CiAgICAgICAgICAgIENOT1QocXNbaV0sIGEpOwogICAgICAgIH0KICAgIH0KfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKb3BlcmF0aW9uIEV4cGVjdGVkIChyZWdpc3RlciA6IFF1Yml0W10pIDogVW5pdCBpcyBBZGogKyBDdGwKewogICAgaWYgKExlbmd0aChyZWdpc3RlcikgPiAxKQogICAgewogICAgICAgIChDb250cm9sbGVkIEV4cGVjdGVkKShbcmVnaXN0ZXJbMF1dLCByZWdpc3RlclsxLi4uXSk7CiAgICB9CgogICAgWChyZWdpc3RlclswXSk7Cn0KCjw8U09MVkU+Pg==",
//     ExpectedOutput = "true",
//     ExpectedStates = "WwogIHsKICAgICJpZCI6ICJ8MTAwMeKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuNSwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfSwKICB7CiAgICAiaWQiOiAifDEwMTDin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjUsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwxMTAw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC41LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MDEwMOKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuNSwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfQpd",
//     CopilotInstructions = "",
//     Level = 3
// };