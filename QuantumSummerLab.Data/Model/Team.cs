namespace QuantumSummerLab.Data.Model;

public class Team
{
    public Guid Id { get; set; }
    public int SysId { get; set; }
    public string Name { get; set; }
    public string PasswordSalt { get; set; }
    public string PasswordHash { get; set; }
    public bool IsArchived { get; set; }
}