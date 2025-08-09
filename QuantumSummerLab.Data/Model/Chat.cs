namespace QuantumSummerLab.Data.Model;

public class Chat
{
    public Guid Id { get; set; }
    public int SysId { get; set; }
    public Team Team { get; set; }
    public string Message { get; set; }
    public string Role { get; set; }
    public DateTime Timestamp { get; set; }
    public int TokensUsed { get; set; }
    public bool IsReduced { get; set; }
}