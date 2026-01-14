using BlazorApp1.Data.Models;

namespace BlazorApp1.Data.Services;

public class CoinGeckoService
{
    // 👇 ВИДАЛИЛИ HttpClient. Тепер конструктор пустий і безпечний.
    public CoinGeckoService()
    {
    }

    // --- МЕТОД 1: СПИСОК (МИТТЄВО) ---
    public Task<List<CoinMarket>> GetTopCoinsAsync(int count = 50, string currency = "usd")
    {
        return Task.FromResult(GetFakeCoins());
    }

    // --- МЕТОД 2: ДЕТАЛІ (МИТТЄВО) ---
    public Task<CoinMarket?> GetCoinByIdAsync(string id)
    {
        var coin = GetFakeCoins().FirstOrDefault(c => c.Id == id) ?? GetFakeCoins().First();
        return Task.FromResult<CoinMarket?>(coin);
    }

    // --- МЕТОД 3: ГРАФІК (ГЕНЕРАЦІЯ) ---
    public Task<double[]> GetCoinHistoryAsync(string id, int days = 30)
    {
        var random = new Random();
        var fakeData = new double[30];
        double startPrice = id == "bitcoin" ? 95000 : (id == "ethereum" ? 3500 : 100);

        for (int i = 0; i < 30; i++)
        {
            fakeData[i] = startPrice;
            startPrice += startPrice * (random.NextDouble() * 0.1 - 0.05);
        }

        return Task.FromResult(fakeData);
    }

    // === БАЗА ДАНИХ (Оновлена) ===
    private List<CoinMarket> GetFakeCoins()
    {
        var list = new List<CoinMarket>();

        // 👇 ПЕРЕКЛАЛИ НАЗВИ (Name) 👇
        list.Add(new CoinMarket
        {
            Id = "uah", Symbol = "uah", Name = "Ukrainian Hryvnia",
            CurrentPrice = 1.0 / 41.5,
            Image = "https://upload.wikimedia.org/wikipedia/commons/4/49/Flag_of_Ukraine.svg"
        });

        list.Add(new CoinMarket
        {
            Id = "usd", Symbol = "usd", Name = "US Dollar",
            CurrentPrice = 1.0,
            Image = "https://upload.wikimedia.org/wikipedia/commons/a/a4/Flag_of_the_United_States.svg"
        });

        list.Add(new CoinMarket
        {
            Id = "eur", Symbol = "eur", Name = "Euro",
            CurrentPrice = 1.08,
            Image = "https://upload.wikimedia.org/wikipedia/commons/b/b7/Flag_of_Europe.svg"
        });

        // Криптовалюти (вони і так англійською)
        list.AddRange(new List<CoinMarket>
        {
            new()
            {
                Id = "bitcoin", Symbol = "btc", Name = "Bitcoin", CurrentPrice = 96543.20,
                Image = "https://assets.coingecko.com/coins/images/1/large/bitcoin.png"
            },
            new()
            {
                Id = "ethereum", Symbol = "eth", Name = "Ethereum", CurrentPrice = 3450.15,
                Image = "https://assets.coingecko.com/coins/images/279/large/ethereum.png"
            },
            new()
            {
                Id = "tether", Symbol = "usdt", Name = "Tether", CurrentPrice = 1.00,
                Image = "https://assets.coingecko.com/coins/images/325/large/Tether.png"
            },
            new()
            {
                Id = "binancecoin", Symbol = "bnb", Name = "BNB", CurrentPrice = 612.50,
                Image = "https://assets.coingecko.com/coins/images/825/large/bnb-icon2_2x.png"
            },
            new()
            {
                Id = "solana", Symbol = "sol", Name = "Solana", CurrentPrice = 145.20,
                Image = "https://assets.coingecko.com/coins/images/4128/large/solana.png"
            },
            new()
            {
                Id = "ripple", Symbol = "xrp", Name = "XRP", CurrentPrice = 0.62,
                Image = "https://assets.coingecko.com/coins/images/44/large/xrp-symbol-white-128.png"
            },
            new()
            {
                Id = "dogecoin", Symbol = "doge", Name = "Dogecoin", CurrentPrice = 0.16,
                Image = "https://assets.coingecko.com/coins/images/5/large/dogecoin.png"
            },
        });

        return list;
    }
}