namespace RestfullAPI.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.Write("[ConsoleLogger] - " + message);
        }
    }
}
