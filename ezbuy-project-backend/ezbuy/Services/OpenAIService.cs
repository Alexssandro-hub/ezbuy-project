using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using ezbuy.Services.Interfaces;

namespace ezbuy.Services
{
    public class OpenAIService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public OpenAIService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<string> GenerateProductDescriptionAsync(string nome, string categoria, string detalhes)
        {
            var dados = new
            {
                nome,
                categoria, 
            };

            var content = new StringContent(
                JsonSerializer.Serialize(dados),
                Encoding.UTF8,
                "application/json"
            );

            var resposta = await _httpClient.PostAsync("http://localhost:8000/gerar-descricao", content);
            resposta.EnsureSuccessStatusCode();

            var json = await resposta.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            return doc.RootElement.GetProperty("descricao").GetString() ?? "Descrição gerada.";
        }
    }
}
