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

    /// <summary>Cria uma cópia profunda, garantindo independência total entre protótipo e clone.</summary>
    public DocumentTemplate DeepCopy()
    {
        var clone = (DocumentTemplate)MemberwiseClone();
        clone.Sections = Sections.ConvertAll(s => s.DeepCopy());
        clone.Style = Style.DeepCopy();
        clone.RequiredFields = new List<string>(RequiredFields);
        clone.Metadata = new Dictionary<string, string>(Metadata);
        clone.Workflow = Workflow.DeepCopy();
        clone.Tags = new List<string>(Tags);
        return clone;
    }
}
