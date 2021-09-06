using Discord.Commands;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Template.Utilities;

namespace Template.Modules
{
    public class Sets : ModuleBase<SocketCommandContext>
    {
        private readonly ILogger<Uniques> _logger;
        private readonly Images _images;
        private readonly ServerHelper _serverHelper;

        public Sets(ILogger<Uniques> logger, Images images, ServerHelper serverHelper)
        {
            _logger = logger;
            _images = images;
            _serverHelper = serverHelper;
        }
        private async Task CreateSetImage(List<Tuple<string, int, int>> affixes, List<Tuple<string, int, int, string>> setBonuses, string name, List<string> requirements, string setPieces, string imageLink)
        {
            string path = await _images.CreateSetImageAsync(affixes, setBonuses, name, requirements, imageLink);
            await Context.Channel.SendFileAsync(path,setPieces);
            File.Delete(path);
        }
        private string ParseSetPieces(string name, string setName)
        {
            var setPieces = GetSetPieces(setName);
            var setMessage = $"**{setName}**:\n\n";

            name = name.Remove(name.IndexOf('('));

            foreach(var setPiece in setPieces.Item1)
            {
                var messageAddition = setPiece;

                if (setPiece.Equals(name))
                {
                    messageAddition = setPiece.Replace(name, $"***{name}***");
                }
                setMessage += messageAddition + "\n";
            }

            return setMessage;
        }


        private Tuple<List<string>, List<Tuple<string, int, int, string>>> GetSetPieces(string setName)
        {
            List<string> setPieces;
            List<Tuple<string, int, int, string>> setBonuses;

            switch (setName)
            {
                case "Berserker's Arsenal":
                    setPieces = new List<string>
                    {
                        "Berserker's Headgear",
                        "Berserker's Hauberk",
                        "Berserker's Hatchet"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" To Life", 50, 0, "2"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Defense", 75, 0, ""),
                        Tuple.Create("% Poison Length Reduction", 75, 0, ""),
                        Tuple.Create(" Poison Damage over 3 seconds", 5, 9, "")
                    };
                    break;
                default:
                    setPieces = new List<string>{};
                    setBonuses = new List<Tuple<string, int, int, string>> {};
                    break;
            }

            return Tuple.Create(setPieces,setBonuses);
        }
        /*
        [Command("Berserker's Arsenal")]
        public async Task ImageBerserkersArsenalAsync()
        {
            await ImageBerserkersHeadgearAsync();
            await ImageBerserkerHauberkAsync();
            await ImageBerserkersHatchetkAsync();

        }

        [Command("")]
        public async Task ImageBerserkersHeadgearAsync()
        {
            var name = "";
            var imageLink = "";
            var setName = "Berserker's Arsenal";
            var requirements = new List<string>
            {
                "26 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 15, 18),
                Tuple.Create(" Bonus Defense", 15, 0),
                Tuple.Create("% Fire Resistance", 25, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Attack Rating(Based On Character Level)", 48, 792, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        */
        [Command("Berserker's Arsenal")]
        public async Task ImageBerserkersArsenalAsync()
        {
            await ImageBerserkersHeadgearAsync();
            await ImageBerserkerHauberkAsync();
            await ImageBerserkersHatchetkAsync();

        }

        [Command("Berserker's Headgear")]
        [Alias("BHG")]
        public async Task ImageBerserkersHeadgearAsync()
        {
            var name = "Berserker's Headgear(3)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/berserkers_headgear_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Berserker's Arsenal";
            var requirements = new List<string>
            {
                "26 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 15, 18),
                Tuple.Create(" Bonus Defense", 15, 0),
                Tuple.Create("% Fire Resistance", 25, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Attack Rating(Based On Character Level)", 48, 792, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }

        [Command("Berserker's Hauberk")]
        [Alias("BHK")]
        public async Task ImageBerserkerHauberkAsync()
        {
            var name = "Berserker's Hauberk(3)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/splint_mail_armor_diablo2_wiki_guide_196px.png";
            var setName = "Berserker's Arsenal";
            var requirements = new List<string>
            {
                "51 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 90, 95),
                Tuple.Create(" To Barbarian Skills", 1, 0),
                Tuple.Create(" Magic Damage Taken", -2, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Bonuse Defense(Based On Character Level)", 3, 297, "2")
            };
            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }

        [Command("Berserker's Hatchet")]
        [Alias("BH")]
        public async Task ImageBerserkersHatchetkAsync()
        {
            var name = "Berserker's Hatchet(3)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/double_axe_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var setName = "Berserker's Arsenal";
            var requirements = new List<string>
            {
                "43 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" One-Handed Damage", 5, 13),
                Tuple.Create(" One-Handed Damage", 7, 19),
                Tuple.Create("% Bonus To Attack Rating", 30, 0),
                Tuple.Create("% Mana Stolen Per Hit", 5, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Enhanced Damage", 50, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
    }
}
