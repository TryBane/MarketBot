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
        
        [Command("Doomslinger")]
        public async Task ImageAsync()
        {
            var name = "Hellcast(27)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "40 Strength",
                "50 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 60, 100));
            affixes.Add(Tuple.Create("% Piercing Attack", 35, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create(" Amazon Skill Levels", 1, 0));
            affixes.Add(Tuple.Create(" Life", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Hellcast")]
        public async Task ImageAsync()
        {
            var name = "Hellcast(27)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "60 Strength",
                "40 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 80));
            affixes.Add(Tuple.Create("Fires Explosive Bolts (Level 5)", 0, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 15, 35));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 70, 0));
            affixes.Add(Tuple.Create("% to Maximum Fire Resist", 15, 0));
            affixes.Add(Tuple.Create("% Fire Resist ", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Ichorstring")]
        public async Task ImageAsync()
        {
            var name = "Ichorstring(18)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "40 Strength",
                "33 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 0));
            affixes.Add(Tuple.Create("Poison Damage Over 3 Seconds", 30, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Piercing Attack", 50, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 50, 0));
            affixes.Add(Tuple.Create(" Dexterity", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Leadcrow")]
        public async Task ImageAsync()
        {
            var name = "Leadcrow(9)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "21 Strength",
                "27 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 25, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 40, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 30, 0));
            affixes.Add(Tuple.Create(" Life", 10, 0));
            affixes.Add(Tuple.Create(" Dexterity", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Buriza-Do Kyanon")]
        public async Task ImageAsync()
        {
            var name = "Buriza-Do Kyanon(41)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "110 Strength",
                "80 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create(" Maximum Damage (Based on Character Level)", 2, 247));
            affixes.Add(Tuple.Create(" Cold Damage", 32, 196));
            affixes.Add(Tuple.Create("% Piercing Attack", 100, -));
            affixes.Add(Tuple.Create("Freezes Target +3", -, -));
            affixes.Add(Tuple.Create(" Defense", 75, 150));
            affixes.Add(Tuple.Create(" Dexterity", 35, -));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 80, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Demon Machine")]
        public async Task ImageAsync()
        {
            var name = "Demon Machine(49)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "80 Strength",
                "95 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 123, 0));
            affixes.Add(Tuple.Create(" Maximum Damage", 66, 0));
            affixes.Add(Tuple.Create("Fires Explosive Bolts (Level 6)", 0, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 632, 0));
            affixes.Add(Tuple.Create("% Piercing Attack", 66, 0));
            affixes.Add(Tuple.Create(" Defense", 321, 0));
            affixes.Add(Tuple.Create(" Mana", 36, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Langer Briser")]
        public async Task ImageAsync()
        {
            var name = "Langer Briser(33)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "52 Strength",
                "61 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 170, 200));
            affixes.Add(Tuple.Create(" Maximum Damage", 10, 30));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 33, ));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 212));
            affixes.Add(Tuple.Create(" Life", 30, ));
            affixes.Add(Tuple.Create("Knockback", , ));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 30, 60));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Pus Spitter")]
        public async Task ImageAsync()
        {
            var name = "Pus Spitter(36)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "32 Strength",
                "28 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 220));
            affixes.Add(Tuple.Create(" Poison Damage Over 8 Seconds", 150, 0));
            affixes.Add(Tuple.Create("% Requirements", -60, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 6 Poison Nova When Struck", 9, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 1 Lower Resist on Striking", 4, 0));
            affixes.Add(Tuple.Create(" Attack Rating (Based on Character Level)", 5, 495));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create(" Necromancer Skill Levels", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Gut Siphon")]
        public async Task ImageAsync()
        {
            var name = "Gut Siphon(71)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "141 Strength",
                "98 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 220));
            affixes.Add(Tuple.Create("% Piercing Attack", 33, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 12, 18));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 33, 0));
            affixes.Add(Tuple.Create("% Slows Target", 25, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Hellrack")]
        public async Task ImageAsync()
        {
            var name = "Hellrack(76)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "163 Strength",
                "77 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 230));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 100, 150));
            affixes.Add(Tuple.Create(" Fire Damage", 63, 324));
            affixes.Add(Tuple.Create(" Lightning Damage", 63, 324));
            affixes.Add(Tuple.Create(" Cold Damage", 63, 324));
            affixes.Add(Tuple.Create(" % Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("Level 18 Immolation Arrow (150 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Sockets", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Gull")]
        public async Task ImageAsync()
        {
            var name = "Gull(4)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Damage", 1, 15));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 100, ));
            affixes.Add(Tuple.Create(" Mana", -5, ));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Spectral Shard")]
        public async Task ImageAsync()
        {
            var name = "Spectral Shard(25)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "35 Strength",
                "51 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Faster Cast Rate", 50, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 55, 0));
            affixes.Add(Tuple.Create(" All Resistances", 10, 0));
            affixes.Add(Tuple.Create(" Mana", 50, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Diggler")]
        public async Task ImageAsync()
        {
            var name = "The Diggler(11)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "25 Dexterity",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 0));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 25, ));
            affixes.Add(Tuple.Create("% Fire Resist", 25, ));
            affixes.Add(Tuple.Create(" Dexterity", 10, ));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Jade Tan Do")]
        public async Task ImageAsync()
        {
            var name = "The Jade Tan Do";
            var imageLink = "";
            var requirements = new List<string>
            {
                "45 Dexterity",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Attack Rating", 100, 150));
            affixes.Add(Tuple.Create(" Poison Damage Over 4 Seconds", 180, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 95, 0));
            affixes.Add(Tuple.Create("% to Maximum Poison Resist", 20, 0));
            affixes.Add(Tuple.Create("Cannot be Frozen", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Blackbog's Sharp")]
        public async Task ImageAsync()
        {
            var name = "Blackbog's Sharp(38)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "25 Strength",
                "88 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Poison Damage Over 10 Seconds", 488, 0));
            affixes.Add(Tuple.Create(" Damage", 15, 45));
            affixes.Add(Tuple.Create("% Increased Attack Speed, 30, 0));
            affixes.Add(Tuple.Create("% Slow Target", 50, 0));
            affixes.Add(Tuple.Create(" Defense", 50, 0));
            affixes.Add(Tuple.Create(" Poison Nova (Necromancer Only)", 4, 0));
            affixes.Add(Tuple.Create(" Poison Explosion (Necromancer Only)", 4, 0));
            affixes.Add(Tuple.Create(" Poison Dagger (Necromancer Only)", 5, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Heart Carver")]
        public async Task ImageAsync()
        {
            var name = "Heart Carver(36)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "25 Strength",
                "58 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 190, 240));
            affixes.Add(Tuple.Create(" Damage", 15, 35));
            affixes.Add(Tuple.Create("% Deadly Strike", 35, 0));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create(" Grim Ward (Barbarian Only)", 4, 0));
            affixes.Add(Tuple.Create(" Find Item (Barbarian Only)", 4, 0));
            affixes.Add(Tuple.Create(" Find Potion (Barbarian Only)", 4, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Spineripper")]
        public async Task ImageAsync()
        {
            var name = "Spineripper(32)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 240));
            affixes.Add(Tuple.Create(" Damage", 15, 27));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 15, 0));
            affixes.Add(Tuple.Create(" Necromancer Skill Levels", 1, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 8, 0));
            affixes.Add(Tuple.Create(" Dexterity", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Stormspike")]
        public async Task ImageAsync()
        {
            var name = "Stormspike(41)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "47 Strength",
                "97 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 120));
            affixes.Add(Tuple.Create("% Chance to Cast Level 3 Charged Bolt When Struck", 25, 0));
            affixes.Add(Tuple.Create("% Lightning Resist (Based on Character Level)", 1, 99));
            affixes.Add(Tuple.Create(" Lightning Damage Taken by Attackers", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Fleshripper")]
        public async Task ImageAsync()
        {
            var name = "Fleshripper(68)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "42 Strength",
                "86 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 300));
            affixes.Add(Tuple.Create("% Target Defense", -50, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 25, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 33, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 50, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("% Slow Target", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Ghostflame")]
        public async Task ImageAsync()
        {
            var name = "Ghostflame(66)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "55 Strength",
                "57 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 190, 240));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create(" Magic Damage", 108, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 10, 15));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));
            affixes.Add(Tuple.Create("Ethereal (Cannot be Repaired)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Wizardspike")]
        public async Task ImageAsync()
        {
            var name = "Wizardspike(61)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "38 Strength",
                "75 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Mana", 2, 198));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 50, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 15, 0));
            affixes.Add(Tuple.Create("% Increased Maximum Mana", 15, 0));
            affixes.Add(Tuple.Create(" All Resistances", 75, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Demon's Arch")]
        public async Task ImageAsync()
        {
            var name = "Demon's Arch(68)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "127 Strength",
                "95 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 210));
            affixes.Add(Tuple.Create(" Fire Damage", 232, 323));
            affixes.Add(Tuple.Create(" Lightning Damage", 23, 333));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 6, 12));
            affixes.Add(Tuple.Create("Replenishes 1 Quantity Every 3 Seconds", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Wraith Flight")]
        public async Task ImageAsync()
        {
            var name = "Wraith Flight(76)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "79 Strength",
                "127 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 190));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 9, 13));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 15, 0));
            affixes.Add(Tuple.Create("Replenishes 1 Quantity Every 2 Seconds", 0, 0));
            affixes.Add(Tuple.Create("Ethereal (Cannot be Repaired)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Gargoyle's Bite")]
        public async Task ImageAsync()
        {
            var name = "Gargoyle's Bite(70)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "70 Strength",
                "145 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 230));
            affixes.Add(Tuple.Create(" Poison Damage Over 10 Seconds", 293, 0));
            affixes.Add(Tuple.Create("Level 11 Plague Javelin (60 Charges)", 0, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 9, 15));
            affixes.Add(Tuple.Create("Replenishes 1 Quantity Every 3 Seconds", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Bloodrise")]
        public async Task ImageAsync()
        {
            var name = "Bloodrise(15)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "36 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 120, 0));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 25, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 5, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 50, 0));
            affixes.Add(Tuple.Create(" Sacrifice (Paladin Only)", 3, 0));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Bonesnap")]
        public async Task ImageAsync()
        {
            var name = "Bonesnap(24)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "69 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 300));
            affixes.Add(Tuple.Create("% Damage to Undead", 100, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 40, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 30, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 30, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Crushflange")]
        public async Task ImageAsync()
        {
            var name = "Crushflange(9)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "27 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 60));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 33, 0));
            affixes.Add(Tuple.Create("Knockback", 0, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 50, 0));
            affixes.Add(Tuple.Create(" Strength", 15, 0));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Felloak")]
        public async Task ImageAsync()
        {
            var name = "Felloak(3)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 80));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 6, 8));
            affixes.Add(Tuple.Create("Knockback", 0, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 60, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 20, 0));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Ironstone")]
        public async Task ImageAsync()
        {
            var name = "Ironstone(27)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "53 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 150));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, ));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 10));
            affixes.Add(Tuple.Create(" Attack Rating", 100, 150));
            affixes.Add(Tuple.Create(" Strength", 10, ));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Steeldriver")]
        public async Task ImageAsync()
        {
            var name = "Steeldriver(29)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "50 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 250));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 40, 0));
            affixes.Add(Tuple.Create("% Requirements", -50, 0));
            affixes.Add(Tuple.Create("% Heal Stamina", 25, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Stoutnail")]
        public async Task ImageAsync()
        {
            var name = "Stoutnail(5)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 0));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Vitality", 7, 0));
            affixes.Add(Tuple.Create("Damage Taken by Attacker", 3, 10));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The General's Tan Do Li Ga")]
        public async Task ImageAsync()
        {
            var name = "The General's Tan Do Li Ga(21)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "41 Strength",
                "35 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 60));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Damage", 1, 20));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 5, 0));
            affixes.Add(Tuple.Create("% Slows Target", 50, 0));
            affixes.Add(Tuple.Create(" Defense", 25, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Baezil's Vortex")]
        public async Task ImageAsync()
        {
            var name = "Baezil's Vortex(45)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "82 Strength",
                "73 Strength"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 200));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("Lightning Damage", 1, 150));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 8 Nova on Striking", 5, 0));
            affixes.Add(Tuple.Create("Level 15 Nova (80 Charges)", 0, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 25, 0));
            affixes.Add(Tuple.Create(" Mana", 100, ));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Bloodtree Stump")]
        public async Task ImageAsync()
        {
            var name = "Bloodtree Stump(48)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "124 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 220));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 50, 0));
            affixes.Add(Tuple.Create(" All Resistances", 20, 0));
            affixes.Add(Tuple.Create(" Strength", 25, 0));
            affixes.Add(Tuple.Create(" Masteries (Barbarian Only)", 2, 0));
            affixes.Add(Tuple.Create(" Mace Mastery (Barbarian Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Dark Clan Crusher")]
        public async Task ImageAsync()
        {
            var name = "Dark Clan Crusher(34)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 195, 0));
            affixes.Add(Tuple.Create("% Damage to Demons", 200, 0));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Attack Rating Against Demons", 200, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 20, 25));
            affixes.Add(Tuple.Create(" Life After Each Demon Kill", 15, 0));
            affixes.Add(Tuple.Create(" Druid Skill Levels", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Earthshaker")]
        public async Task ImageAsync()
        {
            var name = "Earthshaker(43)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "100 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 0));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 7 Fissure on Striking", 5, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target", 0, 0));
            affixes.Add(Tuple.Create("Knockback", 0, 0));
            affixes.Add(Tuple.Create(" Elemental Skills (Druid Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Fleshrender")]
        public async Task ImageAsync()
        {
            var name = "Fleshrender(38)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "30 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 130, 200));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Damage", 35, 50));
            affixes.Add(Tuple.Create("% Deadly Strike", 20, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 20, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 25, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("Druid Skill Levels", 1, 0));
            affixes.Add(Tuple.Create(" Shapeshifting Skills (Druid Only)", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Moonfall")]
        public async Task ImageAsync()
        {
            var name = "Moonfall(41)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "74 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 120, 150));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Damage", 10, 15));
            affixes.Add(Tuple.Create(" Fire Damage", 55, 115));
            affixes.Add(Tuple.Create("% Chance to Cast Level 6 Meteor on Striking", 5, 0));
            affixes.Add(Tuple.Create("Level 11 Meteor (60 Charges)", 0, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced", 9, 12));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Sureshrill Frost")]
        public async Task ImageAsync()
        {
            var name = "Sureshrill Frost(39)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "61 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 180));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Damage", 5, 10));
            affixes.Add(Tuple.Create(" Cold Damage", 63, 112));
            affixes.Add(Tuple.Create("Freezes Target +3", 0, 0));
            affixes.Add(Tuple.Create("Level 9 Frozen Orb (50 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Cannot be Frozen", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Gavel of Pain")]
        public async Task ImageAsync()
        {
            var name = "The Gavel of Pain(45)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "169 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 130, 160));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Damage", 12, 30));
            affixes.Add(Tuple.Create("% Chance to Cast Level 1 Iron Maiden When Struck", 5, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 1 Amplify Damage on Striking", 5, 0));
            affixes.Add(Tuple.Create("Level 8 Amplify Damage (3 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Damage Taken by Attacker", 26, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Baranar's Star")]
        public async Task ImageAsync()
        {
            var name = "Baranar's Start";
            var imageLink = "";
            var requirements = new List<string>
            {
                "153 Strength",
                "44 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 0));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 1, 200));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 200));
            affixes.Add(Tuple.Create(" Cold Damage", 1, 200));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 50, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 200, 0));
            affixes.Add(Tuple.Create(" Strength", 15, 0));
            affixes.Add(Tuple.Create(" Dexterity", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Demon Limb")]
        public async Task ImageAsync()
        {
            var name = "Demon Limb(63)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "133 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 230));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Damage to Demons", 123, 0));
            affixes.Add(Tuple.Create("Fire Damage", 222, 333));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 7, 13));
            affixes.Add(Tuple.Create("% Fire Resist", 15, 20));
            affixes.Add(Tuple.Create("Level 23 Enchant (20 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Repairs 1 Durability Every 20 Seconds", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Earth Shifter")]
        public async Task ImageAsync()
        {
            var name = "Earth Shifter(69)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "253 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 250, 300));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Elemental Skills (Druid Only)", 7, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 14 Fissure on Striking", 25, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 10, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 33, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 10, 0));
            affixes.Add(Tuple.Create("Level 14 Volcano (30 Charges)", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Horizon's Tornado")]
        public async Task ImageAsync()
        {
            var name = "Horizon's Tornado(64)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "100 Strength",
                "62 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 230, 280));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 50, 0));
            affixes.Add(Tuple.Create("% Slows Target", 20, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 15 Tornado on Striking", 20, 0));
            affixes.Add(Tuple.Create("% Requirements", -20, 0));
 
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Nord's Tenderizer")]
        public async Task ImageAsync()
        {
            var name = "Nord's Tenderizer(68)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "88 Strength",
                "43 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 270, 330));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Cold Damage", 205, 455));
            affixes.Add(Tuple.Create(" Freeze Target ", 2, 4));
            affixes.Add(Tuple.Create("% Cold Absorb", 5, 15));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 25, 0));
            affixes.Add(Tuple.Create("Level 16 Blizzard (12 Charges)", 0, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 150, 180));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Schaefer's Hammer")]
        public async Task ImageAsync()
        {
            var name = "Schaefer's Hammer";
            var imageLink = "";
            var requirements = new List<string>
            {
                "189 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 130));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Maximum Damage (Based on Character Level)", 2, 198));
            affixes.Add(Tuple.Create(" Lightning Damage", 50, 200));
            affixes.Add(Tuple.Create("% Chance to Cast Level 10 Static Field on Striking", 20, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 8, 792));
            affixes.Add(Tuple.Create("% Lightning Resist", 75, 0));
            affixes.Add(Tuple.Create(" Life", 50, 0));
            affixes.Add(Tuple.Create(" Light Radius", 1, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Stone Crusher")]
        public async Task ImageAsync()
        {
            var name = "Stone Crusher(68)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "189 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 280, 320));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Damage", 10, 30));
            affixes.Add(Tuple.Create("% Target Defense", -25, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 40, 0));
            affixes.Add(Tuple.Create(" Monster Defense per Hit", -100, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Stormlash")]
        public async Task ImageAsync()
        {
            var name = "Stormlash(82)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "125 Strength",
                "77 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 240, 300));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 473));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 33, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 18 Tornado on Striking", 20, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 10 Static Field on Striking", 15, 0));
            affixes.Add(Tuple.Create(" Lightning Absorb", 3, 9));
            affixes.Add(Tuple.Create(" Lightning Damage by Attacker", 30, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Cranium Basher")]
        public async Task ImageAsync()
        {
            var name = "The Cranium Basher(87)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "253 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 240));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" Minimum Damage", 20, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 75, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 1 Amplify Damage on Striking", 4, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("All Resistances", 25, 0));
            affixes.Add(Tuple.Create(" Strength", 25, 0));
            affixes.Add(Tuple.Create(" Maximum Damage", 20, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Windhammer")]
        public async Task ImageAsync()
        {
            var name = "Windhammer(68)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "225 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 230));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 60, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 22 Twister on Striking", 33, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Dimoak's Hew")]
        public async Task ImageAsync()
        {
            var name = "Dimoak's Hew(8)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "40 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create(" Dexterity", 15, 0));
            affixes.Add(Tuple.Create(" Defense", -8, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Soul Harvest")]
        public async Task ImageAsync()
        {
            var name = "Soul Harvest(19)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "41 Strength",
                "41 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 90));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 30, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 10, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 45, 0));
            affixes.Add(Tuple.Create(" Energy", 5, 0));
            affixes.Add(Tuple.Create(" All Resistances", 20, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Steelgoad")]
        public async Task ImageAsync()
        {
            var name = "Steelgoad(14)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "50 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 60, 80));
            affixes.Add(Tuple.Create("% Deadly Strike", 30, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 30, 0));
            affixes.Add(Tuple.Create(" All Resistances", 5, 0));
            affixes.Add(Tuple.Create("% Hit Causes Monster to Flee", 75, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Battlebranch")]
        public async Task ImageAsync()
        {
            var name = "The Battlebranch(25)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "62 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 70));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 50, 100));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 7, 0));
            affixes.Add(Tuple.Create(" Dexterity", 10, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Grim Reaper")]
        public async Task ImageAsync()
        {
            var name = "The Grim Reaper(28)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "80 Strength",
                "80 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 20, 0));
            affixes.Add(Tuple.Create(" Minimum Damage", 15, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 100, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 5, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Woestave")]
        public async Task ImageAsync()
        {
            var name = "Woestave(28)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "75 Strength",
                "47 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 20, 40));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 50, 0));
            affixes.Add(Tuple.Create("% Slows Target", 50, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target +3", 0, 0));
            affixes.Add(Tuple.Create("Monster Defense per Hit", -50, 0));
            affixes.Add(Tuple.Create("Freezes Target", 0, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("Light Radius", -3, ));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Athena's Wrath")]
        public async Task ImageAsync()
        {
            var name = "Athena's Wrath(42)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "82 Strength",
                "82 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 180));
            affixes.Add(Tuple.Create(" Maximum Damage (Based on Character Level)", 1, 99));
            affixes.Add(Tuple.Create(" Life (Based on Character Level)", 1, 99));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create(" Druid Skill Levels", 1, 3));
            affixes.Add(Tuple.Create(" Dexterity", 15, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Blackleach Blade")]
        public async Task ImageAsync()
        {
            var name = "Blackleach(41)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "72 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 140));
            affixes.Add(Tuple.Create(" Maximum Damage", 1, 123));
            affixes.Add(Tuple.Create("% Chance to Cast Level 5 Weaken on Striking", 5, 0));
            affixes.Add(Tuple.Create("% Requirements", -25, 0));
            affixes.Add(Tuple.Create(" Light Radius", -2, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 8, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Grim's Burning Dead")]
        public async Task ImageAsync()
        {
            var name = "Grim's Burning Dead(45)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "70 Strength",
                "70 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 140, 180));
            affixes.Add(Tuple.Create(" Fire Damage", 131, 232));
            affixes.Add(Tuple.Create(" Necromancer Skill Levels", 3, 0));
            affixes.Add(Tuple.Create("% Target Defense", -50, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 20, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 200, 250));
            affixes.Add(Tuple.Create("% Fire Resist", 45, 0));
            affixes.Add(Tuple.Create("% Requirements", -50, 0));
            affixes.Add(Tuple.Create(" Damage Taken by Attackers", 8, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Husoldal Evo")]
        public async Task ImageAsync()
        {
            var name = "Husoldal Evo(44)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "133 Strength",
                "91 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 200));
            affixes.Add(Tuple.Create(" Damage", 20, 32));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, ));
            affixes.Add(Tuple.Create(" Attack Rating", 200, 250));
            affixes.Add(Tuple.Create("Prevent Monster Heal", , ));
            affixes.Add(Tuple.Create(" Replenish Life", 20, ));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Pierre Tombale Couant")]
        public async Task ImageAsync()
        {
            var name = "Pierre Tombale Couant(43)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "113 Strength",
                "67 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 220));
            affixes.Add(Tuple.Create(" Damage", 12, 20));
            affixes.Add(Tuple.Create("% Deadly Strike", 55, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 100, 200));
            affixes.Add(Tuple.Create(" Barbarian Skill Levels", 3, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 6, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 30, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Meat Scraper")]
        public async Task ImageAsync()
        {
            var name = "The Meat Scraper(41)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "80 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 200));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 50, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 10, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 25, 0));
            affixes.Add(Tuple.Create(" Masteries (Barbarian Only)", 3, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Bonehew")]
        public async Task ImageAsync()
        {
            var name = "Bonehew(64)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "195 Strength",
                "75 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 270, 320));
            affixes.Add(Tuple.Create("Level 14 Corpse Explosion (30 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 16 Bone Spear on Striking", 50, 0));
            affixes.Add(Tuple.Create("Sockets", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Stormspire")]
        public async Task ImageAsync()
        {
            var name = "Stormspire(70)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "188 Strength",
                "140 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 150, 250));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 237));
            affixes.Add(Tuple.Create("% Chance to Cast Level 20 Charged Bolt When Struck", 2, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 5 Chain Lightning When Struck", 5, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 50, 0));
            affixes.Add(Tuple.Create(" Strength", 10, 0));
            affixes.Add(Tuple.Create(" Lightning Damage Taken by Attackers", 27, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("The Reaper's Toll")]
        public async Task ImageAsync()
        {
            var name = "The Reaper's Toll";
            var imageLink = "";
            var requirements = new List<string>
            {
                "114 Strength",
                "89 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 190, 240));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("Cold Damage", 4, 44));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 11, 15));
            affixes.Add(Tuple.Create("% Deadly Strike", 33, 0));
            affixes.Add(Tuple.Create("% Chance to Cast Level 1 Decrepify on Striking", 33, 0));
            affixes.Add(Tuple.Create("% Requirements", -25, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Tomb Reaver")]
        public async Task ImageAsync()
        {
            var name = "Tomb Reaver(84)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "165 Strength",
                "103 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 180));
            affixes.Add(Tuple.Create("% Damage to Undead", 150, 230));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 60, ));
            affixes.Add(Tuple.Create(" Attack Rating Against Undead", 250, 350));
            affixes.Add(Tuple.Create(" All Resistances", 30, 50));
            affixes.Add(Tuple.Create("% Reanimate as: Returned", 10, ));
            affixes.Add(Tuple.Create(" Life After Each Kill", 10, 14));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 50, 80));
            affixes.Add(Tuple.Create(" Light Radius", 4, ));
            affixes.Add(Tuple.Create("Sockets", 1, 3));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
    }
}
