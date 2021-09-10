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
        
        [Command("Lenymo")]
        public async Task ImageAsync()
        {
            var name = "Lenymo(7)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Regenerate Mana", 30, 0));
            affixes.Add(Tuple.Create(" All Resistances", 5, 0));
            affixes.Add(Tuple.Create(" Mana", 15, 0));
            affixes.Add(Tuple.Create(" Light Radius", 1, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Snakecord")]
        public async Task ImageAsync()
        {
            var name = "Snakecord(12)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
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
        public async Task ImageAsync()
        {
            var name = "Nightsmoke(20)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Goldwrap";
            var imageLink = "";
            var requirements = new List<string>
            {
                "45 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Bladebuckle(29)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "60 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 80, 100));
            affixes.Add(Tuple.Create(" Defense", 30, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create(" Dexterity", 10, 0));
            affixes.Add(Tuple.Create(" Strength",5 , 0));
            affixes.Add(Tuple.Create(" Damage Reduced", 3, 0));
            affixes.Add(Tuple.Create(" Attacker Takes Damage of 8", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("String of Ears")]
        public async Task ImageAsync()
        {
            var name = "String of Ears(29)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "20 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Razortail(32)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "20 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Gloom's Trap(36)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "58 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 120, 150));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 5, ));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 15, ));
            affixes.Add(Tuple.Create("% Regenerate Mana", 15, ));
            affixes.Add(Tuple.Create(" Vitality", 15, ));
            affixes.Add(Tuple.Create(" Light Radius", -3, ));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Snowclash")]
        public async Task ImageAsync()
        {
            var name = "Snowclash(42)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "88 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Thundergod's Vigor(47)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "110 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Arachnid Mesh(80)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "50 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Nosferatu's Coil(51)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "50 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Slows Target ", 10, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 2, ));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 5, 7));
            affixes.Add(Tuple.Create(" Strength", 15, ));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, ));
            affixes.Add(Tuple.Create(" Light Radius", -3, ));
   
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Verdungo's Hearty Cord")]
        public async Task ImageAsync()
        {
            var name = "Verdungo's Hearty Cord(63)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "106 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 90, 140));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 10, ));
            affixes.Add(Tuple.Create(" Vitality", 30, 40));
            affixes.Add(Tuple.Create(" Replenish Life", 10, 13));
            affixes.Add(Tuple.Create(" Maximum Stamina", 100, 120));
            affixes.Add(Tuple.Create("% Damage Reduced", 10, 15));
 
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Hotspur")]
        public async Task ImageAsync()
        {
            var name = "Hotspur(5)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 10, 20));
            affixes.Add(Tuple.Create(" Defense", 6, ));
            affixes.Add(Tuple.Create("% Fire Resist", 45, ));
            affixes.Add(Tuple.Create("% to Maximum Fire Resist", 15, ));
            affixes.Add(Tuple.Create(" Fire Damage", 3, 6));
            affixes.Add(Tuple.Create(" Life", 15, ));
 
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Gorefoot")]
        public async Task ImageAsync()
        {
            var name = "Gorefoot(9)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "18 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Threads of Cthon(15)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "30 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 40));
            affixes.Add(Tuple.Create(" Defense", 12, ));
            affixes.Add(Tuple.Create("% Slower Stamina Drain", 50, ));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 30, ));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 50, ));
            affixes.Add(Tuple.Create(" Life", 10, ));
 
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Goblin Toe")]
        public async Task ImageAsync()
        {
            var name = "Goblin Toe(22)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "50 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Tearhaunch(29)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "70 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Infernostride(29)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "20 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Waterwalk(32)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "47 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 180, 210));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 20, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missil", 100, 0));
            affixes.Add(Tuple.Create(" Dexterity", 15, 0));
            affixes.Add(Tuple.Create("% to Maximum Fire Resist", 5, 0));
            affixes.Add(Tuple.Create("% Heal Stamina", 50, ));
            affixes.Add(Tuple.Create(" Maximum Stamina", 40, 0));
            affixes.Add(Tuple.Create(" Life", 45, 65));
 
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Silkweave")]
        public async Task ImageAsync()
        {
            var name = "Silkweave(36)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "65 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150 , 190));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 30, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 5, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 10, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 200, 0));
 
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("War Traveler")]
        public async Task ImageAsync()
        {
            var name = "War Traveler(42)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "95 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 190));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 25, 0));
            affixes.Add(Tuple.Create(" Vitality", 10, 0));
            affixes.Add(Tuple.Create(" Strength", 10, 0));
            affixes.Add(Tuple.Create(" Damage", 15, 25));
            affixes.Add(Tuple.Create("% Slower Stamina Drain", 40, ));
            affixes.Add(Tuple.Create(" Damage Taken by Attackers", 5, 10));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 30, 50));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Gore Rider")]
        public async Task ImageAsync()
        {
            var name = "Gore Rider(47)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "94 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Sandstorm Trek(64)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "91 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Marrowwalk(66)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "118 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Shadow Dancer(71)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "167 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 70, 100));
            affixes.Add(Tuple.Create(" Shadow Disciplines (Assassin Only)", 1, 2));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 30, ));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, ));
            affixes.Add(Tuple.Create("Dexterity", 15, 25));
            affixes.Add(Tuple.Create("% Requirements", -20, ));
  
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Rainbow Facet Cold")]
        public async Task ImageAsync()
        {
            var name = "Rainbow Facet Cold(49)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to Cast Level 43 Frost Nova When You Level Up", 100, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 37 Blizzard When You Die", 100, 0));
            affixes.Add(Tuple.Create(" Cold Damage", 24, 38));
            affixes.Add(Tuple.Create("% to Cold Skill Damage", 3, 5));
            affixes.Add(Tuple.Create("% to Enemy Cold Resistance", 3, 5));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Rainbow Facet Fire")]
        public async Task ImageAsync()
        {
            var name = "Rainbow Facet Fire(49)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to Cast Level 29 Blaze When You Level Up", 100, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 31 Meteor When You Die", 100, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 17, 45));
            affixes.Add(Tuple.Create("% to Fire Skill Damage", 3, 5));
            affixes.Add(Tuple.Create("% to Enemy Fire Resistance", 3, 5));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Rainbow Facet Light")]
        public async Task ImageAsync()
        {
            var name = "Rainbow Facet Light(49)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to Cast Level 41 Nova When You Level Up", 100, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 47 Chain Lightning When You Die", 100, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 74));
            affixes.Add(Tuple.Create("% to Lightning Skill Damage", 3, 5));
            affixes.Add(Tuple.Create("% to Enemy Lightning Resistance", 3, 5));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Rainbow Facet Poison")]
        public async Task ImageAsync()
        {
            var name = "Rainbow Facet Poison(49)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to Cast Level 23 Venom When You Level Up", 100, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 51 Poison Nova When You Die", 100, 0));
            affixes.Add(Tuple.Create("Poison Damage Over 2 Seconds", 37, ));
            affixes.Add(Tuple.Create("% to Poison Skill Damage", 3, 5));
            affixes.Add(Tuple.Create("% to Enemy Poison Resistance", 3, 5));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Kira's Guardian")]
        public async Task ImageAsync()
        {
            var name = "Kira's Guardian(77)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 50, 120));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create(" Cannot be Frozen", 0, 0));
            affixes.Add(Tuple.Create(" All Resistances ", 50, 70));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Griffon's Eye")]
        public async Task ImageAsync()
        {
            var name = "Griffon's Eye(76)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense ", 100, 200));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 25, ));
            affixes.Add(Tuple.Create("% to Enemy Lightning Resistance", 15, 20));
            affixes.Add(Tuple.Create("% to Lightning Skill Damage", 10, 15));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Hand of Broc")]
        public async Task ImageAsync()
        {
            var name = "The Hand of Broc(5)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
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
        public async Task ImageAsync()
        {
            var name = "Bloodfist(9)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
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
        public async Task ImageAsync()
        {
            var name = "Chance Guards(15)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Magefist(23)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "45 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Frostburn(29)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "60 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Venom Grip(29)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "20 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Gravepalm(32)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "20 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Ghoulhide(36)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "58 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Lava Gout(42)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "88 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Hellmouth(47)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "110 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Dracul's Grasp";
            var imageLink = "";
            var requirements = new List<string>
            {
                "50 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Soul Drainer(74)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "50 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Steelrend(70)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "185 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Defense", 170, 210));
            affixes.Add(Tuple.Create("% Enhanced Damage", 30, 60));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 10, ));
            affixes.Add(Tuple.Create(" Strength", 15, 20));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Biggin's Bonnet")]
        public async Task ImageAsync()
        {
            var name = "Tarnhelm(15)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "15 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 25, 50));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 75, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Coif of Glory")]
        public async Task ImageAsync()
        {
            var name = "Coif of Glory(14)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "26 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Duskdeep(17)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "41 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Howltusk(25)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "63 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "The Face of Horror(20)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "23 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Undead Crown(29)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "55 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 60));
            affixes.Add(Tuple.Create(" Defense", 40, 0));
            affixes.Add(Tuple.Create("% Damage to Undead",50 , 0));
            affixes.Add(Tuple.Create(" Attack Rating Against Undead", 50, 100));
            affixes.Add(Tuple.Create(" Half Freeze Duration", 0, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 5, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 50, 0));
            affixes.Add(Tuple.Create(" Skeleton Mastery (Necromancer Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Wormskull")]
        public async Task ImageAsync()
        {
            var name = "Wormskull(21)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Peasant Crown(28)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "20 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Rockstopper(31)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "43 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 160, 220));
            affixes.Add(Tuple.Create("% Damage Reduced", 10, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 20, 40));
            affixes.Add(Tuple.Create("% Fire Resist", 20, 40));
            affixes.Add(Tuple.Create("% Lightning Resist", 20, 40));
            affixes.Add(Tuple.Create(" Vitality", 15, ));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Stealskull")]
        public async Task ImageAsync()
        {
            var name = "Stealskull(35)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "59 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Darksight Helm(38)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "82 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Valkyrie Wing(44)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "115 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 200));
            affixes.Add(Tuple.Create(" Amazon Skill Levels", 1, 2));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 20, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 2, 4));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Blackthorn's Face")]
        public async Task ImageAsync()
        {
            var name = "Blackthorn's Face(41)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "55 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Crown of Thieves(49)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "103 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 160, 200));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 9, 12));
            affixes.Add(Tuple.Create("% Fire Resist", 33, ));
            affixes.Add(Tuple.Create(" Mana", 35, ));
            affixes.Add(Tuple.Create(" Life", 50, ));
            affixes.Add(Tuple.Create(" Dexterity", 25, ));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 80, 100));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Vampire Gaze")]
        public async Task ImageAsync()
        {
            var name = "Vampire Gaze";
            var imageLink = "";
            var requirements = new List<string>
            {
                "58 Strenght",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Harlequin Crest(62)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
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
        public async Task ImageAsync()
        {
            var name = "Steel Shade(62)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "109 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 100, 130));
            affixes.Add(Tuple.Create(" Replenish Life", 10, 18));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 4, 8));
            affixes.Add(Tuple.Create(" Fire Absorb", 5, 11));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Veil of Steel")]
        public async Task ImageAsync()
        {
            var name = "Veil of Steel(73)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "192 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 60, 0));
            affixes.Add(Tuple.Create(" Defense", 140, 0));
            affixes.Add(Tuple.Create(" All Resistances", 50, 0));
            affixes.Add(Tuple.Create(" Strength", 15, 0));
            affixes.Add(Tuple.Create(" Vitality", 15, 0));
            affixes.Add(Tuple.Create(" Light Radius", -4, ));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Nightwing's Veil")]
        public async Task ImageAsync()
        {
            var name = "Nightwing's Veil(67)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "96 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Andariel's Visage(83)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "102 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Crown of Ages(82)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "174 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Giant Skull(65)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "106 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Pelta Lunata(2)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "12 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Umbral Disk(9)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "22 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Stormguild(13)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "34 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Steelclash(17)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "47 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Swordback Hold(15)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "30 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Bverrit Keep(19)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "75 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Wall of the Eyeless(20)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 40));
            affixes.Add(Tuple.Create(" Defense", 10, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 5, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 3, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 20, 0));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Ward")]
        public async Task ImageAsync()
        {
            var name = "The Ward(26)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "60 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Visceratuant(28)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "38 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Moser's Blessed Circle(31)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "53 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Stormchaser(35)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "71 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Tiamat's Rebuke(38)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "91 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Lance Guard(35)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "65 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Gerke's Sanctuary(44)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "133 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Lidless Wall(41)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "58 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 80, 130));
            affixes.Add(Tuple.Create(" All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 10, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, ));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 3, 5));
            affixes.Add(Tuple.Create(" Energy", 10, 0));
            affixes.Add(Tuple.Create(" Light Radius", 1, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Radament's Sphere")]
        public async Task ImageAsync()
        {
            var name = "Radamanent's Sphere(50)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "110 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Blackoak Shield(61)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "100 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Stormshield(73)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "156 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Spike Thorn(70)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "118 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Medusa's Gaze(76)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "219 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 180));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 5, 9));
            affixes.Add(Tuple.Create(" Slows Target By 20%", 0, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 40, 80));
            affixes.Add(Tuple.Create("% Chance to Cast Level 7 Lower Resist When Struck", 10, ));
            affixes.Add(Tuple.Create("% Chance to Cast Level 44 Nova When You Die", 100, ));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Head Hunter's Glory")]
        public async Task ImageAsync()
        {
            var name = "Head Hunter's Glory(75)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "106 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Spirit Ward(68)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "185 Strength",
                ""
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
    }
}
