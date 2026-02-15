namespace DesignPatternChallenge;

public class ApprovalWorkflow
{
    public List<string> Approvers { get; set; } = [];
    public int RequiredApprovals { get; set; }
    public int TimeoutDays { get; set; }

    public ApprovalWorkflow DeepCopy() => new()
    {
        Approvers = new List<string>(Approvers),
        RequiredApprovals = RequiredApprovals,
        TimeoutDays = TimeoutDays
    };
}
