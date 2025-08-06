using QuantumSummerLab.Data.Model;

namespace QuantumSummerLab.Tools;

public static class Challenges
{
    public static Challenge CHALLENGE_0 = new Challenge
    {
        Name = "0",
        Title = "Example Challenge: Prepare |0⟩ or |1⟩",
        Description = "You are given a single qubit, prepared in the |0⟩ state, and a Result with a possible Zero or One value.[BR]Make sure to change the qubit state and leave it in a |0⟩ or |1⟩ state that corresponds with the provided Result value.[BR]You should implement the following Solve method to make that happen and keep the signature of the method exactly like it is.[BR]Go ahead and copy/paste the following template in your Q# project in Visual Studio Code to start working on the solution.",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxIDogUXViaXQsIGV4cGVjdGVkUmVzdWx0IDogUmVzdWx0KSA6IFVuaXQKewogICAgLy8gWW91ciBzb2x1dGlvbiBsb2dpYyBnb2VzIGhlcmUuCn0=",
        ExampleDescription = "Below, you can find a possible solution and additionally, just for reference, the code that will be executed internally to validate the submitted solution.[BR]You should only submit the Solve operation with your implemented solution, or in this example case, a copy from the provided solution below.",
        ExampleCode = "b3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIHVzZSBxID0gUXViaXQoKTsKCiAgICBTb2x2ZShxLCBaZXJvKTsKICAgIGxldCBiMSA9IE0ocSk7CiAgICBSZXNldChxKTsKCiAgICBTb2x2ZShxLCBPbmUpOwogICAgbGV0IGIyID0gTShxKTsKICAgIFJlc2V0KHEpOwoKICAgIHJldHVybiBiMSA9PSBaZXJvIGFuZCBiMiA9PSBPbmU7Cn0KCm9wZXJhdGlvbiBTb2x2ZSAocSA6IFF1Yml0LCBleHBlY3RlZFJlc3VsdCA6IFJlc3VsdCkgOiBVbml0CnsKICAgIGlmKGV4cGVjdGVkUmVzdWx0ID09IE9uZSkgewogICAgICAgIFgocSk7CiAgICB9Cn0=",
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIGxldCByZXN1bHQxID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCBaZXJvKSwgeCA9PiBFeHBlY3RlZCh4WzBdLCBaZXJvKSk7CiAgICBsZXQgcmVzdWx0MiA9IENoZWNrT3BlcmF0aW9uc0FyZUVxdWFsKDEsIHggPT4gU29sdmUoeFswXSwgT25lKSwgeCA9PiBFeHBlY3RlZCh4WzBdLCBPbmUpKTsKCiAgICByZXR1cm4gcmVzdWx0MSBhbmQgcmVzdWx0MjsKfQoKb3BlcmF0aW9uIEV4cGVjdGVkIChxIDogUXViaXQsIGV4cGVjdGVkUmVzdWx0IDogUmVzdWx0KSA6IFVuaXQgaXMgQWRqCnsKICAgIGlmKGV4cGVjdGVkUmVzdWx0ID09IE9uZSkgewogICAgICAgIFgocSk7CiAgICB9Cn0KCjw8U09MVkU+Pg==",
        ExpectedOutput = "true",
        Level = 0
    };

