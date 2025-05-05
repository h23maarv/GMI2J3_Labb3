namespace NetDbMockApp.Interfaces
{
    public interface INetworkClient
    {
        // Simulates an HTTP GET request
        Task<string> GetAsync(string url);

        // Simulates an HTTP POST request with data payload
        Task<bool> PostAsync(string url, string data);

        // Check if the network is available (mockable in tests)
        Task<bool> IsNetworkAvailableAsync();
    }
}