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
        
        [Command("Knell Striker")]
        public async Task ImageAsync()
        {
            var name = "Knell Striker(5)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Rusthandle(18)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Stormeye(30)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Zakarum's Hand(37)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "The Fetid Sprinkler(38)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Hand of Blessed Light(42)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Heaven's Light(61)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "The Redeemer(72)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Astreon's Iron Ward(66)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Bloodthief(17)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Lance of Yaggai(22)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Razortine(12)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "The Dragon Chang(8)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "The Tannr Gorerod(27)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Hone Sundan(37)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Kelpie Snare(33)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Soulfeast Tine(35)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Spire of Honor(39)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "The Impaler(31)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Arioc's Needle(81)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Steel Pillar(69)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Viperfork(71)";
            var imageLink = "";
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
        
        [Command("Bane Ash")]
        public async Task ImageAsync()
        {
            var name = "Bane Ash(5)";
            var imageLink = "";
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
            affixes.Add(Tuple.Create(" Fire Bolt (Sorceress Only, 5, 0));
            affixes.Add(Tuple.Create(" Warmth (Sorceress Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Serpent Lord")]
        public async Task ImageAsync()
        {
            var name = "Serpent Lord(9)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Spire of Lazarus(18)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "The Salamander(21)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "The Iron Jang Bong(28)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Razorswitch(28)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Ribcracker(31)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Chromatic Ire(35)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Warpspear(39)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Skull Collector(41)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Ondal's Wisdom(66)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Mang Song's Lesson(82)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Deathbit(44)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "The Scalper(57)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Warshrike(75)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Gimmershred(70)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Lacerator(68)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Maelstrom(14)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Gravenspine(20)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Ume's Lament(28)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Suicide Branch(33)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Carin Shard(35)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Arm of King Leoric(36)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Blackhand Key(41)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Boneshade(79)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Death's Web(66)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Blood Crescent(7)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Culwen's Point";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Gleamscythe(13)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Griswold's Edge(17)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Hellplague(22)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Rixot's Keen(2)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Skewer of Krintiz(10)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Blacktongue(26)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Kinemil's Awl(23)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Ripsaw(26)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Shadowfang(12)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Soulflay(19)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "The Patriarch(29)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Blade of Ali Baba(35)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Bloodletter(30)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Coldsteel Eye(31)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Ginther's Rift(37)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Headstriker(39)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Hexfire(33)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Plague Bearer(41)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "The Atlantean";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Bing Sz Wang(43)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Cloudcrack(45)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Crainte Vomir(42)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Swordguard(48)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "The Vile Husk(44)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Todesfaelle Flamme";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Azurewrath(85)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Bloodmoon(61)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Djinn Slayer(65)";
            var imageLink = "";
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
            affixes.Add(Tuple.Create("% Mana Stolen per Hit, 3, 6));
            affixes.Add(Tuple.Create(" Lightning Absorb", 3, 7));
            affixes.Add(Tuple.Create(" Sockets", 1, 2));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Frostwind")]
        public async Task ImageAsync()
        {
            var name = "Frostwind(70)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Lightsabre(58)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Doombringer(69)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Flamebellow(71)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "185 Strength",
                "87 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 170, 240));
            affixes.Add(Tuple.Create(" Fire Damage", 233, 482));
            affixes.Add(Tuple.Create(" Fire Skills", 3, ));
            affixes.Add(Tuple.Create(" Inferno", 12, 18));
            affixes.Add(Tuple.Create(" Strength", 10, 20));
            affixes.Add(Tuple.Create(" Vitality", 5, 10));
            affixes.Add(Tuple.Create("% Chance to Cast Level 16 Firestorm on Striking", 12, 0));
            affixes.Add(Tuple.Create("% Fire Absorb", 20, 30));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Grandfather")]
        public async Task ImageAsync()
        {
            var name = "The Grandfather(81)";
            var imageLink = "";
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
