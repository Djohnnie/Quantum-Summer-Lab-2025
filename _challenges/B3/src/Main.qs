import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{    
    let result0 = CheckOperationsAreEqual(2, x => Solve(x, 0), x => Expected(x, 0));
    LogMessage(result0, "You have successfully generated the |B0⟩ = 1/√2 (|00⟩ + |11⟩) for index 0", "You have failed to generate the |B0⟩ = 1/√2 (|00⟩ + |11⟩) state for index 0");
    
    let result1 = CheckOperationsAreEqual(2, x => Solve(x, 1), x => Expected(x, 1));
    LogMessage(result1, "You have successfully generated the |B1⟩ = 1/√2 (|00⟩ - |11⟩) for index 1", "You have failed to generate the |B1⟩ = 1/√2 (|00⟩ - |11⟩) state for index 1");

    let result2 = CheckOperationsAreEqual(2, x => Solve(x, 2), x => Expected(x, 2));
    LogMessage(result2, "You have successfully generated the |B2⟩ = 1/√2 (|01⟩ + |10⟩) for index 2", "You have failed to generate the |B2⟩ = 1/√2 (|01⟩ + |10⟩) state for index 2");

    let result3 = CheckOperationsAreEqual(2, x => Solve(x, 3), x => Expected(x, 3));
    LogMessage(result3, "You have successfully generated the |B3⟩ = 1/√2 (|01⟩ - |10⟩) for index 3", "You have failed to generate the |B3⟩ = 1/√2 (|01⟩ - |10⟩) state for index 3");

    return result0 and result1 and result2 and result3;
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

operation Expected (qs : Qubit[], index : Int) : Unit is Adj
{
    // Put the first qubit in superposition.
    H(qs[0]);

    // If the result should be |00⟩ - |11⟩ or |01⟩ - |10⟩, we need to apply the Z-gate to alter the sign.
    if(index % 2 == 1)
    {
        Z(qs[0]);
    }
    
    // Apply the CNOT gate to entangle the qubits.
    CNOT(qs[0], qs[1]);
    
    // If the result should be |01⟩ + |10⟩ or |01⟩ - |10⟩, we need to apply the X-gate to the second qubit.
    if(index / 2 == 1)
    {
        X(qs[1]);
    }
}

// Generate Bell state
// You are given two qubits in state |00⟩ and an integer index. Your task is to create one of the Bell states on them according to the index:
// 0: |B0⟩ = 1/√2 (|00⟩ + |11⟩)
// 1: |B1⟩ = 1/√2 (|00⟩ - |11⟩)
// 2: |B2⟩ = 1/√2 (|01⟩ + |10⟩)
// 3: |B3⟩ = 1/√2 (|01⟩ - |10⟩)
// You have to implement the Solve operation to make the correct Bell state according to the given index. The operation should have the following signature:

operation Solve (qs : Qubit[], index : Int) : Unit
{
    H(qs[0]);

    if(index % 2 == 1)
    {
        Z(qs[0]);
    }
    
    CNOT(qs[0], qs[1]);
    
    if(index / 2 == 1)
    {
        X(qs[1]);
    }
}

// public static Challenge CHALLENGE_B3 = new Challenge
// {
//     Name = "B3",
//     Title = "Generate Bell state",
//     Description = "You are given two qubits in state |00⟩ and an integer index. Your task is to create one of the Bell states on them according to the index:[BR]0: |B0⟩ = 1/√2 (|00⟩ + |11⟩)[BR]1: |B1⟩ = 1/√2 (|00⟩ - |11⟩)[BR]2: |B2⟩ = 1/√2 (|01⟩ + |10⟩)[BR]3: |B3⟩ = 1/√2 (|01⟩ - |10⟩)[BR]You have to implement the Solve operation to make the correct Bell state according to the given index. The operation should have the following signature:",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxcyA6IFF1Yml0W10sIGluZGV4IDogSW50KSA6IFVuaXQKewogICAgLy8gWW91ciBzb2x1dGlvbiBsb2dpYyBnb2VzIGhlcmUuCn0=",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIGxldCByZXN1bHQwID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMiwgeCA9PiBTb2x2ZSh4LCAwKSwgeCA9PiBFeHBlY3RlZCh4LCAwKSk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIHRoZSB8QjDin6kgPSAxL+KImjIgKHwwMOKfqSArIHwxMeKfqSkgZm9yIGluZGV4IDAiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGdlbmVyYXRlIHRoZSB8QjDin6kgPSAxL+KImjIgKHwwMOKfqSArIHwxMeKfqSkgc3RhdGUgZm9yIGluZGV4IDAiKTsKICAgIAogICAgbGV0IHJlc3VsdDEgPSBDaGVja09wZXJhdGlvbnNBcmVFcXVhbCgyLCB4ID0+IFNvbHZlKHgsIDEpLCB4ID0+IEV4cGVjdGVkKHgsIDEpKTsKICAgIExvZ01lc3NhZ2UocmVzdWx0MSwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBnZW5lcmF0ZWQgdGhlIHxCMeKfqSA9IDEv4oiaMiAofDAw4p+pIC0gfDEx4p+pKSBmb3IgaW5kZXggMSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gZ2VuZXJhdGUgdGhlIHxCMeKfqSA9IDEv4oiaMiAofDAw4p+pIC0gfDEx4p+pKSBzdGF0ZSBmb3IgaW5kZXggMSIpOwoKICAgIGxldCByZXN1bHQyID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMiwgeCA9PiBTb2x2ZSh4LCAyKSwgeCA9PiBFeHBlY3RlZCh4LCAyKSk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDIsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIHRoZSB8QjLin6kgPSAxL+KImjIgKHwwMeKfqSArIHwxMOKfqSkgZm9yIGluZGV4IDIiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGdlbmVyYXRlIHRoZSB8QjLin6kgPSAxL+KImjIgKHwwMeKfqSArIHwxMOKfqSkgc3RhdGUgZm9yIGluZGV4IDIiKTsKCiAgICBsZXQgcmVzdWx0MyA9IENoZWNrT3BlcmF0aW9uc0FyZUVxdWFsKDIsIHggPT4gU29sdmUoeCwgMyksIHggPT4gRXhwZWN0ZWQoeCwgMykpOwogICAgTG9nTWVzc2FnZShyZXN1bHQzLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGdlbmVyYXRlZCB0aGUgfEIz4p+pID0gMS/iiJoyICh8MDHin6kgLSB8MTDin6kpIGZvciBpbmRleCAzIiwgIllvdSBoYXZlIGZhaWxlZCB0byBnZW5lcmF0ZSB0aGUgfEIz4p+pID0gMS/iiJoyICh8MDHin6kgLSB8MTDin6kpIHN0YXRlIGZvciBpbmRleCAzIik7CgogICAgcmV0dXJuIHJlc3VsdDAgYW5kIHJlc3VsdDEgYW5kIHJlc3VsdDIgYW5kIHJlc3VsdDM7Cn0KCmZ1bmN0aW9uIExvZ01lc3NhZ2UoaXNWYWxpZDogQm9vbCwgdmFsaWRNZXNzYWdlOiBTdHJpbmcsIGludmFsaWRNZXNzYWdlOiBTdHJpbmcpIDogKCkKewogICAgbGV0IG1lc3NhZ2UgPSAie1widmFsaWRcIjogIiArIChpc1ZhbGlkID8gInRydWUiIHwgImZhbHNlIikgKyAiLCBcIm1lc3NhZ2VcIjogXCIiICsgKGlzVmFsaWQgPyB2YWxpZE1lc3NhZ2UgfCBpbnZhbGlkTWVzc2FnZSkgKyAiXCJ9IjsKICAgIE1lc3NhZ2UobWVzc2FnZSk7Cn0KCm9wZXJhdGlvbiBFeHBlY3RlZCAocXMgOiBRdWJpdFtdLCBpbmRleCA6IEludCkgOiBVbml0IGlzIEFkagp7CiAgICAvLyBQdXQgdGhlIGZpcnN0IHF1Yml0IGluIHN1cGVycG9zaXRpb24uCiAgICBIKHFzWzBdKTsKCiAgICAvLyBJZiB0aGUgcmVzdWx0IHNob3VsZCBiZSB8MDDin6kgLSB8MTHin6kgb3IgfDAx4p+pIC0gfDEw4p+pLCB3ZSBuZWVkIHRvIGFwcGx5IHRoZSBaLWdhdGUgdG8gYWx0ZXIgdGhlIHNpZ24uCiAgICBpZihpbmRleCAlIDIgPT0gMSkKICAgIHsKICAgICAgICBaKHFzWzBdKTsKICAgIH0KICAgIAogICAgLy8gQXBwbHkgdGhlIENOT1QgZ2F0ZSB0byBlbnRhbmdsZSB0aGUgcXViaXRzLgogICAgQ05PVChxc1swXSwgcXNbMV0pOwogICAgCiAgICAvLyBJZiB0aGUgcmVzdWx0IHNob3VsZCBiZSB8MDHin6kgKyB8MTDin6kgb3IgfDAx4p+pIC0gfDEw4p+pLCB3ZSBuZWVkIHRvIGFwcGx5IHRoZSBYLWdhdGUgdG8gdGhlIHNlY29uZCBxdWJpdC4KICAgIGlmKGluZGV4IC8gMiA9PSAxKQogICAgewogICAgICAgIFgocXNbMV0pOwogICAgfQp9Cgo8PFNPTFZFPj4=",
//     ExpectedOutput = "true",
//     CopilotInstructions = "",
//     Level = 2
// };