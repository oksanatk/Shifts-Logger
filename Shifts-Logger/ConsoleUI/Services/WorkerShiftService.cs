using ConsoleUI.Models;
using System.Net.Http.Json;

namespace ConsoleUI.Services;

internal class WorkerShiftService
{
    private readonly HttpClient _httpClient;

    public WorkerShiftService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(@"https://localhost:7042/");
    }

    internal async Task<string> GetAllShifts()
    {
        try
        {
            using HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/api/Shifts/");
            response.EnsureSuccessStatusCode();

            List<Shift> responseBody = await response.Content.ReadFromJsonAsync<List<Shift>>() ?? new List<Shift>();

        }catch (Exception ex)
        {
            return $"An unexpected error occured trying to connect to the API. \nMessage: {ex.Message}";
        }
        return "";
    }
}
