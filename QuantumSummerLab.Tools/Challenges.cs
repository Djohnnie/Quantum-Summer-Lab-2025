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
        ExpectedStates = "",
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
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgbGV0IHJlc3VsdCA9IENoZWNrT3BlcmF0aW9uc0FyZUVxdWFsKDgsIFNvbHZlLCBFeHBlY3RlZCk7CgogICAgTG9nTWVzc2FnZShyZXN1bHQsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIGVxdWFsIHN1cGVycG9zaXRpb24gb2YgYWxsIGJhc2lzIHN0YXRlcyIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gZ2VuZXJhdGUgZXF1YWwgc3VwZXJwb3NpdGlvbiBvZiBhbGwgYmFzaXMgc3RhdGVzIik7CgogICAgdXNlIHFzID0gUXViaXRbNV07CiAgICBTb2x2ZShxcyk7CiAgICBEdW1wUmVnaXN0ZXIocXMpOwogICAgUmVzZXRBbGwocXMpOwoKICAgIHJldHVybiByZXN1bHQ7Cn0KCmZ1bmN0aW9uIExvZ01lc3NhZ2UoaXNWYWxpZDogQm9vbCwgdmFsaWRNZXNzYWdlOiBTdHJpbmcsIGludmFsaWRNZXNzYWdlOiBTdHJpbmcpIDogKCkKewogICAgbGV0IG1lc3NhZ2UgPSAie1widmFsaWRcIjogIiArIChpc1ZhbGlkID8gInRydWUiIHwgImZhbHNlIikgKyAiLCBcIm1lc3NhZ2VcIjogXCIiICsgKGlzVmFsaWQgPyB2YWxpZE1lc3NhZ2UgfCBpbnZhbGlkTWVzc2FnZSkgKyAiXCJ9IjsKICAgIE1lc3NhZ2UobWVzc2FnZSk7Cn0KCm9wZXJhdGlvbiBFeHBlY3RlZCAocXMgOiBRdWJpdFtdKSA6IFVuaXQgaXMgQWRqCnsKICAgIGZvciBxIGluIHFzIAogICAgewogICAgICAgIEgocSk7CiAgICB9Cn0KCjw8U09MVkU+Pg==",
        ExpectedOutput = "true",
        ExpectedStates = "WwogIHsKICAgICJpZCI6ICJ8MDAwMDDin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjE3NjgsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwwMDAwMeKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuMTc2OCwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfSwKICB7CiAgICAiaWQiOiAifDAwMDEw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4xNzY4LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MDAwMTHin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjE3NjgsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwwMDEwMOKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuMTc2OCwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfSwKICB7CiAgICAiaWQiOiAifDAwMTAx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4xNzY4LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MDAxMTDin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjE3NjgsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwwMDExMeKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuMTc2OCwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfSwKICB7CiAgICAiaWQiOiAifDAxMDAw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4xNzY4LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MDEwMDHin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjE3NjgsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwwMTAxMOKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuMTc2OCwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfSwKICB7CiAgICAiaWQiOiAifDAxMDEx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4xNzY4LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MDExMDDin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjE3NjgsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwwMTEwMeKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuMTc2OCwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfSwKICB7CiAgICAiaWQiOiAifDAxMTEw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4xNzY4LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MDExMTHin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjE3NjgsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwxMDAwMOKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuMTc2OCwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfSwKICB7CiAgICAiaWQiOiAifDEwMDAx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4xNzY4LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MTAwMTDin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjE3NjgsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwxMDAxMeKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuMTc2OCwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfSwKICB7CiAgICAiaWQiOiAifDEwMTAw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4xNzY4LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MTAxMDHin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjE3NjgsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwxMDExMOKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuMTc2OCwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfSwKICB7CiAgICAiaWQiOiAifDEwMTEx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4xNzY4LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MTEwMDDin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjE3NjgsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwxMTAwMeKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuMTc2OCwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfSwKICB7CiAgICAiaWQiOiAifDExMDEw4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4xNzY4LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MTEwMTHin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjE3NjgsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwxMTEwMOKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuMTc2OCwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfSwKICB7CiAgICAiaWQiOiAifDExMTAx4p+pIiwKICAgICJhbXBsaXR1ZGVSZWFsIjogMC4xNzY4LAogICAgImFtcGxpdHVkZUltYWdpbmFyeSI6IDAKICB9LAogIHsKICAgICJpZCI6ICJ8MTExMTDin6kiLAogICAgImFtcGxpdHVkZVJlYWwiOiAwLjE3NjgsCiAgICAiYW1wbGl0dWRlSW1hZ2luYXJ5IjogMAogIH0sCiAgewogICAgImlkIjogInwxMTExMeKfqSIsCiAgICAiYW1wbGl0dWRlUmVhbCI6IDAuMTc2OCwKICAgICJhbXBsaXR1ZGVJbWFnaW5hcnkiOiAwCiAgfQpd",
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
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIGxldCByZXN1bHQxID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCAxKSwgeCA9PiBFeHBlY3RlZCh4WzBdLCAxKSk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDEsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIHRoZSB8K+KfqSBzdGF0ZSBmb3Igc2lnbiAxIiwgIllvdSBoYXZlIGZhaWxlZCB0byBnZW5lcmF0ZSB0aGUgfCvin6kgc3RhdGUgZm9yIHNpZ24gMSIpOwoKICAgIGxldCByZXN1bHQyID0gQ2hlY2tPcGVyYXRpb25zQXJlRXF1YWwoMSwgeCA9PiBTb2x2ZSh4WzBdLCAtMSksIHggPT4gRXhwZWN0ZWQoeFswXSwgLTEpKTsKICAgIExvZ01lc3NhZ2UocmVzdWx0MiwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBnZW5lcmF0ZWQgdGhlIHwt4p+pIHN0YXRlIGZvciBzaWduIC0xIiwgIllvdSBoYXZlIGZhaWxlZCB0byBnZW5lcmF0ZSB0aGUgfC3in6kgc3RhdGUgZm9yIHNpZ24gLTEiKTsKCiAgICByZXR1cm4gcmVzdWx0MSBhbmQgcmVzdWx0MjsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKb3BlcmF0aW9uIEV4cGVjdGVkIChxIDogUXViaXQsIHNpZ24gOiBJbnQpIDogVW5pdCBpcyBBZGoKewogICAgaWYoc2lnbiA8IDApCiAgICB7CiAgICAgICAgWChxKTsKICAgIH0KCiAgICBIKHEpOwp9Cgo8PFNPTFZFPj4=",
        ExpectedOutput = "true",
        ExpectedStates = "",
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
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgLy8gV3JhcCB0aGUgSCBnYXRlIGluIGEgdW5pdGFyeSBvcGVyYXRpb24gdG8gYmUgYWJsZSB0byBjaGVjayB0aGUgbnVtYmVyIG9mIHRpbWVzIGl0IHdhcyBhcHBsaWVkLgogICAgbGV0IHVuaXRhcnkxID0gcSA9PiBIKHEpOwogICAgU3RhcnRDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBsZXQgaSA9IFNvbHZlKHVuaXRhcnkxKTsKICAgIExvZ01lc3NhZ2UoaSA9PSAwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgdGhlIEgtZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIEgtZ2F0ZSIpOwogICAgbGV0IG51bWJlck9mVW5pdGFyeTEgPSBTdG9wQ291bnRpbmdPcGVyYXRpb24odW5pdGFyeTEpOwogICAgTG9nTWVzc2FnZShudW1iZXJPZlVuaXRhcnkxID09IDIsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgYXBwbGllZCB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSIsICQiWW91IGhhdmUgZmFpbGVkIHRvIGFwcGx5IHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIGFuZCBhcHBsaWVkIGl0IHtudW1iZXJPZlVuaXRhcnkxfSB0aW1lcyIpOwoKICAgIC8vIFdyYXAgdGhlIFggZ2F0ZSBpbiBhIHVuaXRhcnkgb3BlcmF0aW9uIHRvIGJlIGFibGUgdG8gY2hlY2sgdGhlIG51bWJlciBvZiB0aW1lcyBpdCB3YXMgYXBwbGllZC4KICAgIGxldCB1bml0YXJ5MiA9IHEgPT4gWChxKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24odW5pdGFyeTIpOwogICAgbGV0IHggPSBTb2x2ZSh1bml0YXJ5Mik7CiAgICBMb2dNZXNzYWdlKHggPT0gMSwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBpZGVudGlmaWVkIHRoZSBYLWdhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IHRoZSBYLWdhdGUiKTsKICAgIGxldCBudW1iZXJPZlVuaXRhcnkyID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkyKTsKICAgIExvZ01lc3NhZ2UobnVtYmVyT2ZVbml0YXJ5MiA9PSAyLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGFwcGxpZWQgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgdHdpY2UiLCAkIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSBhbmQgYXBwbGllZCBpdCB7bnVtYmVyT2ZVbml0YXJ5Mn0gdGltZXMiKTsKCiAgICAvLyBSZXR1cm4gdHJ1ZSBpZiB0aGUgSCBnYXRlIHdhcyBpZGVudGlmaWVkIGFzIDAgYW5kIHRoZSBYIGdhdGUgYXMgMSwgYW5kIGJvdGggdW5pdGFyeSBvcGVyYXRpb25zIHdlcmUgYXBwbGllZCBleGFjdGx5IHR3aWNlLgogICAgcmV0dXJuIGkgPT0gMCBhbmQgbnVtYmVyT2ZVbml0YXJ5MSA9PSAyIGFuZCB4ID09IDEgYW5kIG51bWJlck9mVW5pdGFyeTIgPT0gMjsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKPDxTT0xWRT4+",
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
        VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKeyAgICAKICAgIGxldCByZXN1bHQgPSBDaGVja09wZXJhdGlvbnNBcmVFcXVhbCg4LCBTb2x2ZSwgRXhwZWN0ZWQpOwogICAgTG9nTWVzc2FnZShyZXN1bHQsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgZ2VuZXJhdGVkIHRoZSBHSFogc3RhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGdlbmVyYXRlIHRoZSBHSFogc3RhdGUiKTsKICAgIAogICAgcmV0dXJuIHJlc3VsdDsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKb3BlcmF0aW9uIEV4cGVjdGVkIChxcyA6IFF1Yml0W10pIDogVW5pdCBpcyBBZGoKewogICAgSChxc1swXSk7CiAgICBmb3IgaSBpbiAxIC4uIExlbmd0aChxcykgLSAxCiAgICB7CiAgICAgICAgQ05PVChxc1swXSwgcXNbaV0pOwogICAgfQp9Cgo8PFNPTFZFPj4=",
        ExpectedOutput = "true",
        ExpectedStates = "",
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
        VerificationTemplate = "aW1wb3J0IFN0ZC5Db252ZXJ0LlJlc3VsdEFycmF5QXNJbnQ7CmltcG9ydCBTdGQuQXJpdGhtZXRpYy4qOwppbXBvcnQgU3RkLkNhbm9uLio7CmltcG9ydCBTdGQuRGlhZ25vc3RpY3MuKjsKaW1wb3J0IFN0ZC5NYXRoLio7CmltcG9ydCBTdGQuTWVhc3VyZW1lbnQuKjsKCm9wZXJhdGlvbiBNYWluKCkgOiBCb29sCnsKICAgIC8vIFdyYXAgdGhlIEkg4oqXIEkgZ2F0ZSBpbiBhIHVuaXRhcnkgb3BlcmF0aW9uIHRvIGJlIGFibGUgdG8gY2hlY2sgdGhlIG51bWJlciBvZiB0aW1lcyBpdCB3YXMgYXBwbGllZC4KICAgIGxldCB1bml0YXJ5MCA9IHFzID0+IEFwcGx5VG9FYWNoKEksIHFzKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24odW5pdGFyeTApOwogICAgbGV0IHJlc3VsdDAgPSBTb2x2ZSh1bml0YXJ5MCk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDAgPT0gMCwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBpZGVudGlmaWVkIHRoZSBJIOKKlyBJIGdhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IHRoZSBJIOKKlyBJIGdhdGUiKTsKICAgIGxldCBudW1iZXJPZlVuaXRhcnkwID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkwKTsKICAgIExvZ01lc3NhZ2UobnVtYmVyT2ZVbml0YXJ5MCA9PSAyLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGFwcGxpZWQgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgdHdpY2UiLCAkIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSBhbmQgYXBwbGllZCBpdCB7bnVtYmVyT2ZVbml0YXJ5MH0gdGltZXMiKTsKCiAgICAvLyBXcmFwIHRoZSBDTk9UMTIgZ2F0ZSBpbiBhIHVuaXRhcnkgb3BlcmF0aW9uIHRvIGJlIGFibGUgdG8gY2hlY2sgdGhlIG51bWJlciBvZiB0aW1lcyBpdCB3YXMgYXBwbGllZC4KICAgIGxldCB1bml0YXJ5MSA9IHFzID0+IENOT1QocXNbMF0sIHFzWzFdKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24odW5pdGFyeTEpOwogICAgbGV0IHJlc3VsdDEgPSBTb2x2ZSh1bml0YXJ5MSk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDEgPT0gMSwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBpZGVudGlmaWVkIHRoZSBDTk9UMTIgZ2F0ZSIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgdGhlIENOT1QxMiBnYXRlIik7CiAgICBsZXQgbnVtYmVyT2ZVbml0YXJ5MSA9IFN0b3BDb3VudGluZ09wZXJhdGlvbih1bml0YXJ5MSk7CiAgICBMb2dNZXNzYWdlKG51bWJlck9mVW5pdGFyeTEgPT0gMiwgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBhcHBsaWVkIHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIiwgJCJZb3UgaGF2ZSBmYWlsZWQgdG8gYXBwbHkgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgdHdpY2UgYW5kIGFwcGxpZWQgaXQge251bWJlck9mVW5pdGFyeTB9IHRpbWVzIik7CgogICAgLy8gV3JhcCB0aGUgQ05PVDIxIGdhdGUgaW4gYSB1bml0YXJ5IG9wZXJhdGlvbiB0byBiZSBhYmxlIHRvIGNoZWNrIHRoZSBudW1iZXIgb2YgdGltZXMgaXQgd2FzIGFwcGxpZWQuCiAgICBsZXQgdW5pdGFyeTIgPSBxcyA9PiBDTk9UKHFzWzFdLCBxc1swXSk7CiAgICBTdGFydENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkyKTsKICAgIGxldCByZXN1bHQyID0gU29sdmUodW5pdGFyeTIpOwogICAgTG9nTWVzc2FnZShyZXN1bHQyID09IDIsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgaWRlbnRpZmllZCB0aGUgQ05PVDIxIGdhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IHRoZSBDTk9UMjEgZ2F0ZSIpOwogICAgbGV0IG51bWJlck9mVW5pdGFyeTIgPSBTdG9wQ291bnRpbmdPcGVyYXRpb24odW5pdGFyeTIpOwogICAgTG9nTWVzc2FnZShudW1iZXJPZlVuaXRhcnkyID09IDIsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgYXBwbGllZCB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSIsICQiWW91IGhhdmUgZmFpbGVkIHRvIGFwcGx5IHRoZSB1bml0YXJ5IG9wZXJhdGlvbiBleGFjdGx5IHR3aWNlIGFuZCBhcHBsaWVkIGl0IHtudW1iZXJPZlVuaXRhcnkyfSB0aW1lcyIpOwoKICAgIC8vIFdyYXAgdGhlIFNXQVAgZ2F0ZSBpbiBhIHVuaXRhcnkgb3BlcmF0aW9uIHRvIGJlIGFibGUgdG8gY2hlY2sgdGhlIG51bWJlciBvZiB0aW1lcyBpdCB3YXMgYXBwbGllZC4KICAgIGxldCB1bml0YXJ5MyA9IHFzID0+IFNXQVAocXNbMF0sIHFzWzFdKTsKICAgIFN0YXJ0Q291bnRpbmdPcGVyYXRpb24odW5pdGFyeTMpOwogICAgbGV0IHJlc3VsdDMgPSBTb2x2ZSh1bml0YXJ5Myk7CiAgICBMb2dNZXNzYWdlKHJlc3VsdDMgPT0gMywgIllvdSBoYXZlIHN1Y2Nlc3NmdWxseSBpZGVudGlmaWVkIHRoZSBTV0FQIGdhdGUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IHRoZSBTV0FQIGdhdGUiKTsKICAgIGxldCBudW1iZXJPZlVuaXRhcnkzID0gU3RvcENvdW50aW5nT3BlcmF0aW9uKHVuaXRhcnkzKTsKICAgIExvZ01lc3NhZ2UobnVtYmVyT2ZVbml0YXJ5MyA9PSAyLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGFwcGxpZWQgdGhlIHVuaXRhcnkgb3BlcmF0aW9uIGV4YWN0bHkgdHdpY2UiLCAkIllvdSBoYXZlIGZhaWxlZCB0byBhcHBseSB0aGUgdW5pdGFyeSBvcGVyYXRpb24gZXhhY3RseSB0d2ljZSBhbmQgYXBwbGllZCBpdCB7bnVtYmVyT2ZVbml0YXJ5M30gdGltZXMiKTsKCiAgICAvLyBSZXR1cm4gdHJ1ZSBpZiB0aGUgSSDiipcgSSBnYXRlIHdhcyBpZGVudGlmaWVkIGFzIDAsIHRoZSBDTk9UMTIgZ2F0ZSBhcyAxLCB0aGUgQ05PVDIxIGdhdGUgYXMgMiwgdGhlIFNXQVAgZ2F0ZSBhcyAzLCBhbmQgYWxsIHVuaXRhcnkgb3BlcmF0aW9ucyB3ZXJlIGFwcGxpZWQgZXhhY3RseSB0d2ljZS4KICAgIHJldHVybiByZXN1bHQwID09IDAgYW5kIG51bWJlck9mVW5pdGFyeTAgPT0gMiBhbmQgcmVzdWx0MSA9PSAxIGFuZCBudW1iZXJPZlVuaXRhcnkxID09IDIgYW5kIHJlc3VsdDIgPT0gMiBhbmQgbnVtYmVyT2ZVbml0YXJ5MiA9PSAyIGFuZCByZXN1bHQzID09IDMgYW5kIG51bWJlck9mVW5pdGFyeTMgPT0gMjsKfQoKZnVuY3Rpb24gTG9nTWVzc2FnZShpc1ZhbGlkOiBCb29sLCB2YWxpZE1lc3NhZ2U6IFN0cmluZywgaW52YWxpZE1lc3NhZ2U6IFN0cmluZykgOiAoKQp7CiAgICBsZXQgbWVzc2FnZSA9ICJ7XCJ2YWxpZFwiOiAiICsgKGlzVmFsaWQgPyAidHJ1ZSIgfCAiZmFsc2UiKSArICIsIFwibWVzc2FnZVwiOiBcIiIgKyAoaXNWYWxpZCA/IHZhbGlkTWVzc2FnZSB8IGludmFsaWRNZXNzYWdlKSArICJcIn0iOwogICAgTWVzc2FnZShtZXNzYWdlKTsKfQoKPDxTT0xWRT4+",
        ExpectedOutput = "true",
        ExpectedStates = "",
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
        ExpectedStates = "",
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