namespace DesignPatternChallenge;

public class DocumentTemplate
{
    public string Title { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public List<Section> Sections { get; set; } = [];
    public DocumentStyle Style { get; set; } = new();
    public List<string> RequiredFields { get; set; } = [];
    public Dictionary<string, string> Metadata { get; set; } = [];
    public ApprovalWorkflow Workflow { get; set; } = new();
    public List<string> Tags { get; set; } = [];

    public DocumentTemplate DeepCopy() => new()
    {
        Title = Title,
        Category = Category,
        Sections = Sections.ConvertAll(s => s.DeepCopy()),
        Style = Style.DeepCopy(),
        RequiredFields = new List<string>(RequiredFields),
        Metadata = new Dictionary<string, string>(Metadata),
        Workflow = Workflow.DeepCopy(),
        Tags = new List<string>(Tags)
    };
}
