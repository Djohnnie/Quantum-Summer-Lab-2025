import Std.Arithmetic.*;
import Std.Canon.*;
import Std.Diagnostics.*;
import Std.Math.*;
import Std.Measurement.*;

operation Main() : Bool
{
    let markedElements = [];
    mutable result1Count = 0;
    for i in 1..10
    {
        set result1Count += Solve(2, (register, target) => ApplyOracle(2, markedElements, register, target)) ? 1 | 0;
    }
    LogMessage(result1Count == 10, "You have successfully identified a constant oracle function that marked all bits as zero", "You have failed to identify a constant oracle function that marked all bits as zero");

    let markedElements = [0,1,2,3];
    mutable result2Count = 0;
    for i in 1..10
    {
        set result2Count += Solve(2, (register, target) => ApplyOracle(2, markedElements, register, target)) ? 1 | 0;
    }
    LogMessage(result2Count == 10, "You have successfully identified a constant oracle function that marked all bits as one", "You have failed to identify a constant oracle function that marked all bits as one");

    let markedElements = [0, 2];
    mutable result3Count = 0;
    for i in 1..10
    {
        set result3Count += Solve(2, (register, target) => ApplyOracle(2, markedElements, register, target)) ? 0 | 1;
    }
    LogMessage(result3Count == 10, "You have successfully identified a balanced oracle function that marked two out of four bits as one", "You have failed to identify a balanced oracle function that marked two out of four bits as one");

    let markedElements = [1, 3];
    mutable result4Count = 0;
    for i in 1..10
    {
        set result4Count += Solve(2, (register, target) => ApplyOracle(2, markedElements, register, target)) ? 0 | 1;
    }
    LogMessage(result4Count == 10, "You have successfully identified a balanced oracle function that marked two other out of four bits as one", "You have failed to identify a balanced oracle function that marked two other out of four bits as one");

    return result1Count == 10 and result2Count == 10 and result3Count == 10 and result4Count == 10;
}

function LogMessage(isValid: Bool, validMessage: String, invalidMessage: String) : ()
{
    let message = "{\"valid\": " + (isValid ? "true" | "false") + ", \"message\": \"" + (isValid ? validMessage | invalidMessage) + "\"}";
    Message(message);
}

operation ApplyOracle(n : Int, markedElements : Int[], query : Qubit[], target : Qubit) : Unit 
{
    for markedElement in markedElements 
    {
        ApplyControlledOnInt(markedElement, (register) => ApplyToEachCA(X, register), query, [target]);
    }
}

// Deutch-Jozsa algorithm.
// You have to implement the Deutsch-Jozsa algorithm which determines whether a given oracle function is constant or balanced:
// If the oracle function is constant it returns 0 or 1 on all inputs.
// If the oracle function is balanced it returns 0 on half of the inputs and 1 on the other half.
// The oracle function is assumed to always be constant or balanced.
// Implement the Solve operation where n is the number of bits in the input register and oracle provides you with the oracle function that takes an input register and and output bit.
// The solve operation should return true if the oracle function is constant and false if it is balanced.
operation Solve (n : Int, oracle : (Qubit[], Qubit) => Unit) : Bool
{
    use (qsInput, qOutput) = (Qubit[n], Qubit());
    
    ApplyToEach(H, qsInput);
    
    X(qOutput);
    H(qOutput);
    
    oracle(qsInput, qOutput);
    
    ApplyToEach(H, qsInput);

    mutable isConstant = true;

    for q in qsInput
    {
        if (M(q) == One) 
        {
            set isConstant = false;
        }
    }

    ResetAll(qsInput);
    Reset(qOutput);  

    return isConstant;
}

