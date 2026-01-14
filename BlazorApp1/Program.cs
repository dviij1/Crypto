using BlazorApp1.Components;
using BlazorApp1.Data.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Додаємо підтримку Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Підключаємо MudBlazor
builder.Services.AddMudServices();

// 3. 👇 ВАЖЛИВО: Реєструємо наш сервіс як звичайний (без HttpClient)
builder.Services.AddScoped<CoinGeckoService>();

var app = builder.Build();

// Налаштування HTTP конвеєра
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();