    public static Challenge CHALLENGE_A1 = new Challenge
    {
        Name = "A1",
        Title = "Generate superposition of all basis states.",
        Description = "You are given N qubits (1 ≤ N ≤ 8), prepared in the |0..0⟩ state, and you have to implement an operation which generates an equal superposition of all basis states on these qubits.[BR]The \"output\" of your solution is the state in which it left the input qubits.[BR]You should implement the following Solve operation to make that happen and keep the signature of the method exactly like it is.",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxcyA6IFF1Yml0W10pIDogVW5pdCAKewogICAgLy8gWW91ciBzb2x1dGlvbiBsb2dpYyBnb2VzIGhlcmUuCn0=",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIGxldCByZXN1bHQgPSBDaGVja09wZXJhdGlvbnNBcmVFcXVhbCg4LCBTb2x2ZSwgRXhwZWN0ZWQpOwoKICAgIHJldHVybiByZXN1bHQ7Cn0KCm9wZXJhdGlvbiBFeHBlY3RlZCAocXMgOiBRdWJpdFtdKSA6IFVuaXQgaXMgQWRqCnsKICAgIGZvciBxIGluIHFzIAogICAgewogICAgICAgIEgocSk7CiAgICB9Cn0KCjw8U09MVkU+Pg==",
        ExpectedOutput = "true",
        Level = 0
    };

    public static Challenge CHALLENGE_A2 = new Challenge
    {
        Name = "A2",
        Title = "Distinguish I from X",
        Description = "You are given an operation that implements a single-qubit unitary transformation: either the identity gate (I gate) or the bit-flip gate (X gate).[BR]Your task is to perform necessary operations and measurements to figure out which unitary it was and to return 0 if it was the I gate or 1 if it was the X gate.[BR]You are allowed to apply the given operation exactly once.[BR]You have to implement an operation which takes a single-qubit operation as an input and returns an integer. The operation should have the following signature:",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlICh1bml0YXJ5IDogKFF1Yml0ID0+IFVuaXQpKSA6IEludAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgbGV0IHVuaXRhcnkxID0gcSA9PiBJKHEpOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBsZXQgaSA9IFNvbHZlKHVuaXRhcnkxKTsKICAgIExvZ01lc3NhZ2UoaSA9PSAwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgdGhlIEktZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIEktZ2F0ZSIpOwogICAgbGV0IG51bWJlck9mVW5pdGFyeTEgPSBTdG9wQ291bnRpbmdPcGVyYXRpb24odW5pdGFyeTEpOwogICAgTG9nTWVzc2FnZShudW1iZXJPZlVuaXRhcnkxID09IDEsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgYXBwbGllZCB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSBvbmNlIiwgIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSBvbmNlIik7CgogICAgbGV0IHVuaXRhcnkyID0gcSA9PiBYKHEpOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5Mik7CiAgICBsZXQgeCA9IFNvbHZlKHVuaXRhcnkyKTsKICAgIExvZ01lc3NhZ2UoeCA9PSAxLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgdGhlIFgtZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIFgtZ2F0ZSIpOwogICAgbGV0IG51bWJlck9mVW5pdGFyeTIgPSBTdG9wQ291bnRpbmdPcGVyYXRpb24odW5pdGFyeTIpOwogICAgTG9nTWVzc2FnZShudW1iZXJPZlVuaXRhcnkxID09IDEsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgYXBwbGllZCB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSBvbmNlIiwgIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSBvbmNlIik7CgogICAgcmV0dXJuIGkgPT0gMCBhbmQgbnVtYmVyT2ZVbml0YXJ5MSA9PSAxIGFuZCB4ID09IDEgYW5kIG51bWJlck9mVW5pdGFyeTIgPT0gMTsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKPDxTT0xWRT4+",
        ExpectedOutput = "true",
        Level = 0
    };

