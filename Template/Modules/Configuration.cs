using Discord;
using Discord.Commands;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Template.Utilities;

namespace Template.Modules
{
    public class Configuration : ModuleBase<SocketCommandContext>
    {
        private readonly Servers _servers;
        private readonly ServerHelper _serverHelper;

        public Configuration(Servers servers)
        {
            _servers = servers;
        }

        [Command("prefix", RunMode = RunMode.Async)]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        public async Task Prefix(string prefix = null)
        {
            if (prefix == null)
            {
                var guildPrefix = await _servers.GetGuildPrefix(Context.Guild.Id) ?? "!";
                await ReplyAsync($"The current prefix of this bot is `{guildPrefix}`.");
                return;
            }

            if (prefix.Length > 8)
            {
                await ReplyAsync("The length of the new prefix is too long!");
                return;
            }

            await _servers.ModifyGuildPrefix(Context.Guild.Id, prefix);
            await ReplyAsync($"The prefix has been adjusted to `{prefix}`.");
            await _serverHelper.SendLogAsync(Context.Guild, "Prefix adjusted", $"{Context.User.Mention} modifed the prefix to `{prefix}`.");
        }
    }
}