// public static Challenge CHALLENGE_D3 = new Challenge
// {
//     Name = "D3",
//     Title = "Deutch-Jozsa algorithm.",
//     Description = "You have to implement the Deutsch-Jozsa algorithm which determines whether a given oracle function is constant or balanced:[BR]If the oracle function is constant it returns 0 or 1 on all inputs.[BR]If the oracle function is balanced it returns 0 on half of the inputs and 1 on the other half.[BR]The oracle function is assumed to always be constant or balanced.[BR]Implement the Solve operation where n is the number of bits in the input register and oracle provides you with the oracle function that takes an input register and and output bit.[BR]The solve operation should return true if the oracle function is constant and false if it is balanced.",
//     Tldr = "You should implement the Deutch-Jozsa algorithm in the empty Solve operation below and identify if the oracle function is constant or balanced.",
//     SolutionTemplate = "b3BlcmF0aW9uIFNvbHZlIChuIDogSW50LCBvcmFjbGUgOiAoUXViaXRbXSwgUXViaXQpID0+IFVuaXQpIDogQm9vbAp7CiAgICAvLyBZb3VyIHNvbHV0aW9uIGxvZ2ljIGdvZXMgaGVyZS4KfQ==",
//     ExampleDescription = "",
//     ExampleCode = "",
//     VerificationTemplate = "aW1wb3J0IFN0ZC5Bcml0aG1ldGljLio7CmltcG9ydCBTdGQuQ2Fub24uKjsKaW1wb3J0IFN0ZC5EaWFnbm9zdGljcy4qOwppbXBvcnQgU3RkLk1hdGguKjsKaW1wb3J0IFN0ZC5NZWFzdXJlbWVudC4qOwoKb3BlcmF0aW9uIE1haW4oKSA6IEJvb2wKewogICAgbGV0IG1hcmtlZEVsZW1lbnRzID0gW107CiAgICBtdXRhYmxlIHJlc3VsdDFDb3VudCA9IDA7CiAgICBmb3IgaSBpbiAxLi4xMAogICAgewogICAgICAgIHNldCByZXN1bHQxQ291bnQgKz0gU29sdmUoMiwgKHJlZ2lzdGVyLCB0YXJnZXQpID0+IEFwcGx5T3JhY2xlKDIsIG1hcmtlZEVsZW1lbnRzLCByZWdpc3RlciwgdGFyZ2V0KSkgPyAxIHwgMDsKICAgIH0KICAgIExvZ01lc3NhZ2UocmVzdWx0MUNvdW50ID09IDEwLCAiWW91IGhhdmUgc3VjY2Vzc2Z1bGx5IGlkZW50aWZpZWQgYSBjb25zdGFudCBvcmFjbGUgZnVuY3Rpb24gdGhhdCBtYXJrZWQgYWxsIGJpdHMgYXMgemVybyIsICJZb3UgaGF2ZSBmYWlsZWQgdG8gaWRlbnRpZnkgYSBjb25zdGFudCBvcmFjbGUgZnVuY3Rpb24gdGhhdCBtYXJrZWQgYWxsIGJpdHMgYXMgemVybyIpOwoKICAgIGxldCBtYXJrZWRFbGVtZW50cyA9IFswLDEsMiwzXTsKICAgIG11dGFibGUgcmVzdWx0MkNvdW50ID0gMDsKICAgIGZvciBpIGluIDEuLjEwCiAgICB7CiAgICAgICAgc2V0IHJlc3VsdDJDb3VudCArPSBTb2x2ZSgyLCAocmVnaXN0ZXIsIHRhcmdldCkgPT4gQXBwbHlPcmFjbGUoMiwgbWFya2VkRWxlbWVudHMsIHJlZ2lzdGVyLCB0YXJnZXQpKSA/IDEgfCAwOwogICAgfQogICAgTG9nTWVzc2FnZShyZXN1bHQyQ291bnQgPT0gMTAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgaWRlbnRpZmllZCBhIGNvbnN0YW50IG9yYWNsZSBmdW5jdGlvbiB0aGF0IG1hcmtlZCBhbGwgYml0cyBhcyBvbmUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IGEgY29uc3RhbnQgb3JhY2xlIGZ1bmN0aW9uIHRoYXQgbWFya2VkIGFsbCBiaXRzIGFzIG9uZSIpOwoKICAgIGxldCBtYXJrZWRFbGVtZW50cyA9IFswLCAyXTsKICAgIG11dGFibGUgcmVzdWx0M0NvdW50ID0gMDsKICAgIGZvciBpIGluIDEuLjEwCiAgICB7CiAgICAgICAgc2V0IHJlc3VsdDNDb3VudCArPSBTb2x2ZSgyLCAocmVnaXN0ZXIsIHRhcmdldCkgPT4gQXBwbHlPcmFjbGUoMiwgbWFya2VkRWxlbWVudHMsIHJlZ2lzdGVyLCB0YXJnZXQpKSA/IDAgfCAxOwogICAgfQogICAgTG9nTWVzc2FnZShyZXN1bHQzQ291bnQgPT0gMTAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgaWRlbnRpZmllZCBhIGJhbGFuY2VkIG9yYWNsZSBmdW5jdGlvbiB0aGF0IG1hcmtlZCB0d28gb3V0IG9mIGZvdXIgYml0cyBhcyBvbmUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IGEgYmFsYW5jZWQgb3JhY2xlIGZ1bmN0aW9uIHRoYXQgbWFya2VkIHR3byBvdXQgb2YgZm91ciBiaXRzIGFzIG9uZSIpOwoKICAgIGxldCBtYXJrZWRFbGVtZW50cyA9IFsxLCAzXTsKICAgIG11dGFibGUgcmVzdWx0NENvdW50ID0gMDsKICAgIGZvciBpIGluIDEuLjEwCiAgICB7CiAgICAgICAgc2V0IHJlc3VsdDRDb3VudCArPSBTb2x2ZSgyLCAocmVnaXN0ZXIsIHRhcmdldCkgPT4gQXBwbHlPcmFjbGUoMiwgbWFya2VkRWxlbWVudHMsIHJlZ2lzdGVyLCB0YXJnZXQpKSA/IDAgfCAxOwogICAgfQogICAgTG9nTWVzc2FnZShyZXN1bHQ0Q291bnQgPT0gMTAsICJZb3UgaGF2ZSBzdWNjZXNzZnVsbHkgaWRlbnRpZmllZCBhIGJhbGFuY2VkIG9yYWNsZSBmdW5jdGlvbiB0aGF0IG1hcmtlZCB0d28gb3RoZXIgb3V0IG9mIGZvdXIgYml0cyBhcyBvbmUiLCAiWW91IGhhdmUgZmFpbGVkIHRvIGlkZW50aWZ5IGEgYmFsYW5jZWQgb3JhY2xlIGZ1bmN0aW9uIHRoYXQgbWFya2VkIHR3byBvdGhlciBvdXQgb2YgZm91ciBiaXRzIGFzIG9uZSIpOwoKICAgIHJldHVybiByZXN1bHQxQ291bnQgPT0gMTAgYW5kIHJlc3VsdDJDb3VudCA9PSAxMCBhbmQgcmVzdWx0M0NvdW50ID09IDEwIGFuZCByZXN1bHQ0Q291bnQgPT0gMTA7Cn0KCmZ1bmN0aW9uIExvZ01lc3NhZ2UoaXNWYWxpZDogQm9vbCwgdmFsaWRNZXNzYWdlOiBTdHJpbmcsIGludmFsaWRNZXNzYWdlOiBTdHJpbmcpIDogKCkKewogICAgbGV0IG1lc3NhZ2UgPSAie1widmFsaWRcIjogIiArIChpc1ZhbGlkID8gInRydWUiIHwgImZhbHNlIikgKyAiLCBcIm1lc3NhZ2VcIjogXCIiICsgKGlzVmFsaWQgPyB2YWxpZE1lc3NhZ2UgfCBpbnZhbGlkTWVzc2FnZSkgKyAiXCJ9IjsKICAgIE1lc3NhZ2UobWVzc2FnZSk7Cn0KCm9wZXJhdGlvbiBBcHBseU9yYWNsZShuIDogSW50LCBtYXJrZWRFbGVtZW50cyA6IEludFtdLCBxdWVyeSA6IFF1Yml0W10sIHRhcmdldCA6IFF1Yml0KSA6IFVuaXQgCnsKICAgIGZvciBtYXJrZWRFbGVtZW50IGluIG1hcmtlZEVsZW1lbnRzIAogICAgewogICAgICAgIEFwcGx5Q29udHJvbGxlZE9uSW50KG1hcmtlZEVsZW1lbnQsIChyZWdpc3RlcikgPT4gQXBwbHlUb0VhY2hDQShYLCByZWdpc3RlciksIHF1ZXJ5LCBbdGFyZ2V0XSk7CiAgICB9Cn0KCjw8U09MVkU+Pg==",
//     ExpectedOutput = "true",
//     ExpectedStates = "",
//     CopilotInstructions = "",
//     Level = 4
// };