    public static Challenge CHALLENGE_A3 = new Challenge
    {
        Name = "A3",
        Title = "Example Challenge",
        Description = "You are given a single qubit, prepared in the |0⟩ state, and a Result with a possible Zero or One value.[BR]Make sure to change the qubit state and leave it in a state that corresponds with the provided Result value.[BR]You should implement the following Solve method to make that happen and keep the signature of the method exactly like it is.[BR]Go ahead and copy/paste the following template in your Q# project in Visual Studio Code to start working on the solution.",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxIDogUXViaXQsIGV4cGVjdGVkUmVzdWx0IDogUmVzdWx0KSA6IFVuaXQKewogICAgLy8gWW91ciBzb2x1dGlvbiBsb2dpYyBnb2VzIGhlcmUuCn0=",
        ExampleDescription = "Below, you can find a possible solution and additionally, just for reference, the code that will be executed internally to validate the submitted solution.[BR]You should only submit the Solve operation with your implemented solution, or in this example case, a copy from the provided solution below.",
        ExampleCode = "b3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIHVzZSBxID0gUXViaXQoKTsKCiAgICBTb2x2ZShxLCBaZXJvKTsKICAgIGxldCBiMSA9IE0ocSk7CiAgICBSZXNldChxKTsKCiAgICBTb2x2ZShxLCBPbmUpOwogICAgbGV0IGIyID0gTShxKTsKICAgIFJlc2V0KHEpOwoKICAgIHJldHVybiBiMSA9PSBaZXJvIGFuZCBiMiA9PSBPbmU7Cn0KCm9wZXJhdGlvbiBTb2x2ZSAocSA6IFF1Yml0LCBleHBlY3RlZFJlc3VsdCA6IFJlc3VsdCkgOiBVbml0CnsKICAgIGlmKGV4cGVjdGVkUmVzdWx0ID09IE9uZSkgewogICAgICAgIFgocSk7CiAgICB9Cn0=",
        VerificationTemplate = "b3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIHVzZSBxID0gUXViaXQoKTsKCiAgICBTb2x2ZShxLCBaZXJvKTsKICAgIGxldCBiMSA9IE0ocSk7CiAgICBSZXNldChxKTsKCiAgICBTb2x2ZShxLCBPbmUpOwogICAgbGV0IGIyID0gTShxKTsKICAgIFJlc2V0KHEpOwoKICAgIHJldHVybiBiMSA9PSBaZXJvIGFuZCBiMiA9PSBPbmU7Cn0KCjw8U09MVkU+Pg==",
        ExpectedOutput = "true",
        Level = 0
    };

    public static Challenge CHALLENGE_B1 = new Challenge
    {
        Name = "B1",
        Title = "",
        Description = "",
        SolutionTemplate = "",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "",
        ExpectedOutput = "",
        Level = 0
    };

    public static Challenge CHALLENGE_B2 = new Challenge
    {
        Name = "B2",
        Title = "",
        Description = "",
        SolutionTemplate = "",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "",
        ExpectedOutput = "",
        Level = 0
    };

    public static Challenge CHALLENGE_B3 = new Challenge
    {
        Name = "B3",
        Title = "",
        Description = "",
        SolutionTemplate = "",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "",
        ExpectedOutput = "",
        Level = 0
    };

    public static Challenge CHALLENGE_C1 = new Challenge
    {
        Name = "C1",
        Title = "",
        Description = "",
        SolutionTemplate = "",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "",
        ExpectedOutput = "",
        Level = 0
    };

    public static Challenge CHALLENGE_C2 = new Challenge
    {
        Name = "C2",
        Title = "",
        Description = "",
        SolutionTemplate = "",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "",
        ExpectedOutput = "",
        Level = 0
    };

    public static Challenge CHALLENGE_C3 = new Challenge
    {
        Name = "C3",
        Title = "",
        Description = "",
        SolutionTemplate = "",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "",
        ExpectedOutput = "",
        Level = 0
    };

    public static Challenge CHALLENGE_D1 = new Challenge
    {
        Name = "D1",
        Title = "",
        Description = "",
        SolutionTemplate = "",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "",
        ExpectedOutput = "",
        Level = 0
    };

    public static Challenge CHALLENGE_D2 = new Challenge
    {
        Name = "D2",
        Title = "",
        Description = "",
        SolutionTemplate = "",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "",
        ExpectedOutput = "",
        Level = 0
    };

    public static Challenge CHALLENGE_D3 = new Challenge
    {
        Name = "D3",
        Title = "",
        Description = "",
        SolutionTemplate = "",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "",
        ExpectedOutput = "",
        Level = 0
    };
}