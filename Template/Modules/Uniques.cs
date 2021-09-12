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
    public class Uniques : ModuleBase<SocketCommandContext>
    {
        private readonly ILogger<Uniques> _logger;
        private readonly Images _images;
        private readonly ServerHelper _serverHelper;

        public Uniques(ILogger<Uniques> logger, Images images, ServerHelper serverHelper)
        {
            _logger = logger;
            _images = images;
            _serverHelper = serverHelper;
        }

        private async Task CreateUniqueImage(List<Tuple<string, int, int>> affixes, string name, List<string> requirements, string imageLink)
        {
            string path = await _images.CreateUniqueImageAsync(affixes, name, requirements, imageLink);
            await Context.Channel.SendFileAsync(path);
            File.Delete(path);
        }
        /*
        [Command("")]
        public async Task ImageAsync()
        {
            var name = "";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        */

        [Command("Uniques")]
        [Alias("Unique")]
        public async Task UniqueList([Remainder] string args = null)
        {
            var type = new List<string> {};

            string helms = "**Helms:**\n";

            helms += "Wolfhowl\n";
            helms += "Demonhorn's Edge\n";
            helms += "Halaberd's Reign\n";
            helms += "Jalal's Mane\n";
            helms += "Cerebus' Bite\n";
            helms += "Ravenlore\n";
            helms += "Spirit Keeper\n";
            helms += "Biggin's Bonnet\n";
            helms += "Tarnhelm\n";
            helms += "Coif of Glory\n";
            helms += "Duskdeep\n";
            helms += "Howltusk\n";
            helms += "The Face of Horror\n";
            helms += "Undead Crown\n";
            helms += "Wormskull\n";
            helms += "Peasant Crown\n";
            helms += "Rockstopper\n";
            helms += "Stealskull\n";
            helms += "Darksight Helm\n";
            helms += "Valkyrie Wing\n";
            helms += "Blackhorn's Face\n";
            helms += "Crown of Thieves\n";
            helms += "Vampire Gaze\n";
            helms += "Harlequin Crest\n";
            helms += "Steel Shade\n";
            helms += "Veil of Steel\n";
            helms += "Nightwing's Veil\n";
            helms += "Andariel's Visage\n";
            helms += "Crown of Ages\n";
            helms += "Giant Skull\n";

            string chests = "**Chests:**\n";

            chests += "The Spirit Shroud\n";
            chests += "Skin of the Vipermagi\n";
            chests += "Skin of the Flayed One\n";
            chests += "Iron Pelt\n";
            chests += "Crow Caw\n";
            chests += "Spirit Forge\n";
            chests += "Duriel's Shell\n";
            chests += "Shaftstop\n";
            chests += "Skullder's Ire\n";
            chests += "Que-Hegan's Wisdom\n";
            chests += "Toothrow\n";
            chests += "Guardian Angel\n";
            chests += "Atma's Wail\n";
            chests += "Black Hades\n";
            chests += "Corpsemourn\n";
            chests += "Greyform\n";
            chests += "Blinkbat's Form\n";
            chests += "The Centurion\n";
            chests += "Twitchthroe\n";
            chests += "Darkglow\n";
            chests += "Hawkmail\n";
            chests += "Venom Ward\n";
            chests += "Sparking Mail\n";
            chests += "Iceblink\n";
            chests += "Heavenly Garb\n";
            chests += "Rockfleece\n";
            chests += "Boneflesh\n";
            chests += "Rattlecage\n";
            chests += "Goldskin\n";
            chests += "Silks of the Victor\n";
            chests += "Ormus' Robes\n";
            chests += "The Gladiator's Bane\n";
            chests += "Arkaine's Valor\n";
            chests += "Leviathan\n";
            chests += "Steel Carapace\n";
            chests += "Templar's Might\n";
            chests += "Tyrael's Might\n";

            string belts = "**Belts**\n";

            belts += "Lenymo\n";
            belts += "Snakecord\n";
            belts += "Nightsmoke\n";
            belts += "Goldwrap\n";
            belts += "Bladebuckle\n";
            belts += "String of Ears\n";
            belts += "Razortail\n";
            belts += "Gloom's Trap\n";
            belts += "Snowclash\n";
            belts += "Thundergod's Vigor\n";
            belts += "Arachnid Mesh\n";
            belts += "Nosferatu's Coil\n";
            belts += "Verdungo's Hearty Cord\n";

            string boots = "**Boots**\n";

            boots += "Hotspur\n";
            boots += "Gorefoot\n";
            boots += "Treads of Cthon\n";
            boots += "Goblin Toe\n";
            boots += "Tearhaunch\n";
            boots += "Infernostride\n";
            boots += "Waterwalk\n";
            boots += "Silkweave\n";
            boots += "War Traveler\n";
            boots += "Gore Rider\n";
            boots += "Sandstorm Trek\n";
            boots += "Marrowwalk\n";
            boots += "Shadow Dancer\n";

            string gloves = "**Gloves**\n";

            gloves += "The Hand of Broc\n";
            gloves += "Bloodfist\n";
            gloves += "Chance Guards\n";
            gloves += "Magefist\n";
            gloves += "Frostburn\n";
            gloves += "Venom Grip\n";
            gloves += "Gravepalm\n";
            gloves += "Ghoulhide\n";
            gloves += "Lava Gout\n";
            gloves += "Hellmouth\n";
            gloves += "Dracul's Grasp\n";
            gloves += "Soul Drainer\n";
            gloves += "Steelrend\n";

            string shields = "**Shields**\n";

            shields += "Homunculus\n";
            shields += "Darkforce Spawn\n";
            shields += "Boneflame\n";
            shields += "Alma Negra\n";
            shields += "Herald Of Zakarum\n";
            shields += "Dragonscale\n";
            shields += "Pelta Lunata\n";
            shields += "Umbral Disk\n";
            shields += "Stormguild\n";
            shields += "Steelclash\n";
            shields += "Swordback Hold\n";
            shields += "Bverrit Keep\n";
            shields += "Wall of the Eyeless\n";
            shields += "The Ward\n";
            shields += "Visceratuant\n";
            shields += "Moser's Blessed Circle\n";
            shields += "Stormchaser\n";
            shields += "Tiamat's Rebuke\n";
            shields += "Lance Guard\n";
            shields += "Gerke's Sanctuary\n";
            shields += "Lidless Wall\n";
            shields += "Radament's Sphere\n";
            shields += "Blackoak Shield\n";
            shields += "Stormshield\n";
            shields += "Spike Thorn\n";
            shields += "Medusa's Gaze\n";
            shields += "Head Hunter's Glory\n";
            shields += "Spirit Ward\n";

            string rings = "**Rings**\n";

            rings += "Nagelring\n";
            rings += "Manald Heal\n";
            rings += "Stone of Jordan\n";
            rings += "Dwarf Star\n";
            rings += "Raven Frost\n";
            rings += "Bul-Kathos' Wedding Band\n";
            rings += "Carrion Wind\n";
            rings += "Nature's Peace\n";
            rings += "Wisp Projector\n";

            string amulets = "**Amulets**\n";

            amulets += "Nokozan Relic\n";
            amulets += "The Eye of Etlich\n";
            amulets += "The Mahim-Oak Curio\n";
            amulets += "Saracen's Chance\n";
            amulets += "The Cat's Eye\n";
            amulets += "Crescent Moon\n";
            amulets += "Atma's Scarab\n";
            amulets += "The Rising Sun\n";
            amulets += "Highlord's Wrath\n";
            amulets += "Mara's Kaleidoscope\n";
            amulets += "Seraph's Hymn\n";
            amulets += "Metalgrid\n";

            string charms = "**Charms**\n";

            charms += "Annihilus\n";
            charms += "Gheed's Fortune\n";
            charms += "Hellfire Torch\n";

            string jewels = "**Jewels**\n";

            jewels += "Rainbow Face Cold\n";
            jewels += "Rainbow Face Fire\n";
            jewels += "Rainbow Face Light\n";
            jewels += "Rainbow Face Poison\n";

            string swords = "**Swords**\n";

            swords += "Bul-Kathos' Sacred Charge\n";

            var separatedArgs = new List<string> { };
            int firstIndex = 0, nextIndex = 0, thisIndex = 0, previousIndex = 0;

            if (args != null)
            {
                foreach (var thisArg in args)
                {
                    if (thisArg == ' ')
                    {
                        nextIndex = thisIndex;
                    }
                    if (previousIndex < nextIndex)
                    {
                        separatedArgs.Add(args.Substring(firstIndex, (nextIndex - firstIndex)));
                        previousIndex = nextIndex;
                        firstIndex = nextIndex + 1;
                    }
                    thisIndex++;
                }

                nextIndex = thisIndex;
                separatedArgs.Add(args.Substring(firstIndex, (nextIndex - firstIndex)));
            }


            string message = "", message2 = "", message3 = "", message4 = "";
            type.Add(helms);
            type.Add(chests);
            type.Add(belts);
            type.Add(boots);
            type.Add(gloves);
            type.Add(shields);
            type.Add(rings);
            type.Add(amulets);
            type.Add(charms);
            type.Add(jewels);
            type.Add(swords);

            foreach(var thisArg in separatedArgs)
            {
                switch (thisArg.ToLower())
                {
                    case "helms":
                    case "helm":
                        if (message.Length < 1990 - (type[0] + "\n").Length)
                        {
                            message += type[0] + "\n";
                        }
                        else if (message2.Length < 1990 - (type[0] + "\n").Length)
                        {
                            message2 += type[0] + "\n";
                        }
                        else if (message3.Length < 1990 - (type[0] + "\n").Length)
                        {
                            message3 += type[0] + "\n";
                        }
                        else if (message4.Length < 1990 - (type[0] + "\n").Length)
                        {
                            message4 += type[0] + "\n";
                        }
                        break;
                    case "chests":
                    case "chest":
                        if (message.Length < 1990 - (type[1] + "\n").Length)
                        {
                            message += type[1] + "\n";
                        }
                        else if (message2.Length < 1990 - (type[1] + "\n").Length)
                        {
                            message2 += type[1] + "\n";
                        }
                        else if (message3.Length < 1990 - (type[1] + "\n").Length)
                        {
                            message3 += type[1] + "\n";
                        }
                        else if (message4.Length < 1990 - (type[1] + "\n").Length)
                        {
                            message4 += type[1] + "\n";
                        }
                        break;
                    case "belts":
                    case "belt":
                        if (message.Length < 1990 - (type[2] + "\n").Length)
                        {
                            message += type[2] + "\n";
                        }
                        else if (message2.Length < 1990 - (type[2] + "\n").Length)
                        {
                            message2 += type[2] + "\n";
                        }
                        else if (message3.Length < 1990 - (type[2] + "\n").Length)
                        {
                            message3 += type[2] + "\n";
                        }
                        else if (message4.Length < 1990 - (type[2] + "\n").Length)
                        {
                            message4 += type[2] + "\n";
                        }
                        break;
                    case "boots":
                    case "boot":
                        if (message.Length < 1990 - (type[3] + "\n").Length)
                        {
                            message += type[3] + "\n";
                        }
                        else if (message2.Length < 1990 - (type[3] + "\n").Length)
                        {
                            message2 += type[3] + "\n";
                        }
                        else if (message3.Length < 1990 - (type[3] + "\n").Length)
                        {
                            message3 += type[3] + "\n";
                        }
                        else if (message4.Length < 1990 - (type[3] + "\n").Length)
                        {
                            message4 += type[3] + "\n";
                        }
                        break;
                    case "gloves":
                    case "glove":
                        if (message.Length < 1990 - (type[4] + "\n").Length)
                        {
                            message += type[4] + "\n";
                        }
                        else if (message2.Length < 1990 - (type[4] + "\n").Length)
                        {
                            message2 += type[4] + "\n";
                        }
                        else if (message3.Length < 1990 - (type[4] + "\n").Length)
                        {
                            message3 += type[4] + "\n";
                        }
                        else if (message4.Length < 1990 - (type[4] + "\n").Length)
                        {
                            message4 += type[4] + "\n";
                        }
                        break;
                    case "shields":
                    case "shield":
                        if (message.Length < 1990 - (type[5] + "\n").Length)
                        {
                            message += type[5] + "\n";
                        }
                        else if (message2.Length < 1990 - (type[5] + "\n").Length)
                        {
                            message2 += type[5] + "\n";
                        }
                        else if (message3.Length < 1990 - (type[5] + "\n").Length)
                        {
                            message3 += type[5] + "\n";
                        }
                        else if (message4.Length < 1990 - (type[5] + "\n").Length)
                        {
                            message4 += type[5] + "\n";
                        }
                        break;
                    case "rings":
                    case "ring":
                        if (message.Length < 1990 - (type[6] + "\n").Length)
                        {
                            message += type[6] + "\n";
                        }
                        else if (message2.Length < 1990 - (type[6] + "\n").Length)
                        {
                            message2 += type[6] + "\n";
                        }
                        else if (message3.Length < 1990 - (type[6] + "\n").Length)
                        {
                            message3 += type[6] + "\n";
                        }
                        else if (message4.Length < 1990 - (type[6] + "\n").Length)
                        {
                            message4 += type[6] + "\n";
                        }
                        break;
                    case "amulets":
                    case "amulet":
                        if (message.Length < 1990 - (type[7] + "\n").Length)
                        {
                            message += type[7] + "\n";
                        }
                        else if (message2.Length < 1990 - (type[7] + "\n").Length)
                        {
                            message2 += type[7] + "\n";
                        }
                        else if (message3.Length < 1990 - (type[7] + "\n").Length)
                        {
                            message3 += type[7] + "\n";
                        }
                        else if (message4.Length < 1990 - (type[7] + "\n").Length)
                        {
                            message4 += type[7] + "\n";
                        }
                        break;
                    case "charms":
                    case "charm":
                        if (message.Length < 1990 - (type[8] + "\n").Length)
                        {
                            message += type[8] + "\n";
                        }
                        else if (message2.Length < 1990 - (type[8] + "\n").Length)
                        {
                            message2 += type[8] + "\n";
                        }
                        else if (message3.Length < 1990 - (type[8] + "\n").Length)
                        {
                            message3 += type[8] + "\n";
                        }
                        else if (message4.Length < 1990 - (type[8] + "\n").Length)
                        {
                            message4 += type[8] + "\n";
                        }
                        break;
                    case "jewels":
                    case "jewel":
                        if (message.Length < 1990 - (type[9] + "\n").Length)
                        {
                            message += type[9] + "\n";
                        }
                        else if (message2.Length < 1990 - (type[9] + "\n").Length)
                        {
                            message2 += type[9] + "\n";
                        }
                        else if (message3.Length < 1990 - (type[9] + "\n").Length)
                        {
                            message3 += type[9] + "\n";
                        }
                        else if (message4.Length < 1990 - (type[9] + "\n").Length)
                        {
                            message4 += type[9] + "\n";
                        }
                        break;
                    case "swords":
                    case "sword":
                        if (message.Length < 1990 - (type[10] + "\n").Length)
                        {
                            message += type[10] + "\n";
                        }
                        else if (message2.Length < 1990 - (type[10] + "\n").Length)
                        {
                            message2 += type[10] + "\n";
                        }
                        else if (message3.Length < 1990 - (type[10] + "\n").Length)
                        {
                            message3 += type[10] + "\n";
                        }
                        else if (message4.Length < 1990 - (type[10] + "\n").Length)
                        {
                            message4 += type[10] + "\n";
                        }
                        break;
                    case "armor":
                        for(int i = 0; i < 6; i++)
                        {
                            if (message.Length < 1990 - (type[i] + "\n").Length)
                            {
                                message += type[i] + "\n";
                            }
                            else if (message2.Length < 1990 - (type[i] + "\n").Length)
                            {
                                message2 += type[i] + "\n";
                            }
                            else if (message3.Length < 1990 - (type[i] + "\n").Length)
                            {
                                message3 += type[i] + "\n";
                            }
                            else if (message4.Length < 1990 - (type[i] + "\n").Length)
                            {
                                message4 += type[i] + "\n";
                            }
                        }
                        break;
                    case "jewelry":
                        for(int i = 6; i < 10; i++)
                        {
                            if (message.Length < 1990 - (type[i] + "\n").Length)
                            {
                                message += type[i] + "\n";
                            }
                            else if (message2.Length < 1990 - (type[i] + "\n").Length)
                            {
                                message2 += type[i] + "\n";
                            }
                            else if (message3.Length < 1990 - (type[i] + "\n").Length)
                            {
                                message3 += type[i] + "\n";
                            }
                            else if (message4.Length < 1990 - (type[i] + "\n").Length)
                            {
                                message4 += type[i] + "\n";
                            }
                        }
                        break;
                    case "weapons":
                        for(int i = 10; i < 11; i++)
                        {
                            if (message.Length < 1990 - (type[i] + "\n").Length)
                            {
                                message += type[i] + "\n";
                            }
                            else if (message2.Length < 1990 - (type[i] + "\n").Length)
                            {
                                message2 += type[i] + "\n";
                            }
                            else if (message3.Length < 1990 - (type[i] + "\n").Length)
                            {
                                message3 += type[i] + "\n";
                            }
                            else if (message4.Length < 1990 - (type[i] + "\n").Length)
                            {
                                message4 += type[i] + "\n";
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            if( (message == "") && (message2 == "") && (message3 == "") && (message4 == "") )
            {
                foreach(var thisType in type)
                {
                    if (message.Length < 1990 - (thisType + "\n").Length)
                    {
                        message += thisType + "\n";
                    }
                    else if (message2.Length < 1990 - (thisType + "\n").Length)
                    {
                        message2 += thisType + "\n";
                    }
                    else if (message3.Length < 1990 - (thisType + "\n").Length)
                    {
                        message3 += thisType + "\n";
                    }
                    else if (message4.Length < 1990 - (thisType + "\n").Length)
                    {
                        message4 += thisType + "\n";
                    }
                }
            }

            if (message != "")
            {
                await Context.Channel.SendMessageAsync(message);
                if (message2 != "")
                {
                    await Context.Channel.SendMessageAsync(message2);
                    if (message3 != "")
                    {
                        await Context.Channel.SendMessageAsync(message3);
                        if (message4 != "")
                        {
                            await Context.Channel.SendMessageAsync(message4);
                        }
                    }
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync("Arguments no recognized");
            }
        }

        [Command("Bul-Kathos' Sacred Charge")]
        [Alias("BKSC")]
        public async Task BulKathosSacredChargeImageAsync()
        {
            var name = "Bul-Kathos' Sacred Charge(63)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/great_sword_diablo_2_wiki_guide196px.png";

            var requirements = new List<string>
            {
                "189 Strength",
                "110 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" One Handed Damage", 75, 195));
            affixes.Add(Tuple.Create(" Two Handed Damage", 174, 345));
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 0));
            affixes.Add(Tuple.Create("% Change of Crushing Blow", 35, 0));
            affixes.Add(Tuple.Create(" All Resistances", 20, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("Knockback", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);

        }

        [Command("Nokozan Relic")]
        public async Task ImageAsync()
        {
            var name = "Nokozan Relic(10)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet2_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Fire Damage", 3, 6));
            affixes.Add(Tuple.Create("% to Maximum Fire Resist", 10, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 50, 0));
            affixes.Add(Tuple.Create(" Light Radius", 3, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Eye of Etlich")]
        public async Task TheEyeofEtlichImageAsync()
        {
            var name = "The Eye of Etlich(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet2_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create(" Light Radius", 1, 5));
            affixes.Add(Tuple.Create(" Defense vs Missiles", 10, 40));
            affixes.Add(Tuple.Create("% Life Steal", 3, 7));
            affixes.Add(Tuple.Create(" Cold Damage", 1 - 2, 3 - 5));
            affixes.Add(Tuple.Create(" Seconds Cold Length", 2, 10));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Mahim-Oak Curio")]
        public async Task TheMahimOakCurioImageAsync()
        {
            var name = "The Mahim-Oak Curio(25)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet3_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 10, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 10, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 10, 0));
            affixes.Add(Tuple.Create("% All Resistance", 10, 0));
            affixes.Add(Tuple.Create(" All Attributes", 10, 0));


            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Saracen's Chance")]
        public async Task SaracensChanceImageAsync()
        {
            var name = "Saracen's Chance(47)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet1_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance of Casting level 2 Iron Maiden When Struck", 10, 0));
            affixes.Add(Tuple.Create(" All Resistances", 15, 25));
            affixes.Add(Tuple.Create(" All Attributes", 12, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Cat's Eye")]
        public async Task TheCatsEyeImageAsync()
        {
            var name = "The Cat's Eye(50)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet2_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Faster Run/Walk", 30, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missiles", 100, 0));
            affixes.Add(Tuple.Create(" Defense", 100, 0));
            affixes.Add(Tuple.Create(" Dexterity", 25, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Crescent Moon")]
        public async Task CrescentMoonImageAsync()
        {
            var name = "Crescent Moon(50)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet3_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% of Damage Taken Goes to Mana", 10, 0));
            affixes.Add(Tuple.Create(" Mana", 45, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 3, 6));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 11, 15));
            affixes.Add(Tuple.Create(" Magical Damage Taken Reduced", 10, 0));
            affixes.Add(Tuple.Create(" Light Radius", -2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Atma's Scarab")]
        public async Task AtmasScarabImageAsync()
        {
            var name = "Atma's Scarab(60)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet2_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 2 Amplify Damage On Striking", 5, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 20, 0));
            affixes.Add(Tuple.Create(" Poison Damage over 4 seconds", 40, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 75, 0));
            affixes.Add(Tuple.Create(" Light Radius", 3, 0));
            affixes.Add(Tuple.Create(" Attacker Takes Damage of 5", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Rising Sun")]
        public async Task TheRisingSunImageAsync()
        {
            var name = "The Rising Sun(65)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet3_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Fire Skills", 2, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 13-19 Meteor When Struck", 2, 0));
            affixes.Add(Tuple.Create(" Absorb Fire Damage per Character level", 0, 74));
            affixes.Add(Tuple.Create(" Fire Damage", 24, 48));
            affixes.Add(Tuple.Create(" Replenish Life", 10, 0));
            affixes.Add(Tuple.Create(" Light Radius", 4, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Highlord's Wrath")]
        public async Task HighlordsWrathImageAsync()
        {
            var name = "Highlord's Wrath(65)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet3_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Deadly Strike (Based On Character Level)", 0, 37));
            affixes.Add(Tuple.Create("% Lightning Resistance", 35, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 30));
            affixes.Add(Tuple.Create(" Attacker Takes Lightning Damage Of 15", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Mara's Kaleidoscope")]
        public async Task MarasKaleidoscopeImageAsync()
        {
            var name = "Mara's Kaleidoscope(67)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet1_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("All Skills", 2, 0));
            affixes.Add(Tuple.Create("All Resistances", 20, 30));
            affixes.Add(Tuple.Create("All Attributes", 5, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Seraph's Hymn")]
        public async Task SeraphsHymnImageAsync()
        {
            var name = "Seraph's Hymn(65)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet2_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" All Skills", 2, 0));
            affixes.Add(Tuple.Create(" Defensive Auras (Paladin Only)", 1, 2));
            affixes.Add(Tuple.Create("% Damage To Demons", 25, 50));
            affixes.Add(Tuple.Create(" Attack Rating Against Demons", 150, 250));
            affixes.Add(Tuple.Create("% Damage To Undead", 25, 50));
            affixes.Add(Tuple.Create(" Attack Rating Against Undead", 150, 250));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Metalgrid")]
        public async Task MetalgridImageAsync()
        {
            var name = "Metalgrid(81)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet2_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("Attack Rating", 400, 450));
            affixes.Add(Tuple.Create("Level 22 Iron Golem (11 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Level 12 Iron Maiden (20 Charges)", 0, 0));
            affixes.Add(Tuple.Create("All Resistances", 25, 35));
            affixes.Add(Tuple.Create("Defense", 300, 350));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Nagelring")]
        public async Task NagelringImageAsync()
        {
            var name = "Nagelring(7)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ring4_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("Attack Rating ", 50, 75));
            affixes.Add(Tuple.Create("Attacker Takes Damage of 3", 0, 0));
            affixes.Add(Tuple.Create("Magic Damage Reduced By 3", 0, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 15, 30));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Manald Heal")]
        public async Task ManaldHealImageAsync()
        {
            var name = "Manald Heal(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ring5_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 4, 7));
            affixes.Add(Tuple.Create(" Replenish Life", 5, 8));
            affixes.Add(Tuple.Create("% Mana Regeneration", 20, 0));
            affixes.Add(Tuple.Create(" Life", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Stone of Jordan")]
        public async Task StoneofJordanImageAsync()
        {
            var name = "Stone of Jordan(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ring1_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 20, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 12));
            affixes.Add(Tuple.Create("Mana", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Dwarf Star")]
        public async Task DwarfStarImageAsync()
        {
            var name = "Dwarf Start(45)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ring5_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Life", 40, 0));
            affixes.Add(Tuple.Create(" Maximum Stamina", 40, 0));
            affixes.Add(Tuple.Create("% Heal Stamina", 15, 0));
            affixes.Add(Tuple.Create("% Fire Absorb", 15, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 12, 15));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 100, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Raven Frost")]
        public async Task RavenFrostImageAsync()
        {
            var name = "Raven Frost(45)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ring1_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Attack Rating", 150, 250));
            affixes.Add(Tuple.Create(" Cold Damage", 15, 45));
            affixes.Add(Tuple.Create(" Cannot Be Frozen", 0, 0));
            affixes.Add(Tuple.Create(" Dexterity", 15, 20));
            affixes.Add(Tuple.Create(" Mana", 40, 0));
            affixes.Add(Tuple.Create("% Cold Absorb", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Bul-Kathos' Wedding Band")]
        [Alias("Bk ring")]
        public async Task BulKathosWeddingBandImageAsync()
        {
            var name = "Bul-Kathos' Wedding Band(58)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ring4_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create(" Life (Based On Character Level)", 0, 49));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 3, 5));
            affixes.Add(Tuple.Create(" Maximum Stamina", 50, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Carrion Wind")]
        public async Task CarrionWindImageAsync()
        {
            var name = "Carrion Wind(60)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ring1_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 10 Poison Nova When Struck", 10, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 13 Twister On Striking", 8, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 6, 9));
            affixes.Add(Tuple.Create(" Defense Vs. Missile", 100, 160));
            affixes.Add(Tuple.Create("% Poison Resistance", 55, 0));
            affixes.Add(Tuple.Create("% Damage Taken Goes To Mana", 10, 0));
            affixes.Add(Tuple.Create("Level 21 Poison Creeper (15 Charges)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Nature's Peace")]
        public async Task NaturesPeaceImageAsync()
        {
            var name = "Nature's Peace(69)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ring5_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Slain Monsters Rest In Peace", 0, 0));
            affixes.Add(Tuple.Create(" Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("% Poison Resistance", 20, 30));
            affixes.Add(Tuple.Create(" Damage Reduced", 7, 11));
            affixes.Add(Tuple.Create("Level 5 Oak Sage (27 charges)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Wisp Projector")]
        public async Task WispProjectorImageAsync()
        {
            var name = "Wisp Projector(76)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ring1_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 16 Lightning On Striking", 10, 0));
            affixes.Add(Tuple.Create("% Lightning Absorb", 10, 20));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 10, 20));
            affixes.Add(Tuple.Create(" Level 7 Spirit of Barbs (11 charges)", 0, 0));
            affixes.Add(Tuple.Create(" Level 5 Heart of Wolverine (13 charges)", 0, 0));
            affixes.Add(Tuple.Create(" Level 2 Oak Sage (15 charges)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Annihilus")]
        public async Task AnnihilusImageAsync()
        {
            var name = "Annihilus(70)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/mephisto's_soulstone_quest_item_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create(" All Attributes", 10, 20));
            affixes.Add(Tuple.Create(" All Resistances", 10, 20));
            affixes.Add(Tuple.Create("% To Experience Gained", 5, 10));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Gheed's Fortune")]
        public async Task GheedsFortuneImageAsync()
        {
            var name = "Gheed's Fortune(62)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/charm_large_3_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Extra Gold From Monsters ", 80, 160));
            affixes.Add(Tuple.Create("% Reduces All Vendor Prices ", 10, 15));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 20, 40));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Hellfire Torch")]
        public async Task HellfireTorchImageAsync()
        {
            var name = "Hellfire Torch(75)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/torch_charm_diablo2_wiki_guide_175px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast level 10 Firestorm On Striking", 5, 0));
            affixes.Add(Tuple.Create(" To Random Character Class Skills ", 3, 0));
            affixes.Add(Tuple.Create(" All Attributes ", 10, 20));
            affixes.Add(Tuple.Create(" All Resistances", 10, 20));
            affixes.Add(Tuple.Create(" Light Radius", 8, 0));
            affixes.Add(Tuple.Create(" Level 30 Hydra (10 charges)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Greyform")]
        public async Task GreyformImageAsync()
        {
            var name = "Greyform(7)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/quilted_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "12 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 20, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 5, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 3, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 25, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 25, 0));
            affixes.Add(Tuple.Create(" Dexterity", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Blinkbar's Form")]
        public async Task BlinkbarsFormImageAsync()
        {
            var name = "Blinkbat's Form(12)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/leather_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "12 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 25, 0));
            affixes.Add(Tuple.Create(" Defense VS. Missile", 50, 0));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 10, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 40, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 3, 6));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Centurion")]
        public async Task TheCenturionImageAsync()
        {
            var name = "The centurion(14)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hard_leather_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "20 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 30, 0));
            affixes.Add(Tuple.Create(" Replenish life", 5, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 50, 0));
            affixes.Add(Tuple.Create(" Mana", 15, 0));
            affixes.Add(Tuple.Create(" Maximum Stamina", 15, 0));
            affixes.Add(Tuple.Create(" Life", 15, 0));
            affixes.Add(Tuple.Create("% Slower Stamina Drain", 25, 0));
            affixes.Add(Tuple.Create(" Damage Reduced", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Twitchthroe")]
        public async Task TwitchthroeImageAsync()
        {
            var name = "Twitchthroe(16)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/studded_leather_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "27 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 25, 0));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 25, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create(" Dexterity", 10, 0));
            affixes.Add(Tuple.Create(" Strength", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Darkglow")]
        public async Task DarkglowImageAsync()
        {
            var name = "Darkglow(14)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ring_mail_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "36 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 70, 100));
            affixes.Add(Tuple.Create("% to Maximum Poison Resist", 5, 0));
            affixes.Add(Tuple.Create("% to Maximum Cold Resist", 5, 0));
            affixes.Add(Tuple.Create("% to Maximum Lightning Resist", 5, 0));
            affixes.Add(Tuple.Create("% to Maximum Fire Resist", 5, 0));
            affixes.Add(Tuple.Create(" Defense vs. Melee", 50, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 20, 0));
            affixes.Add(Tuple.Create(" All Resistances", 10, 0));
            affixes.Add(Tuple.Create(" Light Radius", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Hawkmail")]
        public async Task HawkmailImageAsync()
        {
            var name = "Hawkmail(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/scale_mail_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "44 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 80, 100));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 10, 0));
            affixes.Add(Tuple.Create("% to Maximum Cold Resist", 15, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 15, 0));
            affixes.Add(Tuple.Create(" Cannot Be Frozen", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Venom Ward")]
        public async Task VenomWardImageAsync()
        {
            var name = "Venom Ward(20)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/breast_plate_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "30 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 60, 100));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));
            affixes.Add(Tuple.Create("% to Maximum Poison Resist", 15, 0));
            affixes.Add(Tuple.Create("% Poison Resist ", 90, 0));
            affixes.Add(Tuple.Create("% Poison Length Reduced", 50, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Sparking Mail")]
        public async Task SparkingMailImageAsync()
        {
            var name = "Sparking Mail(17)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/chain_mail_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "48 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 75, 85));
            affixes.Add(Tuple.Create("% Lightning Resist", 30, 0));
            affixes.Add(Tuple.Create(" Attacker Takes Lightning Damage of 10-14", 0, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 20));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Iceblink")]
        public async Task IceblinkImageAsync()
        {
            var name = "Iceblink(22)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/splint_mail_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "51 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 70, 80));
            affixes.Add(Tuple.Create(" Freezes Target", 0, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 30, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 1, 0));
            affixes.Add(Tuple.Create("Light Radius", 4, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Heavenly Garb")]
        public async Task HeavenlyGarbImageAsync()
        {
            var name = "Heavenly Garb(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_plate_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "41 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 100, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 25, 0));
            affixes.Add(Tuple.Create(" All Resistances", 10, 0));
            affixes.Add(Tuple.Create(" Energy", 15, 0));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create(" Attack Rating Against Undead", 100, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Boneflesh")]
        public async Task BonefleshImageAsync()
        {
            var name = "Boneflesh(26)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/plate_mail_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "65 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 100, 120));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 5, 0));
            affixes.Add(Tuple.Create("% Chance Of Open Wounds", 25, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 35, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Rockfleece")]
        public async Task RockfleeceImageAsync()
        {
            var name = "Rockfleece(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/field_plate_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "50 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 100, 130));
            affixes.Add(Tuple.Create("% Requirements", -10, 0));
            affixes.Add(Tuple.Create("% Damage Reduced", 10, 0));
            affixes.Add(Tuple.Create(" Damage ReducedStrength", 5, 0));
            affixes.Add(Tuple.Create(" Damage Reduced", 5, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Rattlecage")]
        public async Task RattlecageImageAsync()
        {
            var name = "Rattlecage(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gothic_plate_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "70 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 200, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 25, 0));
            affixes.Add(Tuple.Create("% Hit Causes Monster to Flee", 40, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 45, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Goldskin")]
        public async Task GoldskinImageAsync()
        {
            var name = "Goldskin(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/goldskin_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "80 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 120, 150));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));
            affixes.Add(Tuple.Create("All Resistances", 35, 0));
            affixes.Add(Tuple.Create("Attacker Takes Damage of 10", 0, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 100, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Silks of the Victor")]
        public async Task SilksoftheVictorImageAsync()
        {
            var name = "Silks of the Victor(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/silks_of_the_victor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "100 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 100, 120));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 5, 0));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Spirit Shroud")]
        public async Task TheSpiritShroudImageAsync()
        {
            var name = "The Spirit Shroud(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/quilted_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "38 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 0));
            affixes.Add(Tuple.Create(" Cannot Be Frozen", 0, 0));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create(" Replenish Life", 10, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced ", 7, 11));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Skin of the Vipermagi")]
        public async Task SkinoftheVipermagiImageAsync()
        {
            var name = "Skin of the Vipermagi(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/leather_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "43 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 120, 0));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 30, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 9, 13));
            affixes.Add(Tuple.Create(" All Resistances", 20, 35));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Skin of the Flayed One")]
        public async Task SkinoftheFlayedOneImageAsync()
        {
            var name = "Skin of the Flayed One(31)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hard_leather_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "50 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 190));
            affixes.Add(Tuple.Create(" Repairs 1 Durability Every 10 Seconds", 0, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 5, 7));
            affixes.Add(Tuple.Create(" Replenish Life", 15, 25));
            affixes.Add(Tuple.Create(" Attacker Takes Damage of 15", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Iron Pelt")]
        public async Task IronPeltImageAsync()
        {
            var name = "Iron Pelt(33)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/iron_pelt_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "61 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 50, 100));
            affixes.Add(Tuple.Create(" Defense (Based on Character level)", 3, 297));
            affixes.Add(Tuple.Create(" Damage Reduced", 15, 20));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 10, 16));
            affixes.Add(Tuple.Create(" Life", 25, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Spirit Forge")]
        public async Task SpiritForgeImageAsync()
        {
            var name = "Spirit Forge(35)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ring_mail_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "74 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 120, 160));
            affixes.Add(Tuple.Create(" Life (Based on Character Level)", 1, 123));
            affixes.Add(Tuple.Create("% Fire Resist", 5, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 20, 65));
            affixes.Add(Tuple.Create(" Strength", 15, 0));
            affixes.Add(Tuple.Create(" Socketed (2)", 0, 0));
            affixes.Add(Tuple.Create(" Light Radius", 4, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Crow Caw")]
        public async Task CrowCawImageAsync()
        {
            var name = "Crow Caw(37)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/scale_mail_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "86 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 180));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 15, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 15, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 35, 0));
            affixes.Add(Tuple.Create(" Dexterity", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Duriel's Shell")]
        public async Task DurielsShellImageAsync()
        {
            var name = "Duriel's Shell(41)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/breast_plate_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "65 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 160, 200));
            affixes.Add(Tuple.Create(" Defense (Based of Character Level)", 1, 123));
            affixes.Add(Tuple.Create(" Life (Based of Character Level)", 1, 99));
            affixes.Add(Tuple.Create("% Fire Resist", 20, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 20, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 20, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 50, 0));
            affixes.Add(Tuple.Create(" Cannot Be Frozen", 0, 0));
            affixes.Add(Tuple.Create(" Strength", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Shaftstop")]
        public async Task ShaftstopImageAsync()
        {
            var name = "Shaftstop(38)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/chain_mail_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "92 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 180, 220));
            affixes.Add(Tuple.Create("% Damage Reduced", 30, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 250, 0));
            affixes.Add(Tuple.Create(" Life", 60, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Skullder's Ire")]
        public async Task SkulldersIreImageAsync()
        {
            var name = "Skullder's Ire(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/splint_mail_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "97 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 160, 200));
            affixes.Add(Tuple.Create(" Repairs 1 Durability Every 5 Seconds", 0, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items (Based on Character Level) ", 1, 123));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Que-Hegan's Wisdom")]
        public async Task QueHegansWisdomImageAsync()
        {
            var name = "Que-Hegan's Wisdom(51)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_plate_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "55 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 140, 160));
            affixes.Add(Tuple.Create(" All Skill Levels", 1, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 3, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 6, 10));
            affixes.Add(Tuple.Create(" Energy", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Guardian Angel")]
        public async Task GuardianAngelImageAsync()
        {
            var name = "Guardian Angel(45)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/plate_mail_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "118 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 180, 200));
            affixes.Add(Tuple.Create("% Increased Chance Of Blocking", 20, 0));
            affixes.Add(Tuple.Create("% Faster Block Rate", 30, 0));
            affixes.Add(Tuple.Create(" Attack Rating Against Demons (Based on Character Level)", 2, 247));
            affixes.Add(Tuple.Create(" Paladin Skill Levels", 1, 0));
            affixes.Add(Tuple.Create(" Light Radius", 4, 0));
            affixes.Add(Tuple.Create("% to Maximum Poison Resist", 15, 0));
            affixes.Add(Tuple.Create("% to Maximum Cold Resist", 15, 0));
            affixes.Add(Tuple.Create("% to Maximum Lightning Resist", 15, 0));
            affixes.Add(Tuple.Create(" to Maximum Fire Resist", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Toothrow")]
        public async Task ToothrowImageAsync()
        {
            var name = "Toothrow(48)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/field_plate_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "103 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 160, 220));
            affixes.Add(Tuple.Create(" Defense", 40, 60));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 40, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 15, 0));
            affixes.Add(Tuple.Create(" Strength", 10, 0));
            affixes.Add(Tuple.Create(" Attacker Takes Damage of 20-40", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Atma's Wail")]
        public async Task AtmasWailImageAsync()
        {
            var name = "Atma's Wail(51)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gothic_plate_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "125 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 120, 160));
            affixes.Add(Tuple.Create(" Defense (Based on Character LeveL", 2, 198));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create("Replenish Life", 10, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 15, 0));
            affixes.Add(Tuple.Create(" Dexterity", 15, 0));
            affixes.Add(Tuple.Create("% Better Chance Of Getting Magic Items", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Black Hades")]
        public async Task BlackHadesImageAsync()
        {
            var name = "Black Hades(53)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/full_plate_mail_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "140 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 140, 200));
            affixes.Add(Tuple.Create("% Damage To Demons", 30, 60));
            affixes.Add(Tuple.Create(" Attack Rating Against Demons", 200, 250));
            affixes.Add(Tuple.Create(" Half Freeze Duration", 0, 0));
            affixes.Add(Tuple.Create(" Socketed (3)", 0, 0));
            affixes.Add(Tuple.Create(" Light Radius", -2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Corpsemourn")]
        public async Task CorpsemournImageAsync()
        {
            var name = "Corpsemourn(55)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/corpsemourn_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "170 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" % Enhanced Defense", 150, 180));
            affixes.Add(Tuple.Create(" Level 5 Corpse Explosion (40 Charges)", 0, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 12, 36));
            affixes.Add(Tuple.Create(" 6% Chance To Cast Level 2 Iron Maiden When Struck", 0, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 35, 0));
            affixes.Add(Tuple.Create(" Vitality", 10, 0));
            affixes.Add(Tuple.Create(" Strength", 8, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Ormus Robes")]
        public async Task OrmusRobesImageAsync()
        {
            var name = "Ormus Robes(75)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/quilted_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "77 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 10, 20));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, 0));
            affixes.Add(Tuple.Create("% To Cold Skill Damage", 0, 0));
            affixes.Add(Tuple.Create("% To Fire Skill Damage", 0, 0));
            affixes.Add(Tuple.Create("% To Lightning Skill Damage", 0, 0));
            affixes.Add(Tuple.Create(" to (Random Sorceress Skill) (Sorceress Only)", 3, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 10, 15));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Gladiator's Bane")]
        public async Task TheGladiatorsBaneImageAsync()
        {
            var name = "The Gladiator's Bane(85)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/studded_leather_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "111 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense ", 150, 200));
            affixes.Add(Tuple.Create(" Defense", 50, 0));
            affixes.Add(Tuple.Create(" Cannot Be Frozen", 0, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 0, 0));
            affixes.Add(Tuple.Create("% Poison Length Reduced", 50, 0));
            affixes.Add(Tuple.Create(" Attacker Takes Damage of 20", 00, 0));
            affixes.Add(Tuple.Create(" Damage Reduced", 15, 20));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 15, 20));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Arkaine's Valor")]
        public async Task ArkainesValorImageAsync()
        {
            var name = "Arkaine's Valor";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/splint_mail_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "165 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 180));
            affixes.Add(Tuple.Create(" All Skills", 1, 2));
            affixes.Add(Tuple.Create(" Vitality (Based on Character Level)", 0, 49));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create(" Damage Reduced", 10, 15));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Leviathan")]
        public async Task LeviathanImageAsync()
        {
            var name = "Leviathan(65)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/field_plate_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "174 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 170, 200));
            affixes.Add(Tuple.Create(" Defense", 100, 150));
            affixes.Add(Tuple.Create(" Strenght", 40, 50));
            affixes.Add(Tuple.Create(" Damage Reduced", 15, 25));
            affixes.Add(Tuple.Create(" Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Steel Carapace")]
        public async Task SteelCarapaceImageAsync()
        {
            var name = "Steel Carapace(66)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/full_plate_mail_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "230 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 190, 220));
            affixes.Add(Tuple.Create("% Regenerate Mana", 10, 15));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 9));
            affixes.Add(Tuple.Create("% Cold Resist", 40, 60));
            affixes.Add(Tuple.Create(" Damage Reduced", 9, 14));
            affixes.Add(Tuple.Create(" Repairs 1 Durability Every 20 Seconds", 9, 9));
            affixes.Add(Tuple.Create("% Chance to Cast Level 6 Iron Maiden When Struck", 8, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Templar's Might")]
        public async Task TemplarsMightImageAsync()
        {
            var name = "Templar's Might(74)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/silks_of_the_victor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "232 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 170, 220));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 250, 300));
            affixes.Add(Tuple.Create(" Strength", 10, 15));
            affixes.Add(Tuple.Create(" Vitality", 10, 15));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create(" Maximum Stamina", 40, 50));
            affixes.Add(Tuple.Create(" Offensive Auras (Paladin Only)", 1, 2));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Tyreal's Might")]
        public async Task TyrealsMightImageAsync()
        {
            var name = "Tyreal's Might(84)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/silks_of_the_victor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 120, 150));
            affixes.Add(Tuple.Create("% Damage to Demons", 50, 100));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 20, 0));
            affixes.Add(Tuple.Create(" Strength", 20, 30));
            affixes.Add(Tuple.Create(" All Resistances", 20, 30));
            affixes.Add(Tuple.Create(" Cannot Be Frozen", 0, 0));
            affixes.Add(Tuple.Create("% Requirements", -100, 0));
            affixes.Add(Tuple.Create(" Slain Monsters Rest in Peace", 0, 0));
            affixes.Add(Tuple.Create(" Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Lenymo")]
        public async Task LenymoImageAsync()
        {
            var name = "Lenymo(7)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/sash_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Regenerate Mana", 30, 0));
            affixes.Add(Tuple.Create(" All Resistances", 5, 0));
            affixes.Add(Tuple.Create(" Mana", 15, 0));
            affixes.Add(Tuple.Create(" Light Radius", 1, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Snakecord")]
        public async Task SnakecordImageAsync()
        {
            var name = "Snakecord(12)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_belt_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 20, 30));
            affixes.Add(Tuple.Create(" Defense", 10, 0));
            affixes.Add(Tuple.Create(" Replenish Life", 5, 0));
            affixes.Add(Tuple.Create(" Poison Resist ", 25, 0));
            affixes.Add(Tuple.Create("% Poison Length Reduced", 50, 0));
            affixes.Add(Tuple.Create(" Poison Damage Over 3 Seconds", 12, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Nightsmoke")]
        public async Task NightsmokeImageAsync()
        {
            var name = "Nightsmoke(20)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bell_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "25 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 50));
            affixes.Add(Tuple.Create(" Defense", 15, 0));
            affixes.Add(Tuple.Create("% Damage Taken Goes to Mana", 50, 0));
            affixes.Add(Tuple.Create(" Damage Reduced", 2, 0));
            affixes.Add(Tuple.Create(" All Resistances", 10, 0));
            affixes.Add(Tuple.Create(" Mana", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Goldwrap")]
        public async Task GoldwrapImageAsync()
        {
            var name = "Goldwrap";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_belt_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "45 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 40, 60));
            affixes.Add(Tuple.Create(" Defense", 25, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create("% Better Chance Of Getting Magic Items", 30, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 50, 80));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Bladebuckle")]
        public async Task BladebuckleImageAsync()
        {
            var name = "Bladebuckle(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/plated_belt_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "60 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 80, 100));
            affixes.Add(Tuple.Create(" Defense", 30, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create(" Dexterity", 10, 0));
            affixes.Add(Tuple.Create(" Strength", 5, 0));
            affixes.Add(Tuple.Create(" Damage Reduced", 3, 0));
            affixes.Add(Tuple.Create(" Attacker Takes Damage of 8", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("String of Ears")]
        public async Task StringofEarsImageAsync()
        {
            var name = "String of Ears(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/sash_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "20 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 180));
            affixes.Add(Tuple.Create(" Defense", 15, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 6, 8));
            affixes.Add(Tuple.Create("% Damage Reduced", 10, 15));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 10, 15));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Razortail")]
        public async Task RazortailImageAsync()
        {
            var name = "Razortail(32)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_belt_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "20 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 120, 150));
            affixes.Add(Tuple.Create(" Defense", 15, 0));
            affixes.Add(Tuple.Create(" Maximum Damage", 10, 0));
            affixes.Add(Tuple.Create("% Piercing Attack", 33, 0));
            affixes.Add(Tuple.Create(" Dexterity", 15, 0));
            affixes.Add(Tuple.Create(" Damage taken by Attackers (Based on Character Level)", 1, 99));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Gloom's Trap")]
        public async Task GloomsTrapImageAsync()
        {
            var name = "Gloom's Trap(36)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bell_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "58 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 120, 150));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 5, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 15, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 15, 0));
            affixes.Add(Tuple.Create(" Vitality", 15, 0));
            affixes.Add(Tuple.Create(" Light Radius", -3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Snowclash")]
        public async Task SnowclashImageAsync()
        {
            var name = "Snowclash(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_belt_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "88 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 130, 170));
            affixes.Add(Tuple.Create("% Chance to Cast Level 7-20 Blizzard When Struck", 5, 0));
            affixes.Add(Tuple.Create(" Cold Absorb", 15, 0));
            affixes.Add(Tuple.Create("% to Maximum Cold Resist", 15, 0));
            affixes.Add(Tuple.Create("Cold Damage", 13, 21));
            affixes.Add(Tuple.Create(" Chilling Armor (Sorceress Only)", 2, 0));
            affixes.Add(Tuple.Create(" Blizzard (Sorceress Only)", 2, 0));
            affixes.Add(Tuple.Create(" Glacial Spike (Sorceress Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Thundergod's Vigor")]
        public async Task ThundergodsVigorImageAsync()
        {
            var name = "Thundergod's Vigor(47)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/plated_belt_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "110 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 160, 200));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 50));
            affixes.Add(Tuple.Create("% Chance to Cast Level 7 Fist of the Heavens When Struck", 5, 0));
            affixes.Add(Tuple.Create(" Lightning Absorb", 20, 0));
            affixes.Add(Tuple.Create("% to Maximum Lightning Resist", 10, 0));
            affixes.Add(Tuple.Create(" Strength", 20, 0));
            affixes.Add(Tuple.Create(" Vitality", 20, 0));
            affixes.Add(Tuple.Create(" Lightning Fury (Amazon Only)", 3, 0));
            affixes.Add(Tuple.Create(" Lightning Strike (Amazon Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Arachnid Mesh")]
        public async Task ArachnidMeshImageAsync()
        {
            var name = "Arachnid Mesh(80)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/sash_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "50 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 90, 120));
            affixes.Add(Tuple.Create("% Slows Target", 10, 0));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, 0));
            affixes.Add(Tuple.Create("% Increased Maximum Mana", 5, 0));
            affixes.Add(Tuple.Create(" Level 3 Venom (11 Charges)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Nosferatu's Coil")]
        public async Task NosferatusCoilImageAsync()
        {
            var name = "Nosferatu's Coil(51)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_belt_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "50 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Slows Target ", 10, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 2, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 5, 7));
            affixes.Add(Tuple.Create(" Strength", 15, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create(" Light Radius", -3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Verdungo's Hearty Cord")]
        public async Task VerdungosHeartyCordImageAsync()
        {
            var name = "Verdungo's Hearty Cord(63)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bell_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "106 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 90, 140));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 10, 0));
            affixes.Add(Tuple.Create(" Vitality", 30, 40));
            affixes.Add(Tuple.Create(" Replenish Life", 10, 13));
            affixes.Add(Tuple.Create(" Maximum Stamina", 100, 120));
            affixes.Add(Tuple.Create("% Damage Reduced", 10, 15));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Hotspur")]
        public async Task HotspurImageAsync()
        {
            var name = "Hotspur(5)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/leather_boots_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 10, 20));
            affixes.Add(Tuple.Create(" Defense", 6, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 45, 0));
            affixes.Add(Tuple.Create("% to Maximum Fire Resist", 15, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 3, 6));
            affixes.Add(Tuple.Create(" Life", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Gorefoot")]
        public async Task GorefootImageAsync()
        {
            var name = "Gorefoot(9)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_boots_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "18 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 20, 30));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 20, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 2, 0));
            affixes.Add(Tuple.Create(" Attacker Takes Damage of 2", 0, 0));
            affixes.Add(Tuple.Create(" Defense", 12, 0));
            affixes.Add(Tuple.Create(" Leap (Barbarian Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Threads of Cthon")]
        public async Task ThreadsofCthonImageAsync()
        {
            var name = "Threads of Cthon(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/chain_boots_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "30 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 40));
            affixes.Add(Tuple.Create(" Defense", 12, 0));
            affixes.Add(Tuple.Create("% Slower Stamina Drain", 50, 0));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 30, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 50, 0));
            affixes.Add(Tuple.Create(" Life", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Goblin Toe")]
        public async Task GoblinToeImageAsync()
        {
            var name = "Goblin Toe(22)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_plate_boots_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "50 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 50, 60));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 25, 0));
            affixes.Add(Tuple.Create("Light Radius", -1, 0));
            affixes.Add(Tuple.Create(" Damage Reduced", 1, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 1, 0));
            affixes.Add(Tuple.Create(" Defense", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Tearhaunch")]
        public async Task TearhaunchImageAsync()
        {
            var name = "Tearhaunch(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/plate_boots_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "70 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 60, 80));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 20, 0));
            affixes.Add(Tuple.Create(" All Resistances", 10, 0));
            affixes.Add(Tuple.Create(" Defense", 35, 0));
            affixes.Add(Tuple.Create(" Dexterity", 5, 0));
            affixes.Add(Tuple.Create(" Strength", 5, 0));
            affixes.Add(Tuple.Create(" Vigor (Paladin Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Infernostride")]
        public async Task InfernostrideImageAsync()
        {
            var name = "Infernostride(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/leather_boots_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "20 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 120, 150));
            affixes.Add(Tuple.Create(" Defense", 15, 0));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 20, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 8 Blaze When Struck", 5, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 30, 0));
            affixes.Add(Tuple.Create("% to Maximum Fire Resist", 10, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 12, 33));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 40, 70));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Waterwalk")]
        public async Task WaterwalkImageAsync()
        {
            var name = "Waterwalk(32)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_boots_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "47 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 180, 210));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 20, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missil", 100, 0));
            affixes.Add(Tuple.Create(" Dexterity", 15, 0));
            affixes.Add(Tuple.Create("% to Maximum Fire Resist", 5, 0));
            affixes.Add(Tuple.Create("% Heal Stamina", 50, 0));
            affixes.Add(Tuple.Create(" Maximum Stamina", 40, 0));
            affixes.Add(Tuple.Create(" Life", 45, 65));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Silkweave")]
        public async Task SilkweaveImageAsync()
        {
            var name = "Silkweave(36)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/chain_boots_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "65 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 190));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 30, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 5, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 10, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 200, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("War Traveler")]
        public async Task WarTravelerImageAsync()
        {
            var name = "War Traveler(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_plate_boots_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "95 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 190));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 25, 0));
            affixes.Add(Tuple.Create(" Vitality", 10, 0));
            affixes.Add(Tuple.Create(" Strength", 10, 0));
            affixes.Add(Tuple.Create(" Damage", 15, 25));
            affixes.Add(Tuple.Create("% Slower Stamina Drain", 40, 0));
            affixes.Add(Tuple.Create(" Damage Taken by Attackers", 5, 10));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 30, 50));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Gore Rider")]
        public async Task GoreRiderImageAsync()
        {
            var name = "Gore Rider(47)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/plate_boots_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "94 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 160, 200));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 30, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 10, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 15, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 15, 0));
            affixes.Add(Tuple.Create("% Requirements", -25, 0));
            affixes.Add(Tuple.Create("Maximum Stamina", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Sandstorm Trek")]
        public async Task SandstormTrekImageAsync()
        {
            var name = "Sandstorm Trek(64)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_boots_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "91 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 140, 170));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 20, 0));
            affixes.Add(Tuple.Create("Maximum Stamina (Based on Character Level)", 1, 99));
            affixes.Add(Tuple.Create(" Strength", 10, 15));
            affixes.Add(Tuple.Create(" Vitality", 10, 15));
            affixes.Add(Tuple.Create("% Slower Stamina Drain", 50, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 40, 70));
            affixes.Add(Tuple.Create(" Repairs 1 Durability Every 20 Seconds", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Marrowwalk")]
        public async Task MarrowwalkImageAsync()
        {
            var name = "Marrowwalk(66)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/chain_boots_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "118 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 170, 200));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 20, 0));
            affixes.Add(Tuple.Create(" Skeleton Mastery (Necromancer Only)", 1, 2));
            affixes.Add(Tuple.Create(" Strength", 10, 20));
            affixes.Add(Tuple.Create(" Dexterity", 17, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 10, 0));
            affixes.Add(Tuple.Create("% Heal Stamina", 10, 0));
            affixes.Add(Tuple.Create("Half Freeze Duration", 0, 0));
            affixes.Add(Tuple.Create("Level 33 Bone Prison (13 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Level 12 Life Tap (10 Charges)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Shadow Dancer")]
        public async Task ShadowDancerImageAsync()
        {
            var name = "Shadow Dancer(71)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/plate_boots_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "167 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 70, 100));
            affixes.Add(Tuple.Create(" Shadow Disciplines (Assassin Only)", 1, 2));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 30, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create("Dexterity", 15, 25));
            affixes.Add(Tuple.Create("% Requirements", -20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Rainbow Facet Cold")]
        public async Task RainbowFacetColdImageAsync()
        {
            var name = "Rainbow Facet Cold(49)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/jewel_socketed_item_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to Cast Level 43 Frost Nova When You Level Up", 100, 0));
            affixes.Add(Tuple.Create("OR", 0, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 37 Blizzard When You Die", 100, 0));
            affixes.Add(Tuple.Create(" Cold Damage", 24, 38));
            affixes.Add(Tuple.Create("% to Cold Skill Damage", 3, 5));
            affixes.Add(Tuple.Create("% to Enemy Cold Resistance", 3, 5));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Rainbow Facet Fire")]
        public async Task RainbowFacetFireImageAsync()
        {
            var name = "Rainbow Facet Fire(49)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/jewel4_socketed_item_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to Cast Level 29 Blaze When You Level Up", 100, 0));
            affixes.Add(Tuple.Create("OR", 0, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 31 Meteor When You Die", 100, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 17, 45));
            affixes.Add(Tuple.Create("% to Fire Skill Damage", 3, 5));
            affixes.Add(Tuple.Create("% to Enemy Fire Resistance", 3, 5));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Rainbow Facet Light")]
        public async Task RainbowFacetLightImageAsync()
        {
            var name = "Rainbow Facet Light(49)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/jewel5_socketed_item_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to Cast Level 41 Nova When You Level Up", 100, 0));
            affixes.Add(Tuple.Create("OR", 0, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 47 Chain Lightning When You Die", 100, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 74));
            affixes.Add(Tuple.Create("% to Lightning Skill Damage", 3, 5));
            affixes.Add(Tuple.Create("% to Enemy Lightning Resistance", 3, 5));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Rainbow Facet Poison")]
        public async Task RainbowFacetPoisonImageAsync()
        {
            var name = "Rainbow Facet Poison(49)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/jewel3_socketed_item_diablo2_wiki_guide_98px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to Cast Level 23 Venom When You Level Up", 100, 0));
            affixes.Add(Tuple.Create("OR", 0, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 51 Poison Nova When You Die", 100, 0));
            affixes.Add(Tuple.Create("Poison Damage Over 2 Seconds", 37, 0));
            affixes.Add(Tuple.Create("% to Poison Skill Damage", 3, 5));
            affixes.Add(Tuple.Create("% to Enemy Poison Resistance", 3, 5));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Kira's Guardian")]
        public async Task KirasGuardianImageAsync()
        {
            var name = "Kira's Guardian(77)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/tiara_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 50, 120));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create(" Cannot be Frozen", 0, 0));
            affixes.Add(Tuple.Create(" All Resistances ", 50, 70));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Griffon's Eye")]
        public async Task GriffonsEyeImageAsync()
        {
            var name = "Griffon's Eye(76)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/diadem_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense ", 100, 200));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 25, 0));
            affixes.Add(Tuple.Create("% to Enemy Lightning Resistance", 15, 20));
            affixes.Add(Tuple.Create("% to Lightning Skill Damage", 10, 15));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Hand of Broc")]
        public async Task TheHandofBrocImageAsync()
        {
            var name = "The Hand of Broc(5)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/leather_gloves_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 10, 20));
            affixes.Add(Tuple.Create(" Defense", 10, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 3, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 3, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 10, 0));
            affixes.Add(Tuple.Create(" Mana", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Bloodfist")]
        public async Task BloodfistImageAsync()
        {
            var name = "Bloodfist(9)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_gloves_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            { };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 10, 20));
            affixes.Add(Tuple.Create("Defense", 10, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create("Life", 40, 0));
            affixes.Add(Tuple.Create("Minimum Damage", 5, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Chance Guards")]
        public async Task ChanceGuardsImageAsync()
        {
            var name = "Chance Guards(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/chain_gloves_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "25 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 20, 30));
            affixes.Add(Tuple.Create(" Defense", 15, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 25, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 25, 40));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 200, 0));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Magefist")]
        public async Task MagefistImageAsync()
        {
            var name = "Magefist(23)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_gauntlets_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "45 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 20, 30));
            affixes.Add(Tuple.Create(" Defense", 10, 0));
            affixes.Add(Tuple.Create(" Fire Skills", 1, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, 0));
            affixes.Add(Tuple.Create("% Regenerate Man", 25, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 1, 6));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Frostburn")]
        public async Task FrostburnImageAsync()
        {
            var name = "Frostburn(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gauntlets_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "60 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 10, 20));
            affixes.Add(Tuple.Create(" Defense", 30, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 5, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 40, 0));
            affixes.Add(Tuple.Create(" Cold Damage", 1, 6));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Venom Grip")]
        public async Task VenomGripImageAsync()
        {
            var name = "Venom Grip(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/leather_gloves_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "20 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 130, 160));
            affixes.Add(Tuple.Create(" Defense", 15, 25));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 5, 0));
            affixes.Add(Tuple.Create(" Poison Damage Over 4 Seconds", 60, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 5, 0));
            affixes.Add(Tuple.Create("% to Maximum Poison Resist", 5, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 30, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Gravepalm")]
        public async Task GravepalmImageAsync()
        {
            var name = "Gravepalm(32)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_gloves_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "20 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 140, 180));
            affixes.Add(Tuple.Create("% Damage To Undead ", 100, 200));
            affixes.Add(Tuple.Create(" Attack Rating Against Undead", 100, 200));
            affixes.Add(Tuple.Create("Energy", 10, 0));
            affixes.Add(Tuple.Create("Strength", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Ghoulhide")]
        public async Task GhoulhideImageAsync()
        {
            var name = "Ghoulhide(36)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/chain_gloves_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "58 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 190));
            affixes.Add(Tuple.Create(" Attack Rating Against Undead (Based on Character Level)", 8, 792));
            affixes.Add(Tuple.Create("% Damage To Undead (Based on Character Level)", 2, 198));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 4, 5));
            affixes.Add(Tuple.Create("Life", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Lava Gout")]
        public async Task LavaGoutImageAsync()
        {
            var name = "Lava Gout(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_gauntlets_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "88 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 200));
            affixes.Add(Tuple.Create("% Chance to Cast Level 10 Enchant on Striking", 2, 0));
            affixes.Add(Tuple.Create(" Half Freeze Duratio", 0, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 13, 46));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 24, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Hellmouth")]
        public async Task HellmouthImageAsync()
        {
            var name = "Hellmouth(47)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gauntlets_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "110 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 200));
            affixes.Add(Tuple.Create("% Chance To Cast Level 12 Firestorm on Striking", 4, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 4 Meteor on Striking", 2, 0));
            affixes.Add(Tuple.Create(" Fire Absorb", 15, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 15, 72));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Dracul's Grasp")]
        public async Task DraculsGraspImageAsync()
        {
            var name = "Dracul's Grasp";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_gloves_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "50 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 90, 120));
            affixes.Add(Tuple.Create(" Strength", 10, 15));
            affixes.Add(Tuple.Create(" Life After Each Kill", 5, 10));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 25, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 7, 10));
            affixes.Add(Tuple.Create("% Chance to Cast Level 10 Life Tap on Striking", 5, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Soul Drainer")]
        public async Task SoulDrainerImageAsync()
        {
            var name = "Soul Drainer(74)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/chain_gloves_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "50 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 90, 120));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 4, 7));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 4, 7));
            affixes.Add(Tuple.Create(" Monster Defense per Hit", -50, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 3 Weaken on Striking", 8, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Steelrend")]
        public async Task SteelrendImageAsync()
        {
            var name = "Steelrend(70)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gauntlets_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "185 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 170, 210));
            affixes.Add(Tuple.Create("% Enhanced Damage", 30, 60));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 10, 0));
            affixes.Add(Tuple.Create(" Strength", 15, 20));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Biggin's Bonnet")]
        public async Task BigginsBonnetImageAsync()
        {
            var name = "Tarnhelm(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/biggins_bonnet_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "15 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 25, 50));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 75, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Coif of Glory")]
        public async Task CoifofGloryImageAsync()
        {
            var name = "Coif of Glory(14)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/berserkers_headgear_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "26 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 10, 0));
            affixes.Add(Tuple.Create(" Damage Taken by Attackers", 7, 0));
            affixes.Add(Tuple.Create(" Hit Blinds Target", 0, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 15, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 100, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Duskdeep")]
        public async Task DuskdeepImageAsync()
        {
            var name = "Duskdeep(17)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/duskdeep_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "41 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 50));
            affixes.Add(Tuple.Create(" Defense", 10, 20));
            affixes.Add(Tuple.Create(" Damage Reduced", 7, 0));
            affixes.Add(Tuple.Create(" All Resistances", 15, 0));
            affixes.Add(Tuple.Create(" Maximum Damage", 8, 0));
            affixes.Add(Tuple.Create(" Light Radius", -2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Howltusk")]
        public async Task HowltuskImageAsync()
        {
            var name = "Howltusk(25)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/demonhorns_edge_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "63 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 80, 0));
            affixes.Add(Tuple.Create("% Damage Taken Goes to Mana", 35, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 2, 0));
            affixes.Add(Tuple.Create(" Attacker Takes Damage", 3, 0));
            affixes.Add(Tuple.Create(" Knockback", 0, 0));
            affixes.Add(Tuple.Create("% Chance Hit Causes Monster to Flee", 25, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Face of Horror")]
        public async Task TheFaceofHorrorImageAsync()
        {
            var name = "The Face of Horror(20)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/mask_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "23 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 25, 0));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance Hit Causes Monster to Flee", 50, 0));
            affixes.Add(Tuple.Create(" All Resistances", 10, 0));
            affixes.Add(Tuple.Create("Strength", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Undead Crown")]
        public async Task UndeadCrownImageAsync()
        {
            var name = "Undead Crown(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/crown_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "55 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 60));
            affixes.Add(Tuple.Create(" Defense", 40, 0));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Attack Rating Against Undead", 50, 100));
            affixes.Add(Tuple.Create(" Half Freeze Duration", 0, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 5, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 50, 0));
            affixes.Add(Tuple.Create(" Skeleton Mastery (Necromancer Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Wormskull")]
        public async Task WormskullImageAsync()
        {
            var name = "Wormskull(21)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/wormskull_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "25 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Necromancer Skill Levels", 1, 0));
            affixes.Add(Tuple.Create(" Poison Damage Over 8 Seconds", 80, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 5, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 25, 0));
            affixes.Add(Tuple.Create("Mana", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Peasant Crown")]
        public async Task PeasantCrownImageAsync()
        {
            var name = "Peasant Crown(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/cap_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "20 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 100, 0));
            affixes.Add(Tuple.Create("All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 15, 0));
            affixes.Add(Tuple.Create(" Replenish Life", 6, 12));
            affixes.Add(Tuple.Create(" Energy", 20, 0));
            affixes.Add(Tuple.Create(" Vitality", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Rockstopper")]
        public async Task RockstopperImageAsync()
        {
            var name = "Rockstopper(31)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/rockstopper_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "43 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 160, 220));
            affixes.Add(Tuple.Create("% Damage Reduced", 10, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 20, 40));
            affixes.Add(Tuple.Create("% Fire Resist", 20, 40));
            affixes.Add(Tuple.Create("% Lightning Resist", 20, 40));
            affixes.Add(Tuple.Create(" Vitality", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Stealskull")]
        public async Task StealskullImageAsync()
        {
            var name = "Stealskull(35)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/berserkers_headgear_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "59 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 200, 240));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 10, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 5, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 5, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 30, 50));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Darksight Helm")]
        public async Task DarksightHelmImageAsync()
        {
            var name = "Darksight Helm(38)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/duskdeep_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "82 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense (Based on Character Level)", 2, 198));
            affixes.Add(Tuple.Create("% Chance to Cast Level 3 Dim Vision When Struck", 0, 0));
            affixes.Add(Tuple.Create(" Level 5 Cloak of Shadows (30 Charges)", 0, 0));
            affixes.Add(Tuple.Create(" Cannot Be Frozen", 0, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 20, 40));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 5, 0));
            affixes.Add(Tuple.Create(" Light Radius", -4, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Valkyrie Wing")]
        public async Task ValkyrieWingImageAsync()
        {
            var name = "Valkyrie Wing(44)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/demonhorns_edge_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "115 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 200));
            affixes.Add(Tuple.Create(" Amazon Skill Levels", 1, 2));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 20, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 2, 4));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Blackhorn's Face")]
        public async Task BlackthornsFaceImageAsync()
        {
            var name = "Blackhorn's Face(41)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/mask_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "55 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 180, 220));
            affixes.Add(Tuple.Create(" Slows Target By 20%", 0, 0));
            affixes.Add(Tuple.Create(" Lightning Damage Taken by Attackers", 25, 0));
            affixes.Add(Tuple.Create(" Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" Lightning Absorb", 20, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Crown of Thieves")]
        public async Task CrownofThievesImageAsync()
        {
            var name = "Crown of Thieves(49)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/crown_of_thieves_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "103 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 160, 200));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 9, 12));
            affixes.Add(Tuple.Create("% Fire Resist", 33, 0));
            affixes.Add(Tuple.Create(" Mana", 35, 0));
            affixes.Add(Tuple.Create(" Life", 50, 0));
            affixes.Add(Tuple.Create(" Dexterity", 25, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 80, 100));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Vampire Gaze")]
        public async Task VampireGazeImageAsync()
        {
            var name = "Vampire Gaze";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/wormskull_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "58 Strenght"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 100, 0));
            affixes.Add(Tuple.Create(" Cold Damage", 6, 22));
            affixes.Add(Tuple.Create("% Slower Stamina Drain", 15, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 6, 8));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 6, 8));
            affixes.Add(Tuple.Create("% Damage Reduced", 15, 20));
            affixes.Add(Tuple.Create("Magic Damage Reduced", 10, 15));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Harlequin Crest")]
        [Alias("Shako")]
        public async Task HarlequinCrestImageAsync()
        {
            var name = "Harlequin Crest(62)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/cap_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {};
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" All Skills", 2, 0));
            affixes.Add(Tuple.Create(" Life (Based on Character Level)", 1, 148));
            affixes.Add(Tuple.Create(" Mana (Based on Character Level)", 1, 148));
            affixes.Add(Tuple.Create("% Damage Reduced", 10, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 50, 0));
            affixes.Add(Tuple.Create("All Attributes", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Steel Shade")]
        public async Task SteelShadeImageAsync()
        {
            var name = "Steel Shade(62)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/berserkers_headgear_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "109 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 100, 130));
            affixes.Add(Tuple.Create(" Replenish Life", 10, 18));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 4, 8));
            affixes.Add(Tuple.Create(" Fire Absorb", 5, 11));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Veil of Steel")]
        public async Task VeilofSteelImageAsync()
        {
            var name = "Veil of Steel(73)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/great_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "192 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 60, 0));
            affixes.Add(Tuple.Create(" Defense", 140, 0));
            affixes.Add(Tuple.Create(" All Resistances", 50, 0));
            affixes.Add(Tuple.Create(" Strength", 15, 0));
            affixes.Add(Tuple.Create(" Vitality", 15, 0));
            affixes.Add(Tuple.Create(" Light Radius", -4, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Nightwing's Veil")]
        public async Task NightwingsVeilImageAsync()
        {
            var name = "Nightwing's Veil(67)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/great_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "96 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 90, 120));
            affixes.Add(Tuple.Create(" All Skills", 2, 0));
            affixes.Add(Tuple.Create("% To Cold Skill Damage", 8, 15));
            affixes.Add(Tuple.Create(" Dexterity", 10, 20));
            affixes.Add(Tuple.Create(" Cold Absorb", 5, 9));
            affixes.Add(Tuple.Create(" Half Freeze Duration", 0, 0));
            affixes.Add(Tuple.Create("% Requirements", -50, 0));
    
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Andariel's Visage")]
        [Alias("Andy Face")]
        public async Task AndarielsVisageImageAsync()
        {
            var name = "Andariel's Visage(83)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/mask_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "102 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 100, 150));
            affixes.Add(Tuple.Create(" All Skills", 2, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 8, 10));
            affixes.Add(Tuple.Create(" Strength", 25, 30));
            affixes.Add(Tuple.Create("% To Maximum Poison Resist", 10, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 30, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 70, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 15 Poison Nova When Struck", 15, 0));
            affixes.Add(Tuple.Create(" Level 3 Venom (20 charges)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Crown of Ages")]
        public async Task CrownofAgesImageAsync()
        {
            var name = "Crown of Ages(82)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/crown_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "174 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 50, 0));
            affixes.Add(Tuple.Create(" Defense", 100, 150));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Damage Reduced", 10, 15));
            affixes.Add(Tuple.Create(" All Resistances", 20, 30));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create(" Socketed", 1, 2));
            affixes.Add(Tuple.Create(" Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Giant Skull")]
        public async Task GiantSkullImageAsync()
        {
            var name = "Giant Skull(65)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bone_helm_armor_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "106 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 250, 320));
            affixes.Add(Tuple.Create("% Chance Of Crushing Blow", 10, 0));
            affixes.Add(Tuple.Create(" Knockback", 0, 0));
            affixes.Add(Tuple.Create(" Strength", 25, 35));
            affixes.Add(Tuple.Create(" Socketed", 1, 2));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Pelta Lunata")]
        public async Task PeltaLunataImageAsync()
        {
            var name = "Pelta Lunata(2)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/pelta_lunata_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "12 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 40));
            affixes.Add(Tuple.Create(" Defense", 30, 0));
            affixes.Add(Tuple.Create("% Increased Chance Of Blocking", 20, 0));
            affixes.Add(Tuple.Create("% Faster Block Rate", 40, 0));
            affixes.Add(Tuple.Create(" Energy", 10, 0));
            affixes.Add(Tuple.Create(" Vitality", 10, 0));
            affixes.Add(Tuple.Create(" Strength", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Umbral Disk")]
        public async Task UmbralDiskImageAsync()
        {
            var name = "Umbral Disk(9)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/umbral_disk_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "22 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 40, 50));
            affixes.Add(Tuple.Create(" Defense", 30, 0));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 30, 0));
            affixes.Add(Tuple.Create(" Hit Blinds Target", 0, 0));
            affixes.Add(Tuple.Create(" Life", 20, 0));
            affixes.Add(Tuple.Create(" Dexterity", 10, 0));
            affixes.Add(Tuple.Create(" Light Radius", -2, 0));
            affixes.Add(Tuple.Create(" Durability", 10, 15));
  
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Stormguild")]
        public async Task StormguildImageAsync()
        {
            var name = "Stormguild(13)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/stormguild_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "34 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defens", 50, 60));
            affixes.Add(Tuple.Create(" Defense", 30, 0));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 30, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 25, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 6));
            affixes.Add(Tuple.Create(" Lightning Damage Taken By Attackers", 3, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 1, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Steelclash")]
        public async Task SteelclashImageAsync()
        {
            var name = "Steelclash(17)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/steelclash_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "47 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 60, 100));
            affixes.Add(Tuple.Create(" Defense", 20, 0));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 25, 0));
            affixes.Add(Tuple.Create("% Faster Block Rate", 20, 0));
            affixes.Add(Tuple.Create("All Resistances", 15, 0));
            affixes.Add(Tuple.Create("Paladin Skill Levels", 1, 0));
            affixes.Add(Tuple.Create("Light Radius", 3, 0));
            affixes.Add(Tuple.Create("Damage Reduced", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Swordback Hold")]
        public async Task SwordbackHoldImageAsync()
        {
            var name = "Swordback Hold(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/swordback_hold_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "30 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 60));
            affixes.Add(Tuple.Create("Defense", 10, 0));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 20, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 50, 0));
            affixes.Add(Tuple.Create(" Damage Taken by Attackers", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Bverrit Keep")]
        public async Task BverritKeepImageAsync()
        {
            var name = "Bverrit Keep(19)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bverrit_keep_1_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "75 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 80, 120));
            affixes.Add(Tuple.Create(" Defense", 30, 0));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 10, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 75, 0));
            affixes.Add(Tuple.Create(" Strength", 5, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 5, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Wall of the Eyeless")]
        public async Task WalloftheEyelessImageAsync()
        {
            var name = "Wall of the Eyeless(20)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/wall_of_the_eyeless_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "25 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 40));
            affixes.Add(Tuple.Create(" Defense", 10, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 5, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 3, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 20, 0));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Ward")]
        public async Task TheWardImageAsync()
        {
            var name = "The Ward(26)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_ward_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "60 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 100, 0));
            affixes.Add(Tuple.Create(" Defense", 40, 0));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 10, 0));
            affixes.Add(Tuple.Create(" All Resistances", 30, 50));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 2, 0));
            affixes.Add(Tuple.Create(" Strength", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Visceratuant")]
        public async Task VisceratuantImageAsync()
        {
            var name = "Visceratuant(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/pelta_lunata_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "38 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 100, 150));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 30, 0));
            affixes.Add(Tuple.Create("% Faster Block Rate", 30, 0));
            affixes.Add(Tuple.Create(" Sorceress Skill Levels", 1, 0));
            affixes.Add(Tuple.Create(" Lightning Damage Taken by Attacker", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Moser's Blessed Circle")]
        public async Task MosersBlessedCircleImageAsync()
        {
            var name = "Moser's Blessed Circle(31)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/moser's_blessed_circle_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "53 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 180, 220));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 25, 0));
            affixes.Add(Tuple.Create("% Faster Block Rate", 30, 0));
            affixes.Add(Tuple.Create(" All Resistances", 25, 0));
            affixes.Add(Tuple.Create(" Socketed (2)", 0, 0));
 
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Stormchaser")]
        public async Task StormchaserImageAsync()
        {
            var name = "Stormchaser(35)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/stormchaser_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "71 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 160, 220));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 20, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 5 Tornado When Struck", 4, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 6 Blizzard When Struck", 4, 0));
            affixes.Add(Tuple.Create("% Faster Block Rate", 10, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 150, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 50, 0));
            affixes.Add(Tuple.Create(" Half Freeze Duration", 0, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 60));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Tiamat's Rebuke")]
        public async Task TiamatsRebukeImageAsync()
        {
            var name = "Tiamat's Rebuke(38)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/steelclash_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "91 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 140, 200));
            affixes.Add(Tuple.Create(" Cold Damage", 27, 53));
            affixes.Add(Tuple.Create(" Fire Damage", 35, 95));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 120));
            affixes.Add(Tuple.Create("% Chance to Cast Level 6 Hydra When Struck", 3, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 7 Nova When Struck", 5, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 9 Frost Nova When Struck", 5, 0));
            affixes.Add(Tuple.Create(" All Resistances", 25, 35));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Lance Guard")]
        public async Task LanceGuardImageAsync()
        {
            var name = "Lance Guard(35)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/lance_guard_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "65 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 70, 120));
            affixes.Add(Tuple.Create("% Damage Taken Goes To Mana", 15, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 20, 0));
            affixes.Add(Tuple.Create(" Life", 50, 0));
            affixes.Add(Tuple.Create(" Damage Taken by Attackers", 47, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Gerke's Sanctuary")]
        public async Task GerkesSanctuaryImageAsync()
        {
            var name = "Gerke's Sanctuary(44)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bverrit_keep_1_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "133 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 180, 240));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 30, 0));
            affixes.Add(Tuple.Create(" All Resistances", 20, 30));
            affixes.Add(Tuple.Create(" Replenish Life", 15, 0));
            affixes.Add(Tuple.Create(" Damage Reduced", 11, 16));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 14, 18));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Lidless Wall")]
        public async Task LidlessWallImageAsync()
        {
            var name = "Lidless Wall(41)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/lidless_wall_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "58 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 80, 130));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 10, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 3, 5));
            affixes.Add(Tuple.Create(" Energy", 10, 0));
            affixes.Add(Tuple.Create(" Light Radius", 1, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Radament's Sphere")]
        public async Task RadamentsSphereImageAsync()
        {
            var name = "Radamanent's Sphere(50)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_ward_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "110 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 160, 200));
            affixes.Add(Tuple.Create("% Increased Chance Of Blocking", 20, 0));
            affixes.Add(Tuple.Create("% Faster Block Rate", 20, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 5 Poison Nova When Struck", 5, 0));
            affixes.Add(Tuple.Create(" Level 6 Poison Explosion (40 Charges)", 0, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 75, 0));
            affixes.Add(Tuple.Create(" Poison Damage Over 4 Seconds", 80, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Blackoak Shield")]
        public async Task BlackoakShieldImageAsync()
        {
            var name = "Blackoak Shield(61)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/umbral_disk_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "100 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 160, 200));
            affixes.Add(Tuple.Create(" Absorb Cold Damage (Based on Character Level)", 0, 61));
            affixes.Add(Tuple.Create(" Life (Based on Character Level)", 1, 123));
            affixes.Add(Tuple.Create(" Dexterity (Based on Character Level)", 0, 49));
            affixes.Add(Tuple.Create("% Faster Block Rate", 50, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 5 Weaken When Struck", 4, 0));
            affixes.Add(Tuple.Create(" Half Freeze Duration", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Stormshield")]
        public async Task StormshieldImageAsync()
        {
            var name = "Stormshield(73)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/steelclash_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "156 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense (Based on Character Level)", 3, 371));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 25, 0));
            affixes.Add(Tuple.Create("% Faster Block Rate", 35, 0));
            affixes.Add(Tuple.Create("% Damage Reduced", 35, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 60, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 25, 0));
            affixes.Add(Tuple.Create(" Strength", 30, 0));
            affixes.Add(Tuple.Create(" Lightning Damage Taken by Attacker", 10, 0));
            affixes.Add(Tuple.Create(" Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Spike Thorn")]
        public async Task SpikeThornImageAsync()
        {
            var name = "Spike Thorn(70)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/swordback_hold_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "118 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 120, 150));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create("% Damage Reduced", 15, 20));
            affixes.Add(Tuple.Create(" Damage Taken by Attacker", 1, 136));
            affixes.Add(Tuple.Create(" Socketed (1)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Medusa's Gaze")]
        public async Task MedusasGazeImageAsync()
        {
            var name = "Medusa's Gaze(76)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bverrit_keep_1_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "219 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 180));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 5, 9));
            affixes.Add(Tuple.Create(" Slows Target By 20%", 0, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 40, 80));
            affixes.Add(Tuple.Create("% Chance to Cast Level 7 Lower Resist When Struck", 10, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 44 Nova When You Die", 100, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Head Hunter's Glory")]
        public async Task HeadHuntersGloryImageAsync()
        {
            var name = "Head Hunter's Glory(75)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/wall_of_the_eyeless_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "106 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 320, 420));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 300, 350));
            affixes.Add(Tuple.Create("% Fire Resist", 20, 30));
            affixes.Add(Tuple.Create("% Poison Resist", 30, 40));
            affixes.Add(Tuple.Create(" Life After Each Kill", 5, 7));
            affixes.Add(Tuple.Create(" Socketed", 1, 3));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Spirit Ward")]
        public async Task SpiritWardImageAsync()
        {
            var name = "Spirit Ward(68)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_ward_diablo2_wiki_guide_196x294px.png";
            var requirements = new List<string>
            {
                "185 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 130, 180));
            affixes.Add(Tuple.Create("% Faster Block Rate", 25, 0));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 20, 30));
            affixes.Add(Tuple.Create(" All Resistances", 30, 40));
            affixes.Add(Tuple.Create(" Cold Absorb", 6, 11));
            affixes.Add(Tuple.Create("% Chance to Cast Level 8 Fade When Struck", 5, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
    }
}
