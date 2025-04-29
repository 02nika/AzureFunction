using AzureFunction.Interfaces;

namespace AzureFunction.Services;

// Single Responsibility Principle: გამოიყენება მხოლოდ ლოგირებისთვის
public class ConsoleLoggerService : ILoggerService
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}