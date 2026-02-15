namespace DesignPatternChallenge;

public class TemplateRegistry
{
    private readonly Dictionary<string, DocumentTemplate> _prototypes = [];

    public void Register(string key, DocumentTemplate prototype)
    {
        ArgumentNullException.ThrowIfNull(prototype);
        _prototypes[key] = prototype;
    }

    public DocumentTemplate Clone(string key)
    {
        if (!_prototypes.TryGetValue(key, out var prototype))
            throw new KeyNotFoundException($"Template '{key}' não encontrado no registro.");

        Console.WriteLine($"Clonando template '{prototype.Title}'...");
        return prototype.DeepCopy();
    }
}
