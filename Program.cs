using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.Reflection;

/*
    ********************Bot is currently non-functional********************
*/

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

        private DiscordSocketClient _mainclient;
        public async Task MainAsync()
        {
            _mainclient = new DiscordSocketClient();
            _mainclient.Log += Log;

            var token = "EDITME";

            await _mainclient.LoginAsync(TokenType.Bot, token);
            await _mainclient.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
	        Console.WriteLine(msg.ToString());
	        return Task.CompletedTask;
        }
    }
}
