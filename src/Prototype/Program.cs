using DesignPatternChallenge;

Console.WriteLine("=== Sistema de Templates de Documentos ===\n");

var service = new DocumentService();

Console.WriteLine("Criando 5 contratos de serviço...");
var startTime = DateTime.Now;

for (int i = 1; i <= 5; i++)
{
    var contract = service.CreateServiceContract();
    contract.Title = $"Contrato #{i} - Cliente {i}";
}

var elapsed = (DateTime.Now - startTime).TotalMilliseconds;
Console.WriteLine($"Tempo total: {elapsed}ms\n");

var consultingContract = service.CreateConsultingContract();
service.DisplayTemplate(consultingContract);
