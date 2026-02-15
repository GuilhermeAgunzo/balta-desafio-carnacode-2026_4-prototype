namespace DesignPatternChallenge;

public class DocumentStyle
{
    public string FontFamily { get; set; } = string.Empty;
    public int FontSize { get; set; }
    public string HeaderColor { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    public Margins PageMargins { get; set; } = new();

    public DocumentStyle DeepCopy() => new()
    {
        FontFamily = FontFamily,
        FontSize = FontSize,
        HeaderColor = HeaderColor,
        LogoUrl = LogoUrl,
        PageMargins = PageMargins.DeepCopy()
    };
}
