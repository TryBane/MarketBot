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

        private async Task CreateRunewordImage(List<Tuple<string, int,int>> affixes, string name, string slots, string runes )
        {
            string path = await _images.CreateRunewordImageAsync(affixes, name, slots, runes);
            await Context.Channel.SendFileAsync(path);
            File.Delete(path);
        }
        /*
        [Command("runeword name")]
        public async Task ImageAsync()
        {
            var name = "Runeword Name (level requirement)";
            var slots = "Type 1, Type 2, Type 3";
            var runes = "Rune 1 + Rune 2 + Rune 3";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("Type in Affix here including any % symbol at the front", First (or only) number, Second (if any) number));
            affixes.Add(Tuple.Create("Type in another Affix here including any % symbol at the front", First (or only) number, Second (if any) number));
            /*
        [Command("")]
        public async Task ImageAsync()
        {
            var name = "";
            var slots = "";
            var runes = "";
            
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

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        */

        [Command("Ancients Pledge")]
        [Alias("AP")]
        public async Task AncientsPledgeImageAsync()
        {
            var name = "Ancient's Pledge(21)";
            var slots = "Shield";
            var runes = "Ral + Ort + Tal";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 50, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 43, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 48, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 48, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 48, 0));
            affixes.Add(Tuple.Create("% Damage Taken Goes to Mana", 10, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Beast")]
        public async Task BeastImageAsync()
        {
            var name = "Beast(63)";
            var slots = "Axe, Hammer, Scepter";
            var runes = "Ber + Tir + Um + Mal + Lum";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("Level 9 Fanaticism Aura When Equipped", 0, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 40, 0));
            affixes.Add(Tuple.Create(" Enhanced Damage", 240, 270));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 20, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 25, 0));
            affixes.Add(Tuple.Create(" To Werebear", 3, 0));
            affixes.Add(Tuple.Create(" To Lycanthropy", 3, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" To Strength", 25, 40));
            affixes.Add(Tuple.Create(" To Energy", 10, 0));
            affixes.Add(Tuple.Create(" To Mana After Each Kill", 2, 0));
            affixes.Add(Tuple.Create("Level 13 Summon Grizzly (5 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Black")]
        public async Task BlackImageAsync()
        {
            var name = "Black(35)";
            var slots = "Club, Hammer, Mace";
            var runes = "Thul + io + Nef";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Increased Attack Speed", 15, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 120, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 200, 0));
            affixes.Add(Tuple.Create(" Cold Damage", 3, 14));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 40, 0));
            affixes.Add(Tuple.Create(" Knockback", 0, 0));
            affixes.Add(Tuple.Create(" To Vitality", 10, 0));
            affixes.Add(Tuple.Create(" Magic Damage Reduced By 2", 0, 0));
            affixes.Add(Tuple.Create(" Level 4 Corpse Explosion (12 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Bone")]
        public async Task BoneImageAsync()
        {
            var name = "Bone(47)";
            var slots = "Armor";
            var runes = "Sol + Um + Um";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast level 10 Bone Armor When Struck", 15, 0));
            affixes.Add(Tuple.Create("% Chance To Cast level 10 Bone Spear On Striking", 15, 0));
            affixes.Add(Tuple.Create(" To Necromancer Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" To Mana", 100, 150));
            affixes.Add(Tuple.Create(" All Resistances ", 30, 0));
            affixes.Add(Tuple.Create("Damage Reduced By 7", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Bramble")]
        public async Task BrambleImageAsync()
        {
            var name = "Bramble(61)";
            var slots = "Armor";
            var runes = "Ral + Ohm + Sur + Eth";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To Thorns Aura When Equipped", 15, 21));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 50, 0));
            affixes.Add(Tuple.Create("% To Poison Skill Damage", 25, 50));
            affixes.Add(Tuple.Create(" To Defense", 300, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 5, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana ", 15, 0));
            affixes.Add(Tuple.Create("% To Maximum Cold Resist", 5, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 30, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 100, 0));
            affixes.Add(Tuple.Create("Life After Each Kill", 13, 0));
            affixes.Add(Tuple.Create("Level 13 Spirit of Barbs (33 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Brand")]
        public async Task BrandImageAsync()
        {
            var name = "Brand(65)";
            var slots = "Missile Weapons";
            var runes = "Jah + Lo + Mal + Gul";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 14 Amplify Damage When Struck", 35, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 18 Bone Spear On Striking", 100, 0));
            affixes.Add(Tuple.Create(" Fires Explosive Arrows or Bolts", 0, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 260, 340));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 20, 0));
            affixes.Add(Tuple.Create("% Damage To Demons", 280, 330));
            affixes.Add(Tuple.Create("% Deadly Strike", 20, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("Knockback", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Breath of the Dying")]
        [Alias("botd")]
        public async Task BotdImageAsync()
        {
            var name = "Breath of the Dying(69)";
            var slots = "All Weapons";
            var runes = "Vex, Hel, El, Eld, Zod, Eth";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 20 Poison Nova When You Kill An Enemy", 50, 0));
            affixes.Add(Tuple.Create("Indestructible", 0, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 60, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 350, 400));
            affixes.Add(Tuple.Create("% Target Defense", -25, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 50, 0));
            affixes.Add(Tuple.Create("% Damage To Undead", 200, 0));
            affixes.Add(Tuple.Create(" To Attack Rating Against Undead", 50, 0));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 7, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 12, 15));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" To All Attributes", 30, 0));
            affixes.Add(Tuple.Create(" To Light Radius", 1, 0));
            affixes.Add(Tuple.Create("% Requirements", -20, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Call To Arms")]
        [Alias("cta")]
        public async Task CtaImageAsync()
        {
            var name = "Call To Arms(57)";
            var slots = "All Weapons";
            var runes = "Amn + Ral + Mal + Ist + Ohm";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 40, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 240, 290));
            affixes.Add(Tuple.Create(" Fire Damage", 5, 30));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 7, 0));
            affixes.Add(Tuple.Create(" To Battle Command", 2, 6));
            affixes.Add(Tuple.Create(" To Battle Orders", 1, 6));
            affixes.Add(Tuple.Create(" To Battle Cry", 1, 4));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" Replenish Life", 12, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 30, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Chains of Honor")]
        [Alias("coh")]
        public async Task CohImageAsync()
        {
            var name = "Chains of Honor(63)";
            var slots = "Armor";
            var runes = "Dol + Um + Ber + Ist";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To All Skills", 2, 0));
            affixes.Add(Tuple.Create("% Damage To Demons", 200, 0));
            affixes.Add(Tuple.Create("% Damage To Undead", 100, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 8, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 70, 0));
            affixes.Add(Tuple.Create(" To Strength", 20, 0));
            affixes.Add(Tuple.Create(" Replenish Life", 7, 0));
            affixes.Add(Tuple.Create(" All Resistances", 65, 0));
            affixes.Add(Tuple.Create("% Damage Reduced", 8, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 25, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Chaos")]
        public async Task ChaosImageAsync()
        {
            var name = "Chaos(57)";
            var slots = "Katar";
            var runes = "Fal + Ohm + Um";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 11 Frozen Orb On Striking", 9, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 9 Charged Bolt On Striking", 11, 0));
            affixes.Add(Tuple.Create("% Increased Attacked Speed", 35, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 240, 290));
            affixes.Add(Tuple.Create(" Magic Damage", 216, 471));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 25, 0));
            affixes.Add(Tuple.Create(" To Whirlwind", 1, 0));
            affixes.Add(Tuple.Create(" To Strength", 10, 0));
            affixes.Add(Tuple.Create(" Life After Each Demon Kill", 15, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Crescent Moon")]
        [Alias("CM")]
        public async Task CrescentMoonImageAsync()
        {
            var name = "Crescent Moon(47)";
            var slots = "Axe, Polearm, Sword";
            var runes = "Shael + Um + Tir";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 17 Chain Lightning On Striking", 10, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 13 Static Field On Striking", 7, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 180, 220));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("% To Enemy Lightning Resistance", -35, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 25, 0));
            affixes.Add(Tuple.Create(" Magic Absorb", 9, 11));
            affixes.Add(Tuple.Create(" To Mana After Each Kill", 2, 0));
            affixes.Add(Tuple.Create("Level 18 Summon Spirit Wolf (30 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Death")]
        public async Task DeathImageAsync()
        {
            var name = "Death(55)";
            var slots = "Sword, Axe";
            var runes = "Hel + El + Vex + Ort + Gul";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("Indestructible", 0, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 44 Chain Lightning When You Die", 100, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 18 Glacial Spike On Attack", 25, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 300, 385));
            affixes.Add(Tuple.Create("% Bonus To Attack Rating", 20, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 50, 0));
            affixes.Add(Tuple.Create(" Lightning Damage", 1, 50));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 7, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 50, 0));
            affixes.Add(Tuple.Create("% Deadly Strike(based on Character Level)", 0, 49));
            affixes.Add(Tuple.Create(" To Light Radius", 1, 0));
            affixes.Add(Tuple.Create("Level 22 Blood Golem (15 Charges)", 0, 0));
            affixes.Add(Tuple.Create("% Requirements", -20, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
              
        [Command("Delirium")]
        public async Task DeliriumImageAsync()
        {
            var name = "Delirium(51)";
            var slots = "Helm";
            var runes = "Lem + Ist + io";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast lvl 50 Delirium When Struck", 1, 0));
            affixes.Add(Tuple.Create("% Chance To Cast lvl 14 Mind Blast When Struck", 6, 0));
            affixes.Add(Tuple.Create("% Chance To Cast lvl 13 Terror When Struck", 14, 0));
            affixes.Add(Tuple.Create("% Chance To Cast lvl 18 Confuse On Striking", 11, 0));
            affixes.Add(Tuple.Create(" To All Skills", 2, 0));
            affixes.Add(Tuple.Create(" Defense", 261, 0));
            affixes.Add(Tuple.Create(" To Vitality", 10, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 50, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 25, 0));
            affixes.Add(Tuple.Create("Level 17 Attract (60 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Destruction")]
        public async Task DestructionImageAsync()
        {
            var name = "Destruction(65)";
            var slots = "Polearm, Sword";
            var runes = "Vex + Lo + Ber + Jah + Ko";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 12 Volcano On Striking", 23, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 23 Molten Boulder On Striking", 5, 0));
            affixes.Add(Tuple.Create("% Chance To Cast level 45 Meteor When You Die", 100, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 22 Nova On Attack", 15, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 350, 0));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create(" Magic Damage", 100, 180));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 7, 0));
            affixes.Add(Tuple.Create("% Chance Of Crushing Blow", 20, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 20, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 10, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Doom")]
        public async Task DoomImageAsync()
        {
            var name = "Doom(67)";
            var slots = "Axe, Hammer, Polearm";
            var runes = "Hel + Ohm + Um + Lo + Cham";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 18 Volcano On Striking", 5, 0));
            affixes.Add(Tuple.Create("Level 12 Holy Freeze Aura When Equipped", 0, 0));
            affixes.Add(Tuple.Create(" To All Skills", 2, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 45, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 330, 370));
            affixes.Add(Tuple.Create("% To Enemy Cold Resistance", -40, 60));
            affixes.Add(Tuple.Create("% Deadly Strike", 20, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 25, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("Freezes Target +3", 0, 0));
            affixes.Add(Tuple.Create("% Requirements", -20, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }

        [Command("Dragon")]
        public async Task DragonImageAsync([Remainder] string args = null)
        {

            var name = "Dragon(61)";
            string slots;
            var runes = "Sur + Lo + Sol";

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to Cast Level 18 Venom When Struck", 20, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 15 Hydra On Striking", 12, 0));
            affixes.Add(Tuple.Create("Level 14 Holy Fire Aura When Equipped", 0, 0));
            affixes.Add(Tuple.Create(" Defense", 360, 0));
            affixes.Add(Tuple.Create(" Defense Vs. Missile", 230, 0));
            affixes.Add(Tuple.Create(" To All Attributes", 3, 5));
            affixes.Add(Tuple.Create(" To Strength (Based on Character Level)", 0, 37));
            affixes.Add(Tuple.Create("% To Maximum Lightning Resist", 5, 0));
            affixes.Add(Tuple.Create("Damage Reduced by 7", 0, 0));

            if (args == null)
            {
                slots = "Armor, Shield";
                affixes.Add(Tuple.Create("% Increase Maximum Mana (Armor)", 5, 0));
                affixes.Add(Tuple.Create(" To Mana (Shield)", 50, 0));
            }
            else if (args.ToLower() == "armor")
            {
                slots = "Armor";
                affixes.Add(Tuple.Create("% Increase Maximum Mana", 5, 0));
            }
            else if (args.ToLower() == "shield")
            {
                slots = "Shield";
                affixes.Add(Tuple.Create(" To Mana", 50, 0));
            }
            else
            {
                slots = "Armor, Shield";
                affixes.Add(Tuple.Create("% Increase Maximum Mana (Armor)", 5, 0));
                affixes.Add(Tuple.Create(" To Mana (Shield)", 50, 0));
            }

            await CreateRunewordImage(affixes, name, slots, runes);
        }

        [Command("Dream")]
        public async Task DreamImageAsync([Remainder] string args = null)
        {
            var name = "Dream(65)";
            string slots;
            var runes = "io + Jah + Pul";

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to cast level 15 Confuse when struck", 10, 0));
            affixes.Add(Tuple.Create("Level 15 Holy Shock Aura when equipped", 0, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recover", 20, 30));
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 0));
            affixes.Add(Tuple.Create(" Defense", 150, 220));
            affixes.Add(Tuple.Create(" To Vitality", 10, 0));

            if (args == null)
            {
                slots = "Helm, Shield";
                affixes.Add(Tuple.Create("% Increase Maximum Life (Helm)", 5, 0));
                affixes.Add(Tuple.Create(" Increase Maximum Life (Shield)", 50, 0));
            }
            else if (args.ToLower() == "helm")
            {
                slots = "Helm";
                affixes.Add(Tuple.Create("% Increase Maximum Life", 5, 0));
            }
            else if (args.ToLower() == "shield")
            {
                slots = "Shield";
                affixes.Add(Tuple.Create(" Increase Maximum Life", 50, 0));
            }
            else
            {
                slots = "Helm, Shield";
                affixes.Add(Tuple.Create("% Increase Maximum Life (Helm)", 5, 0));
                affixes.Add(Tuple.Create(" Increase Maximum Life (Shield)", 50, 0));
            }

            affixes.Add(Tuple.Create(" To Mana (Based on Character Level)", 0, 61));
            affixes.Add(Tuple.Create(" All Resistances", 5, 20));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 12, 25));

            await CreateRunewordImage(affixes, name, slots, runes);
        }

        [Command("Duress")]
        public async Task DuressImageAsync()
        {
            var name = "Duress(47)";
            var slots = "Armor";
            var runes = "Shael + Um + Thul";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% faster hit Recovery", 40, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 10, 20));
            affixes.Add(Tuple.Create(" Cold Damage", 37, 133));
            affixes.Add(Tuple.Create("% Crushing Blow", 15, 0));
            affixes.Add(Tuple.Create("% Open Wounds", 33, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 150, 200));
            affixes.Add(Tuple.Create("% Slower Stamina Drain", -20, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 45, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 15, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 15, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 15, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Edge")]
        public async Task EdgeImageAsync()
        {
            var name = "Edge(25)";
            var slots = "Javelin";
            var runes = "Tir + Tal + Amn";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("Level 15 Thorns Aura When Equipped", 0, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 35, 0));
            affixes.Add(Tuple.Create("% Damage To Demons", 320, 380));
            affixes.Add(Tuple.Create("% Damage To Undead", 280, 0));
            affixes.Add(Tuple.Create(" Poison Damage Over 5 Seconds", 75, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 7, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" To All Attributes", 5, 10));
            affixes.Add(Tuple.Create(" To Mana After Each Kill", 2, 0));
            affixes.Add(Tuple.Create("Reduces All Vendor Prices 15%", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
      
        [Command("Enigma")]
        public async Task EnigmaImageAsync()
        {
            var name = "Enigma(65)";
            var slots = "Armor";
            var runes = "Jah + Ith + Ber";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To All Skills", 2, 0));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 45, 0));
            affixes.Add(Tuple.Create(" To Teleport", 1, 0));
            affixes.Add(Tuple.Create("Defense", 750, 775));
            affixes.Add(Tuple.Create(" To Strength(based on Character Level)", 0, 74));
            affixes.Add(Tuple.Create("% Increase Maximum Life", 5, 0));
            affixes.Add(Tuple.Create("% Damage Reduced", 8, 0));
            affixes.Add(Tuple.Create(" Life After Each Kill", 14, 0));
            affixes.Add(Tuple.Create("% Damage Taken Goes To Mana", 15, 0));
            affixes.Add(Tuple.Create("% Better chance of getting magic items(Based on Character Level)", 1 , 99));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Enlightenment")]
        public async Task EnlightenmentImageAsync()
        {
            var name = "Enlightenment(45)";
            var slots = "Armor";
            var runes = "Pul + Ral + Sol";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 15 Blaze When Struck", 5, 0));
            affixes.Add(Tuple.Create("% Chance To Cast level 15 Fire Ball On Striking", 5, 0));
            affixes.Add(Tuple.Create(" To Sorceress Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" To Warmth", 1, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 30, 0));
            affixes.Add(Tuple.Create(" Damage Taken", -7, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
            
        [Command("Eternity")]
        public async Task EternityImageAsync()
        {
            var name = "Eternity(63)";
            var slots = "All Melee Weapons";
            var runes = "Amn + Ber + Ist + Sol + Sur";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("Indestructible", 0, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 260, 310));
            affixes.Add(Tuple.Create(" Added To Minimum Damage", 9, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 7, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 20, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target", 0, 0));
            affixes.Add(Tuple.Create("% Slow On Target", 33, 0));
            affixes.Add(Tuple.Create("% Replenish Mana", 16, 0));
            affixes.Add(Tuple.Create("Cannot Be Frozen", 0, 0));
            affixes.Add(Tuple.Create("% Better Chance Of Getting Magic Items", 30, 0));
            affixes.Add(Tuple.Create("Level 8 Revive (88 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Exile")]
        public async Task ExileImageAsync()
        {
            var name = "Exile(57)";
            var slots = "Shield";
            var runes = "Vex + Ohm + Ist + Dol";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 5 Life Tap On Striking", 15, 0));
            affixes.Add(Tuple.Create(" Level Defiance Aura When Equipped", 13, 16));
            affixes.Add(Tuple.Create(" To Offensive Auras (Paladin Only)", 2, 0));
            affixes.Add(Tuple.Create("% Faster Block Rate", 30, 0));
            affixes.Add(Tuple.Create("Freezes Target", 0, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 220, 260));
            affixes.Add(Tuple.Create(" Replenish Life", 7, 0));
            affixes.Add(Tuple.Create("% To Maximum Cold Resist", 5, 0));
            affixes.Add(Tuple.Create("% To Maximum Fire Resist", 5, 0));
            affixes.Add(Tuple.Create("% Better Chance Of Getting Magic Items", 25, 0));
            affixes.Add(Tuple.Create("Repairs 1 Durability every 4 seconds", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
            
        [Command("Faith")]
        public async Task FaithImageAsync()
        {
            var name = "Faith(65)";
            var slots = "Missile Weapons";
            var runes = "Ohm + Jah + Lem + Eld";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" Level Fanaticism Aura When Equipped", 12, 15));
            affixes.Add(Tuple.Create(" To All Skills", 1, 2));
            affixes.Add(Tuple.Create("% Enhanced Damage", 330, 0));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("% Bonus To Attack Rating", 300, 0));
            affixes.Add(Tuple.Create("% Damage To Undead", 75, 0));
            affixes.Add(Tuple.Create(" To Attack Rating Against Undead", 50, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 120, 0));
            affixes.Add(Tuple.Create(" All Resistances", 15, 0));
            affixes.Add(Tuple.Create("% Reanimate As: Returned", 10, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 75, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }

        [Command("Famine")]
        public async Task FamineImageAsync()
        {
            var name = "Famine(65)";
            var slots = "Axe, Hammer";
            var runes = "Fal + Ohm + Ort + Jah";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 320, 370));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create(" Magic Damage", 180, 200));
            affixes.Add(Tuple.Create(" Fire Damage", 50, 200));
            affixes.Add(Tuple.Create(" Lightning Damage", 51, 250));
            affixes.Add(Tuple.Create(" Cold Damage", 50, 200));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 12, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" To Strength", 10, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
            
        [Command("Fortitude")]
        public async Task FortitudeImageAsync()
        {
            var name = "Fortitude(59)";
            var slots = "Weapon, Armor";
            var runes = "El + Sol + Dol + Lo";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 15 Chilling Armor when Struck", 20, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 25, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 300, 0));
            affixes.Add(Tuple.Create(" To Minimum Damage(Weapons)", 300, 0));
            affixes.Add(Tuple.Create(" To Attack Rating(Weapons)", 300, 0));
            affixes.Add(Tuple.Create("% Deadly Strike(Weapons)", 300, 0));
            affixes.Add(Tuple.Create("% Chance Hit Causes Monster To Flee(Weapons)", 300, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 200, 0));
            affixes.Add(Tuple.Create(" To Life (Based on Character Level [1-1.5 Per Level])", 1, 149));
            affixes.Add(Tuple.Create(" Replenish Life(Armor)", 7, 0));
            affixes.Add(Tuple.Create("% To Maximum Lightning Resistance(Armor)", 5, 0));
            affixes.Add(Tuple.Create(" All Resistances", 25, 30));
            affixes.Add(Tuple.Create(" Reduced Damage(Armor)", 7, 0));
            affixes.Add(Tuple.Create("% Damage Taken Goes To Mana", 12, 0));
            affixes.Add(Tuple.Create(" To Light Radius", 1, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Fury")]
        public async Task FuryImageAsync()
        {
            var name = "Fury(65)";
            var slots = "All Melee Weapons";
            var runes = "Jah + Gul + Eth";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Increased Attack Speed", 40, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 209, 0));
            affixes.Add(Tuple.Create("Ignores Target Defense", 0, 0));
            affixes.Add(Tuple.Create("% Target Defense", -25, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 20, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 6, 0));
            affixes.Add(Tuple.Create("% Chance Of Deadly Strike", 33, 0));
            affixes.Add(Tuple.Create("% Chance Of Open Wounds", 66, 0));
            affixes.Add(Tuple.Create(" To Frenzy (Barbarian Only)", 5, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
            
        [Command("Gloom")]
        public async Task GloomImageAsync()
        {
            var name = "Gloom(47)";
            var slots = "Armor";
            var runes = "Fal + Um + Pul";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 3 Dim Vision When Struck", 15, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 10, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 200, 260));
            affixes.Add(Tuple.Create(" To Strength", 10, 0));
            affixes.Add(Tuple.Create(" All Resistances", 45, 0));
            affixes.Add(Tuple.Create("Half Freeze Duration", 0, 0));
            affixes.Add(Tuple.Create("% Damage Taken Goes To Mana", 5, 0));
            affixes.Add(Tuple.Create(" To Light Radius", -3, 0));
            
            await CreateRunewordImage(affixes, name, slots, runes);
         }
         
            [Command("Grief")]
        public async Task GriefImageAsync()
        {
            var name = "Grief(59)";
            var slots = "Sword, Axe";
            var runes = "Eth + Tir + Lo + Mal + Ral";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 15 Venom On Striking", 35, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 40));
            affixes.Add(Tuple.Create(" Damage", 340, 400));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("% Target Defense", -25, 0));
            affixes.Add(Tuple.Create("% Damage To Demons (Based on Character Level)", 1, 185));
            affixes.Add(Tuple.Create(" Fire Damage", 5, 30));
            affixes.Add(Tuple.Create(" To Enemy Poison Resistance", -20, 25));
            affixes.Add(Tuple.Create("% Deadly Strike", 20, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" To Mana After Each Kill", 2, 0));
            affixes.Add(Tuple.Create(" Life After Each Kill", 10, 15));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Hand of Justice")]
        [Alias("hoj")]
        public async Task HandOfJusticeImageAsync()
        {
            var name = "Hand of Justice(67)";
            var slots = "All Weapons";
            var runes = "Sur + Cham + Amn + Lo";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 36 Blaze When You Level-Up", 100, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 48 Meteor When You Die", 100, 0));
            affixes.Add(Tuple.Create("Level 16 Holy Fire Aura When Equipped", 0, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 33, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 280, 330));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("% To Enemy Fire Resistance", -20, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 7, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 20, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target", 0, 0));
            affixes.Add(Tuple.Create("Freezes Target +3", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Harmony")]
        public async Task HarmonyImageAsync()
        {
            var name = "Harmony(39)";
            var slots = "Missile Weapons";
            var runes = "Tir + Ith + Sol + Ko";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("Level 10 Vigor Aura When Equipped", 0, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 275));
            affixes.Add(Tuple.Create(" To Minimum Damage", 9, 0));
            affixes.Add(Tuple.Create(" To Maximum Damage", 9, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 55, 160));
            affixes.Add(Tuple.Create(" Lightning Damage", 55, 160));
            affixes.Add(Tuple.Create(" Cold Damage", 55, 160));
            affixes.Add(Tuple.Create(" To Valkyrie", 2, 6));
            affixes.Add(Tuple.Create(" To Dexterity", 10, 0));
            affixes.Add(Tuple.Create("Regenerate Mana 20%", 0, 0));
            affixes.Add(Tuple.Create(" To Mana After Each Kill", 2, 0));
            affixes.Add(Tuple.Create(" To Light Radius", 2, 0));
            affixes.Add(Tuple.Create("Level 20 Revive (25 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Heart of the Oak")]
        [Alias("Hoto")]
        public async Task HeartOfTheOakImageAsync()
        {
            var name = "Heart of the Oak(55)";
            var slots = "Staff, Mace";
            var runes = "Ko + Vex + Pul + Thul";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To All Skills", 3, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 40, 0));
            affixes.Add(Tuple.Create("% Damage To Demons", 75, 0));
            affixes.Add(Tuple.Create(" To Attack Rating Against Demons", 100, 0));
            affixes.Add(Tuple.Create(" Cold Damage", 3, 14));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 7, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 10, 0));
            affixes.Add(Tuple.Create(" Replenish Life", 20, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 15, 0));
            affixes.Add(Tuple.Create(" All Resistances", 30, 40));
            affixes.Add(Tuple.Create("Level 4 Oak Sage (25 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Level 14 Raven (60 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Holy Thunder")]
        [Alias("HT")]
        public async Task HolyThunderImageAsync()
        {
            var name = "Holy Thunder(23)";
            var slots = "Scepter";
            var runes = "Eth + Ral + Ort + Tal";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 60, 0));
            affixes.Add(Tuple.Create(" To Maximum Damage", 10, 0));
            affixes.Add(Tuple.Create("% Target Defense", -25, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 5, 30));
            affixes.Add(Tuple.Create(" Lightning Damage", 21, 110));
            affixes.Add(Tuple.Create(" Poison Damage over 5 secs", 75, 0));
            affixes.Add(Tuple.Create(" To Holy Shock (Paladin Only)", 3, 0));
            affixes.Add(Tuple.Create("% to Maximum Lightning Resist", 5, 0));
            affixes.Add(Tuple.Create(" Lightning Resist", 60, 0));
            affixes.Add(Tuple.Create("Level 7 Chain Lightning (60 charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
         [Command("Honor")]
        public async Task HonorImageAsync()
        {
            var name = "Honor(27)";
            var slots = "All Melee Weapons";
            var runes = "Amn + El + Ith + Tir + Sol";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To all skills", 1, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 0));
            affixes.Add(Tuple.Create(" To Minimum Damage", 9, 0));
            affixes.Add(Tuple.Create(" To Maximum Damage", 9, 0));
            affixes.Add(Tuple.Create(" Attack Rating", 250, 0));
            affixes.Add(Tuple.Create("% Life Stolen per Hit", 7, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 25, 0));
            affixes.Add(Tuple.Create(" To Strength", 10, 0));
            affixes.Add(Tuple.Create(" Replenish life", 10, 0));
            affixes.Add(Tuple.Create(" To Mana after each Kill", 2, 0));
            affixes.Add(Tuple.Create(" To Light Radius", 1, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Ice")]
        public async Task IceImageAsync()
        {
            var name = "Ice(65)";
            var slots = "Missile Weapons";
            var runes = "Amn + Shael + Jah + Lo";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 40 Blizzard When You Level-up", 100, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 22 Frost Nova On Striking", 25, 0));
            affixes.Add(Tuple.Create("Level 18 Holy Freeze Aura When Equipped", 0, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 140, 210));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("% To Cold Skill Damage", 25, 30));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 7, 0));
            affixes.Add(Tuple.Create("% To Enemy Cold Resistance", -20, 0));
            affixes.Add(Tuple.Create("% Deadly Strike", 20, 0));
            affixes.Add(Tuple.Create(" Extra Gold From Monsters (Based on Character Level)", 3, 309));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Infinity")]
        public async Task InfinityImageAsync()
        {
            var name = "Infinity(63)";
            var slots = "Polearm";
            var runes = "Ber + Mal + Ber + Ist";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 20 Chain Lightning When You Kill An Enemy", 50, 0));
            affixes.Add(Tuple.Create("Level 12 Conviction Aura When Equipped", 0, 0));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 35, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 255, 325));
            affixes.Add(Tuple.Create("% To Enemy Lightning Resistance", -45, 55));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 40, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" To Vitality (Based on Character Level)", 0, 49));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 30, 0));
            affixes.Add(Tuple.Create("Level 21 Cyclone Armor (30 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Insight")]
        public async Task InsightImageAsync()
        {
            var name = "Insight(27)";
            var slots = "Polearm, Staff";
            var runes = "Ral + Tir + Tal + Sol";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("Meditation Aura When Equipped", 12, 17));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 35, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 260));
            affixes.Add(Tuple.Create(" To Minimum Damage", 9, 0));
            affixes.Add(Tuple.Create("% Bonus to Attack Rating", 180, 250));
            affixes.Add(Tuple.Create(" Fire Damage", 5, 30));
            affixes.Add(Tuple.Create("Poison Damage Over 5 Seconds", 75, 0));
            affixes.Add(Tuple.Create(" To Critical Strike", 1, 6));
            affixes.Add(Tuple.Create(" To All Attributes", 5, 0));
            affixes.Add(Tuple.Create(" To Mana After Each Kill", 2, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 23, 0));
            
            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Kings Grace")]
        [Alias("KG")]
        public async Task KingsGraceImageAsync()
        {
            var name = "King's Grace(25)";
            var slots = "Sword, Scepter";
            var runes = "Amn + Ral + Thul";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 100, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 150, 0));
            affixes.Add(Tuple.Create("% Damage to Demons", 100, 0));
            affixes.Add(Tuple.Create(" To Attack Rating against Demons", 100, 0));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" To Attack Rating against Undead", 100, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 5, 30));
            affixes.Add(Tuple.Create(" Cold damage", 3, 14));
            affixes.Add(Tuple.Create("% Life stolen per hit", 7, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Kingslayer")]
        [Alias("King Slayer","KS")]
        public async Task KingslayerImageAsync()
        {
            var name = "Kingslayer(53)";
            var slots = "Sword, Axe";
            var runes = "Mal + Um + Gul + Fal";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Increased Attack Speed", 30, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 230, 270));
            affixes.Add(Tuple.Create("% Target Defense", -25, 0));
            affixes.Add(Tuple.Create("% Bonus To Attack Rating", 20, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 33, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 50, 0));
            affixes.Add(Tuple.Create(" To Vengeance", 1, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" To Strength", 10, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 40, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Last Wish")]
        [Alias("LW")]
        public async Task LastWishImageAsync()
        {
            var name = "Last Wish(65)";
            var slots = "Axe, Hammer, Sword";
            var runes = "Jah + Mal + Jah + Sur + Jah + Ber";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 11 Fade When Struck", 6, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 18 Life Tap On Striking", 10, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 20 Charged Bolt On Attack", 20, 0));
            affixes.Add(Tuple.Create("Level 17 Might Aura When Equipped", 0, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 330, 375));
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 60, 70));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target", 0, 0));
            affixes.Add(Tuple.Create("% Chance of Getting Magic Items (Based on Character Level)", 0, 49));
            
            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Lawbringer")]
        [Alias("LB")]
        public async Task LawBringerImageAsync()
        {
            var name = "Lawbringer(43)";
            var slots = "Hammer, Scepter, Sword";
            var runes = "Amn + Lem + Ko";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 15 Decrepify On Striking", 20, 0));
            affixes.Add(Tuple.Create(" Sanctuary Aura When Equipped", 16, 18));
            affixes.Add(Tuple.Create("% Target Defense", -50, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 150, 210));
            affixes.Add(Tuple.Create(" Cold Damage", 130, 180));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit", 7, 0));
            affixes.Add(Tuple.Create("Slain Monsters Rest In Peace", 0, 0));
            affixes.Add(Tuple.Create(" Defense Vs. Missile", 200, 250));
            affixes.Add(Tuple.Create(" To Dexterity", 10, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 75, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Leaf")]
        public async Task LeafImageAsync()
        {
            var name = "Leaf(19)";
            var slots = "Staff";
            var runes = "Tir + Ral";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To Fire Skills", 3, 0));
            affixes.Add(Tuple.Create(" Fire Damage", 5, 30));
            affixes.Add(Tuple.Create(" To Inferno (Sorceress Only", 3, 0));
            affixes.Add(Tuple.Create(" To Warmth (Sorceress Only)", 3, 0));
            affixes.Add(Tuple.Create(" To Fire Bolt (Sorceress Only)", 3, 0));
            affixes.Add(Tuple.Create(" Defence (Based on Character Level)", 2, 198));
            affixes.Add(Tuple.Create("% Cold Resist", 33, 0));
            affixes.Add(Tuple.Create(" To Mana after each Kill", 2, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Lionheart")]
        [Alias("LH")]
        public async Task LionheartImageAsync()
        {
            var name = "Lionheart(41)";
            var slots = "Armor";
            var runes = "Hel + Lum + Fal";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 20, 0));
            affixes.Add(Tuple.Create(" To Strength", 25, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 15, 0));
            affixes.Add(Tuple.Create(" To Vitality", 20, 0));
            affixes.Add(Tuple.Create(" To Energy", 10, 0));
            affixes.Add(Tuple.Create(" To Life", 50, 0));
            affixes.Add(Tuple.Create(" All Resistances", 30, 0));
            affixes.Add(Tuple.Create("% Requirements", 15, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Lore")]
        public async Task LoreImageAsync()
        {
            var name = "Lore(27)";
            var slots = "Helm";
            var runes = "Ort + Sol";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To All Skills", 1, 0));
            affixes.Add(Tuple.Create(" To Energy", 10, 0));
            affixes.Add(Tuple.Create("% Lightning Resist", 30, 0));
            affixes.Add(Tuple.Create(" Damage Taken", -7, 0));
            affixes.Add(Tuple.Create(" To Mana after each Kill", 2, 0));
            affixes.Add(Tuple.Create(" To Light Radius", 2, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Malice")]
        public async Task MaliceImageAsync()
        {
            var name = "Malice(15)";
            var slots = "All Melee Weapons";
            var runes = "Ith + El + Eth";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 33, 0));
            affixes.Add(Tuple.Create(" To Maximum Damage", 9, 0));
            affixes.Add(Tuple.Create("% Target Defense", 25, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 50, 0));
            affixes.Add(Tuple.Create("% Chance of Open wounds", 100, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" To Monster Defense Per Hit", -100, 0));
            affixes.Add(Tuple.Create(" Drain Life", -5, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Melody")]
        public async Task MelodyImageAsync()
        {
            var name = "Melody(39)";
            var slots = "Missile Weapons";
            var runes = "Shael + Ko + Nef";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To Bow and Crossbow Skills (Amazon Only)", 3, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 50, 0));
            affixes.Add(Tuple.Create("% Damage To Undead", 300, 0));
            affixes.Add(Tuple.Create(" To Slow Missiles (Amazon Only)", 3, 0));
            affixes.Add(Tuple.Create(" To Dodge (Amazon Only)", 3, 0));
            affixes.Add(Tuple.Create(" To Critical Strike (Amazon Only)", 3, 0));
            affixes.Add(Tuple.Create("Knockback", 0, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 10, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Memory")]
        public async Task MemoryImageAsync()
        {
            var name = "Memory(37)";
            var slots = "Staff";
            var runes = "Lum + io + Sol + Eth";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To Sorceress Skill Levels", 3, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 33, 0));
            affixes.Add(Tuple.Create(" To Minimum Damage", 9, 0));
            affixes.Add(Tuple.Create("% Target Defence", -25, 0));
            affixes.Add(Tuple.Create(" To Energy Shield (Sorceress Only)", 3, 0));
            affixes.Add(Tuple.Create(" To Static Field (Sorceress Only)", 2, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 50, 0));
            affixes.Add(Tuple.Create(" To Vitality", 10, 0));
            affixes.Add(Tuple.Create(" To Energy", 10, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 20, 0));
            affixes.Add(Tuple.Create(" Magic Damage Taken", -7, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Myth")]
        public async Task MythImageAsync()
        {
            var name = "Myth(25)";
            var slots = "Armor";
            var runes = "Hel + Amn + Nef";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 1 Howl When Struck", 3, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 1 Taunt On Striking", 10, 0));
            affixes.Add(Tuple.Create(" To Barbarian Skill Levels", 2, 0));
            affixes.Add(Tuple.Create(" Defense Vs. Missile", 30, 0));
            affixes.Add(Tuple.Create(" Replenish Life", 10, 0));
            affixes.Add(Tuple.Create(" Damage Dealt to Attacker", 14, 0));
            affixes.Add(Tuple.Create("% Requirements", -15, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Nadir")]
        public async Task NadirImageAsync()
        {
            var name = "Nadir(13)";
            var slots = "Helm";
            var runes = "Nef + Tir";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 50, 0));
            affixes.Add(Tuple.Create(" Defense", 10, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 30, 0));
            affixes.Add(Tuple.Create(" To Strength", 5, 0));
            affixes.Add(Tuple.Create(" To Mana after each Kill", 2, 0));
            affixes.Add(Tuple.Create("% Extra Gold from Monsters", -33, 0));
            affixes.Add(Tuple.Create(" To Light Radius", -3, 0));
            affixes.Add(Tuple.Create("Level 13 Cloak of Shadows (9 charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Oath")]
        public async Task OathImageAsync()
        {
            var name = "Oath(59)";
            var slots = "Axe, Mace, Sword";
            var runes = "Shael + Pul + Mal + Lum";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("Indestructible", 0, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 20 Bone Spirit On Striking", 30, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 50, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 210, 340));
            affixes.Add(Tuple.Create("% Damage To Demons", 75, 0));
            affixes.Add(Tuple.Create(" To Attack Rating Against Demons", 100, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" To Energy", 10, 0));
            affixes.Add(Tuple.Create(" Magic Absorb", 10, 15));
            affixes.Add(Tuple.Create("Level 16 Heart of Wolverine (20 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Level 17 Iron Golem (14 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Obedience")]
        public async Task ObedienceImageAsync()
        {
            var name = "Obedience(41)";
            var slots = "Polearm";
            var runes = "Hel + Ko + Thul + Eth + Fal";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 21 Enchant When You Kill An Enemy", 30, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 40, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 370, 0));
            affixes.Add(Tuple.Create("% Target Defense", -25, 0));
            affixes.Add(Tuple.Create(" Cold Damage", 3, 14));
            affixes.Add(Tuple.Create("% To Enemy Fire Resistance", -25, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 40, 0));
            affixes.Add(Tuple.Create(" Defense", 200, 300));
            affixes.Add(Tuple.Create(" To Strength", 10, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 10, 0));
            affixes.Add(Tuple.Create("% All Resistances", 20, 30));
            affixes.Add(Tuple.Create("% Requirements", -20, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Passion")]
        public async Task PassionImageAsync()
        {
            var name = "Passion(43)";
            var slots = "All Weapons";
            var runes = "Dol + Ort + Eld + Lem";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Increased Attack Speed", 25, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 160, 220));
            affixes.Add(Tuple.Create("% Bonus To Attack Rating", 50, 80));
            affixes.Add(Tuple.Create("% Damage To Undead", 75, 0));
            affixes.Add(Tuple.Create(" To Attack Rating Against Undead", 50, 0));
            affixes.Add(Tuple.Create("Adds 1-50 Lightning Damage", 0, 0));
            affixes.Add(Tuple.Create(" To Berserk", 1, 0));
            affixes.Add(Tuple.Create(" To Zeal", 1, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target +10", 0, 0));
            affixes.Add(Tuple.Create("% Hit Causes Monster To Flee", 25, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 75, 0));
            affixes.Add(Tuple.Create("Level 3 Heart of Wolverine (12 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Peace")]
        public async Task PeaceImageAsync()
        {
            var name = "Peace(29)";
            var slots = "Armor";
            var runes = "Shael + Thul + Amn";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 5 Slow Missiles When Struck", 5, 0));
            affixes.Add(Tuple.Create("% Chance To Cast level 15 Valkyrie On Striking", 2, 0));
            affixes.Add(Tuple.Create(" To Amazon Skill Levels", 2, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create(" To Critical Strike", 2, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 30, 0));
            affixes.Add(Tuple.Create(" Damage Dealt To Attacker", 14, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Phoenix")]
        public async Task PhoenixImageAsync()
        {
            var name = "Phoenix(65)";
            var slots = "Weapon, Shield";
            var runes = "";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast level 40 Blaze When You Level-up", 100, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 22 Firestorm On Striking", 40, 0));
            affixes.Add(Tuple.Create(" Redemption Aura When Equipped", 10, 15));
            affixes.Add(Tuple.Create("% Enhanced Damage", 350, 400));
            affixes.Add(Tuple.Create("% To Enemy Fire Resistance", -28, 0));
            affixes.Add(Tuple.Create(" Defense Vs. Missile", 350, 400));
            affixes.Add(Tuple.Create(" Fire Absorb", 15, 21));
            affixes.Add(Tuple.Create("Ignores Target's Defense(All Weapons)", 0, 0));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit(All Weapons)", 14, 0));
            affixes.Add(Tuple.Create("% Deadly Strike(All Weapons)", 20, 0));
            affixes.Add(Tuple.Create(" To Life(Shields)", 50, 0));
            affixes.Add(Tuple.Create("% To Maximum Lightning Resist(Shields)", 5, 0));
            affixes.Add(Tuple.Create("% To Maximum Fire Resist(Shields)", 10, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Pride")]
        public async Task PrideImageAsync()
        {
            var name = "Pride(67)";
            var slots = "Polearm";
            var runes = "Cham + Sur + io + Lo";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 17 Fire Wall When Struck", 25, 0));
            affixes.Add(Tuple.Create(" Concentration Aura When Equipped", 16, 20));
            affixes.Add(Tuple.Create("% Bonus To Attack Rating", 260, 300));
            affixes.Add(Tuple.Create("% Damage To Demons (Based on Character Level)", 1, 99));
            affixes.Add(Tuple.Create(" Lightning Damage", 50, 280));
            affixes.Add(Tuple.Create("% Deadly Strike", 20, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target", 0, 0));
            affixes.Add(Tuple.Create("Freezes Target +3", 0, 0));
            affixes.Add(Tuple.Create(" To Vitality", 10, 0));
            affixes.Add(Tuple.Create(" Replenish Life", 8, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters (Based on Character Level)", 1, 185));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Principle")]
        public async Task PrincipleImageAsync()
        {
            var name = "Principle(55)";
            var slots = "Armor";
            var runes = "Ral + Gul + Eld";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 5 Holy Bolt On Striking", 100, 0));
            affixes.Add(Tuple.Create(" To Paladin Skill Levels", 2, 0));
            affixes.Add(Tuple.Create("% Damage to Undead", 50, 0));
            affixes.Add(Tuple.Create(" To Life", 100, 150));
            affixes.Add(Tuple.Create("% Slower Stamina Drain", 15, 0));
            affixes.Add(Tuple.Create("% To Maximum Poison Resist", 5, 0));
            affixes.Add(Tuple.Create("% Fire Resist", 30, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Prudence")]
        public async Task PrudenceImageAsync()
        {
            var name = "Prudence(49)";
            var slots = "Armor";
            var runes = "Mal + Tir";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 25, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 140, 170));
            affixes.Add(Tuple.Create(" All Resistances", 25, 35));
            affixes.Add(Tuple.Create(" Damage Reduced", -3, 0));
            affixes.Add(Tuple.Create(" Magic Damage Taken", -17, 0));
            affixes.Add(Tuple.Create(" To Mana After Each Kill", 2, 0));
            affixes.Add(Tuple.Create(" To Light Radius", 1, 0));
            affixes.Add(Tuple.Create("Repairs Durability 1 In 4 Seconds", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Radiance")]
        public async Task RadianceImageAsync()
        {
            var name = "Radiance(27)";
            var slots = "Helm";
            var runes = "Nef + Sol + Ith";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Defense", 75, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missiles", 30, 0));
            affixes.Add(Tuple.Create(" To Vitality", 10, 0));
            affixes.Add(Tuple.Create(" To Energy", 10, 0));
            affixes.Add(Tuple.Create(" To Mana", 33, 0));
            affixes.Add(Tuple.Create(" Damage Taken", -7, 0));
            affixes.Add(Tuple.Create(" Magic Damage Taken", -3, 0));
            affixes.Add(Tuple.Create("% Damage Taken Goes to Mana", 15, 0));
            affixes.Add(Tuple.Create(" To Light Radius", 5, 0));
            
            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Rain")]
        public async Task RainImageAsync()
        {
            var name = "Rain(49)";
            var slots = "Armor";
            var runes = "Ort + Mal + Ith";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 15 Cyclone Armor When Struck", 5, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 15 Twister On Striking", 5, 0));
            affixes.Add(Tuple.Create(" To Druid Skills", 2, 0));
            affixes.Add(Tuple.Create(" To Mana", 100, 150));
            affixes.Add(Tuple.Create("% Lightning Resist", 30, 0));
            affixes.Add(Tuple.Create(" Magic Damage Taken", -7, 0));
            affixes.Add(Tuple.Create("% Damage Taken Goes to Mana", 15, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Rhyme")]
        public async Task RhymeImageAsync()
        {
            var name = "Rhyme(29)";
            var slots = "Shield";
            var runes = "Shael + Eth";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Faster Block Rate", 40, 0));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 20, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 15, 0));
            affixes.Add(Tuple.Create(" All Resistances", 25, 0));
            affixes.Add(Tuple.Create("Cannot be Frozen", 0, 0));
            affixes.Add(Tuple.Create("% Extra Gold from Monsters", 50, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 25, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Rift")]
        public async Task RiftImageAsync()
        {
            var name = "Rift(53)";
            var slots = "Polearm, Scepter";
            var runes = "Hel + Ko + Lem + Gul";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 16 Tornado On Striking", 20, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 21 Frozen Orb On Attack", 16, 0));
            affixes.Add(Tuple.Create("% Bonus To Attack Rating", 20, 0));
            affixes.Add(Tuple.Create(" Magic Damage", 160, 250));
            affixes.Add(Tuple.Create(" Fire Damage", 60, 180));
            affixes.Add(Tuple.Create(" To All Attributes", 5, 10));
            affixes.Add(Tuple.Create(" To Dexterity", 10, 0));
            affixes.Add(Tuple.Create("% Damage Taken Goes To Mana", 38, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 75, 0));
            affixes.Add(Tuple.Create("Level 15 Iron Maiden (40 Charges)", 0, 0));
            affixes.Add(Tuple.Create("% Requirements", -20, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Sanctuary")]
        public async Task SanctuaryImageAsync()
        {
            var name = "Sanctuary(49)";
            var slots = "Shield";
            var runes = "Ko + Ko + Mal";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create("% Faster Block Rate", 20, 0));
            affixes.Add(Tuple.Create("% Increased Chance of Blocking", 20, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 130, 160));
            affixes.Add(Tuple.Create(" Defense vs. Missile", 250, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 20, 0));
            affixes.Add(Tuple.Create(" All Resistances", 50, 70));
            affixes.Add(Tuple.Create("Magic Damage Taken", -7, 0));
            affixes.Add(Tuple.Create("Level 12 Slow Missiles (60 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Silence")]
        public async Task SilenceImageAsync()
        {
            var name = "Silence(55)";
            var slots = "Weapon";
            var runes = "Dol + Eld + Hel + Ist + Tir + Vex";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To All Skills", 2, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 20, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 200, 0));
            affixes.Add(Tuple.Create("% Damage To Undead", 75, 0));
            affixes.Add(Tuple.Create(" To Attack Rating Against Undead", 50, 0));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 11, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target +33", 0, 0));
            affixes.Add(Tuple.Create("Hit Causes Monster to Flee 25%", 0, 0));
            affixes.Add(Tuple.Create(" All Resistances", 75, 0));
            affixes.Add(Tuple.Create(" To Mana After Each Kill", 2, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 30, 0));
            affixes.Add(Tuple.Create("% Requirements", -20, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Smoke")]
        public async Task SmokeImageAsync()
        {
            var name = "Smoke(37)";
            var slots = "Armor";
            var runes = "Nef + Lum";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 75, 0));
            affixes.Add(Tuple.Create(" Defense vs. Missiles", 280, 0));
            affixes.Add(Tuple.Create(" To Energy", 10, 0));
            affixes.Add(Tuple.Create(" All Resistances", 50, 0));
            affixes.Add(Tuple.Create(" To Light Radius", -1, 0));
            affixes.Add(Tuple.Create("Level 6 Weaken (18 charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Spirit")]
        public async Task SpiritImageAsync()
        {
            var name = "Spirit(25)";
            var slots = "Shield, Sword";
            var runes = "Tal + Thul + Ort + Amn";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To All Skills", 2, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 25, 35));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 55, 0));
            affixes.Add(Tuple.Create(" Defense Vs. Missile", 250, 0));
            affixes.Add(Tuple.Create(" To Vitality", 22, 0));
            affixes.Add(Tuple.Create(" To Mana", 89, 112));
            affixes.Add(Tuple.Create(" Magic Absorb", 3, 8));
            affixes.Add(Tuple.Create("% Cold Resist(Shield)", 35, 0));
            affixes.Add(Tuple.Create("% Lightning Resist(Shield)", 35, 0));
            affixes.Add(Tuple.Create("% Poison Resist(Shield)", 35, 0));
            affixes.Add(Tuple.Create(" Damage Dealt to Attacker (Shield)", 14, 0));
            affixes.Add(Tuple.Create(" Adds 1-50 Lightning Damage (Sword)", 1, 50));
            affixes.Add(Tuple.Create(" Adds 3-14 Cold Damage (Sword)", 3, 14));
            affixes.Add(Tuple.Create(" Poison Damage Over 5 Seconds (Sword)", 75, 0));
            affixes.Add(Tuple.Create("% Life Stolen Per Hit (Sword)", 7, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Splendor")]
        public async Task SplendorImageAsync()
        {
            var name = "Splendor(37)";
            var slots = "Shield";
            var runes = "Eth + Lum";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To All Skills", 1, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 10, 0));
            affixes.Add(Tuple.Create("% Faster Block Rate", 20, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 60, 100));
            affixes.Add(Tuple.Create(" To Energy", 10, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 15, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 50, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 20, 0));
            affixes.Add(Tuple.Create(" To Light Radius", 3, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Stealth")]
        public async Task StealthImageAsync()
        {
            var name = "Stealth(17)";
            var slots = "Armor";
            var runes = "Tal + Eth";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Faster Run/Walk", 25, 0));
            affixes.Add(Tuple.Create("% Faster Casting Rate", 25, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 25, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 6, 0));
            affixes.Add(Tuple.Create("% Regenerate Mana", 15, 0));
            affixes.Add(Tuple.Create(" Maximum Stamina", 15, 0));
            affixes.Add(Tuple.Create("% Poison Resist", 30, 0));
            affixes.Add(Tuple.Create(" Magic Damage Taken", -3, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Steel")]
        public async Task SteelImageAsync()
        {
            var name = "Steel(13)";
            var slots = "Sword, Axe, Mace";
            var runes = "Tir + El";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Increased Attack Speed", 25, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 20, 0));
            affixes.Add(Tuple.Create(" To Minimum Damage", 3, 0));
            affixes.Add(Tuple.Create(" To Maximum Damage", 3, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 50, 0));
            affixes.Add(Tuple.Create("% Chance of Open Wounds", 50, 0));
            affixes.Add(Tuple.Create(" To Mana after each Kill", 2, 0));
            affixes.Add(Tuple.Create(" To Light Radius", 1, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Stone")]
        public async Task StoneImageAsync()
        {
            var name = "Stone(47)";
            var slots = "Armor";
            var runes = "Shael + Um + Pul + Lum";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 60, 0));
            affixes.Add(Tuple.Create("% Enhanced Defense", 250, 290));
            affixes.Add(Tuple.Create(" Defense Vs. Missile", 300, 0));
            affixes.Add(Tuple.Create(" To Strength", 16, 0));
            affixes.Add(Tuple.Create(" To Vitality", 16, 0));
            affixes.Add(Tuple.Create(" To Energy", 10, 0));
            affixes.Add(Tuple.Create(" All Resistances", 15, 0));
            affixes.Add(Tuple.Create("Level 16 Molten Boulder (80 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Level 16 Clay Golem (16 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Strength")]
        public async Task StrengthImageAsync()
        {
            var name = "Strength(25)";
            var slots = "Melee Weapons";
            var runes = "Amn + Tir";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Enhanced Damage", 35, 0));
            affixes.Add(Tuple.Create("% Life stolen per hit", 7, 0));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 25, 0));
            affixes.Add(Tuple.Create(" To Strength", 20, 0));
            affixes.Add(Tuple.Create(" To Vitality", 10, 0));
            affixes.Add(Tuple.Create(" To Mana after each Kill", 2, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Treachery")]
        public async Task TreacheryImageAsync()
        {
            var name = "Treachery(43)";
            var slots = "Armor";
            var runes = "Shael + Thul + Lem";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 15 Fade When Struck", 5, 0));
            affixes.Add(Tuple.Create("% Chance To Cast level 15 Venom On Striking", 25, 0));
            affixes.Add(Tuple.Create(" To Assassin Skills", 2, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 45, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 20, 0));
            affixes.Add(Tuple.Create("% Cold Resist", 30, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 50, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Venom")]
        public async Task VenomImageAsync()
        {
            var name = "Venom(49)";
            var slots = "All Weapons";
            var runes = "Tal + Dol + Mal";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("Ignore Target's Defense", 0, 0));
            affixes.Add(Tuple.Create(" Poison Damage Over 6 Seconds", 273, 0));
            affixes.Add(Tuple.Create("% Mana Stolen Per Hit", 7, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create("Hit Causes Monster To Flee 25%", 0, 0));
            affixes.Add(Tuple.Create("Level 13 Poison Nova (11 Charges)", 0, 0));
            affixes.Add(Tuple.Create("Level 15 Poison Explosion (27 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Voice of Reason")]
        [Alias("vor")]
        public async Task VoiceOfReasonImageAsync()
        {
            var name = "Voice of Reason(43)";
            var slots = "Mace, Sword";
            var runes = "Lem + Ko + El + Eld";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 13 Frozen Orb On Striking", 15, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 20 Ice Blast On Striking", 18, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 50, 0));
            affixes.Add(Tuple.Create("% Damage To Demons", 220, 350));
            affixes.Add(Tuple.Create("% Damage To Undead", 355, 375));
            affixes.Add(Tuple.Create(" To Attack Rating Against Undead", 50, 0));
            affixes.Add(Tuple.Create(" Cold Damage", 100, 220));
            affixes.Add(Tuple.Create("% To Enemy Cold Resistance", -24, 0));
            affixes.Add(Tuple.Create(" To Dexterity", 10, 0));
            affixes.Add(Tuple.Create("Cannot Be Frozen", 0, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 75, 0));
            affixes.Add(Tuple.Create(" To Light Radius", 1, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Wealth")]
        public async Task WealthImageAsync()
        {
            var name = "Wealth(43)";
            var slots = "Armor";
            var runes = "Lem + Ko + Tir";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To Dexterity", 10, 0));
            affixes.Add(Tuple.Create(" To Mana After Each Kill", 2, 0));
            affixes.Add(Tuple.Create("% Extra Gold From Monsters", 300, 0));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 100, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("White")]
        public async Task WhiteImageAsync()
        {
            var name = "White(35)";
            var slots = "Wand";
            var runes = "Dol + io";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create(" To Poison and Bone Skills (Necromancer Only)", 3, 0));
            affixes.Add(Tuple.Create("% Faster Cast Rate", 20, 0));
            affixes.Add(Tuple.Create(" To Bone Spear (Necromancer Only)", 3, 0));
            affixes.Add(Tuple.Create(" To Skeleton Mastery (Necromancer Only)", 4, 0));
            affixes.Add(Tuple.Create(" To Bone Armor (Necromancer Only)", 3, 0));
            affixes.Add(Tuple.Create("Hit causes monster to flee 25%", 0, 0));
            affixes.Add(Tuple.Create(" To vitality", 10, 0));
            affixes.Add(Tuple.Create(" To mana", 13, 0));
            affixes.Add(Tuple.Create(" Magic Damage Taken", -4, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Wind")]
        public async Task WindImageAsync()
        {
            var name = "Wind(61)";
            var slots = "Melee Weapons";
            var runes = "Sur + El";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 9 Tornado On Striking", 10, 0));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 20, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 40, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recovery", 15, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 120, 160));
            affixes.Add(Tuple.Create("% Target Defense", -50, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 50, 0));
            affixes.Add(Tuple.Create("Hit Blinds Target", 0, 0));
            affixes.Add(Tuple.Create(" To Light Radius", 1, 0));
            affixes.Add(Tuple.Create("Level 13 Twister (127 Charges)", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Wrath")]
        public async Task WrathImageAsync()
        {
            var name = "Wrath(63)";
            var slots = "Missile Weapons";
            var runes = "Pul + Lum + Ber + Mal";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance To Cast Level 1 Decrepify On Striking", 30, 0));
            affixes.Add(Tuple.Create("% Chance To Cast Level 10 Life Tap On Striking", 5, 0));
            affixes.Add(Tuple.Create("% Damage To Demons", 375, 0));
            affixes.Add(Tuple.Create(" To Attack Rating Against Demons", 100, 0));
            affixes.Add(Tuple.Create("% Damage To Undead", 250, 300));
            affixes.Add(Tuple.Create(" Magic Damage", 85, 120));
            affixes.Add(Tuple.Create(" Lightning Damage", 41, 240));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 20, 0));
            affixes.Add(Tuple.Create("Prevent Monster Heal", 0, 0));
            affixes.Add(Tuple.Create(" To Energy", 10, 0));
            affixes.Add(Tuple.Create("Cannot Be Frozen", 0, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }
        
        [Command("Zephyr")]
        public async Task ZephyrImageAsync()
        {
            var name = "Zephyr(21)";
            var slots = "Missile Weapons";
            var runes = "Ort + Eth";
            
            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to Cast Level 1 Twister When Struck", 7, 0));
            affixes.Add(Tuple.Create("% Faster Run/Walk", 25, 0));
            affixes.Add(Tuple.Create("% Increased Attack Speed", 25, 0));
            affixes.Add(Tuple.Create("% Enhanced Damage", 33, 0));
            affixes.Add(Tuple.Create("% Target Defense", -25, 0));
            affixes.Add(Tuple.Create(" To Attack Rating", 66, 0));
            affixes.Add(Tuple.Create(" lightning damage", 1, 50));
            affixes.Add(Tuple.Create(" Defense", 25, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }                           
    }
}
