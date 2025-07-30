namespace QuantumSummerLab.Data.Model;

public class Score
{
    public Guid Id { get; set; }
    public int SysId { get; set; }
    public Challenge Challenge { get; set; }
    public Team Team { get; set; }
    public string ProposedSolution { get; set; }
    public bool IsSuccessful { get; set; }
    public DateTime SubmissionTimestamp { get; set; }
}