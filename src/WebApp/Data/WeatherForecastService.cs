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
        try
        {
            var httpClient = new HttpClient() { BaseAddress = new Uri(url) };

            var response = await httpClient.GetAsync("WeatherForecast");
            if (response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadFromJsonAsync<WeatherForecast[]>();
                return results!;
            }
        
            return  Array.Empty<WeatherForecast>();
        }
        catch (Exception e)
        {
            return  Array.Empty<WeatherForecast>();
        }
    }
}