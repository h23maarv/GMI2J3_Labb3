namespace NetDbMockApp.Interfaces
{
    public interface ILogger
    {
        // Logs a general informational message
        Task Log(string message);

        // Logs an error message along with exception details
        Task LogError(string message, Exception ex);
    }
}