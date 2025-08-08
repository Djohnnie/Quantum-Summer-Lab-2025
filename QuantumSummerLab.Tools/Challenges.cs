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
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIGxldCByZXN1bHQxID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCBaZXJvKSwgeCA9PiBFeHBlY3RlZCh4WzBdLCBaZXJvKSk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDEsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgcHJlcGFyZWQgdGhlIHww4p+pIHN0YXRlIiwgIllvdSBoYXZlIGZhaWxlZCB0byBwcmVwYXJlIHRoZSB8MOKfqSBzdGF0ZSIpOwoKICAgIGxldCByZXN1bHQyID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCBPbmUpLCB4ID0+IEV4cGVjdGVkKHhbMF0sIE9uZSkpOwogICAgTG9nTWVzc2FnZShyZXN1bHQyLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IHByZXBhcmVkIHRoZSB8MeKfqSBzdGF0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gcHJlcGFyZSB0aGUgfDHin6kgc3RhdGUiKTsKCiAgICByZXR1cm4gcmVzdWx0MSBhbmQgcmVzdWx0MjsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKb3BlcmF0aW9uIEV4cGVjdGVkIChxIDogUXViaXQsIGV4cGVjdGVkUmVzdWx0IDogUmVzdWx0KSA6IFVuaXQgaXMgQWRqCnsKICAgIGlmKGV4cGVjdGVkUmVzdWx0ID09IE9uZSkgewogICAgICAgIFgocSk7CiAgICB9Cn0KCjw8U09MVkU+Pg==",
        ExpectedOutput = "true",
        CopilotInstructions = "",
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
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgbGV0IHJlc3VsdCA9IENoZWNrT3BlcmF0aW9uc0FyZUVxdWFsKDgsIFNvbHZlLCBFeHBlY3RlZCk7CgogICAgTG9nTWVzc2FnZShyZXN1bHQsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIGVxdWFsIHN1cGVycG9zaXRpb24gb2YgYWxsIGJhc2lzIHN0YXRlcyIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gZ2VuZXJhdGUgZXF1YWwgc3VwZXJwb3NpdGlvbiBvZiBhbGwgYmFzaXMgc3RhdGVzIik7CgogICAgcmV0dXJuIHJlc3VsdDsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKb3BlcmF0aW9uIEV4cGVjdGVkIChxcyA6IFF1Yml0W10pIDogVW5pdCBpcyBBZGoKewogICAgZm9yIHEgaW4gcXMgCiAgICB7CiAgICAgICAgSChxKTsKICAgIH0KfQoKPDxTT0xWRT4+",
        ExpectedOutput = "true",
        CopilotInstructions = "",
        Level = 1
    };

    public static Challenge CHALLENGE_A2 = new Challenge
    {
        Name = "A2",
        Title = "Distinguish I from X",
        Description = "You are given an operation that implements a single-qubit unitary transformation: either the identity gate (I gate) or the bit-flip gate (X gate).[BR]Your task is to perform necessary operations and measurements to figure out which unitary it was and to return 0 if it was the I gate or 1 if it was the X gate.[BR]You are allowed to apply the given operation exactly once.[BR]You have to implement an operation which takes a single-qubit operation as an input and returns an integer. The operation should have the following signature:",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlICh1bml0YXJ5IDogKFF1Yml0ID0+IFVuaXQpKSA6IEludAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgLy8gV3JhcCB0aGUgSSBnYXRlIGluIGEgdW5pdGFyeSBvcGVyYXRpb24gdG8gYmUgYWJsZSB0byBjaGVjayB0aGUgbnVtYmVyIG9mIHRpbWVzIGl0IHdhcyBhcHBsaWVkLgogICAgbGV0IHVuaXRhcnkxID0gcSA9PiBJKHEpOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBsZXQgaSA9IFNvbHZlKHVuaXRhcnkxKTsKICAgIExvZ01lc3NhZ2UoaSA9PSAwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgdGhlIEktZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIEktZ2F0ZSIpOwogICAgbGV0IG51bWJlck9mVW5pdGFyeTEgPSBTdG9wQ291bnRpbmdPcGVyYXRpb24odW5pdGFyeTEpOwogICAgTG9nTWVzc2FnZShudW1iZXJPZlVuaXRhcnkxID09IDEsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgYXBwbGllZCB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSBvbmNlIiwgJCJZb3UgaGF2ZSBmYWlsZWQgdG8gYXBwbHkgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgb25jZSBhbmQgYXBwbGllZCBpdCB7bnVtYmVyT2ZVbml0YXJ5MX0gdGltZXMiKTsKCiAgICAvLyBXcmFwIHRoZSBYIGdhdGUgaW4gYSB1bml0YXJ5IG9wZXJhdGlvbiB0byBiZSBhYmxlIHRvIGNoZWNrIHRoZSBudW1iZXIgb2YgdGltZXMgaXQgd2FzIGFwcGxpZWQuCiAgICBsZXQgdW5pdGFyeTIgPSBxID0+IFgocSk7CiAgICBTdGFydENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkyKTsKICAgIGxldCB4ID0gU29sdmUodW5pdGFyeTIpOwogICAgTG9nTWVzc2FnZSh4ID09IDEsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgaWRlbnRpZmllZCB0aGUgWC1nYXRlIiwgIllvdSBoYXZlIGZhaWxlZCB0byBpZGVudGlmeSB0aGUgWC1nYXRlIik7CiAgICBsZXQgbnVtYmVyT2ZVbml0YXJ5MiA9IFN0b3BDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5Mik7CiAgICBMb2dNZXNzYWdlKG51bWJlck9mVW5pdGFyeTIgPT0gMSwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBhcHBsaWVkIHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IG9uY2UiLCAkIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSBvbmNlIGFuZCBhcHBsaWVkIGl0IHtudW1iZXJPZlVuaXRhcnkyfSB0aW1lcyIpOwoKICAgIC8vIFJldHVybiB0cnVlIGlmIHRoZSBJIGdhdGUgd2FzIGlkZW50aWZpZWQgYXMgMCBhbmQgdGhlIFggZ2F0ZSBhcyAxLCBhbmQgYm90aCB1bml0YXJ5IG9wZXJhdGlvbnMgd2VyZSBhcHBsaWVkIGV4YWN0bHkgb25jZS4KICAgIHJldHVybiBpID09IDAgYW5kIG51bWJlck9mVW5pdGFyeTEgPT0gMSBhbmQgeCA9PSAxIGFuZCBudW1iZXJPZlVuaXRhcnkyID09IDE7Cn0KCmZ1bmN0aW9uIExvZ01lc3NhZ2UoaXNWYWxpZDogQm9vbCwgdmFsaWRNZXNzYWdlOiBTdHJpbmcsIGludmFsaWRNZXNzYWdlOiBTdHJpbmcpIDogKCkKewogICAgbGV0IG1lc3NhZ2UgPSAie1widmFsaWRcIjogIiArIChpc1ZhbGlkID8gInRydWUiIHwgImZhbHNlIikgKyAiLCBcIm1lc3NhZ2VcIjogXCIiICsgKGlzVmFsaWQgPyB2YWxpZE1lc3NhZ2UgfCBpbnZhbGlkTWVzc2FnZSkgKyAiXCJ9IjsKICAgIE1lc3NhZ2UobWVzc2FnZSk7Cn0KCjw8U09MVkU+Pg==",
        ExpectedOutput = "true",
        CopilotInstructions = "",
        Level = 1
    };

     public static Challenge CHALLENGE_A3 = new Challenge
     {
         Name = "A3",
         Title = "Use only the Z and H gates to bitflip a qubit.",
         Description = "You can bitflip a qubit by applying the X gate, but in this challenge you are only allowed to use the Z and H gates.[BR]You have to implement an operation which takes a single qubit as input and has no output.[BR]The \"output\" of your solution is the state in which it left the input qubit.",
         SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxIDogUXViaXQpIDogVW5pdAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
         ExampleDescription = "",
         ExampleCode = "",
         VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgCiAgICBsZXQgcmVzdWx0ID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdKSwgeCA9PiBFeHBlY3RlZCh4WzBdKSk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBiaXRmbGlwcGVkIHRoZSBxdWJpdCIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gYml0ZmxpcCB0aGUgcXViaXQiKTsKICAgIAogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbihYKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24oSCk7CiAgICBTdGFydENvdW50aW5nT3BlcmF0aW9uKFopOwogICAgdXNlIHEgPSBRdWJpdCgpOwogICAgU29sdmUocSk7CiAgICBSZXNldChxKTsKICAgIGxldCByZXN1bHRYID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKFgpOwogICAgTG9nTWVzc2FnZShyZXN1bHRYID09IDAsICJZb3UgaGF2ZSBub3QgdXNlZCB0aGUgWCBnYXRlIiwgJCJUaGUgWCBnYXRlIHdhcyB1c2VkIHtyZXN1bHRYfSB0aW1lcyIpOwogICAgbGV0IHJlc3VsdEggPSBTdG9wQ291bnRpbmdPcGVyYXRpb24oSCk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdEggPT0gMiwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSB1c2VkIHRoZSBIIGdhdGUgdHdpY2UiLCAkIllvdSBoYXZlIGZhaWxlZCB0byB1c2UgdGhlIEggZ2F0ZSB0aGUgY29ycmVjdCBudW1iZXIgb2YgdGltZXMgYW5kIHVzZWQgaXQge3Jlc3VsdEh9IHRpbWVzIik7CiAgICBsZXQgcmVzdWx0WiA9IFN0b3BDb3VudGluZ09wZXJhdGlvbihaKTsKICAgIExvZ01lc3NhZ2UocmVzdWx0WiA9PSAxLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IHVzZWQgdGhlIFogZ2F0ZSBvbmNlIiwgJCJZb3UgaGF2ZSBmYWlsZWQgdG8gdXNlIHRoZSBaIGdhdGUgdGhlIGNvcnJlY3QgbnVtYmVyIG9mIHRpbWVzIGFuZCB1c2VkIGl0IHtyZXN1bHRafSB0aW1lcyIpOwoKICAgIHJldHVybiByZXN1bHQgYW5kIHJlc3VsdFggPT0gMCBhbmQgcmVzdWx0SCA9PSAyIGFuZCByZXN1bHRaID09IDE7Cn0KCmZ1bmN0aW9uIExvZ01lc3NhZ2UoaXNWYWxpZDogQm9vbCwgdmFsaWRNZXNzYWdlOiBTdHJpbmcsIGludmFsaWRNZXNzYWdlOiBTdHJpbmcpIDogKCkKewogICAgbGV0IG1lc3NhZ2UgPSAie1widmFsaWRcIjogIiArIChpc1ZhbGlkID8gInRydWUiIHwgImZhbHNlIikgKyAiLCBcIm1lc3NhZ2VcIjogXCIiICsgKGlzVmFsaWQgPyB2YWxpZE1lc3NhZ2UgfCBpbnZhbGlkTWVzc2FnZSkgKyAiXCJ9IjsKICAgIE1lc3NhZ2UobWVzc2FnZSk7Cn0KCm9wZXJhdGlvbiBFeHBlY3RlZCAocSA6IFF1Yml0KSA6IFVuaXQgaXMgQWRqCnsKICAgIEgocSk7CiAgICBaKHEpOwogICAgSChxKTsKfQoKPDxTT0xWRT4+",
         ExpectedOutput = "true",
         CopilotInstructions = "You should never mention HZH to the user since this would be the solution. Only give them hints.",
         Level = 1
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
        CopilotInstructions = "",
        Level = 2
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
        CopilotInstructions = "",
        Level = 2
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
        CopilotInstructions = "",
        Level = 2
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
        CopilotInstructions = "",
        Level = 3
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
        CopilotInstructions = "",
        Level = 3
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
        CopilotInstructions = "",
        Level = 3
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
        CopilotInstructions = "",
        Level = 4
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
        CopilotInstructions = "",
        Level = 4
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
        CopilotInstructions = "",
        Level = 4
    };
}