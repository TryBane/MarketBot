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

        public async Task CreateRunewordImage(List<Tuple<string, int,int>> affixes, string name, string slots, string runes )
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
            affixes.Add(Tuple.Create(" to Attack Rating", 200, 0));
            affixes.Add(Tuple.Create(" Cold Damage", 3, 14));
            affixes.Add(Tuple.Create("% Chance of Crushing Blow", 40, 0));
            affixes.Add(Tuple.Create(" Knockback", 0, 0));
            affixes.Add(Tuple.Create(" to Vitality", 10, 0));
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
            affixes.Add(Tuple.Create("To Thorns Aura When Equipped", 15, 21));
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
            var slots = "Missile Weapon";
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
            var slots = "Weapons";
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
        public async Task DragonImageAsync()
        {
            var name = "Dragon(61)";
            var slots = "Armor, Shield";
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
            affixes.Add(Tuple.Create("% Increase Maximum Mana (Armor)", 5, 0));
            affixes.Add(Tuple.Create(" To Mana (Shield)", 50, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }

        [Command("Dragon Armor")]
        public async Task DragonArmorImageAsync()
        {
            var name = "Dragon(61)";
            var slots = "Armor";
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
            affixes.Add(Tuple.Create("% Increase Maximum Mana", 5, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }

        [Command("Dragon Shield")]
        public async Task DragonShieldImageAsync()
        {
            var name = "Dragon(61)";
            var slots = "Shield";
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
            affixes.Add(Tuple.Create(" To Mana", 50, 0));

            await CreateRunewordImage(affixes, name, slots, runes);
        }

        [Command("Dream")]
        public async Task DreamImageAsync()
        {
            var name = "Dream(65)";
            var slots = "Helm, Shield";
            var runes = "io + Jah + Pul";

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to cast level 15 Confuse when struck", 10, 0));
            affixes.Add(Tuple.Create("Level 15 Holy Shock Aura when equipped", 0, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recover", 20, 30));
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 0));
            affixes.Add(Tuple.Create(" Defense", 150, 220));
            affixes.Add(Tuple.Create(" To Vitality", 10, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Life (Helm)", 5, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Life (Shield)", 50, 0));
            affixes.Add(Tuple.Create(" To Mana (Based on Character Level)", 0, 61));
            affixes.Add(Tuple.Create(" All Resistances", 5, 20));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 12, 25));

            await CreateRunewordImage(affixes, name, slots, runes);
        }

        [Command("Dream Helm")]
        public async Task DreamHelmImageAsync()
        {
            var name = "Dream(65)";
            var slots = "Helm";
            var runes = "io + Jah + Pul";

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to cast level 15 Confuse when struck", 10, 0));
            affixes.Add(Tuple.Create("Level 15 Holy Shock Aura when equipped", 0, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recover", 20, 30));
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 0));
            affixes.Add(Tuple.Create(" Defense", 150, 220));
            affixes.Add(Tuple.Create(" To Vitality", 10, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Life", 5, 0));
            affixes.Add(Tuple.Create(" To Mana (Based on Character Level)", 0, 61));
            affixes.Add(Tuple.Create(" All Resistances", 5, 20));
            affixes.Add(Tuple.Create("% Better Chance of Getting Magic Items", 12, 25));

            await CreateRunewordImage(affixes, name, slots, runes);
        }

        [Command("Dream Shield")]
        public async Task DreamShieldImageAsync()
        {
            var name = "Dream(65)";
            var slots = "Shield";
            var runes = "io + Jah + Pul";

            var affixes = new List<Tuple<string, int, int>>();
            affixes.Add(Tuple.Create("% Chance to cast level 15 Confuse when struck", 10, 0));
            affixes.Add(Tuple.Create("Level 15 Holy Shock Aura when equipped", 0, 0));
            affixes.Add(Tuple.Create("% Faster Hit Recover", 20, 30));
            affixes.Add(Tuple.Create("% Enhanced Defense", 30, 0));
            affixes.Add(Tuple.Create(" Defense", 150, 220));
            affixes.Add(Tuple.Create(" To Vitality", 10, 0));
            affixes.Add(Tuple.Create("% Increase Maximum Life", 50, 0));
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
            affixes.Add(Tuple.Create("To All Attributes", 5, 10));
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
            var slots = "Missile Weapon";
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
            affixes.Add(Tuple.Create("% Enhanced Defense", 200, 0));
            affixes.Add(Tuple.Create(" All Resistances", 25, 30));
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
    }
}
