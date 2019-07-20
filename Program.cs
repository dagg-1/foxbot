using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace foxbot
{
    /* 
    dotnet restore
    dotnet run
    hey its like npm install, npm start!
    */ 

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Foxbot exclaims 'hello!'");
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        private DiscordSocketClient _client;
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;

            var token = "EDITME";

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
	        Console.WriteLine(msg.ToString());
	        return Task.CompletedTask;
        }
    }
}
