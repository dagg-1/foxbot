using Discord.Commands;
using System.Threading.Tasks;

namespace foxbot
{
    public class Fox : ModuleBase<SocketCommandContext>
    {
        [Command("say")]
        public Task SayAsync([Remainder] string echo)
		=> ReplyAsync(echo);
    }
}