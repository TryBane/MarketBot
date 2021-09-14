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
        
        [Command("The Gnasher")]
        public async Task ImageAsync()
        {
            var name = "The Gnasher(5)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 60, 70));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 20, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 50, 0));
            affixes.Add(Tuple.Create(" Strength", 8, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Deathspade")]
        public async Task ImageAsync()
        {
            var name = "Deathspade(9)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "32 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Bladebone(15)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "43 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Skull Splitter(21)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Rakescar(27)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "67 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Axe of Fechmar(8)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "35 Strength",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 70, 90));
            affixes.Add(Tuple.Create("Freezes Target +3", 0, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 50, 0));
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Goreshovel")]
        public async Task ImageAsync()
        {
            var name = "Goreshovel(14)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "48 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "The Chieftain(19)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "54 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Brainhew(25)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Humongous(29)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "84 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Coldkill(36)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Butcher's Pupil(39)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "68 Strenght",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Islestrike(43)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "85 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Pompeii's Wrath(45)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Guardian Naga(48)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "121 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Warlord's Trust(35)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "73 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Spellsteel(39)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "37 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Stormrider(41)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "101 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Boneslayer Blade(42)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "The Minotaur(45)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "125 Strength",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Razor's Edge(67)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Rune Master(72)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Cranebeak(63)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Death Cleaver(70)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Ethereal Edge(74)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Hellslayer(66)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Messerschmidt's Reaver";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Executioner's Justice(75)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "164 Strenght",
                "55 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 240, 290));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 25, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Target Defense", -33, ));
            affixes.Add(Tuple.Create("% Chance to Cast Level 6 Decrepify When You Kill an Enemy", 50, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Blastbark")]
        public async Task ImageAsync()
        {
            var name = "Blastbark(28)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Hellclap(27)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Pluckeye(7)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "15 Dexterity",
                ""
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 28, 0));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 3, 0));
            affixes.Add(Tuple.Create(" Life", 10, 0));
            affixes.Add(Tuple.Create(" Mana After Each Kill", 2 0);
            affixes.Add(Tuple.Create(" Light Radius", 2, 0));
 
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Raven Claw")]
        public async Task ImageAsync()
        {
            var name = "Raven Claw(15)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Rogue's Bow(20)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Stormstrike(25)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Witherstring(13)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "28 Dexterity",
                ""
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
        public async Task ImageAsync()
        {
            var name = "Wizendraw(26)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Cliffkiller(41)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Endlesshail(36)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "58 Strength",
                "73 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 220));
            affixes.Add(Tuple.Create(" Cold Damage", 15, 30));
            affixes.Add(Tuple.Create("% Cold Resist", 25, ));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 50, ));
            affixes.Add(Tuple.Create(" Mana", 40, ));
            affixes.Add(Tuple.Create(" Strafe (Amazon Only)", 3, 5));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Goldstrike Arch")]
        public async Task ImageAsync()
        {
            var name = "Goldstrike Arch(46)";
            var imageLink = "";
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
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
            affixes.Add(Tuple.Create("", , ));
        
            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Kuko Shakaku")]
        public async Task ImageAsync()
        {
            var name = "Kuko Shakaku(33)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Magewrath(43)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Riphook(31)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Skystrike(28)";
            var imageLink = "";
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
        
        [Command("Withwild String")]
        public async Task ImageAsync()
        {
            var name = "Witchwild String(39)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Eaglehorn(69)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "97 Strength",
                "121 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, ));
            affixes.Add(Tuple.Create("% Enhanced Maximum Damage", 2, 198));
            affixes.Add(Tuple.Create("To Amazon Skill Levels", 1, 0));
            affixes.Add(Tuple.Create(" Attack Rating (Based on Character Level)", 6, 594));
            affixes.Add(Tuple.Create(" Dexterity", 25, 0));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
        
        [Command("Widowmaker")]
        public async Task ImageAsync()
        {
            var name = "Widowmaker(65)";
            var imageLink = "";
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
        public async Task ImageAsync()
        {
            var name = "Windforce(73)";
            var imageLink = "";
            var requirements = new List<string>
            {
                "134 Strength",
                "167 Dexterity"
            };
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 250, ));
            affixes.Add(Tuple.Create(" Maximum Damage", 3, 309));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 8));
            affixes.Add(Tuple.Create("% Mana Stolen per Hit", 6, 8));
            affixes.Add(Tuple.Create("% Heal Stamina", 30, 0));
            affixes.Add(Tuple.Create(" Strength", 10, 0));
            affixes.Add(Tuple.Create(" Dexterity", 5, 0));
            affixes.Add(Tuple.Create("Knockback", 0, 0));

            await CreateUniqueImage(affixes, name, requirements, imageLink);
        }
    }
}
