using Discord;
using Discord.WebSocket;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Common;

namespace Template.Utilities
{
    public class ServerHelper
    {
        private readonly Servers _servers;

        public ServerHelper(Servers servers)
        {
            _servers = servers;
        }

        public async Task SendLogAsync(IGuild guild, string title, string description)
        {
            var channelId = await _servers.GetLogsAsync(guild.Id);
            if (channelId == 0)
                return;

            var fetchedChannel = await guild.GetTextChannelAsync(channelId);
            if(fetchedChannel == null)
            {
                await _servers.ClearLogsAsync(guild.Id);
                return;
            }

            await fetchedChannel.SendLogAsync(title, description);
        }
    }
}
