namespace DesignPatternChallenge;

public class Section
{
    public string Name { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsEditable { get; set; }
    public List<string> Placeholders { get; set; } = [];

    public Section DeepCopy() => new()
    {
        Name = Name,
        Content = Content,
        IsEditable = IsEditable,
        Placeholders = new List<string>(Placeholders)
    };
}
