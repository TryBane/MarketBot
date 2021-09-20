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
            var type = new List<string> { };

            string helms = "**Helms:**\n";
            {
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
            }
            string chests = "**Chests:**\n";
            {
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
            }
            string belts = "**Belts**\n";
            {
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
            }
            string boots = "**Boots**\n";
            {
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
            }
            string gloves = "**Gloves**\n";
            {
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
            }
            string shields = "**Shields**\n";
            {
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
            }
            string rings = "**Rings**\n";
            {
                rings += "Nagelring\n";
                rings += "Manald Heal\n";
                rings += "Stone of Jordan\n";
                rings += "Dwarf Star\n";
                rings += "Raven Frost\n";
                rings += "Bul-Kathos' Wedding Band\n";
                rings += "Carrion Wind\n";
                rings += "Nature's Peace\n";
                rings += "Wisp Projector\n";
            }
            string amulets = "**Amulets**\n";
            {
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
            }
            string charms = "**Charms**\n";
            {
                charms += "Annihilus\n";
                charms += "Gheed's Fortune\n";
                charms += "Hellfire Torch\n";
            }
            string jewels = "**Jewels**\n";
            {
                jewels += "Rainbow Facet Cold\n";
                jewels += "Rainbow Facet Fire\n";
                jewels += "Rainbow Facet Light\n";
                jewels += "Rainbow Facet Poison\n";
            }
            string axes = "**Axes**\n";
            {
                axes += "The Gnasher\n";
                axes += "Deathspade\n";
                axes += "Bladebone\n";
                axes += "Skull Splitter\n";
                axes += "Rakescar\n";
                axes += "Axe of Fechmar\n";
                axes += "Goreshovel\n";
                axes += "The Chieftain\n";
                axes += "Brainhew\n";
                axes += "Humongous\n";
                axes += "Razor's Edge\n";
                axes += "Rune Master\n";
                axes += "Cranebeak\n";
                axes += "Death Cleaver\n";
                axes += "Ethereal Edge\n";
                axes += "Hellslayer\n";
                axes += "Messerchmidt's Reaver\n";
                axes += "Executioner's Justice\n";
                axes += "Coldkill\n";
                axes += "Butcher's Pupil\n";
                axes += "Islestrike\n";
                axes += "Pompeii's Wrath\n";
                axes += "Guardian Naga\n";
                axes += "Warlord's Trust\n";
                axes += "Spellsteel\n";
                axes += "Stormrider\n";
                axes += "Boneslayer Blade\n";
                axes += "The Minotaur\n";
            }
            string bows = "**Bows**\n";
            {
                bows += "Pluckeye\n";
                bows += "Witherspring\n";
                bows += "Raven Claw\n";
                bows += "Rogue's Bow\n";
                bows += "Stormstrike\n";
                bows += "Wizendraw\n";
                bows += "Hellclap\n";
                bows += "Blastbark\n";
                bows += "Skystrike\n";
                bows += "Riphook\n";
                bows += "Kuko Shukaku\n";
                bows += "Endlesshail\n";
                bows += "Witchwild String\n";
                bows += "Cliffkiller\n";
                bows += "Magewrath\n";
                bows += "Goldstrike Arch\n";
                bows += "Eaglehorn\n";
                bows += "Widowmaker\n";
                bows += "Windforce\n";
                bows += "Lycander's Aim\n";
                bows += "Blood Raven's Charge\n";
            }
            string clubs = "**Clubs**\n";
            {
                clubs += "Felloak\n";
                clubs += "Stoutnail\n";
                clubs += "Dark Clan Crusher\n";
                clubs += "Fleshrender\n";
                clubs += "Nord's Tenderizer\n";
                clubs += "Demon Limb\n";
            }
            string crossbows = "**Crossbows**\n";
            {
                crossbows += "Leadcrow\n";
                crossbows += "Ichorsting\n";
                crossbows += "Hellcast\n";
                crossbows += "Doomslinger\n";
                crossbows += "Langer Briser\n";
                crossbows += "Pus Spitter\n";
                crossbows += "Buriza-Do Kyanon\n";
                crossbows += "Demon Machine\n";
                crossbows += "Hellrack\n";
                crossbows += "Gut Siphon\n";
            }
            string daggers = "**Daggers**\n";
            {
                daggers += "Gull\n";
                daggers += "The Diggler\n";
                daggers += "The Jade Tan Do\n";
                daggers += "Spectral Shard\n";
                daggers += "Spineripper\n";
                daggers += "Heart Carver\n";
                daggers += "Blackbog's Sharp\n";
                daggers += "Stormstrike\n";
                daggers += "Wizardspike\n";
                daggers += "Fleshripper\n";
                daggers += "Ghostflame\n";
            }
            string hammers = "**Hammers**\n";
            {
                hammers += "Ironstone\n";
                hammers += "Bonesnap\n";
                hammers += "Steeldriver\n";
                hammers += "Earthshaker\n";
                hammers += "Bloodtree Stump\n";
                hammers += "The Gavel of Pain\n";
                hammers += "Stone Crusher\n";
                hammers += "Schaefer's Hammer\n";
                hammers += "Windhammer \n";
                hammers += "Earth Shifter\n";
                hammers += "The Cranium Basher\n";
            }
            string javelins = "**Javelins**\n";
            {
                javelins += "Demon's Arch\n";
                javelins += "Wraith Flight\n";
                javelins += "Gargoyle's Bite\n";
                javelins += "Titan's Revenge\n";
                javelins += "Thunderstroke\n";
            }
            string katars = "**Katars**\n";
            {
                katars += "Shadow Killer\n";
                katars += "Bartuc's Cut-Throat\n";
                katars += "Jade Talons\n";
                katars += "Firelizard's Talons\n";
            }
            string maces = "**Maces**\n";
            {
                maces += "Crushflange\n";
                maces += "Bloodrise\n";
                maces += "The General's Tan Do Li Ga\n";
                maces += "Sureshrill Frost\n";
                maces += "Moonfall\n";
                maces += "Baezil's Vortex\n";
                maces += "Baranar's Star\n";
                maces += "Horizon's Tornado\n";
                maces += "Stormlash\n";
            }
            string orbs = "**Orbs**\n";
            {
                orbs += "The Oculus\n";
                orbs += "Eschuta's Temper\n";
                orbs += "Death's Fathom\n";
            }
            string polearms = "**Polearms**\n";
            {
                polearms += "Dimoak's Hew\n";
                polearms += "Steelgoad\n";
                polearms += "Soul Harvest\n";
                polearms += "The Battlebranch\n";
                polearms += "Woestave\n";
                polearms += "The Grim Reaper\n";
                polearms += "The Meat Scrapper\n";
                polearms += "Blackleach Blade\n";
                polearms += "Athena's Wrath\n";
                polearms += "Pierre Tombale Couant\n";
                polearms += "Husoldal Evo\n";
                polearms += "Grim's Burning Dead\n";
                polearms += "Bonehew\n";
                polearms += "The Reaper's Toll\n";
                polearms += "Tomb Reaver\n";
                polearms += "Stormspire\n";
            }
            string scepters = "**Scepters**\n";
            {
                scepters += "Knell Striker\n";
                scepters += "Rusthandle\n";
                scepters += "Stormeye\n";
                scepters += "Zakarum's Hand\n";
                scepters += "The Fetid Sprinkler\n";
                scepters += "Hand of Blessed Light\n";
                scepters += "Heaven's Light\n";
                scepters += "The Redeemer\n";
                scepters += "Astreon's Iron Ward\n";
            }
            string spears = "**Spears**\n";
            {
                spears += "The Dragon Chang\n";
                spears += "Razortine\n";
                spears += "Bloodthief\n";
                spears += "Lance of Yaggai\n";
                spears += "The Tannr Gorerod\n";
                spears += "The Impaler\n";
                spears += "Kelpie Snare\n";
                spears += "Soulfeast Tine\n";
                spears += "Hone Sundan\n";
                spears += "Spire of Honor\n";
                spears += "Arioc's Needle\n";
                spears += "Viperfork\n";
                spears += "Steel Pillar\n";
                spears += "Stoneraven\n";
                spears += "Lycander's Flank\n";
            }
            string staves = "**Staves**\n";
            {
                staves += "Bane Ash\n";
                staves += "Serpent Lord\n";
                staves += "Spire of Lazarus\n";
                staves += "The Salamander\n";
                staves += "The Iron Jang Bong\n";
                staves += "Razorswitch\n";
                staves += "Ribcracker\n";
                staves += "Chromatic Ire\n";
                staves += "Warpspear\n";
                staves += "Skull Collector\n";
                staves += "Ondal's Wisdom\n";
                staves += "Mang Song's Lesson\n";
            }
            string swords = "**Swords**\n";
            {
                swords += "Rixot's Keen\n";
                swords += "Blood Crescent\n";
                swords += "Skewer of Krintiz\n";
                swords += "Gleamscythe\n";
                swords += "Griswold's Edge\n";
                swords += "Hellplague\n";
                swords += "Culwen's Point\n";
                swords += "Shadowfang\n";
                swords += "Soulflay\n";
                swords += "Kinemil's Awl\n";
                swords += "Blacktongue\n";
                swords += "Ripsaw\n";
                swords += "The Patriarch\n";
                swords += "Bloodletter\n";
                swords += "Coldsteel Eye\n";
                swords += "Hexfire\n";
                swords += "Blade of Ali Baba\n";
                swords += "Ginther's Rift\n";
                swords += "Headstriker\n";
                swords += "Plague Bearer\n";
                swords += "The Atlantean\n";
                swords += "Crainte Vomir\n";
                swords += "Bing Sz Wang\n";
                swords += "The Vile Husk\n";
                swords += "Cloudcrack\n";
                swords += "Todesfaelle Flamme\n";
                swords += "Swordguard\n";
                swords += "Djinn Slayer\n";
                swords += "Bloodmoon\n";
                swords += "Lightsabre\n";
                swords += "Azurewrath\n";
                swords += "Frostwind\n";
                swords += "Flamebellow\n";
                swords += "Doombringer\n";
                swords += "The Grandfather\n";
            }
            string throwing = "**Throwing**\n";
            {
                throwing += "Deathbit\n";
                throwing += "The Scalper\n";
                throwing += "Warshrike\n";
                throwing += "Gimmershred\n";
                throwing += "Lacerator\n";
            }
            string wands = "**Wands**\n";
            {
                wands += "Torch of Iro\n";
                wands += "Maelstrom\n";
                wands += "Gravenspine\n";
                wands += "Ume's Lament\n";
                wands += "Suicide Branch\n";
                wands += "Carin Shard\n";
                wands += "Arm of King Leoric\n";
                wands += "Blackhand Key\n";
                wands += "Boneshade\n";
                wands += "Death's Web\n";
            }

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
            {
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
                type.Add(axes);
                type.Add(bows);
                type.Add(clubs);
                type.Add(crossbows);
                type.Add(daggers);
                type.Add(hammers);
                type.Add(javelins);
                type.Add(katars);
                type.Add(maces);
                type.Add(orbs);
                type.Add(polearms);
                type.Add(scepters);
                type.Add(spears);
                type.Add(staves);
                type.Add(swords);
                type.Add(throwing);
                type.Add(wands);
            }

            void AddToMessage(string slotType)
            {
                if (message.Length < 1990 - (slotType + "\n").Length)
                {
                    message += slotType + "\n";
                }
                else if (message2.Length < 1990 - (slotType + "\n").Length)
                {
                    message2 += slotType + "\n";
                }
                else if (message3.Length < 1990 - (slotType + "\n").Length)
                {
                    message3 += slotType + "\n";
                }
                else if (message4.Length < 1990 - (slotType + "\n").Length)
                {
                    message4 += slotType + "\n";
                }
            }

            foreach (var thisArg in separatedArgs)
            {
                switch (thisArg.ToLower())
                {
                    case "helms":
                    case "helm":
                        AddToMessage(type[0]);
                        break;
                    case "chests":
                    case "chest":
                        AddToMessage(type[1]);
                        break;
                    case "belts":
                    case "belt":
                        AddToMessage(type[2]);
                        break;
                    case "boots":
                    case "boot":
                        AddToMessage(type[3]);
                        break;
                    case "gloves":
                    case "glove":
                        AddToMessage(type[4]);
                        break;
                    case "shields":
                    case "shield":
                        AddToMessage(type[5]);
                        break;
                    case "rings":
                    case "ring":
                        AddToMessage(type[6]);
                        break;
                    case "amulets":
                    case "amulet":
                        AddToMessage(type[7]);
                        break;
                    case "charms":
                    case "charm":
                        AddToMessage(type[8]);
                        break;
                    case "jewels":
                    case "jewel":
                        AddToMessage(type[9]);
                        break;
                    case "axe":
                    case "axes":
                        AddToMessage(type[10]);
                        break;
                    case "bow":
                    case "bows":
                        AddToMessage(type[11]);
                        break;
                    case "club":
                    case "clubs":
                        AddToMessage(type[12]);
                        break;
                    case "crossbow":
                    case "crossbows":
                        AddToMessage(type[13]);
                        break;
                    case "dagger":
                    case "daggers":
                        AddToMessage(type[14]);
                        break;
                    case "hammer":
                    case "hammers":
                        AddToMessage(type[15]);
                        break;
                    case "javelin":
                    case "javelins":
                        AddToMessage(type[16]);
                        break;
                    case "katar":
                    case "katars":
                    case "claw":
                    case "claws":
                        AddToMessage(type[17]);
                        break;
                    case "mace":
                    case "maces":
                        AddToMessage(type[18]);
                        break;
                    case "orb":
                    case "orbs":
                        AddToMessage(type[19]);
                        break;
                    case "polearm":
                    case "polearms":
                        AddToMessage(type[20]);
                        break;
                    case "scepter":
                    case "scepters":
                        AddToMessage(type[21]);
                        break;
                    case "spear":
                    case "spears":
                        AddToMessage(type[22]);
                        break;
                    case "staff":
                    case "staves":
                        AddToMessage(type[23]);
                        break;
                    case "swords":
                    case "sword":
                        AddToMessage(type[24]);
                        break;
                    case "throwing":
                    case "projectile":
                    case "projectiles":
                        AddToMessage(type[25]);
                        break;
                    case "wand":
                    case "wands":
                        AddToMessage(type[26]);
                        break;
                    case "armor":
                    case "armors":
                        for(int i = 0; i < 6; i++)
                        {
                            AddToMessage(type[i]);
                        }
                        break;
                    case "jewelry":
                        for(int i = 6; i < 10; i++)
                        {
                            AddToMessage(type[i]);
                        }
                        break;
                    case "weapon":
                    case "weapons":
                        for(int i = 10; i < 26; i++)
                        {
                            AddToMessage(type[i]);
                        }
                        break;
                    default:
                        break;
                }
                break;
            }

            if ( (message == "") && (message2 == "") && (message3 == "") && (message4 == "") )
            {
                message += "Unique listing commands:\n" +
                    "!unique helm\\s\n" +
                    "!unique chest\\s\n" +
                    "!unique belt\\s\n" +
                    "!unique boot\\s\n" +
                    "!unique glove\\s\n" +
                    "!unique shield\\s\n" +
                    "!unique ring\\s\n" +
                    "!unique amulet\\s\n" +
                    "!unique charm\\s\n" +
                    "!unique jewel\\s\n" +
                    "!unique axe\\s\n" +
                    "!unique bow\\s\n" +
                    "!unique club\\s\n" +
                    "!unique crossbow\\s\n" +
                    "!unique dagger\\s\n" +
                    "!unique hammer\\s\n" +
                    "!unique javelin\\s\n" +
                    "!unique katar\\s\n" +
                    "!unique claw\\s\n" +
                    "!unique mace\\s\n" +
                    "!unique orb\\s\n" +
                    "!unique polearm\\s\n" +
                    "!unique scepter\\s\n" +
                    "!unique spear\\s\n" +
                    "!unique staff\n" +
                    "!unique staves\n" +
                    "!unique sword\\s\n" +
                    "!unique throwing\n" +
                    "!unique protectile\\s\n" +
                    "!unique wand\\s\n" +
                    "!unique armor\\s\n" +
                    "!unique jewelry\n" +
                    "!unique weapon\\s";
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
                await Context.Channel.SendMessageAsync("Arguments not recognized");
            }
        }

        [Command("Nokozan Relic")]
        public async Task NokozanRelicImageAsync()
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
        
        [Command("The Gnasher")]
        public async Task TheGnasherImageAsync()
        {
            var name = "The Gnasher(5)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_gnasher_diablo_2_resurrected_wiki_guide_125px.png";
            var requirements = new List<string>
            {
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 60, 70));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 20, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 50, 0));
            affixes.Add(Tuple.Create(" Strength", 8, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Deathspade")]
        public async Task DeathspadeImageAsync()
        {
            var name = "Deathspade(9)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/deathspade_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "32 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 60, 70));
            affixes.Add(Tuple.Create(" Minimum Damage", 8, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 15, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target", 0, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 4, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Bladebone")]
        public async Task BladeboneImageAsync()
        {
            var name = "Bladebone(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/double_axe_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "43 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 30, 50));
            affixes.Add(Tuple.Create("% Damage to Undead", 100, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 8, 12));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create(" Attack Rating Against Undead", 40, 0));
            affixes.Add(Tuple.Create(" Defense", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Skull Splitter")]
        public async Task SkullSplitterImageAsync()
        {
            var name = "Skull Splitter(21)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/military_pick_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "49 Strength",
                "33 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 60, 100));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 12-15));
            affixes.Add(Tuple.Create(" Attack Rating", 50, 100));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 15, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target", 0, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Rakescar")]
        public async Task RakescarImageAsync()
        {
            var name = "Rakescar(27)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_axe_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "67 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 75, 100));
            affixes.Add(Tuple.Create(" Poison Damage Over 3 Seconds", 38, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 50, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 50, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Axe of Fechmar")]
        public async Task AxeofFechmarImageAsync()
        {
            var name = "Axe of Fechmar(8)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/large_axe_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "35 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 90));
            affixes.Add(Tuple.Create("Freezes Target +3", 0, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 50, 0));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Goreshovel")]
        public async Task GoreshovelImageAsync()
        {
            var name = "Goreshovel(14)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/broad_axe_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "48 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 40, 50));
            affixes.Add(Tuple.Create(" Maximum Damage", 9, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 60, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create(" Strength", 25, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Chieftain")]
        public async Task TheChieftainImageAsync()
        {
            var name = "The Chieftain(19)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_chieftan_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "54 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 40));
            affixes.Add(Tuple.Create(" All Resistance", 10, 20));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 6, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Brainhew")]
        public async Task BrainhewImageAsync()
        {
            var name = "Brainhew(25)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/brainhew_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "63 Strength",
                "39 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 80));
            affixes.Add(Tuple.Create(" Minimum Damage", 14, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 15, 35));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 10, 13));
            affixes.Add(Tuple.Create(" Mana", 25, 0));
            affixes.Add(Tuple.Create(" Light Radius", 4, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Humongous")]
        public async Task HumongousImageAsync()
        {
            var name = "Humongous(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/giant_axe_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "84 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 80, 120));
            affixes.Add(Tuple.Create(" Damage", 8, 15-25));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 33, 0));
            affixes.Add(Tuple.Create(" Strength", 20, 30));
            affixes.Add(Tuple.Create("% Requirements ", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Coldkill")]
        public async Task ColdkillImageAsync()
        {
            var name = "Coldkill(36)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_gnasher_diablo_2_resurrected_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                "25 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 190));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 10 Ice Blast on Striking", 10, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 5 Frost Nova When Struck", 10, 0));
            affixes.Add(Tuple.Create(" Cold Damage", 40, 0));
            affixes.Add(Tuple.Create("% to Maximum Cold Resist", 15, 0));
            affixes.Add(Tuple.Create("% Cold Resist",15 , 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Butcher's Pupil")]
        public async Task ButchersPupilImageAsync()
        {
            var name = "Butcher's Pupil(39)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/deathspade_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "68 Strenght"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" Damage", 30, 50));
            affixes.Add(Tuple.Create("% Deadly Strike", 35, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 25, 0));
            affixes.Add(Tuple.Create(" Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Islestrike")]
        public async Task IslestrikeImageAsync()
        {
            var name = "Islestrike(43)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/double_axe_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "85 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 170, 190));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 25, 0));
            affixes.Add(Tuple.Create(" Druid Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 50, 0));
            affixes.Add(Tuple.Create(" All Attributes", 10, 0));
            affixes.Add(Tuple.Create(" Fury (Druid Only)", 1, 0));
            affixes.Add(Tuple.Create(" Maul (Druid Only)", 1, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Pompeii's Wrath")]
        public async Task PompeiisWrathImageAsync()
        {
            var name = "Pompeii's Wrath(45)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/military_pick_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "94 Strength",
                "70 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 140, 170));
            affixes.Add(Tuple.Create(" Fire Damage", 35, 150));
            affixes.Add(Tuple.Create("Slows Target by 50%", 0, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 8 Volcano on Striking", 4, 0));
            affixes.Add(Tuple.Create("Knockback", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Guardian Naga")]
        public async Task GuardianNagaImageAsync()
        {
            var name = "Guardian Naga(48)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_axe_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "121 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 180));
            affixes.Add(Tuple.Create(" Maximum Damage", 20, 0));
            affixes.Add(Tuple.Create(" Poison Damage over 10 Seconds", 250, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 8 Poison Nova on Striking", 0, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 0, 0));
            affixes.Add(Tuple.Create("Damage Taken by Attacker", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Warlord's Trust")]
        public async Task WarlordsTrustImageAsync()
        {
            var name = "Warlord's Trust(35)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/large_axe_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "73 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 175, 0));
            affixes.Add(Tuple.Create(" Repairs 1 Durability Every 4 Seconds", 0, 0));
            affixes.Add(Tuple.Create(" Vitality (Based on Character Level)", 0, 49));
            affixes.Add(Tuple.Create(" Replenish Life", 20, 0));
            affixes.Add(Tuple.Create(" All Resistances", 10, 0));
            affixes.Add(Tuple.Create(" Defense", 75, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Spellsteel")]
        public async Task SpellsteelImageAsync()
        {
            var name = "Spellsteel(39)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/broad_axe_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "37 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 165, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 10, 0));
            affixes.Add(Tuple.Create("% Requirements", -60, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 25, 0));
            affixes.Add(Tuple.Create(" Mana", 100, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 12, 15));
            affixes.Add(Tuple.Create("Level 12 Firestorm (60 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Level 10 Holy Bolt (100 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Level 1 Teleport (20 Charges)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Stormrider")]
        public async Task StormriderImageAsync()
        {
            var name = "Stormrider(41)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/stormrider_weapons_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "101 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 0));
            affixes.Add(Tuple.Create(" Damage", 35, 75));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 200));
            affixes.Add(Tuple.Create("% Chance to Cast Level 5 Charged Bolt When Struck", 15, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 13-20 Charged Bolt on Striking", 10, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 10 Chain Lightning on Striking", 5, 0));
            affixes.Add(Tuple.Create(" Lightning Damage Taken by Attackers", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Boneslayer Blade")]
        public async Task BoneslayerBladeImageAsync()
        {
            var name = "Boneslayer Blade(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/brainhew_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "115 Strength",
                "79 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 220));
            affixes.Add(Tuple.Create(" Attack Rating Against Undead", 5, 495));
            affixes.Add(Tuple.Create("% Damage to Undead", 2, 247));
            affixes.Add(Tuple.Create("% Chance to Cast Level 12-28 Holy Bolt When Struck", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 35, 0));
            affixes.Add(Tuple.Create(" Strength", 8, 0));
            affixes.Add(Tuple.Create("Level 20 Holy Bolt (200 Charges)", 0, 0));
    
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Minotaur")]
        public async Task TheMinotaurImageAsync()
        {
            var name = "The Minotaur(45)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_minataur_weapon_diablo2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "125 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 140, 200));
            affixes.Add(Tuple.Create(" Damage", 20, 30));
            affixes.Add(Tuple.Create("Slows Target by 50%", 0, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 30, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target +2", 0, 0));
            affixes.Add(Tuple.Create("Half Freeze Duration", 0, 0));
            affixes.Add(Tuple.Create(" Strength", 15, 20));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Razor's Edge")]
        public async Task RazorsEdgeImageAsync()
        {
            var name = "Razor's Edge(67)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_gnasher_diablo_2_resurrected_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "125 Strength",
                "67 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 175, 225));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 40, 0));
            affixes.Add(Tuple.Create("% Target Defense", -33, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 50, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 50, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Rune Master")]
        public async Task RuneMasterImageAsync()
        {
            var name = "Rune Master(72)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/double_axe_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "145 Strength",
                "45 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 220, 270));
            affixes.Add(Tuple.Create("% to Maximum Cold Resist", 5, 0));
            affixes.Add(Tuple.Create("Cannot be Frozen", 0, 0));
            affixes.Add(Tuple.Create(" Socketed", 3, 5));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Cranebeak")]
        public async Task CranebeakImageAsync()
        {
            var name = "Cranebeak(63)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/military_pick_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "133 Strength",
                "54 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 240, 300));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 40, 0));
            affixes.Add(Tuple.Create("% Target Defense", -25, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 305));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 20, 50));
            affixes.Add(Tuple.Create("Level 8 Raven (15 Charges)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Death Cleaver")]
        public async Task DeathCleaverImageAsync()
        {
            var name = "Death Cleaver(70)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_axe_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "138 Strength",
                "59 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 230, 280));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 40, 0));
            affixes.Add(Tuple.Create("% Target Defense", -33, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 66, 0));
            affixes.Add(Tuple.Create("Life After Each Kill", 6, 9));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Ethereal Edge")]
        public async Task EtherealEdgeImageAsync()
        {
            var name = "Ethereal Edge(74)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/broad_axe_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "156 Strength",
                "55 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 180));
            affixes.Add(Tuple.Create("% Damage to Demons", 150, 200));
            affixes.Add(Tuple.Create(" Attack Rating", 270, 350));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 25, 0));
            affixes.Add(Tuple.Create(" Absorb Fire", 10, 12));
            affixes.Add(Tuple.Create(" Life After Each Demon Kill", 5, 10));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));
            affixes.Add(Tuple.Create("Ethereal (Cannot be Repaired)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Hellslayer")]
        public async Task HellslayerImageAsync()
        {
            var name = "Hellslayer(66)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_chieftan_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "189 Strength",
                "33 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 0));
            affixes.Add(Tuple.Create("% Enhanced Maximum Damage", 3, 297));
            affixes.Add(Tuple.Create(" Fire Damage", 150, 250));
            affixes.Add(Tuple.Create(" Strength", 0, 49));
            affixes.Add(Tuple.Create(" Dexterity", 0, 49));
            affixes.Add(Tuple.Create(" Life", 25, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 16-20 Fireball on Attack", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Messerschmidt's Reaver")]
        public async Task MesserschmidtsReaverImageAsync()
        {
            var name = "Messerschmidt's Reaver";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/great_axe_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "167 Strength",
                "59 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 0));
            affixes.Add(Tuple.Create("% Enhanced Maximum Damage", 2, 247));
            affixes.Add(Tuple.Create(" Fire Damage", 20, 240));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 100, 0));
            affixes.Add(Tuple.Create(" All Attributes", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Executioner's Justice")]
        public async Task ExecutionersJusticeImageAsync()
        {
            var name = "Executioner's Justice(75)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/giant_axe_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "164 Strenght",
                "55 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 240, 290));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 25, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Target Defense", -33, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 6 Decrepify When You Kill an Enemy", 50, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Blastbark")]
        public async Task BlastbarkImageAsync()
        {
            var name = "Blastbark(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/long_war_bow_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "50 Strength",
                "65 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 130));
            affixes.Add(Tuple.Create(" Amazon Skill Levels", 1, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 3, 0));
            affixes.Add(Tuple.Create(" Strength", 5, 0));
            affixes.Add(Tuple.Create(" Exploding Arrow (Amazon Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Hellclap")]
        public async Task HellclapImageAsync()
        {
            var name = "Hellclap(27)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hellclap_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "35 Strength",
                "55 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 90));
            affixes.Add(Tuple.Create(" Fire Damage", 15, 30-50));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create("Attack Rating", 50, 75));
            affixes.Add(Tuple.Create(" Fire Skills", 1, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 40, 0));
            affixes.Add(Tuple.Create(" Dexterity", 12, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Pluckeye")]
        public async Task PluckeyeImageAsync()
        {
            var name = "Pluckeye(7)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/short_bow_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "15 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 28, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 3, 0));
            affixes.Add(Tuple.Create(" Life", 10, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 2, 0));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));
 
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Raven Claw")]
        public async Task RavenClawImageAsync()
        {
            var name = "Raven Claw(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/long_bow_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "22 Strength",
                "19 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 60, 70));
            affixes.Add(Tuple.Create("Fires Explosive Arrows (Level 3)", 0, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 50, 0));
            affixes.Add(Tuple.Create(" Dexterity", 3, 0));
            affixes.Add(Tuple.Create(" Strength", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Rogue's Bow")]
        public async Task RoguesBowImageAsync()
        {
            var name = "Rogue's Bow(20)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/piercerib_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "25 Strength",
                "35 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 40, 60));
            affixes.Add(Tuple.Create("% Damage to Undead", 100, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 30, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 50, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 60, 0));
            affixes.Add(Tuple.Create(" All Resistances", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Stormstrike")]
        public async Task StormstrikeImageAsync()
        {
            var name = "Stormstrike(25)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/pullspite_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "30 Strength",
                "40 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 90));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 30));
            affixes.Add(Tuple.Create("% Piercing Attack", 25, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 28, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 25, 0));
            affixes.Add(Tuple.Create(" Strength", 8, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Witherstring")]
        public async Task WitherstringImageAsync()
        {
            var name = "Witherstring(13)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hunters_bow_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "28 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 40, 50));
            affixes.Add(Tuple.Create(" Fires Magic Arrows (Level 3)", 0, 0));
            affixes.Add(Tuple.Create(" Damage", 1, 3));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 50, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Wizendraw")]
        public async Task WizendrawImageAsync()
        {
            var name = "Wizendraw(26)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/long_battle_bow_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "40 Strength",
                "50 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 80));
            affixes.Add(Tuple.Create(" Attack Rating", 50, 100));
            affixes.Add(Tuple.Create("Fires Magic Arrows (Level 5)", 0, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Cold Resist ", 26, 0));
            affixes.Add(Tuple.Create(" Energy", 15, 0));
            affixes.Add(Tuple.Create(" Mana", 30, 0));
            affixes.Add(Tuple.Create("% to Enemy Cold Resistance",20 , 35));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Cliffkiller")]
        public async Task CliffkillerImageAsync()
        {
            var name = "Cliffkiller(41)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/long_battle_bow_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "80 Strength",
                "95 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 190, 230));
            affixes.Add(Tuple.Create(" Damage", 5-10, 20-30));
            affixes.Add(Tuple.Create(" Amazon Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 80, 0));
            affixes.Add(Tuple.Create(" Life", 50, 0));
            affixes.Add(Tuple.Create("Knockback", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Endlesshail")]
        public async Task EndlesshailImageAsync()
        {
            var name = "Endlesshail(36)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/piercerib_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "58 Strength",
                "73 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 220));
            affixes.Add(Tuple.Create(" Cold Damage", 15, 30));
            affixes.Add(Tuple.Create("% Cold Resist", 25, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 50, 0));
            affixes.Add(Tuple.Create(" Mana", 40, 0));
            affixes.Add(Tuple.Create(" Strafe (Amazon Only)", 3, 5));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Goldstrike Arch")]
        public async Task GoldstrikeArchImageAsync()
        {
            var name = "Goldstrike Arch(46)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/long_war_bow_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "95 Strength",
                "118 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 250));
            affixes.Add(Tuple.Create("% Damage to Demons", 100, 200));
            affixes.Add(Tuple.Create("% Damage to Undead", 100, 200));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 50, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 7 Fist of the Heavens on Striking", 5, 0));
            affixes.Add(Tuple.Create(" Replenish Life ", 12, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 100, 150));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Kuko Shakaku")]
        public async Task KukoShakakuImageAsync()
        {
            var name = "Kuko Shakaku(33)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/kuko_shakaku_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "53 Strength",
                "49 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 180));
            affixes.Add(Tuple.Create("Fires Explosive Arrows (Level 7)", 0, 0));
            affixes.Add(Tuple.Create("% Piercing Attack", 50, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 40, 180));
            affixes.Add(Tuple.Create(" Immolation Arrow (Amazon Only)", 3, 0));
            affixes.Add(Tuple.Create("Bow and Crossbow Skills (Amazon Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Magewrath")]
        public async Task MagewrathImageAsync()
        {
            var name = "Magewrath(43)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hellclap_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "73 Strength",
                "103 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 120, 150));
            affixes.Add(Tuple.Create(" Damage", 25, 50));
            affixes.Add(Tuple.Create(" Attack Rating", 200, 250));
            affixes.Add(Tuple.Create(" Amazon Skill Levels", 1, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target", 0, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 0, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 0, 0));
            affixes.Add(Tuple.Create(" Dexterity", 10, 0));
            affixes.Add(Tuple.Create(" Guided Arrow (Amazon Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Riphook")]
        public async Task RiphookImageAsync()
        {
            var name = "Riphook(31)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hunters_bow_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "25 Strength",
                "62 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 220));
            affixes.Add(Tuple.Create("Slows Target by 30%", 0, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 30, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 7, 10));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Skystrike")]
        public async Task SkystrikeImageAsync()
        {
            var name = "Skystrike(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/short_bow_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "25 Strength",
                "43 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 250));
            affixes.Add(Tuple.Create("% Chance to Cast Level 6 Meteor on Striking", 2, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 100, 0));
            affixes.Add(Tuple.Create(" Amazon Skill Levels", 1, 0));
            affixes.Add(Tuple.Create(" Energy", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Witchwild String")]
        public async Task WitchwildStringImageAsync()
        {
            var name = "Witchwild String(39)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/whichwild_string_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "65 Strength",
                "80 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 170));
            affixes.Add(Tuple.Create("Fires Magic Arrows (Level 20)", 0, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 5 Amplify Damage on Striking", 2, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 1, 99));
            affixes.Add(Tuple.Create(" All Resistances", 40, 0));
            affixes.Add(Tuple.Create("Socketed (2)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Eaglehorn")]
        public async Task EaglehornImageAsync()
        {
            var name = "Eaglehorn(69)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/long_battle_bow_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "97 Strength",
                "121 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 0));
            affixes.Add(Tuple.Create("% Enhanced Maximum Damage", 2, 198));
            affixes.Add(Tuple.Create("To Amazon Skill Levels", 1, 0));
            affixes.Add(Tuple.Create(" Attack Rating (Based on Character Level)", 6, 594));
            affixes.Add(Tuple.Create(" Dexterity", 25, 0));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Widowmaker")]
        public async Task WidowmakerImageAsync()
        {
            var name = "Widowmaker(65)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hellclap_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "72 Strength",
                "146 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 33, 0));
            affixes.Add(Tuple.Create(" Guided Arrow", 3, 5));
            affixes.Add(Tuple.Create("Fires Magic Arrows (Level 11)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Windforce")]
        public async Task WindforceImageAsync()
        {
            var name = "Windforce(73)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/long_war_bow_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "134 Strength",
                "167 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 250, 0));
            affixes.Add(Tuple.Create(" Maximum Damage", 3, 309));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 8));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 6, 8));
            affixes.Add(Tuple.Create("% Heal Stamina", 30, 0));
            affixes.Add(Tuple.Create(" Strength", 10, 0));
            affixes.Add(Tuple.Create(" Dexterity", 5, 0));
            affixes.Add(Tuple.Create("Knockback", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Lycander's Aim")]
        public async Task LycandersAimImageAsync()
        {
            var name = "Lycander's Aim(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/reflex_bow_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "73 Strength",
                "110 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" Additional Damage", 25, 50));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 5, 8));
            affixes.Add(Tuple.Create(" Energy", 20, 0));
            affixes.Add(Tuple.Create(" Dexterity", 20, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 20, 0));
            affixes.Add(Tuple.Create(" To Bow And Crossbow Skills (Amazon Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Blood Raven's Charge")]
        public async Task BloodRavensChargeImageAsync()
        {
            var name = "Blood Raven's Charge(71)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hellclap_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "87 Strength",
                "187 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 230));
            affixes.Add(Tuple.Create("% Bonus To Attack Rating", 200, 300));
            affixes.Add(Tuple.Create("Fires Explosive Arrows Or Bolts [Level 13]", 0, 0));
            affixes.Add(Tuple.Create("Level 5 Revive (30 Charges)", 0, 0));
            affixes.Add(Tuple.Create(" To Bow And Crossbow Skills (Amazon Only)", 2, 4));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Felloak")]
        public async Task FelloakImageAsync()
        {
            var name = "Felloak(3)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/felloak_weapons_diablo_2_wiki_guide.png";
            var requirements = new List<string>
            {
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 80));
            affixes.Add(Tuple.Create("% Additional Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create(" Additional Fire Damage", 6, 8));
            affixes.Add(Tuple.Create("Knockback", 0, 0));
            affixes.Add(Tuple.Create("% Lightning Resistance", 60, 0));
            affixes.Add(Tuple.Create("% Fire Resistance", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Stoutnail")]
        public async Task StoutnailImageAsync()
        {
            var name = "Stoutnail(5)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/stoutnail_weapons_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 0));
            affixes.Add(Tuple.Create("% Additional Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create(" To Vitality", 7, 0));
            affixes.Add(Tuple.Create(" Damage To Attacker", 3, 10));
            affixes.Add(Tuple.Create(" Magic Damage Taken", -2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Dark Clan Crusher")]
        public async Task DarkClanCrusherImageAsync()
        {
            var name = "Dark Clan Crusher(34)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/felloak_weapons_diablo_2_wiki_guide.png";
            var requirements = new List<string>
            {
                "25 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 195, 0));
            affixes.Add(Tuple.Create("% Additional Damage To Demons", 200, 0));
            affixes.Add(Tuple.Create("% Additional Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create(" Bonus To Attack Rating Against Demons", 200, 0));
            affixes.Add(Tuple.Create("% Bonus To Attack Rating", 20, 25));
            affixes.Add(Tuple.Create(" Life After Each Demon Kill", 15, 0));
            affixes.Add(Tuple.Create(" To Druid Skill Levels", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Fleshrender")]
        public async Task FleshrenderImageAsync()
        {
            var name = "Fleshrender(38)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/stoutnail_weapons_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "30 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 130, 200));
            affixes.Add(Tuple.Create(" Additional Damage", 35, 50));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 20, 0));
            affixes.Add(Tuple.Create("% Chance Of Crushing Blow", 20, 0));
            affixes.Add(Tuple.Create("% Chance Of Open Wounds", 25, 0));
            affixes.Add(Tuple.Create(" To Druid Skills", 1, 0));
            affixes.Add(Tuple.Create(" To Shape Shifting Skills (Druid Only)", 2, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Nord's Tenderizer")]
        public async Task NordsTenderizerImageAsync()
        {
            var name = "Nord's Tenderizer(68)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/felloak_weapons_diablo_2_wiki_guide.png";
            var requirements = new List<string>
            {
                "88 Strength",
                "43 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 270, 330));
            affixes.Add(Tuple.Create("% Additional Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create(" Addtional Cold Damage", 205, 455));
            affixes.Add(Tuple.Create(" Additional Freeze Targets", 2, 4));
            affixes.Add(Tuple.Create("% Cold Absorb", 5, 15));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 25, 0));
            affixes.Add(Tuple.Create("Level 16 Blizzard (12 Charges)", 0, 0));
            affixes.Add(Tuple.Create("% Bonus To Attack Rating", 150, 180));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Demon Limb")]
        public async Task DemonLimbImageAsync()
        {
            var name = "Demon Limb(63)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/stoutnail_weapons_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "133 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 230));
            affixes.Add(Tuple.Create("% Additional Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create("% Additional Damage To Demons", 123, 0));
            affixes.Add(Tuple.Create(" Additional Fire Damage", 222, 333));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 7, 13));
            affixes.Add(Tuple.Create("% Fire Resistance", 15, 20));
            affixes.Add(Tuple.Create("Level 23 Enchant (20 Charges)", 0, 0));
            affixes.Add(Tuple.Create(" Durability Repaired In 20 Seconds", 1, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Leadcrow")]
        public async Task LeadcrowImageAsync()
        {
            var name = "Leadcrow(9)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/leadcrow_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "21 Strength",
                "27 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 25, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 40, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 30, 0));
            affixes.Add(Tuple.Create(" To Life", 10, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Ichorsting")]
        public async Task IchorstingImageAsync()
        {
            var name = "Ichorsting(18)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ichorsting_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "40 Strength",
                "33 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 0));
            affixes.Add(Tuple.Create(" Poison Damage Over 3 Seconds", 30, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("Piercing Attack (50)", 0, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 50, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Hellcast")]
        public async Task HellcastImageAsync()
        {
            var name = "Hellcast(27)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hellcast_diablo_2_weapons_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "60 Strength",
                "40 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 80));
            affixes.Add(Tuple.Create("Fires Explosive Arrows Or Bolts [Level 5]", 0, 0));
            affixes.Add(Tuple.Create(" Additional Fire Damage", 15, 35));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 70, 0));
            affixes.Add(Tuple.Create("% To Max Fire Resistance", 15, 0));
            affixes.Add(Tuple.Create("% Fire Resistance", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Doomslinger")]
        public async Task DoomslingerImageAsync()
        {
            var name = "Doomslinger(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/doomspittle_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "40 Strength",
                "50 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 60, 100));
            affixes.Add(Tuple.Create("Piercing Attack (35)", 0, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create(" To Amazon Skill Levels", 1, 0));
            affixes.Add(Tuple.Create(" To Life", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Langer Briser")]
        public async Task LangerBriserImageAsync()
        {
            var name = "Langer Briser(32)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/langer_briser_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "52 Strength",
                "61 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 170, 200));
            affixes.Add(Tuple.Create(" To Maximum Damage", 10, 30));
            affixes.Add(Tuple.Create("% Chance Of Open Wounds", 33, 0));
            affixes.Add(Tuple.Create(" Additional Lightning Damage", 1, 212));
            affixes.Add(Tuple.Create(" To Life", 30, 0));
            affixes.Add(Tuple.Create("Knockback", 0, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 30, 60));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Pus Spitter")]
        public async Task PusSpitterImageAsync()
        {
            var name = "Pus Spitter(36)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/pus_spiter_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "32 Strength",
                "28 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 220));
            affixes.Add(Tuple.Create(" Poison Damage Over 8 Seconds", 150, 0));
            affixes.Add(Tuple.Create("% Requirements", -60, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 6 Poison Nova When Struck", 9, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 1 Lower Resist On Striking", 4, 0));
            affixes.Add(Tuple.Create(" To Attack Rating (Based On Character Level)", 5, 495));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create(" To Necromancer Skill Levels", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Buriza-Do Kyanon")]
        public async Task BurizaDoKyanonImageAsync()
        {
            var name = "Buriza-Do Kyanon(41)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hellcast_diablo_2_weapons_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "110 Strength",
                "80 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" To Maximum Damage (Based On Character Level)", 2, 247));
            affixes.Add(Tuple.Create(" Additional Cold Damage", 32, 196));
            affixes.Add(Tuple.Create("Piercing Attack (100)", 0, 0));
            affixes.Add(Tuple.Create("Freezes Target +3", 0, 0));
            affixes.Add(Tuple.Create(" Additional Defense", 75, 150));
            affixes.Add(Tuple.Create(" To Dexterity", 35, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 80, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Demon Machine")]
        public async Task DemonMachineImageAsync()
        {
            var name = "Demon Machine(49)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/doomspittle_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "80 Strength",
                "95 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 123, 0));
            affixes.Add(Tuple.Create(" To Maximum Damage", 66, 0));
            affixes.Add(Tuple.Create("Fires Explosive Bolts [Level 6]", 0, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 632, 0));
            affixes.Add(Tuple.Create("Piercing Atack (66)", 0, 0));
            affixes.Add(Tuple.Create(" To Defense", 321, 0));
            affixes.Add(Tuple.Create(" To Mana", 36, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Hellrack")]
        public async Task HellrackImageAsync()
        {
            var name = "Hellrack(76)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hellcast_diablo_2_weapons_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "163 Strength",
                "77 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 230));
            affixes.Add(Tuple.Create("% To Attack Rating", 100, 150));
            affixes.Add(Tuple.Create(" Additional Fire Damage", 63, 324));
            affixes.Add(Tuple.Create(" Additional Lightning Damage", 63, 324));
            affixes.Add(Tuple.Create(" Additional Cold Damage", 63, 324));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("Level 18 Immolation Arrow (150 Charges)", 0, 0));
            affixes.Add(Tuple.Create(" Sockets", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Gut Siphon")]
        public async Task GutSiphonImageAsync()
        {
            var name = "Gut Siphon(71)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/doomspittle_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "141 Strength",
                "98 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 220));
            affixes.Add(Tuple.Create("Piercing Attack (33)", 0, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 12, 18));
            affixes.Add(Tuple.Create("% Chance Of Open Wounds", 33, 0));
            affixes.Add(Tuple.Create("% Target Slow", 25, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Gull")]
        public async Task GullImageAsync()
        {
            var name = "Gull(4)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/dagger_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Additional Damage", 1, 15));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 100, 0));
            affixes.Add(Tuple.Create(" To Mana", -5, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }


        [Command("The Diggler")]
        public async Task TheDigglerImageAsync()
        {
            var name = "The Diggler(11)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/dirk_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "25 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 0));
            affixes.Add(Tuple.Create("Ignore Targets Defense", 0, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 25, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 25, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }


        [Command("The Jade Tan Do")]
        public async Task TheJadeTanDoImageAsync()
        {
            var name = "The Jade Tan Do(19)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_jade_tan_do_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "45 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To Attack Rating", 100, 150));
            affixes.Add(Tuple.Create(" Poison Damage Over 4 Seconds", 180, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 95, 0));
            affixes.Add(Tuple.Create("% To Maximum Poison Resist", 20, 0));
            affixes.Add(Tuple.Create("Cannot Be Frozen", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }


        [Command("Spectral Shard")]
        public async Task SpectralShardImageAsync()
        {
            var name = "Spectral Shard(25)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/blade_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "35 Strength",
                "51 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Faster Cast Rate", 50, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 55, 0));
            affixes.Add(Tuple.Create(" To All Resists", 10, 0));
            affixes.Add(Tuple.Create(" To Mana", 50, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }


        [Command("Spineripper")]
        public async Task SpineripperImageAsync()
        {
            var name = "Spineripper(32)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/dagger_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "25 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 240));
            affixes.Add(Tuple.Create(" Additional Damage", 15, 27));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 15, 0));
            affixes.Add(Tuple.Create(" To Necromancer Skills", 1, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("Ignore Targets Defense", 0, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 8, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }


        [Command("Heart Carver")]
        public async Task HeartCarverImageAsync()
        {
            var name = "Heart Carver(36)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/dirk_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "25 Strength",
                "58 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 190, 240));
            affixes.Add(Tuple.Create(" Additional Damage", 15, 35));
            affixes.Add(Tuple.Create("% Deadly Strike", 35, 0));
            affixes.Add(Tuple.Create("Ignore Targets Defense", 0, 0));
            affixes.Add(Tuple.Create(" To Grim Ward (Barbarian Only)", 4, 0));
            affixes.Add(Tuple.Create(" To Find Item (Barbarian Only)", 4, 0));
            affixes.Add(Tuple.Create(" To Find Potion (Barbarian Only)", 4, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }


        [Command("Blackbog's Sharp")]
        public async Task BlackbogsSharpImageAsync()
        {
            var name = "Blackbog's Sharp(38)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_jade_tan_do_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "25 Strength",
                "88 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Poison Damage Over 10 Seconds", 488, 0));
            affixes.Add(Tuple.Create(" Additional Damage", 15, 45));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Target Slow", 50, 0));
            affixes.Add(Tuple.Create(" To Defense", 50, 0));
            affixes.Add(Tuple.Create(" To Poison Nova (Necromancer Only)", 4, 0));
            affixes.Add(Tuple.Create(" To Poison Explosion (Necromancer Only)", 4, 0));
            affixes.Add(Tuple.Create(" To Poison Dagger (Necromancer Only)", 5, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }


        [Command("Stormspike")]
        public async Task StormspikeImageAsync()
        {
            var name = "Stormspike(41)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/stormspike_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "47 Strength",
                "97 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Ehanced Damage", 150, 0));
            affixes.Add(Tuple.Create(" Additional Lightning Damage", 1, 120));
            affixes.Add(Tuple.Create("% Chance To Cast Level 3", 25, 0));
            affixes.Add(Tuple.Create("Charged Bolt When Struck", 0, 0));
            affixes.Add(Tuple.Create("% To Lightning Resist (Based On Character Level)", 1, 99));
            affixes.Add(Tuple.Create(" Lightning Damage To Attacker", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }


        [Command("Wizardspike")]
        public async Task WizardspikeImageAsync()
        {
            var name = "Wizardspike(61)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/dagger_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "38 Strength",
                "75 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To Mana (Based On Character Level)", 2, 198));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 50, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 15, 0));
            affixes.Add(Tuple.Create("% Increased Maximum Mana", 15, 0));
            affixes.Add(Tuple.Create(" To All Resists", 75, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }


        [Command("Fleshripper")]
        public async Task FleshripperImageAsync()
        {
            var name = "Fleshripper(68)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_jade_tan_do_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "42 Strength",
                "86 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 300));
            affixes.Add(Tuple.Create("% Target Defense", -50, 0));
            affixes.Add(Tuple.Create("% Chance Of Crushing Blow", 25, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 33, 0));
            affixes.Add(Tuple.Create("% Chance Of Open Wounds", 50, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("% Target Slow", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Ghostflame")]
        public async Task GhostflameImageAsync()
        {
            var name = "Ghostflame(66)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/blade_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "55 Strength",
                "57 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 190, 240));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create(" Additional Magic Damage", 108, 0));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 10, 15));
            affixes.Add(Tuple.Create(" To Light Radius", 2, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));
            affixes.Add(Tuple.Create("Ethereal (Cannot Be Repaired)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Ironstone")]
        public async Task IronstoneImageAsync()
        {
            var name = "Ironstone(27)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_hammer_weapons_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "53 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 150));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create(" Additional Lightning Damage", 1, 10));
            affixes.Add(Tuple.Create(" To Attack Rating", 100, 150));
            affixes.Add(Tuple.Create(" To Strength", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Bonesnap")]
        public async Task BonesnapImageAsync()
        {
            var name = "Bonesnap(24)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bonesob_weapons_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "69 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 300));
            affixes.Add(Tuple.Create("% Damage To Undead", 100, 0));
            affixes.Add(Tuple.Create("% chance of Crushing Blow", 40, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 30, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 30, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Steeldriver")]
        public async Task SteeldriverImageAsync()
        {
            var name = "Steeldriver(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/great_maul_weapons_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "50 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 250));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 40, 0));
            affixes.Add(Tuple.Create("% Requirements", -50, 0));
            affixes.Add(Tuple.Create("% Faster Stamina Regen", 25, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Earthshaker")]
        public async Task EarthshakerImageAsync()
        {
            var name = "Earthshaker(43)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_hammer_weapons_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "100 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 0));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 7 Fissure On Striking", 5, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target", 0, 0));
            affixes.Add(Tuple.Create("Knockback", 0, 0));
            affixes.Add(Tuple.Create(" To Elemental Skills (Druid Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Bloodtree Stump")]
        public async Task BloodtreeStumpImageAsync()
        {
            var name = "Bloodtree Stump(48)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/maul_weapons_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "124 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 220));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance Of Crushing Blow", 50, 0));
            affixes.Add(Tuple.Create(" All Resists", 20, 0));
            affixes.Add(Tuple.Create(" To Strength", 25, 0));
            affixes.Add(Tuple.Create(" To Masteries (Barbarian Only)", 2, 0));
            affixes.Add(Tuple.Create(" To Mace Masteries (Barbarian Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Gavel of Pain")]
        public async Task TheGavelofPainImageAsync()
        {
            var name = "The Gavel of Pain(45)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_gavel_of_pain_weapons_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "169 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 130, 160));
            affixes.Add(Tuple.Create(" Additional Damage", 12, 30));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 1 Iron Maiden When Struck", 5, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 1 Amplify Damage On Striking", 5, 0));
            affixes.Add(Tuple.Create("Level 8 Amplify Damage (3 Charges)", 0, 0));
            affixes.Add(Tuple.Create(" Damage To Attacker", 26, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Stone Crusher")]
        public async Task StoneCrusherImageAsync()
        {
            var name = "Stone Crusher(68)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_hammer_weapons_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "189 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 280, 320));
            affixes.Add(Tuple.Create(" Additional Damage", 10, 30));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create("% Target Defense", -25, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 40, 0));
            affixes.Add(Tuple.Create(" To Monster Defense Per Hit", -100, 0));
            affixes.Add(Tuple.Create(" To Strength", 20, 30));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Schaefer's Hammer")]
        public async Task SchaefersHammerImageAsync()
        {
            var name = "Schaefer's Hammer(79)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_hammer_weapons_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "189 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 130));
            affixes.Add(Tuple.Create(" To Maximum Damage (Based On Character Level)", 2, 198));
            affixes.Add(Tuple.Create(" Additional Lightning Damage", 50, 200));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 10 Static Field On Striking", 20, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create(" To Attack Rating (Based On Character Level)", 8, 792));
            affixes.Add(Tuple.Create(" To Lightning Resist", 75, 0));
            affixes.Add(Tuple.Create(" To Life", 50, 0));
            affixes.Add(Tuple.Create(" To Light Radius", 1, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Windhammer ")]
        public async Task WindhammerImageAsync()
        {
            var name = "Windhammer(68)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/maul_weapons_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "225 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 230));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 60, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 22 Twister On Striking", 33, 0));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Earth Shifter")]
        public async Task EarthShifterImageAsync()
        {
            var name = "Earth Shifter(69)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/great_maul_weapons_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "253 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 250, 300));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create(" To Elemental Skills (Druid Only)", 7, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 14 Fissure On Striking", 25, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 33, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 10, 0));
            affixes.Add(Tuple.Create("Level 14 Volcano (30 charges)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Cranium Basher")]
        public async Task TheCraniumBasherImageAsync()
        {
            var name = "The Cranium Basher(87)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/great_maul_weapons_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "253 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 240));
            affixes.Add(Tuple.Create(" To Minimum Damage", 20, 0));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance Of Crushing Blow", 75, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 1 Amplify Damage On Striking", 4, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create(" To All Resists", 25, 0));
            affixes.Add(Tuple.Create(" To Strength", 25, 0));
            affixes.Add(Tuple.Create(" To Maximum Damage (not shown)", 20, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Demon's Arch")]
        public async Task DemonsArchImageAsync()
        {
            var name = "Demon's Arch(68)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/short_spear_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "127 Strength",
                "95 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 210));
            affixes.Add(Tuple.Create(" Additional Fire Damage", 232, 323));
            affixes.Add(Tuple.Create(" Additional Lightning Damage", 23, 333));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 6, 12));
            affixes.Add(Tuple.Create("Replenishes Quantity [1 in 3 sec.]", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Wraith Flight")]
        public async Task WraithFlightImageAsync()
        {
            var name = "Wraith Flight(76)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/glaive_weapon_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "79 Strength",
                "127 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 190));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 9, 13));
            affixes.Add(Tuple.Create(" To Mana After Each Kill", 15, 0));
            affixes.Add(Tuple.Create("Replenishes Quantity [1 in 2 sec.]", 0, 0));
            affixes.Add(Tuple.Create("Ethereal (Cannot Be Repaired)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Gargoyle's Bite")]
        public async Task GargoylesBiteImageAsync()
        {
            var name = "Gargoyle's Bite(70)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/throwing_spear_weapons_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "76 Strength",
                "145 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 230));
            affixes.Add(Tuple.Create(" Additional Poison Damage Over 10 Seconds", 293, 0));
            affixes.Add(Tuple.Create("Level 11 Plague Javelin (60 charges)", 0, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit (varies)", 9, 15));
            affixes.Add(Tuple.Create("Replenishes Quantity [1 in 3 sec.]", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Titan's Revenge")]
        public async Task TitansRevengeImageAsync()
        {
            var name = "Titan's Revenge(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/maiden_javelin_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "25 Strength",
                "109 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" Additional Damage", 25, 50));
            affixes.Add(Tuple.Create(" To Amazon Skill Levels", 2, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 5, 9));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 30, 0));
            affixes.Add(Tuple.Create(" To Strength", 20, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 20, 0));
            affixes.Add(Tuple.Create("Replenishes Quantity [1 in 3 sec.]", 0, 0));
            affixes.Add(Tuple.Create("Increased Stack Size [60]", 0, 0));
            affixes.Add(Tuple.Create(" To Javelin and Spear Skills (Amazon Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Thunderstroke")]
        public async Task ThunderstrokeImageAsync()
        {
            var name = "Thunderstroke(69)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/maiden_javelin_weapons_diablo_2_resurrected_wiki_guide.png";
            var requirements = new List<string>
            {
                "107 Strength",
                "151 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" Additional Lightning Damage", 1, 511));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 15, 0));
            affixes.Add(Tuple.Create("% To Enemy Lightning Resistance", -15, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 14 Lightning On Striking", 20, 0));
            affixes.Add(Tuple.Create(" To Javelin and Spear Skills (Amazon Only)", 2, 4));
            affixes.Add(Tuple.Create(" To Lightning Bolt (Amazon Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Shadow Killer")]
        public async Task ShadowKillerImageAsync()
        {
            var name = "Shadow Killer(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/shadowkiller_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "79 Strength",
                "79 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 170, 220));
            affixes.Add(Tuple.Create("% Target Defense", -25, 0));
            affixes.Add(Tuple.Create("Freezes Target +2", 0, 0));
            affixes.Add(Tuple.Create(" To Mana After Each Kill", 10, 15));
            affixes.Add(Tuple.Create("% Chance To Cast Level 8 Frost Nova On Striking", 33, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));
            affixes.Add(Tuple.Create("Ethereal (Cannot Be Repaired)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Bartuc's Cut-Throat")]
        public async Task BartucsCutThroatImageAsync()
        {
            var name = "Bartuc's Cut-Throat(66)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/claws_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "105 Strength",
                "105 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" Additional Damage", 25, 50));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create("% Bonus To Attack Rating", 20, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 5, 9));
            affixes.Add(Tuple.Create(" To Strength", 20, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 20, 0));
            affixes.Add(Tuple.Create(" To Assassin Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" To Martial Arts Skills (Assassin Only)", 1, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Jade Talons")]
        public async Task JadeTalonsImageAsync()
        {
            var name = "Jade Talons(78)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/katar_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "100 Strength",
                "100 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 190, 240));
            affixes.Add(Tuple.Create(" To Martial Arts (Assassin Only)", 1, 2));
            affixes.Add(Tuple.Create(" To Shadow Disciplines (Assassin Only)", 1, 2));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 10, 15));
            affixes.Add(Tuple.Create(" All Resists", 40, 50));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Firelizard's Talons")]
        public async Task FirelizardsTalonsImageAsync()
        {
            var name = "Firelizard's Talons(67)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/claws_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "113 Strength",
                "113 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 270));
            affixes.Add(Tuple.Create(" Additional Fire Damage", 236, 480));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 15, 0));
            affixes.Add(Tuple.Create(" To Martial Arts (Assassin Only)", 1, 3));
            affixes.Add(Tuple.Create(" To Wake of Inferno (Assassin Only)", 1, 2));
            affixes.Add(Tuple.Create(" To Wake of Fire (Assassin Only)", 1, 2));
            affixes.Add(Tuple.Create(" Fire Resist", 40, 70));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Crushflange")]
        public async Task CrushflangeImageAsync()
        {
            var name = "Crushflange(9)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/mace_weapon_diablo_2_resurrected_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "27 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 60));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance Of Crushing Blow", 33, 0));
            affixes.Add(Tuple.Create("Knockback", 0, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 50, 0));
            affixes.Add(Tuple.Create(" To Strength", 15, 0));
            affixes.Add(Tuple.Create(" To Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Bloodrise")]
        public async Task BloodriseImageAsync()
        {
            var name = "Bloodrise(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bloodrise_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "36 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 120, 0));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance Of Open Wounds", 25, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 5, 0));
            affixes.Add(Tuple.Create("% bonus to Attack Rating", 50, 0));
            affixes.Add(Tuple.Create(" To Sacrifice (Paladin Only)", 3, 0));
            affixes.Add(Tuple.Create(" To Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The General's Tan Do Li Ga")]
        public async Task TheGeneralsTanDoLiGaImageAsync()
        {
            var name = "The General's Tan Do Li Ga(21)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/flail_weapon_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "41 Strength",
                "35 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 60));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create(" Additional Damage", 1, 20));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 5, 0));
            affixes.Add(Tuple.Create("% Target Slow", 20, 0));
            affixes.Add(Tuple.Create(" To Defense", 25, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Sureshrill Frost")]
        public async Task SureshrillFrostImageAsync()
        {
            var name = "Sureshrill Frost(39)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/mace_weapon_diablo_2_resurrected_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "61 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 180));
            affixes.Add(Tuple.Create(" Additional Damage", 5, 10));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create(" Additional Cold Damage", 63, 112));
            affixes.Add(Tuple.Create("Freezes Target +3", 0, 0));
            affixes.Add(Tuple.Create("Level 9 Frozen Orb (50 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Cannot Be Frozen", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Moonfall")]
        public async Task MoonfallImageAsync()
        {
            var name = "Moonfall(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bloodrise_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "74 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 120, 150));
            affixes.Add(Tuple.Create(" Additional Damage", 10, 15));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create(" Additional Fire Damage", 55, 115));
            affixes.Add(Tuple.Create("% Chance To Cast Level 6 Meteor On Striking", 5, 0));
            affixes.Add(Tuple.Create("Level 11 Meteor (60 Charges)", 0, 0));
            affixes.Add(Tuple.Create(" Magic Damage Taken", 9, 12));
            affixes.Add(Tuple.Create(" To Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Baezil's Vortex")]
        public async Task BaezilsVortexImageAsync()
        {
            var name = "Baezil's Vortex(45)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/flail_weapon_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "82 Strength",
                "73 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 200));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create(" Additional Lightning Damage", 1, 150));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 8 Nova On Striking", 5, 0));
            affixes.Add(Tuple.Create("Level 15 Nova (80 Charges)", 0, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 25, 0));
            affixes.Add(Tuple.Create(" To Mana", 100, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Baranar's Star")]
        public async Task BaranarsStarImageAsync()
        {
            var name = "Baranar's Star(65)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bloodrise_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "153 Strength",
                "44 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 0));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create(" Additional Fire Damage", 1, 200));
            affixes.Add(Tuple.Create(" Additional Lightning Damage", 1, 200));
            affixes.Add(Tuple.Create(" Additional Cold Damage", 1, 200));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 50, 0));
            affixes.Add(Tuple.Create("% Bonus To Attack Rating", 200, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 15, 0));
            affixes.Add(Tuple.Create(" To Strength", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Horizon's Tornado")]
        public async Task HorizonsTornadoImageAsync()
        {
            var name = "Horizon's Tornado(64)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/flail_weapon_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "100 Strength",
                "62 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 230, 280));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 50, 0));
            affixes.Add(Tuple.Create("% Target Slow", 20, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 15 Tornado On Striking", 20, 0));
            affixes.Add(Tuple.Create("% Requirements", -20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Stormlash")]
        public async Task StormlashImageAsync()
        {
            var name = "Stormlash(82)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/flail_weapon_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "125 Strength",
                "77 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 240, 300));
            affixes.Add(Tuple.Create("% Damage To Undead", 50, 0));
            affixes.Add(Tuple.Create(" Additional Lightning Damage", 1, 473));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 33, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 18 Tornado On Striking", 20, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 10 Static Field On Striking", 15, 0));
            affixes.Add(Tuple.Create(" Lightning Absorb", 3, 9));
            affixes.Add(Tuple.Create(" Attacker Takes Lightning Damage", 30, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Oculus")]
        public async Task TheOculusImageAsync()
        {
            var name = "The Oculus(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/dragon_stone_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To Sorceress Skill Levels", 3, 0));
            affixes.Add(Tuple.Create(" To Mana After Each Kill", 5, 0));
            affixes.Add(Tuple.Create(" All Resist", 20, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 1 Teleport When Struck", 25, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 30, 0));
            affixes.Add(Tuple.Create(" To Vitality", 20, 0));
            affixes.Add(Tuple.Create(" To Energy", 20, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 20, 0));
            affixes.Add(Tuple.Create("% Better Chance Of Getting Magic Items", 50, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Eschuta's Temper")]
        public async Task EschutasTemperImageAsync()
        {
            var name = "Eschuta's Temper(72)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/sacred_globe_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To Sorceress Skill Levels", 1, 3));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 40, 0));
            affixes.Add(Tuple.Create("% To Fire Skill Damage", 10, 20));
            affixes.Add(Tuple.Create("% To Lightning Skill Damage", 10, 20));
            affixes.Add(Tuple.Create(" To Energy", 20, 30));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Death's Fathom")]
        public async Task DeathsFathomImageAsync()
        {
            var name = "Death's Fathom(73)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/dragon_stone_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To Sorceress Skill Levels", 3, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, 0));
            affixes.Add(Tuple.Create("% To Cold Skill Damage ", 15, 30));
            affixes.Add(Tuple.Create("% Lightning Resist", 25, 40));
            affixes.Add(Tuple.Create("% Fire Resist", 25, 40));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Dimoak's Hew")]
        public async Task DimoaksHewImageAsync()
        {
            var name = "Dimoak's Hew(8)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bardiche_polearm_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "40 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 15, 0));
            affixes.Add(Tuple.Create(" To Defense", -8, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Steelgoad")]
        public async Task SteelgoadImageAsync()
        {
            var name = "Steelgoad(14)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/voulge_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "50 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 60, 80));
            affixes.Add(Tuple.Create("% Deadly Strike", 30, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 30, 0));
            affixes.Add(Tuple.Create("% All Resists", 5, 0));
            affixes.Add(Tuple.Create("% Chance Hit Causes Monster To Flee", 75, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Soul Harvest")]
        public async Task SoulHarvestImageAsync()
        {
            var name = "Soul Harvest(19)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/soul_harvest_weapons_diablo_2_resurrected_wiki_guiude_196px.png";
            var requirements = new List<string>
            {
                "41 Strength",
                "41 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 90));
            affixes.Add(Tuple.Create("% Chance Of Open Wounds", 30, 0));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 10, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 45, 0));
            affixes.Add(Tuple.Create(" To Energy", 5, 0));
            affixes.Add(Tuple.Create("% All Resists", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Battlebranch")]
        public async Task TheBattlebranchImageAsync()
        {
            var name = "The Battlebranch(25)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/poleaxe_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "62 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 70));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 50, 100));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 7, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Woestave")]
        public async Task WoestaveImageAsync()
        {
            var name = "Woestave(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/halberd_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "75 Strength",
                "47 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 20, 40));
            affixes.Add(Tuple.Create("% Chance Of Open Wounds", 50, 0));
            affixes.Add(Tuple.Create("% Target Slow", 20, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target +3", 0, 0));
            affixes.Add(Tuple.Create(" To Monster Defense Per Hit", -50, 0));
            affixes.Add(Tuple.Create("Freezes Target", 0, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" To Light Radius", -3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Grim Reaper")]
        public async Task TheGrimReaperImageAsync()
        {
            var name = "The Grim Reaper(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_scythe_weapons_diablo_2_resurrected_wiki_guide__196px.png";
            var requirements = new List<string>
            {
                "80 Strength",
                "80 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 20, 0));
            affixes.Add(Tuple.Create(" To Minimum Damage", 15, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 100, 0));
            affixes.Add(Tuple.Create("% Mana stolen per hit", 5, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Meat Scrapper")]
        public async Task TheMeatScrapperImageAsync()
        {
            var name = "The Meat Scrapper(41)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bardiche_polearm_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "80 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create("% Chance Of Open Wounds", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 10, 0));
            affixes.Add(Tuple.Create("% Better Chance Of Getting Magic Items", 25, 0));
            affixes.Add(Tuple.Create(" To Masteries (Barbarian Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Blackleach Blade")]
        public async Task BlackleachBladeImageAsync()
        {
            var name = "Blackleach Blade(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/voulge_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "72 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" To Maximum Damage (Based On Character Level)", 1, 123));
            affixes.Add(Tuple.Create("% Chance To Cast Level 5 Weaken On Striking", 5, 0));
            affixes.Add(Tuple.Create(" Requirements", -25, 0));
            affixes.Add(Tuple.Create(" To Light Radius", -2, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 8, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Athena's Wrath")]
        public async Task AthenasWrathImageAsync()
        {
            var name = "Athena's Wrath(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/athenas_wrath_polearms_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "82 Strength",
                "82 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 180));
            affixes.Add(Tuple.Create(" To Maximum Damage (Based On Character Level)", 1, 99));
            affixes.Add(Tuple.Create(" To Life (Based On Character Level)", 1, 99));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create(" To Druid Skill Levels ", 1, 3));
            affixes.Add(Tuple.Create(" To Dexterity", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Pierre Tombale Couant")]
        public async Task PierreTombaleCouantImageAsync()
        {
            var name = "Pierre Tombale Couant(43)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/poleaxe_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "113 Strength",
                "67 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 220));
            affixes.Add(Tuple.Create(" Additional Damage", 12, 20));
            affixes.Add(Tuple.Create("% Deadly Strike", 55, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 100, 200));
            affixes.Add(Tuple.Create(" To Barbarian Skill Levels", 3, 0));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 6, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Husoldal Evo")]
        public async Task HusoldalEvoImageAsync()
        {
            var name = "Husoldal Evo(44)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/halberd_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "133 Strength",
                "91 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 200));
            affixes.Add(Tuple.Create(" Additional Damage", 20, 32));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 200, 250));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" Replenish Life", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Grim's Burning Dead")]
        public async Task GrimsBurningDeadImageAsync()
        {
            var name = "Grim's Burning Dead(45)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_scythe_weapons_diablo_2_resurrected_wiki_guide__196px.png";
            var requirements = new List<string>
            {
                "70 Strength",
                "70 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 140, 180));
            affixes.Add(Tuple.Create(" Additional Fire Damage", 131, 232));
            affixes.Add(Tuple.Create(" To Necromancer Skill Levels", 3, 0));
            affixes.Add(Tuple.Create("% Target Defense", -50, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 20, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 200, 250));
            affixes.Add(Tuple.Create("% Fire Resist", 45, 0));
            affixes.Add(Tuple.Create("% Requirements", -50, 0));
            affixes.Add(Tuple.Create(" Damage To Attacker", 8, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Bonehew")]
        public async Task BonehewImageAsync()
        {
            var name = "Bonehew(64)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bardiche_polearm_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "195 Strength",
                "75 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 270, 320));
            affixes.Add(Tuple.Create("Level 14 Corpse Explosion (30 charges)", 0, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 16 Bone Spear On Striking", 50, 0));
            affixes.Add(Tuple.Create("Socketed (2)", 2, 4));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("The Reaper's Toll")]
        public async Task TheReapersTollImageAsync()
        {
            var name = "The Reaper's Toll(75)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/scythe_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "114 Strength",
                "89 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 190, 240));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create(" Additional Cold Damage", 4, 44));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 11, 15));
            affixes.Add(Tuple.Create("% Deadly Strike", 33, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 1 Decrepify On Striking", 33, 0));
            affixes.Add(Tuple.Create("% Requirements", -25, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Tomb Reaver")]
        public async Task TombReaverImageAsync()
        {
            var name = "Tomb Reaver(84)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/poleaxe_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "165 Strength",
                "103 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 280));
            affixes.Add(Tuple.Create("% Damage To Undead ", 150, 230));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 60, 0));
            affixes.Add(Tuple.Create(" To Attack Rating Against Undead ", 250, 350));
            affixes.Add(Tuple.Create("% All Resist", 30, 50));
            affixes.Add(Tuple.Create("% Reanimate As: Returned", 10, 0));
            affixes.Add(Tuple.Create(" Life After Each Kill", 10, 14));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items ", 50, 80));
            affixes.Add(Tuple.Create(" To Light Radius", 4, 0));
            affixes.Add(Tuple.Create("Socketed (1-3)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Stormspire")]
        public async Task StormspireImageAsync()
        {
            var name = "Stormspire(70)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_scythe_weapons_diablo_2_resurrected_wiki_guide__196px.png";
            var requirements = new List<string>
            {
                "188 Strength",
                "140 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 250));
            affixes.Add(Tuple.Create(" Additional Lightning Damage", 1, 237));
            affixes.Add(Tuple.Create("% Chance To Cast Level 20 Charged Bolt When Struck", 2, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 5 Chain Lightning When Struck", 5, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 50, 0));
            affixes.Add(Tuple.Create(" To Strength", 10, 0));
            affixes.Add(Tuple.Create(" Lightning Damage Taken", 27, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Knell Striker")]
        public async Task KnellStrikerImageAsync()
        {
            var name = "Knell Striker(5)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/scepter_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 80));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 25, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 35, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 20, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 20, 0));
            affixes.Add(Tuple.Create(" Mana", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Rusthandle")]
        public async Task RusthandleImageAsync()
        {
            var name = "Rusthandle(18)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/grand_scepter_weapons_diablo_2_resurrected_wiki_guide_196xp.png";
            var requirements = new List<string>
            {
                "37 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 60));
            affixes.Add(Tuple.Create("% Damage to Undead", 100, 110));
            affixes.Add(Tuple.Create(" Damage", 3, 7));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 8, 0));
            affixes.Add(Tuple.Create(" Paladin Skill Levels", 1, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 1, 0));
            affixes.Add(Tuple.Create(" Thorns (Paladin Only)", 3, 0));
            affixes.Add(Tuple.Create(" Vengeance (Paladin Only)", 1, 3));
  
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Stormeye")]
        public async Task StormeyeImageAsync()
        {
            var name = "Stormeye(30)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_scepter_weapons_diablo_2_resurrected_wiki_guide_196xp.png";
            var requirements = new List<string>
            {
                "55 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 80, 120));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Cold Damage", 3, 5));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 6));
            affixes.Add(Tuple.Create(" Replenish Life", 10, 0));
            affixes.Add(Tuple.Create(" Fist of the Heavens (Paladin Only)", 1, 0));
            affixes.Add(Tuple.Create(" Holy Shock (Paladin Only)", 3, 0));
            affixes.Add(Tuple.Create(" Resist Lightning (Paladin Only)", 3, 5));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Zakarum's Hand")]
        public async Task ZakarumsHandImageAsync()
        {
            var name = "Zakarum's Hand(37)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/scepter_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "58 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 220));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 5 Blizzard on Striking", 6, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 8, 0));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 10, 0));
            affixes.Add(Tuple.Create("% Heal Stamina", 15, 0));
            affixes.Add(Tuple.Create(" Holy Shock (Paladin Only)", 2, 0));
            affixes.Add(Tuple.Create(" Holy Freeze (Paladin Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Fetid Sprinkler")]
        public async Task TheFetidSprinklerImageAsync()
        {
            var name = "The Fetid Sprinkler(38)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/grand_scepter_weapons_diablo_2_resurrected_wiki_guide_196xp.png";
            var requirements = new List<string>
            {
                "76 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 190));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Damage", 15, 25));
            affixes.Add(Tuple.Create(" Paladin Skill Levels", 2, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 1 Confuse on Striking", 10, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 1 Decrepify on Striking", 5, 0));
            affixes.Add(Tuple.Create(" Poison Damage Over 4 Seconds", 160, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 150, 200));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Hand of Blessed Light")]
        public async Task HandofBlessedLightImageAsync()
        {
            var name = "Hand of Blessed Light(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_scepter_weapons_diablo_2_resurrected_wiki_guide_196xp.png";
            var requirements = new List<string>
            {
                "42 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 130, 160));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Damage", 20, 45));
            affixes.Add(Tuple.Create(" Paladin Skill Levels", 2, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 100, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 15, 0));
            affixes.Add(Tuple.Create(" Defense", 50, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 4 Fist of the Heavens on Striking", 5, 0));
            affixes.Add(Tuple.Create(" Fist of the Heavens (Paladin Only)", 2, 0));
            affixes.Add(Tuple.Create(" Holy Bolt (Paladin Only)", 4, 0));
            affixes.Add(Tuple.Create(" Light Radius", 4, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Heaven's Light")]
        public async Task HeavensLightImageAsync()
        {
            var name = "Heaven's Light(61)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/scepter_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "125 Strength",
                "65 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 250, 300));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Target Defense", 33, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", -33, 0));
            affixes.Add(Tuple.Create(" Life After Each Demon Kill", 15, 20));
            affixes.Add(Tuple.Create(" Paladin Skill Levels", 2, 3));
            affixes.Add(Tuple.Create(" Light Radius", 3, 0));
            affixes.Add(Tuple.Create(" Sockets", 1, 2));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Redeemer")]
        public async Task TheRedeemerImageAsync()
        {
            var name = "The Redeemer(72)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/scepter_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "50 Strength",
                "26 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 250, 300));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Damage", 60, 120));
            affixes.Add(Tuple.Create("% Damage to Demons", 200, 250));
            affixes.Add(Tuple.Create(" Paladin Skill Levels", 2, 0));
            affixes.Add(Tuple.Create("% Target Defense", -33, 0));
            affixes.Add(Tuple.Create(" Redemption (Paladin Only", 2, 4));
            affixes.Add(Tuple.Create(" Holy Bolt (Paladin Only)", 2, 4));
            affixes.Add(Tuple.Create(" Light Radius", 3, 0));
            affixes.Add(Tuple.Create("% Requirements", -60, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Astreon's Iron Ward")]
        public async Task AstreonsIronWardImageAsync()
        {
            var name = "Astreon's Iron Ward(66)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_scepter_weapons_diablo_2_resurrected_wiki_guide_196xp.png";
            var requirements = new List<string>
            {
                "97 Strength",
                "70 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 240, 290));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Damage", 40, 85));
            affixes.Add(Tuple.Create(" Magic Damage", 80, 240));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 33, 0));
            affixes.Add(Tuple.Create("% Slows Target", 25, 0));
            affixes.Add(Tuple.Create(" Damage Reduced", 4, 7));
            affixes.Add(Tuple.Create(" Combat Skills (Paladin Only)", 2, 4));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 150, 200));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Bloodthief")]
        public async Task BloodthiefImageAsync()
        {
            var name = "Bloodthief(17)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/brandistock_weapons_diablo_2_resurrected_wiki_guide_201px.png";
            var requirements = new List<string>
            {
                "40 Strength",
                "50 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 70));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 35, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 8, 12));
            affixes.Add(Tuple.Create(" Life", 26, 0));
            affixes.Add(Tuple.Create(" Strength", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Lance of Yaggai")]
        public async Task LanceofYaggaiImageAsync()
        {
            var name = "Lance of Yaggai(22)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/spetum_weapons_diablo_2_resurrected_wiki_guide_201px.png";
            var requirements = new List<string>
            {
                "54 Strength",
                "35 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 60));
            affixes.Add(Tuple.Create(" All Resistances", 15, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 40, 0));
            affixes.Add(Tuple.Create(" Damage Taken by Attackers", 8, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Razortine")]
        public async Task RazortineImageAsync()
        {
            var name = "Razortine(12)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/razortine_weapons_diablo_2_resurrected_wiki_guide_201px.png";
            var requirements = new List<string>
            {
                "38 Strength",
                "24 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 30, 50));
            affixes.Add(Tuple.Create("% Slows Target", 25, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Target Defense", -50, 0));
            affixes.Add(Tuple.Create(" Dexterity", 8, 0));
            affixes.Add(Tuple.Create(" Strength", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Dragon Chang")]
        public async Task TheDragonChangImageAsync()
        {
            var name = "The Dragon Chang(8)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/spear_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "20 Dexterity",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 0));
            affixes.Add(Tuple.Create(" Minimum Damage", 10, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 3, 6));
            affixes.Add(Tuple.Create(" Attack Rating", 35, 0));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Tannr Gorerod")]
        public async Task TheTannrGorerodImageAsync()
        {
            var name = "The Tannr Gorerod(27)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/pike_weapons_diablo-2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "60 Strength",
                "45 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 80, 100));
            affixes.Add(Tuple.Create(" Fire Damage", 23, 54));
            affixes.Add(Tuple.Create(" Attack Rating", 60, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 15, 0));
            affixes.Add(Tuple.Create("% Maximum Fire Resist", 15, 0));
            affixes.Add(Tuple.Create(" Life", 30, 0));
            affixes.Add(Tuple.Create(" Light Radius", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Hone Sundan")]
        public async Task HoneSundanImageAsync()
        {
            var name = "Hone Sundan(37)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/spetum_weapons_diablo_2_resurrected_wiki_guide_201px.png";
            var requirements = new List<string>
            {
                "101 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 200));
            affixes.Add(Tuple.Create(" Damage", 20, 40));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 45, 0));
            affixes.Add(Tuple.Create("Repairs 1 Durability Every 10 Seconds", 0, 0));
            affixes.Add(Tuple.Create("Sockets", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Kelpie Snare")]
        public async Task KelpieSnareImageAsync()
        {
            var name = "Kelpie Snare(33)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/razortine_weapons_diablo_2_resurrected_wiki_guide_201px.png";
            var requirements = new List<string>
            {
                "77 Strength",
                "25 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 140, 180));
            affixes.Add(Tuple.Create(" Damage", 30, 50));
            affixes.Add(Tuple.Create("% Slows Target", 75, 0));
            affixes.Add(Tuple.Create(" Life (Based on Character Level)", 1, 123));
            affixes.Add(Tuple.Create("% Fire Resist", 50, 0));
            affixes.Add(Tuple.Create(" Strength", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Soulfeast Tine")]
        public async Task SoulfeastTineImageAsync()
        {
            var name = "Soulfeast Tine(35)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/soulfeast_tine_weapons_diablo_2_resurrected_wiki_guide_196xp.png";
            var requirements = new List<string>
            {
                "64 Strength",
                "76 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 190));
            affixes.Add(Tuple.Create(" Attack Rating", 150, 250));
            affixes.Add(Tuple.Create("% Requirements", -20, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 7, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 7, 0));
            affixes.Add(Tuple.Create("% Slower Stamina Drain", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Spire of Honor")]
        public async Task SpireofHonorImageAsync()
        {
            var name = "Spire of Honor(39)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/pike_weapons_diablo-2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "110 Strenght",
                "88 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" Damage", 20, 40));
            affixes.Add(Tuple.Create("% Damage to Demons (Based on Character Level)", 1, 148));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create(" Replenish Life", 20, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 25, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 25, 0));
            affixes.Add(Tuple.Create(" Combat Skills (Paladin Only)", 3, 0));
            affixes.Add(Tuple.Create(" Light Radius", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Impaler")]
        public async Task TheImpalerImageAsync()
        {
            var name = "The Impaler(31)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/spear_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                "25 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 140, 170));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 40, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 150, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" Impale (Amazon Only)", 5, 0));
            affixes.Add(Tuple.Create(" Power Strike (Amazon Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Arioc's Needle")]
        public async Task AriocsNeedleImageAsync()
        {
            var name = "Arioc's Needle(81)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/spear_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "155 Strength",
                "120 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 230));
            affixes.Add(Tuple.Create("% Deadly Strike", 50, 0));
            affixes.Add(Tuple.Create("Poison Damage Over 10 Seconds", 394, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create(" All Skills", 2, 3));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Steel Pillar")]
        public async Task SteelPillarImageAsync()
        {
            var name = "Steel Pillar(69)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/pike_weapons_diablo-2_resurrected_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "165 Strength",
                "106 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 210, 260));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 25, 0));
            affixes.Add(Tuple.Create("% Target Defense", -20, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 25, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 50, 80));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Viperfork")]
        public async Task ViperforkImageAsync()
        {
            var name = "Viperfork(71)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/spetum_weapons_diablo_2_resurrected_wiki_guide_201px.png";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 190, 240));
            affixes.Add(Tuple.Create(" Attack Rating", 200, 250));
            affixes.Add(Tuple.Create(" Poison Damage Over 10 Seconds", 325, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 50, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 30, 50));
            affixes.Add(Tuple.Create("% Chance to Cast Level 9 Poison Explosion on Striking", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Stoneraven")]
        public async Task StoneravenImageAsync()
        {
            var name = "Stoneraven(64)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "114 Strength",
                "142 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 230, 280));
            affixes.Add(Tuple.Create(" Additional Magic Damage", 101, 187));
            affixes.Add(Tuple.Create(" To Defense", 400, 600));
            affixes.Add(Tuple.Create(" To All Resists", 30, 50));
            affixes.Add(Tuple.Create(" To Javelin and Spear Skills (Amazon Only)", 1, 3));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Lycander's Flank")]
        public async Task LycandersFlankImageAsync()
        {
            var name = "Lycander's Flank(64)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 190, 240));
            affixes.Add(Tuple.Create(" Additional Damage", 25, 50));
            affixes.Add(Tuple.Create(" To Amazon Skill Levels", 2, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 5, 9));
            affixes.Add(Tuple.Create(" To Strength", 20, 0));
            affixes.Add(Tuple.Create(" To Vitality", 20, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 20, 0));
            affixes.Add(Tuple.Create(" To Javelin and Spear Skills (Amazon Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }

        [Command("Bane Ash")]
        public async Task BaneAshImageAsync()
        {
            var name = "Bane Ash(5)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/short_staff_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 60));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create(" Mana", 30, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 50, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 4, 6));
            affixes.Add(Tuple.Create(" Fire Bolt (Sorceress Only)", 5, 0));
            affixes.Add(Tuple.Create(" Warmth (Sorceress Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Serpent Lord")]
        public async Task SerpentLordImageAsync()
        {
            var name = "Serpent Lord(9)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/long_staff_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 30, 40));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Poison Damage Over 3 Seconds",12 , 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 100, 0));
            affixes.Add(Tuple.Create("% Target Defense", -50, 0));
            affixes.Add(Tuple.Create(" Mana", 10, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 50, 0));
            affixes.Add(Tuple.Create(" Light Radius", -1, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Spire of Lazarus")]
        public async Task SpireofLazarusImageAsync()
        {
            var name = "Spire of Lazarus(18)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/lazarus_spire_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 28));
            affixes.Add(Tuple.Create(" Sorceress Skill Levels", 1, 0));
            affixes.Add(Tuple.Create(" Lightning (Sorceress Only)", 2, 0));
            affixes.Add(Tuple.Create(" Chain Lightning (Sorceress Only)", 1, 0));
            affixes.Add(Tuple.Create(" Static Field (Sorceress Only)", 3, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 43, 0));
            affixes.Add(Tuple.Create(" Energy", 15, 0));
            affixes.Add(Tuple.Create(" Damage Reduced", 5, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 75, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Salamander")]
        public async Task TheSalamanderImageAsync()
        {
            var name = "The Salamander(21)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/battle_staf_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 15, 32));
            affixes.Add(Tuple.Create("% Fire Resist", 30, 0));
            affixes.Add(Tuple.Create(" Fire Skills", 2, 0));
            affixes.Add(Tuple.Create(" Warmth (Sorceress Only)", 3, 0));
            affixes.Add(Tuple.Create(" Fire Ball (Sorceress Only)", 2, 0));
            affixes.Add(Tuple.Create(" Fire Wall (Sorceress Only)", 1, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Iron Jang Bong")]
        public async Task TheIronJangBongImageAsync()
        {
            var name = "The Iron Jang Bong(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_staf_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 0));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 50, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, 0));
            affixes.Add(Tuple.Create(" Sorceress Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" Frost Nova (Sorceress Only)", 3, 0));
            affixes.Add(Tuple.Create(" Blaze (Sorceress Only)", 2, 0));
            affixes.Add(Tuple.Create(" Nova (Sorceress Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Razorswitch")]
        public async Task RazorswitchImageAsync()
        {
            var name = "Razorswitch(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/short_staff_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 30, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 15, 0));
            affixes.Add(Tuple.Create(" All Resistances", 50, 0));
            affixes.Add(Tuple.Create(" Mana", 175, 0));
            affixes.Add(Tuple.Create(" Life", 80, 0));
            affixes.Add(Tuple.Create(" Damage Taken by Attackers", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Ribcracker")]
        public async Task RibcrackerImageAsync()
        {
            var name = "Ribcracker(31)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/long_staff_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 300));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Damage", 30, 65));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 50, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 50, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 100, 0));
            affixes.Add(Tuple.Create(" Defense", 100, 0));
            affixes.Add(Tuple.Create(" Dexterity", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Chromatic Ire")]
        public async Task ChromaticIreImageAsync()
        {
            var name = "Chromatic Ire(35)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/lazarus_spire_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, 0));
            affixes.Add(Tuple.Create(" Sorceress Skill Levels", 3, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Life", 20, 25));
            affixes.Add(Tuple.Create(" All Resistances", 20, 40));
            affixes.Add(Tuple.Create(" Lightning Damage Taken by Attackers", 20, 0));
            affixes.Add(Tuple.Create(" Cold Mastery (Sorceress Only)", 1, 0));
            affixes.Add(Tuple.Create(" Fire Mastery (Sorceress Only)", 1, 0));
            affixes.Add(Tuple.Create(" Lightning Mastery (Sorceress Only)", 1, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Warpspear")]
        public async Task WarpspearImageAsync()
        {
            var name = "Warpspear(39)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/battle_staf_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 250, 0));
            affixes.Add(Tuple.Create(" Sorceress Skill Levels", 3, 0));
            affixes.Add(Tuple.Create(" Energy Shield (Sorceress Only)", 3, 0));
            affixes.Add(Tuple.Create(" Telekinesis (Sorceress Only)", 3, 0));
            affixes.Add(Tuple.Create(" Teleport (Sorceress Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Skull Collector")]
        public async Task SkullCollectorImageAsync()
        {
            var name = "Skull Collector(41)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/skullcollector_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 20, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 20, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items (Character Level)", 1, 99));
            affixes.Add(Tuple.Create(" All Skills", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Ondal's Wisdom")]
        public async Task OndalsWisdomImageAsync()
        {
            var name = "Ondal's Wisdom(66)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/lazarus_spire_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "44 Strength",
                "37 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("  All Skills", 2, 4));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 45, 0));
            affixes.Add(Tuple.Create(" Defense", 450, 550));
            affixes.Add(Tuple.Create(" Energy", 40, 50));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 5, 8));
            affixes.Add(Tuple.Create("% to Experience Gained", 5, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Mang Song's Lesson")]
        public async Task MangSongsLessonImageAsync()
        {
            var name = "Mang Song's Lesson(82)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/skullcollector_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "34 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" All Skills", 5, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 30, 0));
            affixes.Add(Tuple.Create("% to Enemy Cold Resistance", -7, 15));
            affixes.Add(Tuple.Create("% to Enemy Fire Resistance", -7, 15));
            affixes.Add(Tuple.Create("% to Enemy Lightning Resistance", -7, 15));
            affixes.Add(Tuple.Create("% Regenerate Mana", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Deathbit")]
        public async Task DeathbitImageAsync()
        {
            var name = "Deathbit(44)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/throwing_knife_weapons_diablo_2_resurrected_wiki_guide196px1.png";
            var requirements = new List<string>
            {
                "25 Strength",
                "52 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 130, 180));
            affixes.Add(Tuple.Create("% Deadly Strike", 40, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 200, 450));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 7, 9));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 4, 6));
            affixes.Add(Tuple.Create("Replenishes 1 Quantity Every 4 Seconds", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Scalper")]
        public async Task TheScalperImageAsync()
        {
            var name = "The Scalper(57)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/throwing_axe_diablo_2_resurrected_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                "80 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 33, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 4, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 25, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 4, 6));
            affixes.Add(Tuple.Create("Replenishes 1 Quantity Every 3 Seconds", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Warshrike")]
        public async Task WarshrikeImageAsync()
        {
            var name = "Warshrike(75)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/warshrike_weapons_diablo_2_resurrected_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "45 Strength",
                "142 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 250));
            affixes.Add(Tuple.Create("% Deadly Strike", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Piercing Attack", 50, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 9 Nova on Striking", 25, 0));
            affixes.Add(Tuple.Create("Replenishes 1 Quantity Every 3 Seconds", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Gimmershred")]
        public async Task GimmershredImageAsync()
        {
            var name = "Gimmershred(70)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/throwing_axe_diablo_2_resurrected_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "88 Strength",
                "108 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 210));
            affixes.Add(Tuple.Create(" Fire Damage", 218, 483));
            affixes.Add(Tuple.Create(" Lightning Damage", 29, 501));
            affixes.Add(Tuple.Create(" Cold Damage", 176, 397));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("Increased Stack Size (60)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Lacerator")]
        public async Task LaceratorImageAsync()
        {
            var name = "Lacerator(68)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/balanced_axediablo_2_resurrected_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "96 Strength",
                "122 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 210));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 33, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("% Hit Causes Monster to Flee", 50, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 3 Amplify Damage on Striking", 33, 0));
            affixes.Add(Tuple.Create("Replenishes 1 Quantity Every 4 Seconds", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Torch of Iro")]
        public async Task TorchofIroImageAsync()
        {
            var name = "Torch of Iro(5)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/iros_torch_weapons_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 5, 9));
            affixes.Add(Tuple.Create(" Necromancer Skill Levels", 1, 0));
            affixes.Add(Tuple.Create(" Energy", 10, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 5, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 6, 0));
            affixes.Add(Tuple.Create(" Light Radius", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Maelstrom")]
        public async Task MaelstromImageAsync()
        {
            var name = "Maelstrom(14)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/yew_wand_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 9));
            affixes.Add(Tuple.Create(" Mana", 13, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 30, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 40, 0));
            affixes.Add(Tuple.Create(" Iron Maiden (Necromancer Only)", 1, 3));
            affixes.Add(Tuple.Create(" Amplify Damage (Necromancer Only)", 1, 3));
            affixes.Add(Tuple.Create(" Terror (Necromancer Only)", 1, 3));
            affixes.Add(Tuple.Create(" Corpse Explosion (Necromancer Only)", 1, 3));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Gravenspine")]
        public async Task GravenspineImageAsync()
        {
            var name = "Gravenspine(20)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gravenspine_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Necromancer Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" Cold Damage", 4, 8));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 5, 0));
            affixes.Add(Tuple.Create(" Mana", 25, 50));
            affixes.Add(Tuple.Create(" Dexterity", 10, 0));
            affixes.Add(Tuple.Create(" Strength", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Ume's Lament")]
        public async Task UmesLamentImageAsync()
        {
            var name = "Ume's Lament(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/grim_wand_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Necromancer Skill Levels", 2, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, 0));
            affixes.Add(Tuple.Create(" Mana", 40, 0));
            affixes.Add(Tuple.Create("% Hit Causes Monster to Flee", 50, 0));
            affixes.Add(Tuple.Create(" Decrepify (Necromancer Only)", 2, 0));
            affixes.Add(Tuple.Create(" Terror (Necromancer Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Suicide Branch")]
        public async Task SuicideBranchImageAsync()
        {
            var name = "Suicide Branch(33)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/wand_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 50, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 10, 0));
            affixes.Add(Tuple.Create(" All Resistances", 10, 0));
            affixes.Add(Tuple.Create(" Life", 40, 0));
            affixes.Add(Tuple.Create(" Damen taken by Attackers", 25, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Carin Shard")]
        public async Task CarinShardImageAsync()
        {
            var name = "Carin Shard(35)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/yew_wand_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 0, 0));
            affixes.Add(Tuple.Create(" Mana (Based on Character Level)", 1, 123));
            affixes.Add(Tuple.Create(" Life (Based on Character Level)", 1, 123));
            affixes.Add(Tuple.Create(" Necromancer Skill Levels", 1, 0));
            affixes.Add(Tuple.Create(" Summoning Skills (Necromancer Only)", 2, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 10, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create(" Replenish Life", 5, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Arm of King Leoric")]
        public async Task ArmofKingLeoricImageAsync()
        {
            var name = "Arm of King Leoric(36)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gravenspine_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 2 Bone Prison When Struck", 10, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 10 Bone Spirit When Struck", 5, 0));
            affixes.Add(Tuple.Create(" Mana", 1, 123));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 10, 0));
            affixes.Add(Tuple.Create(" Terror (Necromancer Only)", 2, 0));
            affixes.Add(Tuple.Create(" Raise Skeletal Mage (Necromancer Only)", 2, 0));
            affixes.Add(Tuple.Create(" Skeleton Mastery (Necromancer Only", 3, 0));
            affixes.Add(Tuple.Create(" Raise Skeleton (Necromancer Only)", 3, 0));
            affixes.Add(Tuple.Create(" Summoning Skills (Necromancer Only)", 2, 0));
            affixes.Add(Tuple.Create(" Poison and Bone Skills (Necromancer Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Blackhand Key")]
        public async Task BlackhandKeyImageAsync()
        {
            var name = "Blackhand Key(41)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/blackhand_key_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Necromancer Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" Curses (Necromancer Only)", 1, 0));
            affixes.Add(Tuple.Create("% Damage Taken Goes to Mana", 20, 0));
            affixes.Add(Tuple.Create(" Faster Cast Rate", 30, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 37, 0));
            affixes.Add(Tuple.Create(" Life", 50, 0));
            affixes.Add(Tuple.Create("Level 13 Grim Ward (30 Charges)", 0, 0));
            affixes.Add(Tuple.Create(" Light Radius", -2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Boneshade")]
        public async Task BoneshadeImageAsync()
        {
            var name = "Boneshade(79)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gravenspine_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Necromancer Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" Bone Spirit (Necromancer Only)", 1, 2));
            affixes.Add(Tuple.Create(" Bone Spear (Necromancer Only)", 2, 3));
            affixes.Add(Tuple.Create(" Bone Wall (Necromancer Only)", 2, 3));
            affixes.Add(Tuple.Create(" Bone Armor (Necromancer Only)", 4, 5));
            affixes.Add(Tuple.Create(" Teeth (Necromancer Only)", 4, 5));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 25, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Death's Web")]
        public async Task DeathsWebImageAsync()
        {
            var name = "Death's Web(66)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/grim_wand_diablo_2_wiki_guide_125px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% to Enemy Poison Resistance", -40, 50));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 7, 12));
            affixes.Add(Tuple.Create(" Life After Each Kill", 7, 12));
            affixes.Add(Tuple.Create(" All Skills", 2, 0));
            affixes.Add(Tuple.Create(" Poison and Bone Skills (Necromancer Only)", 1, 2));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Blood Crescent")]
        public async Task BloodCrescentImageAsync()
        {
            var name = "Blood Crescent(7)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/blood_crescent_weapons_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "21 Dexterity",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 60, 80));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 33, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 15, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 15, 0));
            affixes.Add(Tuple.Create(" All Resistances", 15, 0));
            affixes.Add(Tuple.Create(" Life", 15, 0));
            affixes.Add(Tuple.Create(" Light Radius", 4, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Culwen's Point")]
        public async Task CulwensPointImageAsync()
        {
            var name = "Culwen's Point";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_sword_weapons_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "71 Strength",
                "45 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 80));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Poison Length Reduced", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 60, 0));
 
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Gleamscythe")]
        public async Task GleamscytheImageAsync()
        {
            var name = "Gleamscythe(13)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gleamscythe_weapons_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "33 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 60, 100));
            affixes.Add(Tuple.Create(" Cold Damage", 3, 5));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create(" Defense", 20, 0));
            affixes.Add(Tuple.Create(" Mana", 30, 0));
            affixes.Add(Tuple.Create(" Light Radius", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Griswold's Edge")]
        public async Task GriswoldsEdgeImageAsync()
        {
            var name = "Griswold's Edge(17)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/griswold's_edge_sword_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "48 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 80, 120));
            affixes.Add(Tuple.Create(" Fire Damage", 10-12, 15-25));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 100, 0));
            affixes.Add(Tuple.Create(" Strength", 12, 0));
            affixes.Add(Tuple.Create("Knockback", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Hellplague")]
        public async Task HellplagueImageAsync()
        {
            var name = "Hellplague(22)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hellplague_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "55 Strength",
                "39 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 80));
            affixes.Add(Tuple.Create(" Fire Skills", 2, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 25, 75));
            affixes.Add(Tuple.Create(" Poison Damage Over 6 Seconds", 28, 56));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 5, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 5, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Rixot's Keen")]
        public async Task RixotsKeenImageAsync()
        {
            var name = "Rixot's Keen(2)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/short_sword_weapons_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 0));
            affixes.Add(Tuple.Create(" Minimum Damage", 5, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 25, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 20, 0));
            affixes.Add(Tuple.Create(" Defense", 25, 0));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Skewer of Krintiz")]
        public async Task SkewerofKrintizImageAsync()
        {
            var name = "Skewer of Krintiz(10)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/krintizs_skewer_swords_weapons_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                "25 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 0));
            affixes.Add(Tuple.Create(" Damage", 3, 7));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 7, 0));
            affixes.Add(Tuple.Create(" Dexterity", 10, 0));
            affixes.Add(Tuple.Create(" Strength", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Blacktongue")]
        public async Task BlacktongueImageAsync()
        {
            var name = "Blacktongue(26)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/blacktongue_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "62 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 60));
            affixes.Add(Tuple.Create(" Poison Damage Over 6 Seconds", 113, 0));
            affixes.Add(Tuple.Create(" Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 50, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 50, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Kinemil's Awl")]
        public async Task KinemilsAwlImageAsync()
        {
            var name = "Kinemil's Awl(23)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/kinemils_awl_weapons_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "56 Strength",
                "34 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 80, 100));
            affixes.Add(Tuple.Create(" Attack Rating", 100, 150));
            affixes.Add(Tuple.Create(" Fire Damage", 6, 20-40));
            affixes.Add(Tuple.Create(" Mana", 20, 0));
            affixes.Add(Tuple.Create(" Holy Fire (Paladin Only)", 6, 0));
 
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Ripsaw")]
        public async Task RipsawImageAsync()
        {
            var name = "Ripsaw(26)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/flamberge_weapons_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "70 Strength",
                "49 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 80, 100));
            affixes.Add(Tuple.Create(" Maximum Damage", 15, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 80, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 6, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Shadowfang")]
        public async Task ShadowfangImageAsync()
        {
            var name = "Shadowfang(12)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/shadowfang_weapons_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "35 Strength",
                "27 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 0));
            affixes.Add(Tuple.Create(" Cold Damage", 10, 30));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 9, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 9, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 20, 0));
            affixes.Add(Tuple.Create(" Light Radius", -2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Soulflay")]
        public async Task SoulflayImageAsync()
        {
            var name = "Soulflay(19)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/claymore_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "47 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 100));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 4, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 4, 10));
            affixes.Add(Tuple.Create(" All Resistances", 5, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Patriarch")]
        public async Task ThePatriarchImageAsync()
        {
            var name = "The Patriarch(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_patriarch_weapons_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "100 Strength",
                "60 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 120));
            affixes.Add(Tuple.Create("Hit Blinds Target", 0, 0));
            affixes.Add(Tuple.Create(" Strength", 10, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 100, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 3, 0));
            affixes.Add(Tuple.Create(" Damage Reduced", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Blade of Ali Baba")]
        public async Task BladeofAliBabaImageAsync()
        {
            var name = "Blade of Ali Baba(35)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/falchion_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "70 Strength",
                "42 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 60, 120));
            affixes.Add(Tuple.Create("% Exta Gold From Monsters (Based on Character Level)", 2, 247));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items (Based on Character Level)", 1, 99));
            affixes.Add(Tuple.Create(" Mana", 15, 0));
            affixes.Add(Tuple.Create(" Dexterity ", 5, 15));
            affixes.Add(Tuple.Create(" Sockets", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Bloodletter")]
        public async Task BloodletterImageAsync()
        {
            var name = "Bloodletter(30)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/short_sword_weapons_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 140, 0));
            affixes.Add(Tuple.Create(" Damage", 12, 45));
            affixes.Add(Tuple.Create(" Attack Rating", 90, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Slower Stamina Drain", 10, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 8, 0));
            affixes.Add(Tuple.Create(" Whirlwind (Barbarian Only)", 1, 3));
            affixes.Add(Tuple.Create(" Sword Mastery (Barbarian Only)", 2, 4));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Coldsteel Eye")]
        public async Task ColdsteelEyeImageAsync()
        {
            var name = "Coldsteel Eye(31)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/blood_crescent_weapons_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                "52 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 250));
            affixes.Add(Tuple.Create("% Chance of Deadly Strike", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 6, 0));
            affixes.Add(Tuple.Create("% Slows Target", 30, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target", 0, 0));
  
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Ginther's Rift")]
        public async Task GinthersRiftImageAsync()
        {
            var name = "Ginther's Rift(37)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ginthers_rift_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "85 Strength",
                "60 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 150));
            affixes.Add(Tuple.Create(" Magic Damage", 50, 120));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 7, 12));
            affixes.Add(Tuple.Create("Repairs 1 Durability Every 5 Seconds", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Headstriker")]
        public async Task HeadstrikerImageAsync()
        {
            var name = "Headstriker(39)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/broad_sword_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "92 Strength",
                "43 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 0));
            affixes.Add(Tuple.Create(" Maximum Damage (Based on Character Level)", 1, 99));
            affixes.Add(Tuple.Create("% Deadly Strike (Based on Character Level)", 1, 148));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" Strength", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Hexfire")]
        public async Task HexfireImageAsync()
        {
            var name = "Hexfire(33)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hexfire_sword_weapons_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "58 Strength",
                "58 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 140, 160));
            affixes.Add(Tuple.Create(" Damage", 35, 40));
            affixes.Add(Tuple.Create(" Fire Skills", 3, 0));
            affixes.Add(Tuple.Create("Level 6 Hydra (36 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 25, 0));
            affixes.Add(Tuple.Create("% to Maximum Fire Resist", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Plague Bearer")]
        public async Task PlagueBearerImageAsync()
        {
            var name = "Plague Bearer(41)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hellplague_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "103 Strength",
                "79 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 0));
            affixes.Add(Tuple.Create(" Damage", 10, 45));
            affixes.Add(Tuple.Create(" Poison Damage Over 8 Seconds", 300, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 4 Poison Nova on Striking", 5, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 45, 0));
            affixes.Add(Tuple.Create(" Rabies (Druid Only)", 5, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Atlantean")]
        public async Task TheAtlanteanImageAsync()
        {
            var name = "The Atlantean";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_sword_weapons_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "127 Strength",
                "88 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 250));
            affixes.Add(Tuple.Create(" Paladin Skill Levels", 2, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 50, 0));
            affixes.Add(Tuple.Create(" Defense", 75, 0));
            affixes.Add(Tuple.Create(" Vitality", 8, 0));
            affixes.Add(Tuple.Create(" Dexterity", 12, 0));
            affixes.Add(Tuple.Create(" Strength", 16, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Bing Sz Wang")]
        public async Task BingSzWangImageAsync()
        {
            var name = "Bing Sz Wang(43)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/claymore_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "64 Strength",
                "14 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 130, 160));
            affixes.Add(Tuple.Create(" Cold Damage", 50, 149));
            affixes.Add(Tuple.Create("% Chance to Cast Level 3 Frozen Orb on Striking", 5, 0));
            affixes.Add(Tuple.Create("Freezes Target +2", 0, 0));
            affixes.Add(Tuple.Create("% Requirements", -30, 0));
            affixes.Add(Tuple.Create(" Strength", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Cloudcrack")]
        public async Task CloudcrackImageAsync()
        {
            var name = "Cloudcrack(45)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/blacktongue_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "113 Strength",
                "20 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create("% Chance to Cast Level 7 Fist of the Heavens on Striking", 5, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 240));
            affixes.Add(Tuple.Create("% to Maximum Lightning Resist", 10, 0));
            affixes.Add(Tuple.Create(" Defense", 30, 0));
            affixes.Add(Tuple.Create(" Lightning Damage Taken by Attackers", 15, 0));
            affixes.Add(Tuple.Create(" Defensive Auras (Paladin Only)", 2, 0));
            affixes.Add(Tuple.Create(" Offensive Auras (Paladin Only)", 2, 0));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Crainte Vomir")]
        public async Task CrainteVomirImageAsync()
        {
            var name = "Crainte Vomir(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/shadowfang_weapons_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "73 Strength",
                "61 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 200));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 50, 0));
            affixes.Add(Tuple.Create("% Slows Target", 35, 0));
            affixes.Add(Tuple.Create(" To Monster Defense per Hit", -70, 0));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 20, 0));
            affixes.Add(Tuple.Create("% Damage Reduced", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Swordguard")]
        public async Task SwordguardImageAsync()
        {
            var name = "Swordguard(48)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_patriarch_weapons_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "85 Strength",
                "55 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 170, 180));
            affixes.Add(Tuple.Create(" Defense (Based on Character Level)", 5, 495));
            affixes.Add(Tuple.Create("% Damage Taken Goes to Mana", 30, 0));
            affixes.Add(Tuple.Create("% Requirements", -50, 0));
            affixes.Add(Tuple.Create(" All Resistances", 10, 20));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 20, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 100, 0));
            affixes.Add(Tuple.Create(" Defense vs. Melee", 200, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Vile Husk")]
        public async Task TheVileHuskImageAsync()
        {
            var name = "The Vile Husk(44)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/kinemils_awl_weapons_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "104 Strength",
                "71 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create("% Damage to Undead (Based on Character Level)", 7, 742));
            affixes.Add(Tuple.Create(" Attack Rating Against Undead (Based on Character Level)", 10, 990));
            affixes.Add(Tuple.Create(" Poison Damage Over 6 Seconds", 250, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 1 Amplify Damage on Striking", 6, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 50, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Todesfaelle Flamme")]
        public async Task TodesfaelleFlammeImageAsync()
        {
            var name = "Todesfaelle Flamme";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/todesfaelle_flamme_weapons_diablo_2_wiki_guide196_px.png";
            var requirements = new List<string>
            {
                "125 Strength",
                "94 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 120, 160));
            affixes.Add(Tuple.Create(" Fire Damage", 50, 200));
            affixes.Add(Tuple.Create("% Chance to Cast Level 6 Fire Ball on Attack", 10, 0));
            affixes.Add(Tuple.Create("Level 10 Fire Wall (20 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Level 10 Enchant (45 Charges)", 0, 0));
            affixes.Add(Tuple.Create(" Fire Absorb", 10, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 40, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Azurewrath")]
        public async Task AzurewrathImageAsync()
        {
            var name = "Azurewrath(85)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ginthers_rift_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                "136 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 230, 270));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create(" Magic Damage", 250, 500));
            affixes.Add(Tuple.Create(" Cold Damage", 250, 500));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create(" All Attributes", 5, 10));
            affixes.Add(Tuple.Create("Level 10-13 Sanctuary Aura When Equipped", 0, 0));
            affixes.Add(Tuple.Create(" Light Radius", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Bloodmoon")]
        public async Task BloodmoonImageAsync()
        {
            var name = "Bloodmoon(61)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hexfire_sword_weapons_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "109 Strength",
                "122 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 210, 260));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 10, 15));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 50, 0));
            affixes.Add(Tuple.Create("Life After Each Kill", 7, 13));
            affixes.Add(Tuple.Create("Level 15 Blood Golem (9 Charges)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Djinn Slayer")]
        public async Task DjinnSlayerImageAsync()
        {
            var name = "Djinn Slayer(65)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/blood_crescent_weapons_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "138 Strength",
                "95 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 190, 240));
            affixes.Add(Tuple.Create("% Damage to Demons", 100, 150));
            affixes.Add(Tuple.Create("Attack Rating Against Demons", 200, 300));
            affixes.Add(Tuple.Create(" Fire Damage", 250, 500));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 3, 6));
            affixes.Add(Tuple.Create(" Lightning Absorb", 3, 7));
            affixes.Add(Tuple.Create(" Sockets", 1, 2));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Frostwind")]
        public async Task FrostwindImageAsync()
        {
            var name = "Frostwind(70)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hellplague_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "99 Strength",
                "109 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 230));
            affixes.Add(Tuple.Create(" Cold Damage", 237, 486));
            affixes.Add(Tuple.Create(" Arctic Blast", 7, 14));
            affixes.Add(Tuple.Create("Freezes Target +4", 0, 0));
            affixes.Add(Tuple.Create("% Cold Absorb", 7, 15));
            affixes.Add(Tuple.Create("Half Freeze Duration", 0, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 25, 0));
  
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Lightsabre")]
        public async Task LightsabreImageAsync()
        {
            var name = "Lightsabre(58)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/lightsabre_diablo_2_wiki_guide196px.png";
            var requirements = new List<string>
            {
                "25 Strength",
                "136 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" Damage", 10, 30));
            affixes.Add(Tuple.Create(" Magic Damage", 60, 120));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 200));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 5, 7));
            affixes.Add(Tuple.Create("% Chance to Cast Level 14-20 Chain Lightning on Attack", 5, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("% Lightning Absorb", 25, 0));
            affixes.Add(Tuple.Create(" Light Radius", 7, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Doombringer")]
        public async Task DoombringerImageAsync()
        {
            var name = "Doombringer(69)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/blacktongue_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "163 Strength",
                "103 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 250));
            affixes.Add(Tuple.Create(" Damage", 30, 100));
            affixes.Add(Tuple.Create("% Chance to Cast Level 3 Weaken on Striking", 8, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 40, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Life", 20, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 5, 7));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Flamebellow")]
        public async Task FlamebellowImageAsync()
        {
            var name = "Flamebellow(71)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/kinemils_awl_weapons_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "185 Strength",
                "87 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 170, 240));
            affixes.Add(Tuple.Create(" Fire Damage", 233, 482));
            affixes.Add(Tuple.Create(" Fire Skills", 3, 0));
            affixes.Add(Tuple.Create(" Inferno", 12, 18));
            affixes.Add(Tuple.Create(" Strength", 10, 20));
            affixes.Add(Tuple.Create(" Vitality", 5, 10));
            affixes.Add(Tuple.Create("% Chance to Cast Level 16 Firestorm on Striking", 12, 0));
            affixes.Add(Tuple.Create("% Fire Absorb", 20, 30));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Grandfather")]
        public async Task TheGrandfatherImageAsync()
        {
            var name = "The Grandfather(81)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_patriarch_weapons_diablo_2_wiki_guide_196px.png";
            var requirements = new List<string>
            {
                "189 Strength",
                "110 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 250));
            affixes.Add(Tuple.Create(" Maximum Damage", 2, 247));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 50, 0));
            affixes.Add(Tuple.Create(" Life", 80, 0));
            affixes.Add(Tuple.Create(" All Attributes", 20, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));
  
            await CreateUniqueImage(affixes, name, requirements, imageLink);

        }
    }
}
