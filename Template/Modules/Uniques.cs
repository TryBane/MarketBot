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

        [Command("Bul-Kathos' Sacred Charge")]
        [Alias("BKSC")]
        public async Task ImageAsync()
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
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Fire Damage", 3, 6));
            affixes.Add(Tuple.Create("% to Maximum Fire Resist", 10, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 50, 0));
            affixes.Add(Tuple.Create(" Light Radius", 3, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Eye of Etlich")]
        public async Task ImageAsync()
        {
            var name = "The Eye of Etlich(15)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" All Skills", 1, ));
            affixes.Add(Tuple.Create(" Light Radius", 1, 5));   
            affixes.Add(Tuple.Create(" Defense vs Missiles", 10, 40));                     
            affixes.Add(Tuple.Create("% Life Steal", 3, 7));
            affixes.Add(Tuple.Create(" Cold Damage", 1-2, 3-5));
            affixes.Add(Tuple.Create(" Seconds Cold Length", 2, 10));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Mahim-Oak Curio")]
        public async Task ImageAsync()
        {
            var name = "The Mahim-Oak Curio(25)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 10, ));
            affixes.Add(Tuple.Create("% Enhanced Defense", 10, 0));            
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 10, 0));
            affixes.Add(Tuple.Create("% All Resistance", 10, 0));
            affixes.Add(Tuple.Create(" All Attributes", 10, 0));
            

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Saracen's Chance")]
        public async Task ImageAsync()
        {
            var name = "Saracen's Chance(47)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance of Casting level 2 Iron Maiden When Struck", 10, 0));
            affixes.Add(Tuple.Create(" All Resistances", 15, 25));          
            affixes.Add(Tuple.Create(" All Attributes", 12, 0));
            
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Cat's Eye")]
        public async Task ImageAsync()
        {
            var name = "The Cat's Eye(50)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Faster Run/Walk", 30, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));           
            affixes.Add(Tuple.Create(" Defense vs. Missiles", 100, 0));
            affixes.Add(Tuple.Create(" Defense", 100, 0));
            affixes.Add(Tuple.Create(" Dexterity", 25, 0));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Crescent Moon")]
        public async Task ImageAsync()
        {
            var name = "Crescent Moon(50)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
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
        public async Task ImageAsync()
        {
            var name = "Atma's Scarab(60)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
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
        public async Task ImageAsync()
        {
            var name = "The Rising Sun(65)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
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
        public async Task ImageAsync()
        {
            var name = "Highlord's Wrath(65)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
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
        public async Task ImageAsync()
        {
            var name = "Mara's Kaleidoscope(67)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("All Skills", 2, ));
            affixes.Add(Tuple.Create("All Resistances", 20, 30));
            affixes.Add(Tuple.Create("All Attributes", 5, 0));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Seraph's Hymn")]
        public async Task ImageAsync()
        {
            var name = "Seraph's Hymn(65)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
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
        public async Task ImageAsync()
        {
            var name = "Metalgrid(81)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("Attack Rating", 400, 450));
            affixes.Add(Tuple.Create("Level 22 Iron Golem (11 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Level 12 Iron Maiden (20 Charges)", 0, 0));
            affixes.Add(Tuple.Create("All Resistances", 25, 35));
            affixes.Add(Tuple.Create("Defense", 300, 350));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Nagelring")]
        public async Task ImageAsync()
        {
            var name = "Nagelring(7)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("Attack Rating ", 50, 75));
            affixes.Add(Tuple.Create("Attacker Takes Damage of 3", 0, 0));
            affixes.Add(Tuple.Create("Magic Damage Reduced By 3", 0, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 15, 30));            
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Manald Heal")]
        public async Task ImageAsync()
        {
            var name = "Manald Heal(15)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 4, 7));
            affixes.Add(Tuple.Create(" Replenish Life", 5, 8));
            affixes.Add(Tuple.Create("% Mana Regeneration", 20, 0));
            affixes.Add(Tuple.Create(" Life", 20, 0));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Stone of Jordan")]
        public async Task ImageAsync()
        {
            var name = "Stone of Jordan(29)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 20, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 12));
            affixes.Add(Tuple.Create("Mana", 20, 0));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Dwarf Star")]
        public async Task ImageAsync()
        {
            var name = "Dwarf Start(45)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
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
        public async Task ImageAsync()
        {
            var name = "Raven Frost(45)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
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
        public async Task ImageAsync()
        {
            var name = "";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create(" Life (Based On Character Level)", 0, 49));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 3, 5));
            affixes.Add(Tuple.Create(" Maximum Stamina", 50, 0));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Carrion Wind")]
        public async Task ImageAsync()
        {
            var name = "Carrion Wind(60)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 10 Poison Nova When Struck", 10, ));
            affixes.Add(Tuple.Create("% Chance To Cast Level 13 Twister On Striking", 8, ));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 6, 9));
            affixes.Add(Tuple.Create(" Defense Vs. Missile", 100, 160));
            affixes.Add(Tuple.Create("% Poison Resistance", 55, 0));
            affixes.Add(Tuple.Create("% Damage Taken Goes To Mana", 10, 0));
            affixes.Add(Tuple.Create("Level 21 Poison Creeper (15 Charges)", 0, 0));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Nature's Peace")]
        public async Task ImageAsync()
        {
            var name = "Nature's Peace(69)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Slain Monsters Rest In Peace", 0, 0));
            affixes.Add(Tuple.Create(" Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("% Poison Resistance", 20, 30));
            affixes.Add(Tuple.Create(" Damage Reduced", 7, 11));
            affixes.Add(Tuple.Create("Level 5 Oak Sage (27 charges)", 0, 0));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Wisp Projector")]
        public async Task ImageAsync()
        {
            var name = "Wisp Projector(76)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
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
        public async Task ImageAsync()
        {
            var name = "Annihilus(70)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create(" All Attributes", 10, 20));
            affixes.Add(Tuple.Create(" All Resistances", 10, 20));
            affixes.Add(Tuple.Create("% To Experience Gained", 5, 10));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Gheed's Fortune")]
        public async Task ImageAsync()
        {
            var name = "Gheed's Fortune(62)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Extra Gold From Monsters ", 80, 160));
            affixes.Add(Tuple.Create("% Reduces All Vendor Prices ", 10, 15));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 20, 40));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Hellfire Torch")]
        public async Task ImageAsync()
        {
            var name = "Hellfire Torch(75)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
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
        public async Task ImageAsync()
        {
            var name = "Greyform";
            var imageLink = "";
            var requirements = new List<string>
            {
                "12 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Blinkbat's Form(12)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "12 Strength",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 25, 0));
            affixes.Add(Tuple.Create(" Defense VS. Missile", 50, 0));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 10, ));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 40, ));
            affixes.Add(Tuple.Create(" Fire Damage", 3, 6));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Centurion")]
        public async Task ImageAsync()
        {
            var name = "The centurion(14)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "20 Strength",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 30, ));
            affixes.Add(Tuple.Create(" Replenish life", 5, ));
            affixes.Add(Tuple.Create(" Attack Rating", 50, ));
            affixes.Add(Tuple.Create(" Mana", 15, ));
            affixes.Add(Tuple.Create(" Maximum Stamina", 15, ));
            affixes.Add(Tuple.Create(" Life", 15, ));
            affixes.Add(Tuple.Create("% Slower Stamina Drain", 25, ));
            affixes.Add(Tuple.Create(" Damage Reduced", 2, ));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Twitchthroe")]
        public async Task ImageAsync()
        {
            var name = "Twitchthroe(16)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "27 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Darkglow(14)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "36 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Hawkmail(15)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "44 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Venom Ward(20)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "30 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Sparking Mail(17)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "48 Strength",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 75, 85));
            affixes.Add(Tuple.Create("% Lightning Resist", 30, ));
            affixes.Add(Tuple.Create(" Attacker Takes Lightning Damage of 10-14", 0, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 20));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Iceblink")]
        public async Task ImageAsync()
        {
            var name = "Iceblink(22)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "51 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Heavenly Garb(29)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "41 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Boneflesh(26)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "65 Strength",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 100, 120));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 5, 0));
            affixes.Add(Tuple.Create("% Chance Of Open Wounds", 25, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 35, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Rockfleece")]
        public async Task ImageAsync()
        {
            var name = "Rockfleece(28)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "50 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Rattlecage(29)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "70 Strength",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 200, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 25, 0));
            affixes.Add(Tuple.Create("% Hit Causes Monster to Flee", 40, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 45, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Goldskin")]
        public async Task ImageAsync()
        {
            var name = "Goldskin(28)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "80 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Silks of the Victor(28)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "100 Strength",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 100, 120));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 5, 0));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Spirit Shroud")]
        public async Task ImageAsync()
        {
            var name = "The Spirit Shroud(28)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "38 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Skin of the Vipermagi(29)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "43 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Skin of the Flayed One(31)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "50 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Iron Pelt(33)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "61 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Spirit Forge(35)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "74 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Crow Caw(37)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "86 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Duriel's Shell(41)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "65 Strength",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 160, 200));
            affixes.Add(Tuple.Create(" Defense (Based of Character Level)", 1, 123));
            affixes.Add(Tuple.Create(" Life (Based of Character Level)", 1, 99));
            affixes.Add(Tuple.Create("% Fire Resist", 20, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 20, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 20, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 50, 0));
            affixes.Add(Tuple.Create(" Cannot Be Frozen", , 0));
            affixes.Add(Tuple.Create(" Strength", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Shaftstop")]
        public async Task ImageAsync()
        {
            var name = "Shaftstop(38)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "92 Strength",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 180, 220));
            affixes.Add(Tuple.Create("% Damage Reduced", 30, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 250, 0));
            affixes.Add(Tuple.Create(" Life", 60, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Skullder's Ire")]
        public async Task ImageAsync()
        {
            var name = "Skullder's Ire(42)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "97 Strength",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 160, 200));
            affixes.Add(Tuple.Create(" Repairs 1 Durability Every 5 Seconds", 0, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items (Based on Character Level) ", 1, 123));
            affixes.Add(Tuple.Create(" All Skills", 1, ));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Que-Hegan's Wisdom")]
        public async Task ImageAsync()
        {
            var name = "Que-Hegan's Wisdom(51)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "55 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Guardian Angel(45)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "118 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Toothrow(48)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "103 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Atma's Wail(51)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "125 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Black Hades(53)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "140 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Corpsemourn(55)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "170 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Ormus Robes(75)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "77 Strength",
                "0"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 10, 20));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, 0));
            affixes.Add(Tuple.Create("% To Cold Skill Damage", 0, 0));
            affixes.Add(Tuple.Create("% To Fire Skill Damage", 0, 0));
            affixes.Add(Tuple.Create("% To Lightning Skill Damage", 0, 0));
            affixes.Add(Tuple.Create(" to (Random Sorceress Skill) (Sorceress Only)", 3, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 10 , 15));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Gladiator's Bane")]
        public async Task ImageAsync()
        {
            var name = "The Gladiator's Bane(85)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "111 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Arkaine's Valor";
            var imageLink = "";
            var requirements = new List<string>
            {
                "165 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Leviathan(65)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "174 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Steel Carapace(66)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "230 Strength",
                "0"
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
        public async Task ImageAsync()
        {
            var name = "Templar's Might(74)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "232 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Tyreal's Might(84)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "0",
                "0"
            };
            
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
        
        }
    }
}
