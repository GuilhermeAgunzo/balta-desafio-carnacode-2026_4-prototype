namespace DesignPatternChallenge;

public class ApprovalWorkflow
{
    public List<string> Approvers { get; set; } = [];
    public int RequiredApprovals { get; set; }
    public int TimeoutDays { get; set; }

    public ApprovalWorkflow DeepCopy()
    {
        var clone = (ApprovalWorkflow)MemberwiseClone();
        clone.Approvers = new List<string>(Approvers);
        return clone;
    }
}
