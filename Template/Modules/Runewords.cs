using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Template.Utilities;

namespace Template.Modules
{


    public class Runewords : ModuleBase<SocketCommandContext>
    {
        private readonly ILogger<Runewords> _logger;
        private readonly Images _images;
        private readonly ServerHelper _serverHelper;

        public Runewords(ILogger<Runewords> logger, Images images, ServerHelper serverHelper)
        {
            _logger = logger;
            _images = images;
            _serverHelper = serverHelper;
        }

        public async Task CreateRunewordImage(List<Tuple<string, int,int>> affixes, string name, string slots, string runes )
        {
            string path = await _images.CreateRunewordImageAsync(affixes, name, slots, runes);
            await Context.Channel.SendFileAsync(path);
            File.Delete(path);
        }


        [Command("dream")]
        public async Task ImageAsync()
        {
            var name = "Dream (65)";
            var slots = "Helm, Shield";
            var runes = "Io + Jah + Pul";

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to cast level 15 Confuse when struck", 10, 0));
            affixes.Add(Tuple.Create("Level 15 Holy Shock Aura when equipped", 0, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recover", 20, 30));
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 0));
            affixes.Add(Tuple.Create(" Defense", 150, 220));
            affixes.Add(Tuple.Create(" to Vitality", 10, 0));
            affixes.Add(Tuple.Create("Increase Maximum Life 5%", 0, 0));
            affixes.Add(Tuple.Create(" to Mana (Based on Character Level)", 56, 0));
            affixes.Add(Tuple.Create(" All Resistances", 5, 20));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 12, 25));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
    }
}
