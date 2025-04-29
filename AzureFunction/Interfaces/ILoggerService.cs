namespace AzureFunction.Interfaces;

// Interface Segregation Principle
public interface ILoggerService
{
    void Log(string message);
}