using Spectre.Console;

namespace RealEstate.ApiGateway.Properties
{
    public static class ConsoleMessageUtil
    {
        public static void APIGatewayStartupMessage() 
        {
            AnsiConsole.Write(new FigletText(".NET RealEstate").Centered().Color(Color.Red));
            AnsiConsole.Write(new FigletText("API Gateway").Centered().Color(Color.Red));
            AnsiConsole.Write(new FigletText("App Startup").Centered().Color(Color.Red));
        }

        public static void MicroserviceStartupMessage(string microserviceName)
        {
            AnsiConsole.Write(new FigletText($"{microserviceName} Startup").Centered().Color(Color.Red));
        }
    }
}
