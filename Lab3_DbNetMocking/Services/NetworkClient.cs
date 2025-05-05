using NetDbMockApp.Interfaces;

namespace NetDbMockApp.Services
{
    internal class NetworkClient : INetworkClient
    {
        // Simulates an HTTP GET request by returning a mock response
        public Task<string> GetAsync(string url)
        {
            // Simulating a network call, could return different mock responses based on URL or other logic
            Console.WriteLine($"Simulating GET request to {url}");

            // Return a mock response
            return Task.FromResult($"Mock response from GET request to {url}");
        }

        // Simulates an HTTP POST request with a data payload
        public Task<bool> PostAsync(string url, string data)
        {
            // Simulating a POST request, could log or modify behavior based on data
            Console.WriteLine($"Simulating POST request to {url} with data: {data}");

            // Return true to simulate successful POST
            return Task.FromResult(true);
        }

        // Simulates a check for network availability
        public Task<bool> IsNetworkAvailableAsync()
        {
            // Always return true in this mock (assuming network is always available)
            Console.WriteLine("Simulating network availability check.");

            return Task.FromResult(true);
        }
    }
}