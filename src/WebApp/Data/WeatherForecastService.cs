using System.Net.Http.Json;

namespace WebApp.Blazor.Data;

public class WeatherForecastService
{
    private readonly IConfiguration _configuration;
    
    public WeatherForecastService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<WeatherForecast[]> GetForecastAsync()
    {
        var url = _configuration.GetValue<string>("ApiUrl");
        var httpClient = new HttpClient() { BaseAddress = new Uri(url) };

        var response = await httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        return response;
    }
}