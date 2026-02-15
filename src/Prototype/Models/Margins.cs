namespace DesignPatternChallenge;

public class Margins
{
    public int Top { get; set; }
    public int Bottom { get; set; }
    public int Left { get; set; }
    public int Right { get; set; }

    /// <summary>All properties are value types — shallow copy is sufficient.</summary>
    public Margins DeepCopy() => (Margins)MemberwiseClone();
}
