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

    class Program : ModuleBase<SocketCommandContext>
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
            _client.Log += Log;

            await _client.LoginAsync(TokenType.Bot, "EDIT.TOKEN");
            _client.MessageReceived += MessageReceived;

            await _client.StartAsync();

            await Task.Delay(-1);
        }

        public async Task MessageReceived(SocketMessage message)
        {
            // Extremely basic "command" handler
            switch(message.Content)
            {
                #region !about
                case "!about":
                    var aboutembed = new EmbedBuilder();
                    aboutembed.WithAuthor("FoxBot", "https://cdn.discordapp.com/avatars/601967284394917900/f25955e890f89f1015762647f82ea555.webp")
                    .WithThumbnailUrl("https://dagg.xyz/randomfox/images/" + rnd.Next(0, 125) + ".jpg")
                    .WithTitle("Github")
                    .WithColor(255,0,100)
                    .WithUrl("https://github.com/daggintosh/foxbox")
                    .WithDescription("**Hello!**");
                    await message.Channel.SendMessageAsync("", false, aboutembed.Build());
                    break;
                #endregion
                
                #region !fox
                case "!fox":
                    var foxembed = new EmbedBuilder();

                    #region Catchphrases
                    string[] catchphrase = {"A fox appears!", 
                    "A fox is here!", 
                    "Theres a fox here!", 
                    "A fox has manifested!",
                    "A fox has taken hold!",
                    "There's a fox in my boot!",
                    "A wild fox has appeared!",
                    "A fox challenges you!",
                    "You see a fox!",
                    "Wow! A fox!"};
                    #endregion

                    foxembed.WithAuthor("FoxBot", "https://cdn.discordapp.com/avatars/601967284394917900/f25955e890f89f1015762647f82ea555.webp")
                    .WithImageUrl("https://dagg.xyz/randomfox/images/" + rnd.Next(0, 125) + ".jpg")
                    .WithDescription(catchphrase[rnd.Next(catchphrase.Length)])
                    .WithColor(rnd.Next(0,255), rnd.Next(0,255), rnd.Next(0,255));
                    await message.Channel.SendMessageAsync("", false, foxembed.Build());
                    break;
                #endregion
            }
        }

        private Task Log(LogMessage msg)
        {
	        Console.WriteLine(msg.ToString());
	        return Task.CompletedTask;
        }
    }
}
