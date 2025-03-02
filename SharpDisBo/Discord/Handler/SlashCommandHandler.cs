using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDisBo.Discord.Handler
{
    public class SlashCommandHandler
    {
        public static async Task OnSlashCommand(SocketSlashCommand command)
        {
            await command.RespondAsync($"You executed the {command.Data.Name} command :D");
        }
    }
}
