import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Unit
{
    use qs = Qubit[4];
    Solve(qs);
    DumpRegister(qs);
    ResetAll(qs);
}

// Generate generalized W-state.
// Your task is to create Greenberger–Horne–Zeilinger (W) state on n qubits where n = 2^k (1 ≤ k ≤ 4) from zero |0..0⟩ state.
// The W-state is defined as |W⟩ = 1/√3 (|100⟩ + |010⟩ + |001⟩) for n = 3.
// The generalized W-state is defined as |W⟩ = 1/√n (|10..0⟩ + |01..0⟩ + ... + |00..1⟩) for n > 3 where n = 2^k (1 ≤ k ≤ 4).
// You have to implement the Solve operation which takes an array of n qubits in state |0..0⟩ and you need to create the W-state on them.
// The operation should have the following signature:
operation Solve (qs : Qubit[]) : Unit
{
    let n = Length(qs);

    if( n == 1 )
    {
        X(qs[0]);
    }
    else
    {
        let k = n / 2;

        Solve(qs[0..k-1]);

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

// public static Challenge CHALLENGE_D2 = new Challenge
// {
//     Name = "D2",
//     Title = "Generate generalized W-state",
//     Description = "Your task is to create Greenberger–Horne–Zeilinger (W) state on n qubits where n = 2^k (1 ≤ k ≤ 4) from zero |0..0⟩ state.[BR]The W-state is defined as |W⟩ = 1/√3 (|100⟩ + |010⟩ + |001⟩) for n = 3.[BR]The generalized W-state is defined as |W⟩ = 1/√n (|10..0⟩ + |01..0⟩ + ... + |00..1⟩) for n > 3 where n = 2^k (1 ≤ k ≤ 4).[BR]You have to implement the Solve operation which takes an array of n qubits in state |0..0⟩ and you need to create the W-state on them.[BR]The operation should have the following signature:",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxcyA6IFF1Yml0W10pIDogVW5pdAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IFVuaXQKewogICAgdXNlIHFzID0gUXViaXRbNF07CiAgICBTb2x2ZShxcyk7CiAgICBEdW1wUmVnaXN0ZXIocXMpOwogICAgUmVzZXRBbGwocXMpOwp9Cgo8PFNPTFZFPj4=",
//     ExpectedOutput = "",
//     ExpectedStates = "WwogIHsKICAgICJpZCI6ICJ8MDAwMeKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuNSwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfSwKICB7CiAgICAiaWQiOiAifDAwMTDin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjUsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwwMTAw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC41LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MTAwMOKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuNSwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfQpd",
//     CopilotInstructions = "",
//     Level = 4
// };