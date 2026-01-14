using System.Text.Json.Serialization;

namespace BlazorApp1.Data.Models;

public class MarketChart
{
    // API повертає масив: [[timestamp, price], [timestamp, price], ...]
    // Ми читаємо це як список списків чисел
    [JsonPropertyName("prices")]
    public List<List<double>> Prices { get; set; } = new();
}