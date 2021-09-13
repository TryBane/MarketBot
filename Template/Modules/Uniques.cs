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
        
        [Command("Lycander's Aim")]
        public async Task ImageAsync()
        {
            var name = "Lycander's Aim(42)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "73 Strength",
                "110 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" Damage", 25, 50));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create(" Amazon Skill Levels", 2, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 5, 8));
            affixes.Add(Tuple.Create(" Energy ", 20, 0));
            affixes.Add(Tuple.Create(" Dexterity", 20, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 20, 0));
            affixes.Add(Tuple.Create(" Bow and Crossbow Skills (Amazon Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Lycander's Flank")]
        public async Task ImageAsync()
        {
            var name = "Lycander's Flank(42)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "115 Strength",
                "98 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" Damage", 25, 50));
            affixes.Add(Tuple.Create(" Amazon Skill Levels", 2, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 5, 9));
            affixes.Add(Tuple.Create(" Strength", 20, 0));
            affixes.Add(Tuple.Create(" Vitality", 20, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 20, 0));
            affixes.Add(Tuple.Create(" Javelin and Spear Skills (Amazon Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Titan's Revenge")]
        public async Task ImageAsync()
        {
            var name = "Titan's Revenge(42)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "25 Strength",
                "109 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" Damage", 25, 50));
            affixes.Add(Tuple.Create(" Amazon Skill Levels", 2, 0));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 30, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 5, 9));
            affixes.Add(Tuple.Create(" Strength", 20, 0));
            affixes.Add(Tuple.Create(" Dexterity", 20, 0));
            affixes.Add(Tuple.Create("Replenishes 1 Quantity Every 3 Seconds", 0, 0));
            affixes.Add(Tuple.Create("Increased Stack Size (60)", 0, 0));
            affixes.Add(Tuple.Create("Javelin and Spear Skills (Amazon Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Blood Raven's Charge")]
        public async Task ImageAsync()
        {
            var name = "Blood Raven's Charge(71)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "87 Strength",
                "187 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 230));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 200, 300));
            affixes.Add(Tuple.Create("Fires Explosive Arrows (Level 13)", 0, 0));
            affixes.Add(Tuple.Create("Level 5 Revive (30 Charges)", 0, 0));
            affixes.Add(Tuple.Create(" Bow and Crossbow Skills (Amazon Only)", 2, 4));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Stoneraven")]
        public async Task ImageAsync()
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
            affixes.Add(Tuple.Create(" Magic Damage", 101, 187));
            affixes.Add(Tuple.Create(" Defense", 400, 600));
            affixes.Add(Tuple.Create(" All Resistances", 30, 50));
            affixes.Add(Tuple.Create(" Javelin and Spear Skills (Amazon Only)", 3, 6));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Thunderstroke")]
        public async Task ImageAsync()
        {
            var name = "Thunderstroke(69)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "107 Strength",
                "151 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 511));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 15, 0));
            affixes.Add(Tuple.Create("% to Enemy Lightning Resistance", -15, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 14 Lightning on Striking", 20, 0));
            affixes.Add(Tuple.Create(" Javelin and Spear Skills (Amazon Only)", 2, 4));
            affixes.Add(Tuple.Create(" Lightning Bolt (Amazon Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Bartuc's Cut-Throat")]
        public async Task ImageAsync()
        {
            var name = "Bartuc's Cut-Throat(42)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "79 Strength",
                "79 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" Damage", 25, 50));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 20, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 5, 9));
            affixes.Add(Tuple.Create(" Strength", 20, 0));
            affixes.Add(Tuple.Create(" Dexterity", 20, 0));
            affixes.Add(Tuple.Create(" Assassin Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" Martial Arts (Assassin Only)", 1, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Jade Talon")]
        public async Task ImageAsync()
        {
            var name = "Jade Talon(66)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "105 Strength",
                "105 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 190, 240));
            affixes.Add(Tuple.Create(" Martial Arts (varies) (Assassin Only)", 1, 2));
            affixes.Add(Tuple.Create(" Shadow Disciplines (varies) (Assassin Only)", 1, 2));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 10, 15));
            affixes.Add(Tuple.Create("All Resistances", 40, 50));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Shadow Killer")]
        public async Task ImageAsync()
        {
            var name = "Shadow Killer(78)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "100 Strength",
                "100 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 170, 220));
            affixes.Add(Tuple.Create("% Target Defense", -25, 0));
            affixes.Add(Tuple.Create("Freezes Target +2", 0, 0));
            affixes.Add(Tuple.Create("Mana After Each Kill", 10, 15));
            affixes.Add(Tuple.Create("% Chance to Cast Level 8 Frost Nova on Striking", 33, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));
            affixes.Add(Tuple.Create("Ethereal (Cannot be Repaired)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Firelizard's Talon")]
        public async Task ImageAsync()
        {
            var name = "Firelizard's Talon(67)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "113 Strength",
                "113 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 270));
            affixes.Add(Tuple.Create("Fire Damage", 236, 480));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 15, ));
            affixes.Add(Tuple.Create("Martial Arts (varies) (Assassin Only)", 1, 3));
            affixes.Add(Tuple.Create("Wake of Inferno (varies) (Assassin Only)", 1, 2));
            affixes.Add(Tuple.Create("Wake of Fire (varies) (Assassin Only)", 1, 2));
            affixes.Add(Tuple.Create("% Fire Resist", 40, 70));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Arreat's Face")]
        public async Task ImageAsync()
        {
            var name = "Arreat's Face(42)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "118 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 200));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 20, 0));
            affixes.Add(Tuple.Create(" Barbarian Skill Levels", 2, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 3, 6));
            affixes.Add(Tuple.Create(" All Resistances", 30, 0));
            affixes.Add(Tuple.Create(" Strength", 20, 0));
            affixes.Add(Tuple.Create(" Dexterity", 20, 0));
            affixes.Add(Tuple.Create(" Combat Skills (Barbarian Only", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Wolfhowl")]
        public async Task ImageAsync()
        {
            var name = "Wolfhowl(79)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "129 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 120, 150));
            affixes.Add(Tuple.Create(" Warcries (varies) (Barbarian Only)", 2, 3));
            affixes.Add(Tuple.Create(" Feral Rage", 3, 6));
            affixes.Add(Tuple.Create(" Lycanthropy", 3, 6));
            affixes.Add(Tuple.Create(" Werewolf", 3, 6));
            affixes.Add(Tuple.Create(" Strength", 8, 15));
            affixes.Add(Tuple.Create(" Dexterity", 8, 15));
            affixes.Add(Tuple.Create(" Vitality", 8, 15));
            affixes.Add(Tuple.Create("Level 15 Summon Dire Wolf (18 Charges)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Demonhorn's Edge")]
        public async Task ImageAsync()
        {
            var name = "Demonhorn's Edge(61)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "151 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 120, 160));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 3, 6));
            affixes.Add(Tuple.Create(" Damage Taken by Attackers", 55, 77));
            affixes.Add(Tuple.Create(" Warcries (varies) (Barbarian Only)", 1, 3));
            affixes.Add(Tuple.Create(" Masteries (varies) (Barbarian Only)", 1, 3));
            affixes.Add(Tuple.Create(" Combat Skills (varies) (Barbarian Only)", 1, 3));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Halaberd's Reign")]
        public async Task ImageAsync()
        {
            var name = "Halaberd's Reign(77)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "174 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 140, 170));
            affixes.Add(Tuple.Create(" Replenish Life", 15, 23));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create(" Barbarian Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" Masteries (Barbarian Only)", 1, 0));
            affixes.Add(Tuple.Create(" Battle Command (varies) (Barbarian Only)", 1, 2));
            affixes.Add(Tuple.Create(" Battle Orders (varies) (Barbarian Only)", 1, 2));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Jalal's Mane")]
        public async Task ImageAsync()
        {
            var name = "Jalal's Mane(42)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "65 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 200));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create("% Bonus To Attack Rating", 20, 0));
            affixes.Add(Tuple.Create(" Druid Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" All Resistances", 30, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 5, 0));
            affixes.Add(Tuple.Create(" Strength", 20, 0));
            affixes.Add(Tuple.Create(" Energy", 20, 0));
            affixes.Add(Tuple.Create(" Shape Shifting Skills (Druid Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Cerebus Bite")]
        public async Task ImageAsync()
        {
            var name = "Cerebus Bite(63)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "86 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 130, 140));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 60, 120));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 7, 10));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 33, 0));
            affixes.Add(Tuple.Create(" Shape Shifting Skills (Druid Only)", 2, 4));
            affixes.Add(Tuple.Create(" Feral Rage (Druid Only)", 1, 2));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Spirit Keeper")]
        public async Task ImageAsync()
        {
            var name = "Spirit Keeper(67)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "104 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 170, 190));
            affixes.Add(Tuple.Create(" Druid Skill Levels", 1, 2));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create("% To Maximum Poison Resist", 10, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 30, 40));
            affixes.Add(Tuple.Create(" Lightning Absorb", 9, 14));
            affixes.Add(Tuple.Create("% Cold Absorb ", 15, 25));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Ravenlore")]
        public async Task ImageAsync()
        {
            var name = "Ravenlore(74)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "74 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 120, 150));
            affixes.Add(Tuple.Create(" Raven (Druid Only)", 7, 0));
            affixes.Add(Tuple.Create(" Elemental Skills (Druid Only)", 3, 0));
            affixes.Add(Tuple.Create(" Energy", 20, 30));
            affixes.Add(Tuple.Create("% To Enemy Fire Resistance", -10, 20));
            affixes.Add(Tuple.Create(" All Resistances", 15, 25));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Homunculus")]
        public async Task ImageAsync()
        {
            var name = "Homunculus(42)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "58 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 200));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 5, 0));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 40, 0));
            affixes.Add(Tuple.Create("% Faster Block Rate", 30, 0));
            affixes.Add(Tuple.Create(" Necromancer Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" Energy", 20, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 33, 0));
            affixes.Add(Tuple.Create(" All Resistances", 40, 0));
            affixes.Add(Tuple.Create(" Curses (Necromancer Only", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Boneflame")]
        public async Task ImageAsync()
        {
            var name = "Boneflame(72)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "95 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 120, 150));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 20, 0));
            affixes.Add(Tuple.Create(" Necromancer Skill Levels", 2, 3));
            affixes.Add(Tuple.Create(" All Resistances", 20, 30));
            affixes.Add(Tuple.Create("% Chance To Cast Level 3 Terror When Struck", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Darkforce Spawn")]
        public async Task ImageAsync()
        {
            var name = "Darkforce Spawn(65)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "106 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 140, 180));
            affixes.Add(Tuple.Create(" Summoning Skills (Necromancer Only)", 1, 3));
            affixes.Add(Tuple.Create(" Poison And Bone Skills (Necromancer Only)", 1, 3));
            affixes.Add(Tuple.Create(" Curses (Necromancer Only)", 1, 3));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 30, 0));
            affixes.Add(Tuple.Create("$ Increase Maximum Mana", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Herald of Zakarum")]
        public async Task ImageAsync()
        {
            var name = "Herald of Zakarum(42)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "89 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 200));
            affixes.Add(Tuple.Create("% Increased Chance Of Blocking", 30, 0));
            affixes.Add(Tuple.Create("% Faster Block Rate", 30, 0));
            affixes.Add(Tuple.Create("% Bonus To Attack Rating", 20, 0));
            affixes.Add(Tuple.Create(" Strength", 20, 0));
            affixes.Add(Tuple.Create(" Vitality", 20, 0));
            affixes.Add(Tuple.Create(" All Resistances", 50, 0));
            affixes.Add(Tuple.Create(" Paladin Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" Combat Skills (Paladin Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Alma Negra")]
        public async Task ImageAsync()
        {
            var name = "Alma Negra(77)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "109 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 180, 210));
            affixes.Add(Tuple.Create(" Paladin Skill Levels", 1, 2));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 20, 0));
            affixes.Add(Tuple.Create("% Faster Block Rate", 30, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 40, 75));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 40, 75));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 5, 9));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Dragonscale")]
        public async Task ImageAsync()
        {
            var name = "Dragonscale(80)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "80 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 170, 200));
            affixes.Add(Tuple.Create(" Fire Damage", 211, 371));
            affixes.Add(Tuple.Create(" % To Fire Skill Damage", 15, 0));
            affixes.Add(Tuple.Create(" To Hydra", 10, 0));
            affixes.Add(Tuple.Create(" Strength", 15, 25));
            affixes.Add(Tuple.Create("% Fire Absorb", 10, 20));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Oculus")]
        public async Task ImageAsync()
        {
            var name = "The Oculus(42)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Sorceress Skill Levels", 3, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 5, 0));
            affixes.Add(Tuple.Create(" All Resistances", 20, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 1 Teleport When Struck", 25, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 30, 0));
            affixes.Add(Tuple.Create(" Vitality", 20, 0));
            affixes.Add(Tuple.Create(" Energy", 20, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 20, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 50, 0));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Eschuta's Temper")]
        public async Task ImageAsync()
        {
            var name = "Eschuta's Temper(72)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Sorceress Skill Levels", 1, 3));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 40, 0));
            affixes.Add(Tuple.Create("% to Fire Skill Damage", 10, 20));
            affixes.Add(Tuple.Create("% to Lightning Skill Damage", 10, 20));
            affixes.Add(Tuple.Create(" Energy", 20, 30));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Death's Fathom")]
        public async Task ImageAsync()
        {
            var name = "Death's Fathom(73)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Sorceress Skill Levels", 3, ));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, ));
            affixes.Add(Tuple.Create("% to Cold Skill Damage", 15, 30));
            affixes.Add(Tuple.Create("% Lightning Resist", 25, 40));
            affixes.Add(Tuple.Create("% Fire Resist", 25, 40));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }            
    }
}
