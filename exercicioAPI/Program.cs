using System.Net.Http.Json;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public float Valor { get; set; }
    public int Quantidade { get; set; }
}

class valor {
    static async Task Main(string[] args)
    {
        // URL da API (ajuste conforme o endereço da API)
        string apiUrl = "https://localhost:7289/api/produto";


        // Solicita informações do pedido ao usuário
        Console.Write("Digite o seu nome: ");
        string nome = Console.ReadLine();

        Console.Write("Digite a quantidade:  ");
        int quantidade = int.Parse(Console.ReadLine());

        float valor = 0;

        // Solicita o valor até que seja maior que 10
        do
        {
            Console.Write("Digite o valor: ");
            valor = float.Parse(Console.ReadLine());

            if (valor <= 10)
            {
                Console.WriteLine("São válidos apenas valores maiores que 10.");
            }
        } while (valor <= 10);


        // Cria um novo pedido
        Produto novoPedido = new Produto
        {
            Nome = nome,
            Quantidade = quantidade,
            Valor = valor
        };

        // Envia o pedido para a API
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, novoPedido);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Produto enviado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao enviar o produto.");
            }
        }
    }
}
