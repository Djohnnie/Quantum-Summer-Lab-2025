namespace QuantumSummerLab.Data.Model;

public class Challenge
{
    public Guid Id { get; set; }
    public int SysId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Level { get; set; }
    public string ExampleCode { get; set; }
    public string ExampleDescription { get; set; }
    public string VerificationTemplate { get; set; }
    public string SolutionTemplate { get; set; }
    public string ExpectedOutput { get; set; }
}