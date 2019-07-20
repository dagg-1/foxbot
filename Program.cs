using System;
using System.Threading.Tasks;

using Discord;
using Discord.WebSocket;
using Discord.Commands;


namespace foxbot
{
    /* 
    dotnet restore
    dotnet run
    hey its like npm install, npm start!
    */ 

    class Program
    {
        private DiscordSocketClient _client;
        public Random rnd = new Random();
        static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            await _client.LoginAsync(TokenType.Bot, "TOKEN");
            _client.MessageReceived += MessageReceived;
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task MessageReceived(SocketMessage message)
        {
            // Extremely basic "command" handler
            switch(message.Content)
            {
                case "!hello":
                    await message.Channel.SendMessageAsync("Hello!");
                    break;
                
                case "!fox":
                    await message.Channel.SendMessageAsync("https://dagg.xyz/randomfox/images/" + rnd.Next(0, 125) + ".jpg");
                    break;
            }
        }
    }
}
