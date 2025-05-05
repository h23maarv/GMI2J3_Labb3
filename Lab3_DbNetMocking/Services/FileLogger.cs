using NetDbMockApp.Interfaces;

namespace NetDbMockApp.Services
{
    internal class FileLogger : ILogger
    {
        private readonly string _logFilePath;

        public FileLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public async Task Log(string message)
        {
            try
            {
                // Append the message to the log file asynchronously
                await File.AppendAllTextAsync(_logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Log any issues to the console
                Console.WriteLine($"Error logging message: {ex.Message}");
            }
        }

        public async Task LogError(string message, Exception ex)
        {
            try
            {
                // Log the error message and exception details to the log file asynchronously
                await File.AppendAllTextAsync(_logFilePath, $"{DateTime.Now}: ERROR - {message} - Exception: {ex}{Environment.NewLine}");
            }
            catch (Exception innerEx)
            {
                // Handle any logging errors
                Console.WriteLine($"Error logging error: {innerEx.Message}");
            }
        }
    }
}