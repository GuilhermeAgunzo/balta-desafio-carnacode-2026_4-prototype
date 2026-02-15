namespace DesignPatternChallenge;

public class Section
{
    public string Name { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsEditable { get; set; }
    public List<string> Placeholders { get; set; } = [];

    public Section DeepCopy()
    {
        var clone = (Section)MemberwiseClone();
        clone.Placeholders = new List<string>(Placeholders);
        return clone;
    }
}
