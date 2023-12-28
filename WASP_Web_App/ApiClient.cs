using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("http://localhost:7110"); // Replace with your API base URL
    }

    public async Task<string> GetWeatherForecastAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("/weatherforecast");

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            // Process the response data here or return it to the caller
            return responseBody;
        }
        else
        {
            // Handle error scenario
            return "Error occurred while fetching weather data.";
        }
    }
}
