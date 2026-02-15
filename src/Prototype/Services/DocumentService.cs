namespace DesignPatternChallenge;

public class DocumentService
{
    private const string ServiceContractKey = "contrato-servico";
    private const string ConsultingContractKey = "contrato-consultoria";

    private readonly TemplateRegistry _registry = new();

    public DocumentService()
    {
        InitializePrototypes();
    }


    private void InitializePrototypes()
    {
        Console.WriteLine("Inicializando protótipos (operação única)...");

        // Simulando processo custoso de inicialização
        Thread.Sleep(100);

        var serviceContract = new DocumentTemplate
        {
            Title = "Contrato de Prestação de Serviços",
            Category = "Contratos",
            Style = new DocumentStyle
            {
                FontFamily = "Arial",
                FontSize = 12,
                HeaderColor = "#003366",
                LogoUrl = "https://company.com/logo.png",
                PageMargins = new Margins { Top = 2, Bottom = 2, Left = 3, Right = 3 }
            },
            Workflow = new ApprovalWorkflow
            {
                Approvers = ["gerente@empresa.com", "juridico@empresa.com"],
                RequiredApprovals = 2,
                TimeoutDays = 5
            },
            Sections =
            [
                new Section { Name = "Cláusula 1 - Objeto", Content = "O presente contrato tem por objeto...", IsEditable = true },
                new Section { Name = "Cláusula 2 - Prazo", Content = "O prazo de vigência será de...", IsEditable = true },
                new Section { Name = "Cláusula 3 - Valor", Content = "O valor total do contrato é de...", IsEditable = true }
            ],
            RequiredFields = ["NomeCliente", "CPF", "Endereco"],
            Tags = ["contrato", "servicos"],
            Metadata = new Dictionary<string, string>
            {
                ["Versao"] = "1.0",
                ["Departamento"] = "Comercial",
                ["UltimaRevisao"] = DateTime.Now.ToString()
            }
        };

        _registry.Register(ServiceContractKey, serviceContract);

        // Consultoria reutiliza o protótipo de serviço, ajustando apenas o necessário
        var consultingContract = serviceContract.DeepCopy();
        consultingContract.Title = "Contrato de Consultoria";
        consultingContract.Tags = ["contrato", "consultoria"];
        consultingContract.Sections[0].Content = "O presente contrato de consultoria tem por objeto...";
        consultingContract.Sections.RemoveAt(2);

        _registry.Register(ConsultingContractKey, consultingContract);
    }

    public DocumentTemplate CreateServiceContract() => _registry.Clone(ServiceContractKey);

    public DocumentTemplate CreateConsultingContract() => _registry.Clone(ConsultingContractKey);

    public void DisplayTemplate(DocumentTemplate template)
    {
        Console.WriteLine($"\n=== {template.Title} ===");
        Console.WriteLine($"Categoria: {template.Category}");
        Console.WriteLine($"Seções: {template.Sections.Count}");
        Console.WriteLine($"Campos obrigatórios: {string.Join(", ", template.RequiredFields)}");
        Console.WriteLine($"Aprovadores: {string.Join(", ", template.Workflow.Approvers)}");
        Console.WriteLine($"Tags: {string.Join(", ", template.Tags)}");
    }
}
