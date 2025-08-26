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
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAKICAgIGxldCByZXN1bHQxID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCBaZXJvKSwgeCA9PiBFeHBlY3RlZCh4WzBdLCBaZXJvKSk7CiAgICBtdXRhYmxlIHJlc3VsdDFDb3VudCA9IDA7CiAgICBmb3IgaSBpbiAxLi4xMAogICAgewogICAgICAgIHVzZSBxID0gUXViaXQoKTsKICAgICAgICBTb2x2ZShxLCBaZXJvKTsKICAgICAgICBzZXQgcmVzdWx0MUNvdW50ICs9IE1SZXNldFoocSkgPT0gWmVybyA/IDEgfCAwOwogICAgfQogICAgTG9nTWVzc2FnZShyZXN1bHQxIGFuZCByZXN1bHQxQ291bnQgPT0gMTAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgcHJlcGFyZWQgdGhlIHww4p+pIHN0YXRlIiwgIllvdSBoYXZlIGZhaWxlZCB0byBwcmVwYXJlIHRoZSB8MOKfqSBzdGF0ZSIpOwoKICAgIGxldCByZXN1bHQyID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCBPbmUpLCB4ID0+IEV4cGVjdGVkKHhbMF0sIE9uZSkpOwogICAgbXV0YWJsZSByZXN1bHQyQ291bnQgPSAwOwogICAgZm9yIGkgaW4gMS4uMTAKICAgIHsKICAgICAgICB1c2UgcSA9IFF1Yml0KCk7CiAgICAgICAgU29sdmUocSwgT25lKTsKICAgICAgICBzZXQgcmVzdWx0MkNvdW50ICs9IE1SZXNldFoocSkgPT0gT25lID8gMSB8IDA7CiAgICB9CiAgICBMb2dNZXNzYWdlKHJlc3VsdDIgYW5kIHJlc3VsdDJDb3VudCA9PSAxMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBwcmVwYXJlZCB0aGUgfDHin6kgc3RhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIHByZXBhcmUgdGhlIHwx4p+pIHN0YXRlIik7CgogICAgcmV0dXJuIHJlc3VsdDEgYW5kIHJlc3VsdDFDb3VudCA9PSAxMCBhbmQgcmVzdWx0MiBhbmQgcmVzdWx0MkNvdW50ID09IDEwOwp9CgpmdW5jdGlvbiBMb2dNZXNzYWdlKGlzVmFsaWQ6IEJvb2wsIHZhbGlkTWVzc2FnZTogU3RyaW5nLCBpbnZhbGlkTWVzc2FnZTogU3RyaW5nKSA6ICgpCnsKICAgIGxldCBtZXNzYWdlID0gIntcInZhbGlkXCI6ICIgKyAoaXNWYWxpZCA/ICJ0cnVlIiB8ICJmYWxzZSIpICsgIiwgXCJtZXNzYWdlXCI6IFwiIiArIChpc1ZhbGlkID8gdmFsaWRNZXNzYWdlIHwgaW52YWxpZE1lc3NhZ2UpICsgIlwifSI7CiAgICBNZXNzYWdlKG1lc3NhZ2UpOwp9CgpvcGVyYXRpb24gRXhwZWN0ZWQgKHEgOiBRdWJpdCwgZXhwZWN0ZWRSZXN1bHQgOiBSZXN1bHQpIDogVW5pdCBpcyBBZGoKewogICAgaWYoZXhwZWN0ZWRSZXN1bHQgPT0gT25lKSB7CiAgICAgICAgWChxKTsKICAgIH0KfQoKPDxTT0xWRT4+",
        ExpectedOutput = "true",
        ExpectedStates = "",
        CopilotInstructions = "Challenge 0 is an example challenge that demonstrates how to use this platform to solve challenges. You can help the user in any way you can.",
        Level = 0
    };

    public static Challenge CHALLENGE_A1 = new Challenge
    {
        Name = "A1",
        Title = "Generate superposition of all basis states.",
        Description = "You are given n qubits (1 ≤ n ≤ 8), prepared in the |0..0⟩ state, and you have to implement an operation which generates an equal superposition of all basis states on these qubits.[BR]The \"output\" of your solution is the state in which it left the input qubits.[BR]You should implement the following Solve operation to make that happen and keep the signature of the method exactly like it is.",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxcyA6IFF1Yml0W10pIDogVW5pdCAKewogICAgLy8gWW91ciBzb2x1dGlvbiBsb2dpYyBnb2VzIGhlcmUuCn0=",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgbXV0YWJsZSByZXN1bHRDb3VudCA9IDA7CiAgICBmb3IgaSBpbiAxLi44CiAgICB7CiAgICAgICAgbGV0IHJlc3VsdCA9IENoZWNrT3BlcmF0aW9uc0FyZUVxdWFsKGksIFNvbHZlLCBFeHBlY3RlZCk7CiAgICAgICAgc2V0IHJlc3VsdENvdW50ICs9IHJlc3VsdCA/IDEgfCAwOwogICAgfQoKICAgIExvZ01lc3NhZ2UocmVzdWx0Q291bnQgPT0gOCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBnZW5lcmF0ZWQgZXF1YWwgc3VwZXJwb3NpdGlvbiBvZiBhbGwgYmFzaXMgc3RhdGVzIiwgIllvdSBoYXZlIGZhaWxlZCB0byBnZW5lcmF0ZSBlcXVhbCBzdXBlcnBvc2l0aW9uIG9mIGFsbCBiYXNpcyBzdGF0ZXMiKTsKCiAgICB1c2UgcXMgPSBRdWJpdFszXTsKICAgIFNvbHZlKHFzKTsKICAgIER1bXBSZWdpc3Rlcihxcyk7CiAgICBSZXNldEFsbChxcyk7CgogICAgcmV0dXJuIHJlc3VsdENvdW50ID09IDg7Cn0KCmZ1bmN0aW9uIExvZ01lc3NhZ2UoaXNWYWxpZDogQm9vbCwgdmFsaWRNZXNzYWdlOiBTdHJpbmcsIGludmFsaWRNZXNzYWdlOiBTdHJpbmcpIDogKCkKewogICAgbGV0IG1lc3NhZ2UgPSAie1widmFsaWRcIjogIiArIChpc1ZhbGlkID8gInRydWUiIHwgImZhbHNlIikgKyAiLCBcIm1lc3NhZ2VcIjogXCIiICsgKGlzVmFsaWQgPyB2YWxpZE1lc3NhZ2UgfCBpbnZhbGlkTWVzc2FnZSkgKyAiXCJ9IjsKICAgIE1lc3NhZ2UobWVzc2FnZSk7Cn0KCm9wZXJhdGlvbiBFeHBlY3RlZCAocXMgOiBRdWJpdFtdKSA6IFVuaXQgaXMgQWRqCnsKICAgIGZvciBxIGluIHFzIAogICAgewogICAgICAgIEgocSk7CiAgICB9Cn0KCjw8U09MVkU+Pg==",
        ExpectedOutput = "true",
        ExpectedStates = "WwogIHsKICAgICJpZCI6ICJ8MDAw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MDAx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MDEw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MDEx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MTAw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MTAx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MTEw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MTEx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4zNTM2LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9Cl0=",
        CopilotInstructions = "You should not immediately tell the user to use the H-gate in a for loop or use the ApplyToEach operation. After discussing the concept of superposition, you can suggest that they apply the Hadamard gate to each qubit individually or even search documentation about the ApplyToEach operation online to achieve the same result.",
        Level = 1
    };

    public static Challenge CHALLENGE_A2 = new Challenge
    {
        Name = "A2",
        Title = "Distinguish I from X",
        Description = "You are given an operation that implements a single-qubit unitary transformation: either the identity gate (I gate) or the bit-flip gate (X gate).[BR]Your task is to perform necessary operations and/or measurements to figure out which unitary it was and to return 0 if it was the I gate or 1 if it was the X gate.[BR]You are allowed to apply the given operation exactly once.[BR]You have to implement an operation which takes a single-qubit operation as an input and returns an integer. The operation should have the following signature:",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlICh1bml0YXJ5IDogKFF1Yml0ID0+IFVuaXQpKSA6IEludAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgLy8gV3JhcCB0aGUgSSBnYXRlIGluIGEgdW5pdGFyeSBvcGVyYXRpb24gdG8gYmUgYWJsZSB0byBjaGVjayB0aGUgbnVtYmVyIG9mIHRpbWVzIGl0IHdhcyBhcHBsaWVkLgogICAgbGV0IHVuaXRhcnkxID0gcSA9PiBJKHEpOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBtdXRhYmxlIHJlc3VsdDFDb3VudCA9IDA7CiAgICBmb3IgaSBpbiAxLi4xMAogICAgewogICAgICAgIGxldCByZXN1bHQxID0gU29sdmUodW5pdGFyeTEpOwogICAgICAgIHNldCByZXN1bHQxQ291bnQgKz0gcmVzdWx0MSA9PSAwID8gMSB8IDA7CiAgICB9CiAgICBMb2dNZXNzYWdlKHJlc3VsdDFDb3VudCA9PSAxMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBpZGVudGlmaWVkIHRoZSBJLWdhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IHRoZSBJLWdhdGUiKTsKICAgIGxldCBudW1iZXJPZlVuaXRhcnkxID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkxKTsKICAgIExvZ01lc3NhZ2UobnVtYmVyT2ZVbml0YXJ5MSA9PSAxMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBhcHBsaWVkIHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IG9uY2Ugd2hpbGUgaWRlbnRpZnlpbmcgdGhlIEktZ2F0ZSIsICQiWW91IGhhdmUgZmFpbGVkIHRvIGFwcGx5IHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IG9uY2UgYW5kIGFwcGxpZWQgaXQge251bWJlck9mVW5pdGFyeTF9IHRpbWVzIHdoaWxlIGlkZW50aWZ5aW5nIHRoZSBJLWdhdGUiKTsKCiAgICAvLyBXcmFwIHRoZSBYIGdhdGUgaW4gYSB1bml0YXJ5IG9wZXJhdGlvbiB0byBiZSBhYmxlIHRvIGNoZWNrIHRoZSBudW1iZXIgb2YgdGltZXMgaXQgd2FzIGFwcGxpZWQuCiAgICBsZXQgdW5pdGFyeTIgPSBxID0+IFgocSk7CiAgICBTdGFydENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkyKTsKICAgIG11dGFibGUgcmVzdWx0MkNvdW50ID0gMDsKICAgIGZvciBpIGluIDEuLjEwCiAgICB7CiAgICAgICAgbGV0IHJlc3VsdDIgPSBTb2x2ZSh1bml0YXJ5Mik7CiAgICAgICAgc2V0IHJlc3VsdDJDb3VudCArPSByZXN1bHQyID09IDEgPyAxIHwgMDsKICAgIH0KICAgIExvZ01lc3NhZ2UocmVzdWx0MkNvdW50ID09IDEwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgdGhlIFgtZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIFgtZ2F0ZSIpOwogICAgbGV0IG51bWJlck9mVW5pdGFyeTIgPSBTdG9wQ291bnRpbmdPcGVyYXRpb24odW5pdGFyeTIpOwogICAgTG9nTWVzc2FnZShudW1iZXJPZlVuaXRhcnkyID09IDEwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGFwcGxpZWQgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgb25jZSB3aGlsZSBpZGVudGlmeWluZyB0aGUgWC1nYXRlIiwgJCJZb3UgaGF2ZSBmYWlsZWQgdG8gYXBwbHkgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgb25jZSBhbmQgYXBwbGllZCBpdCB7bnVtYmVyT2ZVbml0YXJ5Mn0gdGltZXMgd2hpbGUgaWRlbnRpZnlpbmcgdGhlIFgtZ2F0ZSIpOwoKICAgIC8vIFJldHVybiB0cnVlIGlmIHRoZSBJIGdhdGUgd2FzIGlkZW50aWZpZWQgYXMgMCBhbmQgdGhlIFggZ2F0ZSBhcyAxLCBhbmQgYm90aCB1bml0YXJ5IG9wZXJhdGlvbnMgd2VyZSBhcHBsaWVkIGV4YWN0bHkgb25jZS4KICAgIHJldHVybiByZXN1bHQxQ291bnQgPT0gMTAgYW5kIG51bWJlck9mVW5pdGFyeTEgPT0gMTAgYW5kIHJlc3VsdDJDb3VudCA9PSAxMCBhbmQgbnVtYmVyT2ZVbml0YXJ5MiA9PSAxMDsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKPDxTT0xWRT4+",
        ExpectedOutput = "true",
        ExpectedStates = "",
        CopilotInstructions = "",
        Level = 1
    };

    public static Challenge CHALLENGE_A3 = new Challenge
     {
         Name = "A3",
         Title = "Use only the Z and H gates to bitflip a qubit",
         Description = "You can bitflip a qubit by applying the X gate, but in this challenge you are only allowed to use the Z and H gates.[BR]You have to implement an operation which takes a single qubit as input and has no output.[BR]The \"output\" of your solution is the state in which it left the input qubit.",
         SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxIDogUXViaXQpIDogVW5pdAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
         ExampleDescription = "",
         ExampleCode = "",
         VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgCiAgICBsZXQgcmVzdWx0ID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdKSwgeCA9PiBFeHBlY3RlZCh4WzBdKSk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBiaXRmbGlwcGVkIHRoZSBxdWJpdCIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gYml0ZmxpcCB0aGUgcXViaXQiKTsKICAgIAogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbihYKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24oSCk7CiAgICBTdGFydENvdW50aW5nT3BlcmF0aW9uKFopOwogICAgdXNlIHEgPSBRdWJpdCgpOwogICAgU29sdmUocSk7CiAgICBSZXNldChxKTsKICAgIGxldCByZXN1bHRYID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKFgpOwogICAgTG9nTWVzc2FnZShyZXN1bHRYID09IDAsICJZb3UgaGF2ZSBub3QgdXNlZCB0aGUgWCBnYXRlIiwgJCJUaGUgWCBnYXRlIHdhcyB1c2VkIHtyZXN1bHRYfSB0aW1lcyIpOwogICAgbGV0IHJlc3VsdEggPSBTdG9wQ291bnRpbmdPcGVyYXRpb24oSCk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdEggPT0gMiwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSB1c2VkIHRoZSBIIGdhdGUgdHdpY2UiLCAkIllvdSBoYXZlIGZhaWxlZCB0byB1c2UgdGhlIEggZ2F0ZSB0aGUgY29ycmVjdCBudW1iZXIgb2YgdGltZXMgYW5kIHVzZWQgaXQge3Jlc3VsdEh9IHRpbWVzIik7CiAgICBsZXQgcmVzdWx0WiA9IFN0b3BDb3VudGluZ09wZXJhdGlvbihaKTsKICAgIExvZ01lc3NhZ2UocmVzdWx0WiA9PSAxLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IHVzZWQgdGhlIFogZ2F0ZSBvbmNlIiwgJCJZb3UgaGF2ZSBmYWlsZWQgdG8gdXNlIHRoZSBaIGdhdGUgdGhlIGNvcnJlY3QgbnVtYmVyIG9mIHRpbWVzIGFuZCB1c2VkIGl0IHtyZXN1bHRafSB0aW1lcyIpOwoKICAgIHJldHVybiByZXN1bHQgYW5kIHJlc3VsdFggPT0gMCBhbmQgcmVzdWx0SCA9PSAyIGFuZCByZXN1bHRaID09IDE7Cn0KCmZ1bmN0aW9uIExvZ01lc3NhZ2UoaXNWYWxpZDogQm9vbCwgdmFsaWRNZXNzYWdlOiBTdHJpbmcsIGludmFsaWRNZXNzYWdlOiBTdHJpbmcpIDogKCkKewogICAgbGV0IG1lc3NhZ2UgPSAie1widmFsaWRcIjogIiArIChpc1ZhbGlkID8gInRydWUiIHwgImZhbHNlIikgKyAiLCBcIm1lc3NhZ2VcIjogXCIiICsgKGlzVmFsaWQgPyB2YWxpZE1lc3NhZ2UgfCBpbnZhbGlkTWVzc2FnZSkgKyAiXCJ9IjsKICAgIE1lc3NhZ2UobWVzc2FnZSk7Cn0KCm9wZXJhdGlvbiBFeHBlY3RlZCAocSA6IFF1Yml0KSA6IFVuaXQgaXMgQWRqCnsKICAgIEgocSk7CiAgICBaKHEpOwogICAgSChxKTsKfQoKPDxTT0xWRT4+",
         ExpectedOutput = "true",
         ExpectedStates = "",
         CopilotInstructions = "You should never mention HZH to the user since this would be the solution. Only give them hints.",
         Level = 1
     };

    public static Challenge CHALLENGE_B1 = new Challenge
    {
        Name = "B1",
        Title = "Generate |+⟩ state or |-⟩ state",
        Description = "You have to implement an operation which takes a qubit that has been prepared in the |0⟩ state and an integer that specifies the desired sign: +1 for the |+⟩ state and -1 for |-⟩ state.[BR]You should implement the following Solve method to make that happen and keep the signature of the method exactly like it is.",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxIDogUXViaXQsIHNpZ24gOiBJbnQpIDogVW5pdAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIGxldCByZXN1bHQxID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCAxKSwgeCA9PiBFeHBlY3RlZCh4WzBdLCAxKSk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDEsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIHRoZSB8K+KfqSBzdGF0ZSBmb3Igc2lnbiAxIiwgIllvdSBoYXZlIGZhaWxlZCB0byBnZW5lcmF0ZSB0aGUgfCvin6kgc3RhdGUgZm9yIHNpZ24gMSIpOwoKICAgIGxldCByZXN1bHQyID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCAtMSksIHggPT4gRXhwZWN0ZWQoeFswXSwgLTEpKTsKICAgIExvZ01lc3NhZ2UocmVzdWx0MiwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBnZW5lcmF0ZWQgdGhlIHwt4p+pIHN0YXRlIGZvciBzaWduIC0xIiwgIllvdSBoYXZlIGZhaWxlZCB0byBnZW5lcmF0ZSB0aGUgfC3in6kgc3RhdGUgZm9yIHNpZ24gLTEiKTsKCiAgICB1c2UgKHExLCBxMikgPSAoUXViaXQoKSwgUXViaXQoKSk7CiAgICBTb2x2ZShxMSwgMSk7CiAgICBTb2x2ZShxMiwgLTEpOwogICAgRHVtcFJlZ2lzdGVyKFtxMSwgcTJdKTsKICAgIFJlc2V0QWxsKFtxMSwgcTJdKTsKCiAgICByZXR1cm4gcmVzdWx0MSBhbmQgcmVzdWx0MjsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKb3BlcmF0aW9uIEV4cGVjdGVkIChxIDogUXViaXQsIHNpZ24gOiBJbnQpIDogVW5pdCBpcyBBZGoKewogICAgaWYoc2lnbiA8IDApCiAgICB7CiAgICAgICAgWChxKTsKICAgIH0KCiAgICBIKHEpOwp9Cgo8PFNPTFZFPj4=",
        ExpectedOutput = "true",
        ExpectedStates = "WwogIHsKICAgICJpZCI6ICJ8MDDin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjUsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwwMeKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IC0wLjUsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwxMOKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuNSwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfSwKICB7CiAgICAiaWQiOiAifDEx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogLTAuNSwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfQpd",
        CopilotInstructions = "",
        Level = 2
    };

    public static Challenge CHALLENGE_B2 = new Challenge
    {
        Name = "B2",
        Title = "Distinguish H from X",
        Description = "You are given an operation that implements a single-qubit unitary transformation: either the Hadamard gate (H gate) or the bit-flip gate (X gate).[BR]Your task is to perform necessary operations and measurements to figure out which unitary it was and to return 0 if it was the H gate or 1 if it was the X gate.[BR]You are allowed to apply the given operation exactly twice.[BR]You have to implement an operation which takes a single-qubit operation as an input and returns an integer. The operation should have the following signature:",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlICh1bml0YXJ5IDogKFF1Yml0ID0+IFVuaXQpKSA6IEludAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgLy8gV3JhcCB0aGUgSCBnYXRlIGluIGEgdW5pdGFyeSBvcGVyYXRpb24gdG8gYmUgYWJsZSB0byBjaGVjayB0aGUgbnVtYmVyIG9mIHRpbWVzIGl0IHdhcyBhcHBsaWVkLgogICAgbGV0IHVuaXRhcnkxID0gcSA9PiBIKHEpOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBtdXRhYmxlIHJlc3VsdDFDb3VudCA9IDA7CiAgICBmb3IgaSBpbiAxLi4xMAogICAgewogICAgICAgIGxldCByZXN1bHQxID0gU29sdmUodW5pdGFyeTEpOwogICAgICAgIHNldCByZXN1bHQxQ291bnQgKz0gcmVzdWx0MSA9PSAwID8gMSB8IDA7CiAgICB9ICAgIAogICAgTG9nTWVzc2FnZShyZXN1bHQxQ291bnQgPT0gMTAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgaWRlbnRpZmllZCB0aGUgSC1nYXRlIiwgIllvdSBoYXZlIGZhaWxlZCB0byBpZGVudGlmeSB0aGUgSC1nYXRlIik7CiAgICBsZXQgbnVtYmVyT2ZVbml0YXJ5MSA9IFN0b3BDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBMb2dNZXNzYWdlKG51bWJlck9mVW5pdGFyeTEgPT0gMjAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgYXBwbGllZCB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSB3aGlsZSBpZGVudGlmeWluZyB0aGUgSC1nYXRlIiwgJCJZb3UgaGF2ZSBmYWlsZWQgdG8gYXBwbHkgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgdHdpY2UgYW5kIGFwcGxpZWQgaXQge251bWJlck9mVW5pdGFyeTF9IHRpbWVzIHdoaWxlIGlkZW50aWZ5aW5nIHRoZSBILWdhdGUiKTsKCiAgICAvLyBXcmFwIHRoZSBYIGdhdGUgaW4gYSB1bml0YXJ5IG9wZXJhdGlvbiB0byBiZSBhYmxlIHRvIGNoZWNrIHRoZSBudW1iZXIgb2YgdGltZXMgaXQgd2FzIGFwcGxpZWQuCiAgICBsZXQgdW5pdGFyeTIgPSBxID0+IFgocSk7CiAgICBTdGFydENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkyKTsKICAgIG11dGFibGUgcmVzdWx0MkNvdW50ID0gMDsKICAgIGZvciBpIGluIDEuLjEwCiAgICB7CiAgICAgICAgbGV0IHJlc3VsdDIgPSBTb2x2ZSh1bml0YXJ5Mik7CiAgICAgICAgc2V0IHJlc3VsdDJDb3VudCArPSByZXN1bHQyID09IDEgPyAxIHwgMDsKICAgIH0KICAgIExvZ01lc3NhZ2UocmVzdWx0MkNvdW50ID09IDEwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgdGhlIFgtZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIFgtZ2F0ZSIpOwogICAgbGV0IG51bWJlck9mVW5pdGFyeTIgPSBTdG9wQ291bnRpbmdPcGVyYXRpb24odW5pdGFyeTIpOwogICAgTG9nTWVzc2FnZShudW1iZXJPZlVuaXRhcnkyID09IDIwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGFwcGxpZWQgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgdHdpY2Ugd2hpbGUgaWRlbnRpZnlpbmcgdGhlIFgtZ2F0ZSIsICQiWW91IGhhdmUgZmFpbGVkIHRvIGFwcGx5IHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIGFuZCBhcHBsaWVkIGl0IHtudW1iZXJPZlVuaXRhcnkyfSB0aW1lcyB3aGlsZSBpZGVudGlmeWluZyB0aGUgWC1nYXRlIik7CgogICAgLy8gUmV0dXJuIHRydWUgaWYgdGhlIEggZ2F0ZSB3YXMgaWRlbnRpZmllZCBhcyAwIGFuZCB0aGUgWCBnYXRlIGFzIDEsIGFuZCBib3RoIHVuaXRhcnkgb3BlcmF0aW9ucyB3ZXJlIGFwcGxpZWQgZXhhY3RseSB0d2ljZS4KICAgIHJldHVybiByZXN1bHQxQ291bnQgPT0gMTAgYW5kIG51bWJlck9mVW5pdGFyeTEgPT0gMjAgYW5kIHJlc3VsdDJDb3VudCA9PSAxMCBhbmQgbnVtYmVyT2ZVbml0YXJ5MiA9PSAyMDsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKPDxTT0xWRT4+",
        ExpectedOutput = "true",
        ExpectedStates = "",
        CopilotInstructions = "",
        Level = 2
    };

    public static Challenge CHALLENGE_B3 = new Challenge
    {
        Name = "B3",
        Title = "Generate Bell state",
        Description = "You are given two qubits in state |00⟩ and an integer index. Your task is to create one of the Bell states on them according to the index:[BR]0: |B0⟩ = 1/√2 (|00⟩ + |11⟩)[BR]1: |B1⟩ = 1/√2 (|00⟩ - |11⟩)[BR]2: |B2⟩ = 1/√2 (|01⟩ + |10⟩)[BR]3: |B3⟩ = 1/√2 (|01⟩ - |10⟩)[BR]You have to implement the Solve operation to make the correct Bell state according to the given index. The operation should have the following signature:",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxcyA6IFF1Yml0W10sIGluZGV4IDogSW50KSA6IFVuaXQKewogICAgLy8gWW91ciBzb2x1dGlvbiBsb2dpYyBnb2VzIGhlcmUuCn0=",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIGxldCByZXN1bHQwID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMiwgeCA9PiBTb2x2ZSh4LCAwKSwgeCA9PiBFeHBlY3RlZCh4LCAwKSk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIHRoZSB8QjDin6kgPSAxL+KImjIgKHwwMOKfqSArIHwxMeKfqSkgZm9yIGluZGV4IDAiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGdlbmVyYXRlIHRoZSB8QjDin6kgPSAxL+KImjIgKHwwMOKfqSArIHwxMeKfqSkgc3RhdGUgZm9yIGluZGV4IDAiKTsKICAgIAogICAgbGV0IHJlc3VsdDEgPSBDaGVja09wZXJhdGlvbnNBcmVFcXVhbCgyLCB4ID0+IFNvbHZlKHgsIDEpLCB4ID0+IEV4cGVjdGVkKHgsIDEpKTsKICAgIExvZ01lc3NhZ2UocmVzdWx0MSwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBnZW5lcmF0ZWQgdGhlIHxCMeKfqSA9IDEv4oiaMiAofDAw4p+pIC0gfDEx4p+pKSBmb3IgaW5kZXggMSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gZ2VuZXJhdGUgdGhlIHxCMeKfqSA9IDEv4oiaMiAofDAw4p+pIC0gfDEx4p+pKSBzdGF0ZSBmb3IgaW5kZXggMSIpOwoKICAgIGxldCByZXN1bHQyID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMiwgeCA9PiBTb2x2ZSh4LCAyKSwgeCA9PiBFeHBlY3RlZCh4LCAyKSk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDIsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIHRoZSB8QjLin6kgPSAxL+KImjIgKHwwMeKfqSArIHwxMOKfqSkgZm9yIGluZGV4IDIiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGdlbmVyYXRlIHRoZSB8QjLin6kgPSAxL+KImjIgKHwwMeKfqSArIHwxMOKfqSkgc3RhdGUgZm9yIGluZGV4IDIiKTsKCiAgICBsZXQgcmVzdWx0MyA9IENoZWNrT3BlcmF0aW9uc0FyZUVxdWFsKDIsIHggPT4gU29sdmUoeCwgMyksIHggPT4gRXhwZWN0ZWQoeCwgMykpOwogICAgTG9nTWVzc2FnZShyZXN1bHQzLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGdlbmVyYXRlZCB0aGUgfEIz4p+pID0gMS/iiJoyICh8MDHin6kgLSB8MTDin6kpIGZvciBpbmRleCAzIiwgIllvdSBoYXZlIGZhaWxlZCB0byBnZW5lcmF0ZSB0aGUgfEIz4p+pID0gMS/iiJoyICh8MDHin6kgLSB8MTDin6kpIHN0YXRlIGZvciBpbmRleCAzIik7CgogICAgcmV0dXJuIHJlc3VsdDAgYW5kIHJlc3VsdDEgYW5kIHJlc3VsdDIgYW5kIHJlc3VsdDM7Cn0KCmZ1bmN0aW9uIExvZ01lc3NhZ2UoaXNWYWxpZDogQm9vbCwgdmFsaWRNZXNzYWdlOiBTdHJpbmcsIGludmFsaWRNZXNzYWdlOiBTdHJpbmcpIDogKCkKewogICAgbGV0IG1lc3NhZ2UgPSAie1widmFsaWRcIjogIiArIChpc1ZhbGlkID8gInRydWUiIHwgImZhbHNlIikgKyAiLCBcIm1lc3NhZ2VcIjogXCIiICsgKGlzVmFsaWQgPyB2YWxpZE1lc3NhZ2UgfCBpbnZhbGlkTWVzc2FnZSkgKyAiXCJ9IjsKICAgIE1lc3NhZ2UobWVzc2FnZSk7Cn0KCm9wZXJhdGlvbiBFeHBlY3RlZCAocXMgOiBRdWJpdFtdLCBpbmRleCA6IEludCkgOiBVbml0IGlzIEFkagp7CiAgICAvLyBQdXQgdGhlIGZpcnN0IHF1Yml0IGluIHN1cGVycG9zaXRpb24uCiAgICBIKHFzWzBdKTsKCiAgICAvLyBJZiB0aGUgcmVzdWx0IHNob3VsZCBiZSB8MDDin6kgLSB8MTHin6kgb3IgfDAx4p+pIC0gfDEw4p+pLCB3ZSBuZWVkIHRvIGFwcGx5IHRoZSBaLWdhdGUgdG8gYWx0ZXIgdGhlIHNpZ24uCiAgICBpZihpbmRleCAlIDIgPT0gMSkKICAgIHsKICAgICAgICBaKHFzWzBdKTsKICAgIH0KICAgIAogICAgLy8gQXBwbHkgdGhlIENOT1QgZ2F0ZSB0byBlbnRhbmdsZSB0aGUgcXViaXRzLgogICAgQ05PVChxc1swXSwgcXNbMV0pOwogICAgCiAgICAvLyBJZiB0aGUgcmVzdWx0IHNob3VsZCBiZSB8MDHin6kgKyB8MTDin6kgb3IgfDAx4p+pIC0gfDEw4p+pLCB3ZSBuZWVkIHRvIGFwcGx5IHRoZSBYLWdhdGUgdG8gdGhlIHNlY29uZCBxdWJpdC4KICAgIGlmKGluZGV4IC8gMiA9PSAxKQogICAgewogICAgICAgIFgocXNbMV0pOwogICAgfQp9Cgo8PFNPTFZFPj4=",
        ExpectedOutput = "true",
        ExpectedStates = "",
        CopilotInstructions = "",
        Level = 2
    };

    public static Challenge CHALLENGE_C1 = new Challenge
    {
        Name = "C1",
        Title = "Generate GHZ state",
        Description = "Your task is to create Greenberger–Horne–Zeilinger (GHZ) state on N qubits (1 ≤ N ≤ 8) in zero |0..0⟩ state.[BR]The GHZ state is defined as |GHZ⟩ = 1/√2 (|0..0⟩ + |1..1⟩).[BR]You have to implement an operation which takes an array of N qubits and you need to create the GHZ state on them. The operation should have the following signature:",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxcyA6IFF1Yml0W10pIDogVW5pdAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgbXV0YWJsZSByZXN1bHRDb3VudGVyID0gMDsKCiAgICBmb3IgaSBpbiAxLi44CiAgICB7CiAgICAgICAgbGV0IHJlc3VsdCA9IENoZWNrT3BlcmF0aW9uc0FyZUVxdWFsKGksIFNvbHZlLCBFeHBlY3RlZCk7CiAgICAgICAgc2V0IHJlc3VsdENvdW50ZXIgKz0gcmVzdWx0ID8gMSB8IDA7CiAgICB9CgogICAgTG9nTWVzc2FnZShyZXN1bHRDb3VudGVyID09IDgsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIHRoZSBHSFogc3RhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGdlbmVyYXRlIHRoZSBHSFogc3RhdGUiKTsKCiAgICB1c2UgcXMgPSBRdWJpdFs4XTsKICAgIFNvbHZlKHFzKTsKICAgIER1bXBSZWdpc3Rlcihxcyk7CiAgICBSZXNldEFsbChxcyk7CgogICAgcmV0dXJuIHJlc3VsdENvdW50ZXIgPT0gODsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKb3BlcmF0aW9uIEV4cGVjdGVkIChxcyA6IFF1Yml0W10pIDogVW5pdCBpcyBBZGoKewogICAgSChxc1swXSk7CiAgICBmb3IgaSBpbiAxIC4uIExlbmd0aChxcykgLSAxCiAgICB7CiAgICAgICAgQ05PVChxc1swXSwgcXNbaV0pOwogICAgfQp9Cgo8PFNPTFZFPj4=",
        ExpectedOutput = "true",
        ExpectedStates = "WwogIHsKICAgICJpZCI6ICJ8MDAwMDAwMDDin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjcwNzEsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwxMTExMTExMeKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuNzA3MSwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfQpd",
        CopilotInstructions = "",
        Level = 3
    };

    public static Challenge CHALLENGE_C2 = new Challenge
    {
        Name = "C2",
        Title = "Distinguish I, CNOTs and SWAP",
        Description = "You are given an operation that implements a two-qubit unitary transformation: either the identity (I ⊗ I gate), the CNOT gate (either with the first qubit as control and the second qubit as target or vice versa) or the SWAP gate.[BR]Your task is to perform necessary operations and measurements to figure out which unitary it was and to return:[BR]0 if it was the I ⊗ I gate,[BR]1 if it was the CNOT12 gate,[BR]2 if it was the CNOT21 gate,[BR]3 if it was the SWAP gate.[BR]You are allowed to apply the given operation exactly twice.[BR]You have to implement an operation which takes a two-qubit operation unitary as an input and returns an integer. The operation unitary will accept an array of qubits as input, but it will fail if the array is empty or has one or more than two qubits. Your code should have the following signature:",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlICh1bml0YXJ5IDogKFF1Yml0W10gPT4gVW5pdCkpIDogSW50CnsKICAgIC8vIFlvdXIgc29sdXRpb24gbG9naWMgZ29lcyBoZXJlLgp9",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "aW1wb3J0IFN0ZC5Db252ZXJ0LlJlc3VsdEFycmF5QXNJbnQ7CmltcG9ydCBTdGQuQXJpdGhtZXRpYy4qOwppbXBvcnQgU3RkLkNhbm9uLio7CmltcG9ydCBTdGQuRGlhZ25vc3RpY3MuKjsKaW1wb3J0IFN0ZC5NYXRoLio7CmltcG9ydCBTdGQuTWVhc3VyZW1lbnQuKjsKCm9wZXJhdGlvbiBNYWluKCkgOiBCb29sCnsKICAgIC8vIFdyYXAgdGhlIEkg4oqXIEkgZ2F0ZSBpbiBhIHVuaXRhcnkgb3BlcmF0aW9uIHRvIGJlIGFibGUgdG8gY2hlY2sgdGhlIG51bWJlciBvZiB0aW1lcyBpdCB3YXMgYXBwbGllZC4KICAgIGxldCB1bml0YXJ5MCA9IHFzID0+IEFwcGx5VG9FYWNoKEksIHFzKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24odW5pdGFyeTApOwogICAgbXV0YWJsZSByZXN1bHQwQ291bnQgPSAwOwogICAgZm9yIGkgaW4gMS4uMTAKICAgIHsKICAgICAgICBsZXQgcmVzdWx0MCA9IFNvbHZlKHVuaXRhcnkwKTsKICAgICAgICByZXN1bHQwQ291bnQgKz0gcmVzdWx0MCA9PSAwID8gMSB8IDA7CiAgICB9CiAgICBMb2dNZXNzYWdlKHJlc3VsdDBDb3VudCA9PSAxMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBpZGVudGlmaWVkIHRoZSBJIOKKlyBJIGdhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IHRoZSBJIOKKlyBJIGdhdGUiKTsKICAgIGxldCBudW1iZXJPZlVuaXRhcnkwID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkwKTsKICAgIExvZ01lc3NhZ2UobnVtYmVyT2ZVbml0YXJ5MCA9PSAyMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBhcHBsaWVkIHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIHdoaWxlIGlkZW50aWZ5aW5nIHRoZSBJIOKKlyBJIGdhdGUiLCAkIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSBhbmQgYXBwbGllZCBpdCB7bnVtYmVyT2ZVbml0YXJ5MH0gdGltZXMgd2hpbGUgaWRlbnRpZnlpbmcgdGhlIEkg4oqXIEkgZ2F0ZSIpOwoKICAgIC8vIFdyYXAgdGhlIENOT1QxMiBnYXRlIGluIGEgdW5pdGFyeSBvcGVyYXRpb24gdG8gYmUgYWJsZSB0byBjaGVjayB0aGUgbnVtYmVyIG9mIHRpbWVzIGl0IHdhcyBhcHBsaWVkLgogICAgbGV0IHVuaXRhcnkxID0gcXMgPT4gQ05PVChxc1swXSwgcXNbMV0pOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBtdXRhYmxlIHJlc3VsdDFDb3VudCA9IDA7CiAgICBmb3IgaSBpbiAxLi4xMAogICAgewogICAgICAgIGxldCByZXN1bHQxID0gU29sdmUodW5pdGFyeTEpOwogICAgICAgIHJlc3VsdDFDb3VudCArPSByZXN1bHQxID09IDEgPyAxIHwgMDsKICAgIH0KICAgIExvZ01lc3NhZ2UocmVzdWx0MUNvdW50ID09IDEwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgdGhlIENOT1QxMiBnYXRlIiwgIllvdSBoYXZlIGZhaWxlZCB0byBpZGVudGlmeSB0aGUgQ05PVDEyIGdhdGUiKTsKICAgIGxldCBudW1iZXJPZlVuaXRhcnkxID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkxKTsKICAgIExvZ01lc3NhZ2UobnVtYmVyT2ZVbml0YXJ5MSA9PSAyMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBhcHBsaWVkIHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIHdoaWxlIGlkZW50aWZ5aW5nIHRoZSBDTk9UMTIgZ2F0ZSIsICQiWW91IGhhdmUgZmFpbGVkIHRvIGFwcGx5IHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIGFuZCBhcHBsaWVkIGl0IHtudW1iZXJPZlVuaXRhcnkxfSB0aW1lcyB3aGlsZSBpZGVudGlmeWluZyB0aGUgQ05PVDEyIGdhdGUiKTsKCiAgICAvLyBXcmFwIHRoZSBDTk9UMjEgZ2F0ZSBpbiBhIHVuaXRhcnkgb3BlcmF0aW9uIHRvIGJlIGFibGUgdG8gY2hlY2sgdGhlIG51bWJlciBvZiB0aW1lcyBpdCB3YXMgYXBwbGllZC4KICAgIGxldCB1bml0YXJ5MiA9IHFzID0+IENOT1QocXNbMV0sIHFzWzBdKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24odW5pdGFyeTIpOwogICAgbXV0YWJsZSByZXN1bHQyQ291bnQgPSAwOwogICAgZm9yIGkgaW4gMS4uMTAKICAgIHsKICAgICAgICBsZXQgcmVzdWx0MiA9IFNvbHZlKHVuaXRhcnkyKTsKICAgICAgICByZXN1bHQyQ291bnQgKz0gcmVzdWx0MiA9PSAyID8gMSB8IDA7CiAgICB9CiAgICBMb2dNZXNzYWdlKHJlc3VsdDJDb3VudCA9PSAxMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBpZGVudGlmaWVkIHRoZSBDTk9UMjEgZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIENOT1QyMSBnYXRlIik7CiAgICBsZXQgbnVtYmVyT2ZVbml0YXJ5MiA9IFN0b3BDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5Mik7CiAgICBMb2dNZXNzYWdlKG51bWJlck9mVW5pdGFyeTIgPT0gMjAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgYXBwbGllZCB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSB3aGlsZSBpZGVudGlmeWluZyB0aGUgQ05PVDIxIGdhdGUiLCAkIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSBhbmQgYXBwbGllZCBpdCB7bnVtYmVyT2ZVbml0YXJ5Mn0gdGltZXMgd2hpbGUgaWRlbnRpZnlpbmcgdGhlIENOT1QyMSBnYXRlIik7CgogICAgLy8gV3JhcCB0aGUgU1dBUCBnYXRlIGluIGEgdW5pdGFyeSBvcGVyYXRpb24gdG8gYmUgYWJsZSB0byBjaGVjayB0aGUgbnVtYmVyIG9mIHRpbWVzIGl0IHdhcyBhcHBsaWVkLgogICAgbGV0IHVuaXRhcnkzID0gcXMgPT4gU1dBUChxc1swXSwgcXNbMV0pOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5Myk7CiAgICBtdXRhYmxlIHJlc3VsdDNDb3VudCA9IDA7CiAgICBmb3IgaSBpbiAxLi4xMAogICAgewogICAgICAgIGxldCByZXN1bHQzID0gU29sdmUodW5pdGFyeTMpOwogICAgICAgIHJlc3VsdDNDb3VudCArPSByZXN1bHQzID09IDMgPyAxIHwgMDsKICAgIH0KICAgIExvZ01lc3NhZ2UocmVzdWx0M0NvdW50ID09IDEwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgdGhlIFNXQVAgZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIFNXQVAgZ2F0ZSIpOwogICAgbGV0IG51bWJlck9mVW5pdGFyeTMgPSBTdG9wQ291bnRpbmdPcGVyYXRpb24odW5pdGFyeTMpOwogICAgTG9nTWVzc2FnZShudW1iZXJPZlVuaXRhcnkzID09IDIwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGFwcGxpZWQgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgdHdpY2Ugd2hpbGUgaWRlbnRpZnlpbmcgdGhlIFNXQVAgZ2F0ZSIsICQiWW91IGhhdmUgZmFpbGVkIHRvIGFwcGx5IHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIGFuZCBhcHBsaWVkIGl0IHtudW1iZXJPZlVuaXRhcnkzfSB0aW1lcyB3aGlsZSBpZGVudGlmeWluZyB0aGUgU1dBUCBnYXRlIik7CgogICAgLy8gUmV0dXJuIHRydWUgaWYgdGhlIEkg4oqXIEkgZ2F0ZSB3YXMgaWRlbnRpZmllZCBhcyAwLCB0aGUgQ05PVDEyIGdhdGUgYXMgMSwgdGhlIENOT1QyMSBnYXRlIGFzIDIsIHRoZSBTV0FQIGdhdGUgYXMgMywgYW5kIGFsbCB1bml0YXJ5IG9wZXJhdGlvbnMgd2VyZSBhcHBsaWVkIGV4YWN0bHkgdHdpY2UuCiAgICByZXR1cm4gcmVzdWx0MENvdW50ID09IDEwIGFuZCBudW1iZXJPZlVuaXRhcnkwID09IDIwIGFuZCByZXN1bHQxQ291bnQgPT0gMTAgYW5kIG51bWJlck9mVW5pdGFyeTEgPT0gMjAgYW5kIHJlc3VsdDJDb3VudCA9PSAxMCBhbmQgbnVtYmVyT2ZVbml0YXJ5MiA9PSAyMCBhbmQgcmVzdWx0M0NvdW50ID09IDEwIGFuZCBudW1iZXJPZlVuaXRhcnkzID09IDIwOwp9CgpmdW5jdGlvbiBMb2dNZXNzYWdlKGlzVmFsaWQ6IEJvb2wsIHZhbGlkTWVzc2FnZTogU3RyaW5nLCBpbnZhbGlkTWVzc2FnZTogU3RyaW5nKSA6ICgpCnsKICAgIGxldCBtZXNzYWdlID0gIntcInZhbGlkXCI6ICIgKyAoaXNWYWxpZCA/ICJ0cnVlIiB8ICJmYWxzZSIpICsgIiwgXCJtZXNzYWdlXCI6IFwiIiArIChpc1ZhbGlkID8gdmFsaWRNZXNzYWdlIHwgaW52YWxpZE1lc3NhZ2UpICsgIlwifSI7CiAgICBNZXNzYWdlKG1lc3NhZ2UpOwp9Cgo8PFNPTFZFPj4=",
        ExpectedOutput = "true",
        ExpectedStates = "",
        CopilotInstructions = "",
        Level = 3
    };

    public static Challenge CHALLENGE_C3 = new Challenge
    {
        Name = "C3",
        Title = "Generate 1/√3 (|01⟩ + |10⟩ + |11⟩)",
        Description = "Your task is to prepare the following state on two qubits in state |00⟩:[BR]1/√3 (|01⟩ + |10⟩ + |11⟩)[BR]You have to implement the Solve operation which takes an array of qubits and you need to create the above state on them.[BR]The operation should have the following signature:",
        SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChxcyA6IFF1Yml0W10pIDogVW5pdAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
        ExampleDescription = "",
        ExampleCode = "",
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgdXNlIHFzID0gUXViaXRbMl07CgogICAgbXV0YWJsZSByZXN1bHRDb3VudCA9IDA7CgogICAgZm9yIGkgaW4gMS4uMTAwCiAgICB7CiAgICAgICAgU29sdmUocXMpOwoKICAgICAgICBsZXQgYjEgPSBNUmVzZXRaKHFzWzBdKTsKICAgICAgICBsZXQgYjIgPSBNUmVzZXRaKHFzWzFdKTsKCiAgICAgICAgc2V0IHJlc3VsdENvdW50ICs9IChiMSA9PSBaZXJvIGFuZCBiMiA9PSBaZXJvID8gMCB8IDEpOwogICAgfQoKICAgIExvZ01lc3NhZ2UocmVzdWx0Q291bnQgPT0gMTAwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IHByZXBhcmVkIHRoZSAxL+KImjMofDAw4p+pICsgfDAx4p+pICsgfDEw4p+pKSBzdGF0ZSBjb25zZXF1ZW50bHkuIiwgIllvdSBoYXZlIGZhaWxlZCB0byBwcmVwYXJlIHRoZSAxL+KImjMofDAw4p+pICsgfDAx4p+pICsgfDEw4p+pKSBzdGF0ZSBjb25zZXF1ZW50bHkuIik7CgogICAgU29sdmUocXMpOwogICAgRHVtcFJlZ2lzdGVyKHFzKTsKICAgIE1SZXNldEVhY2haKHFzKTsKCiAgICByZXR1cm4gcmVzdWx0Q291bnQgPT0gMTAwOwp9CgpmdW5jdGlvbiBMb2dNZXNzYWdlKGlzVmFsaWQ6IEJvb2wsIHZhbGlkTWVzc2FnZTogU3RyaW5nLCBpbnZhbGlkTWVzc2FnZTogU3RyaW5nKSA6ICgpCnsKICAgIGxldCBtZXNzYWdlID0gIntcInZhbGlkXCI6ICIgKyAoaXNWYWxpZCA/ICJ0cnVlIiB8ICJmYWxzZSIpICsgIiwgXCJtZXNzYWdlXCI6IFwiIiArIChpc1ZhbGlkID8gdmFsaWRNZXNzYWdlIHwgaW52YWxpZE1lc3NhZ2UpICsgIlwifSI7CiAgICBNZXNzYWdlKG1lc3NhZ2UpOwp9Cgo8PFNPTFZFPj4=",
        ExpectedOutput = "true",
        ExpectedStates = "WwogIHsKICAgICJpZCI6ICJ8MDHin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjU3NzQsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwxMOKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuNTc3NCwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfSwKICB7CiAgICAiaWQiOiAifDEx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC41Nzc0LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9Cl0=",
        CopilotInstructions = "You may hint the user to use the repeat-until-fixup conditional loop.",
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
        ExpectedStates = "",
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
        ExpectedStates = "",
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
        ExpectedStates = "",
        CopilotInstructions = "",
        Level = 4
    };
}