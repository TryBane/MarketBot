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
    public class Sets : ModuleBase<SocketCommandContext>
    {
        private readonly ILogger<Uniques> _logger;
        private readonly Images _images;
        private readonly ServerHelper _serverHelper;

        public Sets(ILogger<Uniques> logger, Images images, ServerHelper serverHelper)
        {
            _logger = logger;
            _images = images;
            _serverHelper = serverHelper;
        }
        private async Task CreateSetImage(List<Tuple<string, int, int>> affixes, List<Tuple<string, int, int, string>> setBonuses, string name, List<string> requirements, string setPieces, string imageLink, string numOfPieces = null)
        {
            string path = await _images.CreateSetImageAsync(affixes, setBonuses, name, requirements, imageLink);

            if (numOfPieces == null)
            {
                await Context.Channel.SendFileAsync(path, setPieces);
            }
            else if( (Int32.Parse(numOfPieces) > 0) )
            {
                string replacement = setPieces.Replace("***", "");

                await Context.Channel.SendFileAsync(path, replacement);
            }
            else
            {
                await Context.Channel.SendFileAsync(path);
            }
            File.Delete(path);
        }
        private string ParseSetPieces(string name, string setName)
        {
            var setPieces = GetSetPieces(setName);
            var setMessage = $"**{setName}**:\n\n";

            name = name.Remove(name.IndexOf('('));

            foreach(var setPiece in setPieces.Item1)
            {
                var messageAddition = setPiece;

                if (setPiece.Equals(name))
                {
                    messageAddition = setPiece.Replace(name, $"***{name}***");
                }
                setMessage += messageAddition + "\n";
            }

            return setMessage;
        }


        private Tuple<List<string>, List<Tuple<string, int, int, string>>> GetSetPieces(string setName)
        {
            List<string> setPieces;
            List<Tuple<string, int, int, string>> setBonuses;

            switch (setName)
            {
                case "Berserker's Arsenal":
                    setPieces = new List<string>
                    {
                        "Berserker's Headgear",
                        "Berserker's Hauberk",
                        "Berserker's Hatchet"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" To Life", 50, 0, "2"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Defense", 75, 0, ""),
                        Tuple.Create("% Poison Length Reduction", 75, 0, ""),
                        Tuple.Create(" Poison Damage over 3 seconds", 5, 9, "")
                    };
                    break;
                case "Arcanna's Tricks":
                    setPieces = new List<string>
                    {
                        "Arcanna's Deathwand",
                        "Arcanna's Flesh",
                        "Arcanna's Head",
                        "Arcanna's Sign"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Mana", 25, 0, "2"),
                        Tuple.Create(" Life", 50, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Mana", 50, 0, ""),
                        Tuple.Create(" Life", 50, 0, ""),
                        Tuple.Create("% Faster Cast Rate", 20, 0, ""),
                        Tuple.Create("% Mana Stolen per Hit", 5, 0, "")
                    };
                    break;
                case "Arctic Gear":
                    setPieces = new List<string>
                    {
                        "Arctic Horn",
                        "Arctic Furs",
                        "Arctic Mitts",
                        "Arctic Binding"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Strength", 5, 0, "2"),
                        Tuple.Create(" Life", 50, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Strength", 5, 0, ""),
                        Tuple.Create(" Life", 50, 0, ""),
                        Tuple.Create("Cannot be Frozen", 0, 0, ""),
                        Tuple.Create(" Cold Damage", 6, 14, "")
                    };
                    break;
                case "Cathan's Traps":
                    setPieces = new List<string>
                    {
                        "Cathan's Rule",
                        "Cathan's Mesh",
                        "Cathan's Visage",
                        "Cathan's Sigil",
                        "Cathan's Seal"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Fire Damage", 15, 20, "2"),
                        Tuple.Create("% Resist Lightning", 25, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create("% Resist Lightning", 25, 0, ""),                   
                        Tuple.Create(" Fire Damage", 15, 20, ""),
                        Tuple.Create("% Faster Cast Rate", 10, 0, ""),
                        Tuple.Create(" Magic Damage Reduced", 3, 0, ""),
                        Tuple.Create(" All Resistances", 25, 0, ""),
                        Tuple.Create(" Attack Rating", 60, 0, ""),
                        Tuple.Create(" Mana", 20, 0, "")
                    };
                    break;
                case "Civerb's Vestments":
                    setPieces = new List<string>
                    {
                        "Civerb's Cudgel",
                        "Civerb's Ward",
                        "Civerb's Icon"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create("% Fire Resist", 15, 0, "2"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create("% Damage to Undead", 200, 0, ""),
                        Tuple.Create(" Strength", 15, 0, ""),
                        Tuple.Create("% Fire Resist", 15, 0, ""),
                        Tuple.Create("% Lightning Resist", 25, 0, "")
                    };
                    break;
                case "Cleglaw's Brace":
                    setPieces = new List<string>
                    {
                        "Cleglaw's Tooth",
                        "Cleglaw's Claw",
                        "Cleglaw's Pincers"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Defense", 50, 0, "2"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Defense", 100, 0, ""),
                        Tuple.Create("% Chance of Crushing Blow", 35, 0, ""),
                        Tuple.Create("% Mana Stolen per Hit", 6, 0, ""),
                        Tuple.Create("% Increased Attack Speed", 20, 0, "")
                    };
                    break;
                case "Angelic Raiment":
                    setPieces = new List<string>
                    {
                        "Angelic Sickle",
                        "Angelic Mantle",
                        "Angelic Wings",
                        "Angelic Halo"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Dexterity", 10, 0, "2"),
                        Tuple.Create(" Mana", 50, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create("Half Freeze Duration", 0, 0, ""),
                        Tuple.Create(" All Resistances", 25, 0, ""),
                        Tuple.Create("% Better Chance of Getting Magic Item", 40, 0, ""),
                        Tuple.Create("% Regenerate Mana", 8, 0, ""),
                        Tuple.Create(" Dexterity", 10, 0, ""),
                        Tuple.Create(" Mana", 50, 0, "")
                    };
                    break;
                case "Hsarus' Defense":
                    setPieces = new List<string>
                    {
                        "Hsarus' Iron Fist",
                        "Hsarus' Iron Stay",
                        "Hsarus' Iron Heel"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Damage Taken by Attacker", 5, 0, "2"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Damage Taken by Attacker", 5, 0, ""),
                        Tuple.Create("Cannot be Frozen", 0, 0, ""),
                        Tuple.Create("% Lightning Resist", 25, 0, ""),
                        Tuple.Create(" Maximum Damage", 5, 0, "")
                    };
                    break;
                case "Infernal Tools":
                    setPieces = new List<string>
                    {
                        "Infernal Torch",
                        "Infernal Cranium",
                        "Infernal Sign"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Poison Damage Over 3 Seconds", 8, 0, "2"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Poison Damage Over 3 Seconds", 8, 0, ""),
                        Tuple.Create("% Chance of Open Wounds", 20, 0, ""),
                        Tuple.Create("Necromancer Skill Levels", 1, 0, ""),
                        Tuple.Create("% Bonus to Attack Rating", 20, 0, ""),
                        Tuple.Create("% Mana Stolen per Hit", 6, 0, "")
                    };
                    break;
                case "Iratha's Finery":
                    setPieces = new List<string>
                    {
                        "Iratha's Coil",
                        "Iratha's Cuff",
                        "Iratha's Cord",
                        "Iratha's Collar"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Defense", 50, 0, "2"),
                        Tuple.Create("% Faster Run/Walk", 20, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create("% Faster Run/Walk", 20, 0, ""),
                        Tuple.Create(" Defense", 50, 0, ""),
                        Tuple.Create(" Dexterity", 15, 0, ""),
                        Tuple.Create("% to Maximum Poison Resist", 10, 0, ""),
                        Tuple.Create("% to Maximum Cold Resist", 10, 0, ""),
                        Tuple.Create("% to Maximum Lightning Resist", 10, 0, ""),
                        Tuple.Create("% to Maximum Fire Resist", 10, 0, ""),
                        Tuple.Create(" All Resistances", 20, 0, "")
                    };
                    break;

                case "Isenhart's Armory":
                    setPieces = new List<string>
                    {
                        "Isenhart's Lightbrand",
                        "Isenhart's Case",
                        "Isenhart's Parry",
                        "Isenhart's Horns"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Strength", 10, 0, "2"),
                        Tuple.Create(" Dexterity", 10, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Strength", 10, 0, ""),
                        Tuple.Create(" Dexterity", 10, 0, ""),
                        Tuple.Create("% Faster Run/Walk", 20, 0, ""),
                        Tuple.Create("% Increased Chance of Blocking", 30, 0, ""),
                        Tuple.Create("% Bonus to Attack Rating", 35, 0, ""),
                        Tuple.Create("% Life Stolen per Hit", 5, 0, ""),
                        Tuple.Create(" All Resistances", 10, 0, "")
                    };
                    break;

                case "Milabrega's Regalia":
                    setPieces = new List<string>
                    {
                        "Milabrega's Rod",
                        "Milabrega's Robe",
                        "Milabrega's Orb",
                        "Milabrega's Diadem"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Attack Rating", 75, 0, "2"),
                        Tuple.Create(" Attack Rating", 125, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Attack Rating", 200, 0, ""),
                        Tuple.Create(" Paladin Skill Levels", 2, 0, ""),
                        Tuple.Create("% Life Stolen per Hit", 8, 0, ""),
                        Tuple.Create("% Mana Stolen per Hit", 10, 0, ""),
                        Tuple.Create("% Poison Resist", 15, 0, "")
                    };
                    break;
                case "Sigon's Complete Steel":
                    setPieces = new List<string>
                    {
                        "Sigon's Shelter",
                        "Sigon's Guard",
                        "Sigon's Visor",
                        "Sigon's Gage",
                        "Sigon's Wrap",
                        "Sigon's Sabot"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create("% Life Stolen per Hit", 10, 0, "2"),
                        Tuple.Create(" Defense", 100, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create("% Life Stolen per Hit", 10, 0, ""),
                        Tuple.Create(" Defense", 100, 0, ""),
                        Tuple.Create(" Mana", 20, 0, ""),
                        Tuple.Create("% Fire Resist", 12, 0, ""),
                        Tuple.Create(" Maximum Fire Damage", 24, 0, ""),
                        Tuple.Create(" Damage Taken by Attackers", 12, 0, ""),
                        Tuple.Create(" Damage Reduced", 7, 0, "")
                    };
                    break;
                case "Tancred's Battlegear":
                    setPieces = new List<string>
                    {
                        "Tancred's Crowbill",
                        "Tancred's Spine",
                        "Tancred's Skull",
                        "Tancred's Hobnails",
                        "Tancred's Weird"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Lightning Damage", 15, 0, "2"),
                        Tuple.Create("% Life Stolen per Hit", 5, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Lightning Damage", 15, 0, ""),
                        Tuple.Create("% Life Stolen per Hit", 5, 0, ""),
                        Tuple.Create("% Slows Target", 35, 0, ""),
                        Tuple.Create("% Mana Stolen per Hit", 5, 0, ""),
                        Tuple.Create(" All Resistances", 10, 0, ""),
                        Tuple.Create("% Extra Gold From Monsters", 75, 0, "")
                    };
                    break;
                case "Death's Disguise":
                    setPieces = new List<string>
                    {
                        "Death's Touch",
                        "Death's Hand",
                        "Death's Guard"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create("% Life Stolen per Hit", 8, 0, "2"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create("% Life Stolen per Hit", 8, 0, ""),
                        Tuple.Create("% Bonus to Attack Rating", 40, 0, ""),
                        Tuple.Create(" All Resistances", 25, 0, ""),
                        Tuple.Create(" Minimum Damage", 10, 0, "")
                    };
                    break;
                case "Vidala's Rig":
                    setPieces = new List<string>
                    {
                        "Vidala's Barb",
                        "Vidala's Ambush",
                        "Vidala's Fetlock",
                        "Vidala's Snare"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Attack Rating", 75, 0, "2"),
                        Tuple.Create(" Dexterity", 15, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Attack Rating", 75, 0, ""),
                        Tuple.Create(" Cold Damage", 15, 20, ""),
                        Tuple.Create("% Piercing Attack", 50, 0, ""),
                        Tuple.Create("Freezes Target", 0, 0, ""),
                        Tuple.Create(" Dexterity", 15, 0, ""),
                        Tuple.Create(" Strength", 10, 0, "")
                    };
                    break;
                case "Heaven's Brethren":
                    setPieces = new List<string>
                    {
                        "Dangoon's Teaching",
                        "Haemosu's Adamant",
                        "Taebaek's Glory",
                        "Ondal's Almighty"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Heal Stamina", 50, 0, "2"),
                        Tuple.Create(" Replenish Life", 20, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" All Skills", 2, 0, ""),
                        Tuple.Create(" Replenish Life", 20, 0, ""),
                        Tuple.Create(" Heal Stamina", 50, 0, ""),
                        Tuple.Create(" All Resistances", 50, 0, ""),
                        Tuple.Create("Cannot be Frozen", 0, 0, ""),
                        Tuple.Create(" Light Radius", 5, 0, "")
                    };
                    break;
                case "The Disciple":
                    setPieces = new List<string>
                    {
                        "Dark Adherent",
                        "Laying of Hands",
                        "Credendum",
                        "Rite of Passage",
                        "Telling of Beads"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Defense", 150, 0, "2"),
                        Tuple.Create(" Poison Damage Over 3 Seconds", 22, 0, "3"),
                        Tuple.Create(" Strength", 10, 0, "4"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Strength", 10, 0, ""),
                        Tuple.Create(" Defense", 150, 0, ""),
                        Tuple.Create(" Poison Damage Over 3 Seconds", 22, 0, ""),
                        Tuple.Create(" All Skills", 2, 0, ""),
                        Tuple.Create(" All Resistances", 50, 0, ""),
                        Tuple.Create(" Mana", 100, 0, "")
                    };
                    break;
                case "Hwanin's Majesty":
                    setPieces = new List<string>
                    {
                        "Hwanin's Justice",
                        "Hwanin's Refuge",
                        "Hwanin's Splendor",
                        "Hwanin's Blessing"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Defense", 100, 0, "2"),
                        Tuple.Create(" Defense", 200, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Defense", 300, 0, ""),
                        Tuple.Create(" All Skills", 2, 0, ""),
                        Tuple.Create("% Faster Run/Walk", 30, 0, ""),
                        Tuple.Create("% Life Stolen per Hit", 20, 0, ""),
                        Tuple.Create(" All Resistances", 30, 0, "")
                    };
                    break;
                case "Cow King's Leathers":
                    setPieces = new List<string>
                    {
                        "Cow King's Horns",
                        "Cow King's Hide",
                        "Cow King's Hooves"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create("% Poison Resist", 25, 0, "2"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create("% Poison Resist", 25, 0, ""),
                        Tuple.Create("% Chance to Cast Level 5 Static Field When Struck", 25, 0, ""),
                        Tuple.Create(" Maximum Stamina", 100, 0, ""),
                        Tuple.Create(" Strength", 20, 0, ""),
                        Tuple.Create("% Increased Attack Speed", 30, 0, ""),                     
                        Tuple.Create("% Better Chance of Getting Magic Items", 100, 0, "")
                    };
                    break;
                case "Naj's Ancient Vestige":
                    setPieces = new List<string>
                    {
                        "Naj's Puzzler",
                        "Naj's Light Plate",
                        "Naj's Circlet"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Defense", 175, 0, "2"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Defense", 175, 0, ""),
                        Tuple.Create(" Dexterity", 15, 0, ""),
                        Tuple.Create(" All Resistances", 50, 0, ""),
                        Tuple.Create(" Strength", 20, 0, ""),
                        Tuple.Create(" Mana", 100, 0, ""),
                        Tuple.Create(" All Skills", 1, 0, "")
                    };
                    break;
                case "Sander's Folly":
                    setPieces = new List<string>
                    {
                        "Sander's Paragon",
                        "Sander's Superstition",
                        "Sander's Taboo",
                        "Sander's Riprap"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Defense", 50, 0, "2"),
                        Tuple.Create(" Attack Rating", 75, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Defense", 50, 0, ""),
                        Tuple.Create(" Attack Rating", 75, 0, ""),
                        Tuple.Create(" All Skills", 1, 0, ""),
                        Tuple.Create("% Life Stolen per Hit", 4, 0, ""),
                        Tuple.Create(" Mana", 50, 0, ""),
                        Tuple.Create("% Better Chance of Getting Magic Items", 50, 0, "")
                    };
                    break;
                case "Sazabi's Grand Tribute":
                    setPieces = new List<string>
                    {
                        "Sazabi's Cobalt Redeemer",
                        "Sazabi's Ghost Liberator",
                        "Sazabi's Mental Sheath"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create("% Faster Run/Walk", 40, 0, "2"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create("% Faster Run/Walk", 40, 0, ""),
                        Tuple.Create("% Life Stolen per Hit", 15, 0, ""),
                        Tuple.Create("% Increase Maximum Life", 27, 0, ""),
                        Tuple.Create(" All Resistances", 30, 0, "")
                    };
                    break;
                case "Orphan's Call":
                    setPieces = new List<string>
                    {
                        "Guillaume's Face",
                        "Whitstan's Guard",
                        "Magnus' Skin",
                        "Wilhelm's Pride"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Life", 35, 0, "2"),
                        Tuple.Create(" Damage Taken by Attackers", 5, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Life", 85, 0, ""),
                        Tuple.Create(" Damage Taken by Attackers", 5, 0, ""),
                        Tuple.Create(" All Resistances", 15, 0, ""),
                        Tuple.Create(" Defense", 100, 0, ""),
                        Tuple.Create(" Dexterity", 10, 0, ""),
                        Tuple.Create(" Strength", 20, 0, ""),
                        Tuple.Create("% Better Chance of Getting Magic Items", 80, 0, "")
                    };
                    break;
                case "Aldur's Watchtower":
                    setPieces = new List<string>
                    {
                        "Aldur's Rhythm",
                        "Aldur's Deception",
                        "Aldur's Stony Gaze",
                        "Aldur's Advance"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create("% Bonus to Attack Rating", 150, 0, "2"),
                        Tuple.Create("% Better Chance of Getting Magic Items", 50, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Druid Skills", 3, 0, ""),
                        Tuple.Create("% Enhanced Damage", 350, 0, ""),
                        Tuple.Create("% Bonus to Attack Rating", 150, 0, ""),
                        Tuple.Create("% Better Chance of Getting Magic Items", 50, 0, ""),
                        Tuple.Create("% Mana Stolen per Hit", 10, 0, ""),
                        Tuple.Create(" All Resistances", 50, 0, ""),
                        Tuple.Create(" Defense", 150, 0, ""),
                        Tuple.Create(" Mana", 150, 0, "")
                    };
                    break;
                case "Bul-Kathos' Children":
                    setPieces = new List<string>
                    {
                        "Bul-Kathos' Sacred Charge",
                        "Bul-Kathos' Tribal Guardian"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" All Skill Levels", 2, 0, ""),
                        Tuple.Create(" Attack Rating", 200, 0, ""),
                        Tuple.Create("% Damage to Demons", 200, 0, "")
                    };
                    break;
                case "Griswold's Legacy":
                    setPieces = new List<string>
                    {
                        "Griswold's Redemption",
                        "Griswold's Heart",
                        "Griswold's Honor",
                        "Griswold's Valor"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Strength", 20, 0, "2"),
                        Tuple.Create(" Dexterity", 30, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Paladin Skill Levels", 3, 0, ""),
                        Tuple.Create("% Faster Hit Recovery", 30, 0, ""),
                        Tuple.Create(" Attack Rating", 200, 0, ""),
                        Tuple.Create(" Strength", 20, 0, ""),
                        Tuple.Create(" Dexterity", 30, 0, ""),
                        Tuple.Create(" Life", 150, 0, ""),
                        Tuple.Create(" All Resistances", 50, 0, ""),
                        Tuple.Create(" Display Aura", 0, 0, "")
                    };
                    break;
                case "M'avina's Battle Hymn":
                    setPieces = new List<string>
                    {
                        "M'avina's Caster",
                        "M'avina's Embrace",
                        "M'avina's True Sight",
                        "M'avina's Icy Clutch",
                        "M'avina's Tenet"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Strength", 20, 0, "2"),
                        Tuple.Create(" Dexterity", 30, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Amazon Skill Levels", 3, 0, ""),
                        Tuple.Create(" Strength", 20, 0, ""),
                        Tuple.Create(" Dexterity", 30, 0, ""),
                        Tuple.Create(" All Resistances", 50, 0, ""),
                        Tuple.Create(" Defense", 100, 0, ""),
                        Tuple.Create(" Attack Rating", 100, 0, ""),
                        Tuple.Create("% Better Chance of Getting Magic Items", 100, 0, ""),
                        Tuple.Create(" Display Aura", 0, 0, "")
                    };
                    break;
                case "Natalya's Odium":
                    setPieces = new List<string>
                    {
                        "Natalya's Mark",
                        "Natalya's Shadow",
                        "Natalya's Totem",
                        "Natalya's Soul"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Magic Damage Reduced", 15, 0, "2"),
                        Tuple.Create(" Defense", 200, 0, "3"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Assassin Skill Levels", 3, 0, ""),
                        Tuple.Create(" Defense", 350, 0, ""),
                        Tuple.Create("% Life Stolen per Hit", 14, 0, ""),
                        Tuple.Create("% Mana Stolen per Hit", 14, 0, ""),
                        Tuple.Create(" All Resistances", 50, 0, ""),
                        Tuple.Create("% Damage Reduced", 30, 0, ""),
                        Tuple.Create(" Magic Damage Reduced", 15, 0, ""),
                        Tuple.Create(" Fade", 0, 0, "")
                    };
                    break;
                case "Tal Rasha's Wrappings":
                    setPieces = new List<string>
                    {
                        "Tal Rasha's Lidless Eye",
                        "Tal Rasha's Guardianship",
                        "Tal Rasha's Horadric Crest",
                        "Tal Rasha's Fine-Spun Cloth",
                        "Tal Rasha's Adjudication"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Replenish Life", 10, 0, "2"),                     
                        Tuple.Create("% Better Chance of Getting Magic Items", 65, 0, "3"),
                        Tuple.Create("% Faster Hit Recovery", 25, 0, "4"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),                      
                        Tuple.Create(" Sorceress Skill Levels", 3, 0, ""),
                        Tuple.Create(" Replenish Life", 10, 0, "2"),
                        Tuple.Create("% Better Chance of Getting Magic Items", 65, 0, "3"),
                        Tuple.Create("% Faster Hit Recovery", 25, 0, ""),
                        Tuple.Create(" Life", 150, 0, ""),
                        Tuple.Create(" All Resistances", 50, 0, ""),
                        Tuple.Create(" Defense vs. Missile", 50, 0, ""),
                        Tuple.Create(" Defense", 150, 0, ""),
                        Tuple.Create(" Display Aura", 0, 0, "")
                    };
                    break;
                case "Immortal King":
                    setPieces = new List<string>
                    {
                        "Immortal King's Stone Crusher",
                        "Immortal King's Soul Cage",
                        "Immortal King's Will",
                        "Immortal King's Forge",
                        "Immortal King's Detail",
                        "Immortal King's Pillar"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Attack Rating", 50, 0, "2"),
                        Tuple.Create(" Additional to Attack Rating", 75, 0, "3"),
                        Tuple.Create(" Additional to Attack Rating", 125, 0, "4"),
                        Tuple.Create(" Additional to Attack Rating", 200, 0, "5"),                        
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Barbarian Skill Levels", 3, 0, ""),
                        Tuple.Create(" Attack Rating", 450, 0, ""),
                        Tuple.Create(" Life", 150, 0, ""),
                        Tuple.Create(" All Resistances", 50, 0, ""),
                        Tuple.Create(" Magic Damage Reduced", 10, 0, ""),
                        Tuple.Create(" Display Aura", 0, 0, "")
                    };
                    break;
                case "Trang-Oul's Avatar":
                    setPieces = new List<string>
                    {
                        "Trang-Oul's Scales",
                        "Trang-Oul's Wing",
                        "Trang-Oul's Guise",
                        "Trang-Oul's Claws",
                        "Trang-Oul's Girth"
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create(" Fire Ball", 18, 0, "2"),
                        Tuple.Create("% Regenerate Mana", 15, 0, "2"),
                        Tuple.Create(" Fire Wall", 13, 0, "3"),
                        Tuple.Create("% Additional Regenerate Mana", 15, 0, "3"),
                        Tuple.Create(" Meteor", 10, 0, "4"),
                        Tuple.Create("% Additional Regenerate Mana", 15, 0, "4"),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create(" Necromancer Skill Levels", 3, 0, ""),
                        Tuple.Create("% Life Stolen per Hit", 20, 0, ""),
                        Tuple.Create(" Fire Mastery", 3, 0, ""),
                        Tuple.Create(" Meteor", 10, 0, ""),
                        Tuple.Create(" Fire Wall", 13, 0, ""),
                        Tuple.Create(" Fire Ball", 18, 0, ""),
                        Tuple.Create(" Defense", 200, 0, ""),
                        Tuple.Create(" Mana", 100, 0, ""),
                        Tuple.Create("% Regenerate Mana", 60, 0, ""),
                        Tuple.Create(" Replenish Life", 5, 0, ""),
                        Tuple.Create(" All Resistances", 50, 0, ""),
                        Tuple.Create("Transforms into Vampire", 0, 0, "")
                    };
                    break;
                default:
                    setPieces = new List<string>{};
                    setBonuses = new List<Tuple<string, int, int, string>> {};
                    break;
                    
            }

            return Tuple.Create(setPieces,setBonuses);
        }

        [Command("Set")]
        [Alias("Sets")]
        public async Task SetListAsync()
        {
            string message = "";

            {
                message += "Angelic Raiment\n";
                message += "Arcanna's Tricks\n";
                message += "Arctic Gear\n";
                message += "Berserker's Arsenal\n";
                message += "Cathan's Traps\n";
                message += "Civerb's Vestments\n";
                message += "Cleglaw's Brace\n";
                message += "Death's Disguise\n";
                message += "Hsarus' Defense\n";
                message += "Infernal Tools\n";
                message += "Iratha's Finery\n";
                message += "Isenhart's Armory\n";
                message += "Milabrega's Regalia\n";
                message += "Sigon's Complete Steel\n";
                message += "Tancred's Battlegear\n";
                message += "Vidala's Rig\n";
                message += "Aldur's Watchtower\n";
                message += "Bul-Kathos' Children\n";
                message += "Cow King's Leathers\n";
                message += "The Disciple\n";
                message += "Griswold's Legacy\n";
                message += "Heaven's Brethren\n";
                message += "Hwanin's Majesty\n";
                message += "Immortal King\n";
                message += "M'avina's Battle Hymn\n";
                message += "Natalya's Odium\n";
                message += "Naj's Ancient Vestige\n";
                message += "Orphan's Call\n";
                message += "Sander's Folly\n";
                message += "Sazabi's Grand Tribute\n";
                message += "Tal Rasha's Wrappings\n";
                message += "Trang-Oul's Avatar\n";

            }

            await Context.Channel.SendMessageAsync(message);
        }

        /*
        [Command("")]
        public async Task ImageAsync()
        {
            await ImageAsync();
            await ImageAsync();
            await ImageAsync();

        }

        [Command("")]
        public async Task ImageAsync()
        {
            var name = "";
            var imageLink = "";
            var setName = "";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , )

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("")]
        public async Task ImageAsync()
        {
            var name = "";
            var imageLink = "";
            var setName = "";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , )

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("")]
        public async Task ImageAsync()
        {
            var name = "";
            var imageLink = "";
            var setName = "";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , ),
                Tuple.Create("", , )

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        */
        [Command("Berserker's Arsenal")]
        public async Task ImageBerserkersArsenalAsync()
        {
            await ImageBerserkersHeadgearAsync("3");
            await ImageBerserkerHauberkAsync("0");
            await ImageBerserkersHatchetkAsync("0");
        }

        [Command("Berserker's Headgear")]
        [Alias("BHG")]
        public async Task ImageBerserkersHeadgearAsync([Remainder] string args = null)
        {
            var name = "Berserker's Headgear(3)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/berserkers_headgear_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Berserker's Arsenal";
            var requirements = new List<string>
            {
                "26 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 15, 18),
                Tuple.Create(" Bonus Defense", 15, 0),
                Tuple.Create("% Fire Resistance", 25, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Attack Rating(Based On Character Level)", 48, 792, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }

        [Command("Berserker's Hauberk")]
        [Alias("BHK")]
        public async Task ImageBerserkerHauberkAsync([Remainder] string args = null)
        {
            var name = "Berserker's Hauberk(3)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/splint_mail_armor_diablo2_wiki_guide_196px.png";
            var setName = "Berserker's Arsenal";
            var requirements = new List<string>
            {
                "51 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 90, 95),
                Tuple.Create(" To Barbarian Skills", 1, 0),
                Tuple.Create(" Magic Damage Taken", -2, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Bonuse Defense(Based On Character Level)", 3, 297, "2")
            };
            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }

        [Command("Berserker's Hatchet")]
        [Alias("BH")]
        public async Task ImageBerserkersHatchetkAsync([Remainder] string args = null)
        {
            var name = "Berserker's Hatchet(3)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/double_axe_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var setName = "Berserker's Arsenal";
            var requirements = new List<string>
            {
                "43 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" One-Handed Damage", 5, 13),
                Tuple.Create(" One-Handed Damage", 7, 19),
                Tuple.Create("% Bonus To Attack Rating", 30, 0),
                Tuple.Create("% Mana Stolen Per Hit", 5, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Enhanced Damage", 50, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        
                
        [Command("Arcanna's Tricks")]
        public async Task ArcannasTricksImageAsync()
        {
            await ArcannasDeathwandImageAsync("3");
            await ArcannasFleshImageAsync("0");
            await ArcannasHeadImageAsync("0");
            await ArcannasSignImageAsync("0");

        }

        [Command("Arcanna's Deathwand")]
        public async Task ArcannasDeathwandImageAsync([Remainder] string args = null)
        {
            var name = "Arcanna's Deathwand(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_staf_diablo_2_wiki_guide_125px.png";
            var setName = "Arcanna's Tricks";
            var requirements = new List<string>
            {
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Damage to Undead", 50, 0),
                Tuple.Create(" Sorceress Skill Levels", 1, 0),
                Tuple.Create("% Deadly Strike", 25, 0),

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Mana", 50, 0, "2"),
                Tuple.Create("% Regenerate Mana ", 5, 0, "3")
                
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }

        [Command("Arcanna's Flesh")]
        public async Task ArcannasFleshImageAsync([Remainder] string args = null)
        {
            var name = "Arcanna's Flesh(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_plate_diablo2_wiki_guide_196px.png";
            var setName = "Arcanna's Tricks";
            var requirements = new List<string>
            {
                "41 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Light Radius", 2, 0),
                Tuple.Create(" Damage Reduced", 3, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense ", 100, 0, "2"),
                Tuple.Create(" Energy ", 10, 0 , "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }

        [Command("Arcanna's Head")]
        public async Task ArcannasHeadImageAsync([Remainder] string args = null)
        {
            var name = "Arcanna's Head(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/skull_cap_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Arcanna's Tricks";
            var requirements = new List<string>
            {
                "15 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Replenish Life", 4, 0),
                Tuple.Create(" Damage Taken by Attackers", 2, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense (Based on Character Level)", 3, 297, "2"),
                Tuple.Create("% Lightning Resist", 15, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }

        [Command("Arcanna's Sign")]
        public async Task ArcannasSignImageAsync([Remainder] string args = null)
        {
            var name = "Arcanna's Sign(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet3_diablo2_wiki_guide_98px.png";
            var setName = "Arcanna's Tricks";
            var requirements = new List<string>
            {
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Regenerate Mana", 20, 0),
                Tuple.Create(" Mana", 15, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Better Chance of Getting Magic Items", 50, 0, "2"),
                Tuple.Create("% Fire Resist", 20, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Arctic Gear")]
        public async Task ArcticGearImageAsync()
        {
            await ArcticHornImageAsync("3");
            await ArcticFursImageAsync("0");
            await ArcticMittsImageAsync("0");
            await ArcticBindingImageAsync("0");

        }

        [Command("Arctic Horn")]
        public async Task ArcticHornImageAsync([Remainder] string args = null)
        {
            var name = "Arctic Horn(2)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hellclap_weapons_diablo_2_resurrected_wiki_guide.png";
            var setName = "Arctic Gear";
            var requirements = new List<string>
            {
                "35 Strength",
                "55 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Damage", 50, 0),
                Tuple.Create("% Bonus to Attack Rating", 20, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Attack Rating (Based on Character Level)", 8, 792, "2"),
                Tuple.Create(" Cold Damage", 20, 30, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Arctic Furs")]
        public async Task ArcticFursImageAsync([Remainder] string args = null)
        {
            var name = "Arctic Furs(2)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/quilted_armor_diablo2_wiki_guide_196px.png";
            var setName = "Arctic Gear";
            var requirements = new List<string>
            {
                "12 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Defense", 275, 325),
                Tuple.Create(" All Resistances", 10, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense (Based on Character Level)", 3, 297, "2"),
                Tuple.Create("% Cold Resist", 15, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Arctic Mitts")]
        public async Task ArcticMittsImageAsync([Remainder] string args = null)
        {
            var name = "Arctic Mitts(2)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_gauntlets_diablo2_wiki_guide_196px.png";
            var setName = "Arctic Gear";
            var requirements = new List<string>
            {
                "45 Strength"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Life", 20, 0),
                Tuple.Create("% Increased Attack Speed", 10, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Attack rating", 50, 0, "2"),
                Tuple.Create(" Dexterity ", 10, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Arctic Binding")]
        public async Task ArcticBindingImageAsync([Remainder] string args = null)
        {
            var name = "Arctic Binding(2)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_belt_armor_diablo2_wiki_guide_196px.png";
            var setName = "Arctic Gear";
            var requirements = new List<string>
            {
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Cold Resist", 40, 0),
                Tuple.Create(" Defense", 30, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Better Chance of Getting Magic Items", 40, 0, "2"),
                Tuple.Create("% Cold Resist", 10, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }

        [Command("Cathan's Traps")]
        public async Task CathansTrapsImageAsync()
        {
            await CathansRuleImageAsync("3");
            await CathansMeshImageAsync("0");
            await CathansVisageImageAsync("0");
            await CathansSigilImageAsync("0");
            await CathansSealImageAsync("0");
            
        }

        [Command("Cathan's Rule")]
        public async Task CathansRuleImageAsync([Remainder] string args = null)
        {
            var name = "Cathan's Rule(11)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/battle_staf_diablo_2_wiki_guide_125px.png";
            var setName = "Cathan's Traps";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Fire Skills", 1, 9),
                Tuple.Create(" Maximum Fire Damage", 10, 0),
                Tuple.Create(" Damage to Undead", 50, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Mana ", 50, 0, "2"),
                Tuple.Create(" All Resistances", 10, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Cathan's Mesh")]
        public async Task CathansMeshImageAsync([Remainder] string args = null)
        {
            var name = "Cathan's Mesh(11)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/chain_mail_armor_diablo2_wiki_guide_196px.png";
            var setName = "Cathan's Traps";
            var requirements = new List<string>
            {
                "24 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 15, 0),
                Tuple.Create("% Requirements", -50, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Damage Taken by Attackers", 5, 0, "2"),
                Tuple.Create("% Fire Resist", 30, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Cathan's Visage")]
        public async Task CathansVisageImageAsync([Remainder] string args = null)
        {
            var name = "Cathan's Visage(11)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/mask_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Cathan's Traps";
            var requirements = new List<string>
            {
                "23 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Cold Resist", 25, 0),
                Tuple.Create(" Mana", 20, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense (Based on Character Level)", 2, 198, "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Cathan's Sigil")]
        public async Task CathansSigilImageAsync([Remainder] string args = null)
        {
            var name = "Cathan's Sigil(11)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet1_diablo2_wiki_guide_98px.png";
            var setName = "Cathan's Traps";
            var requirements = new List<string>
            {
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Faster Hit Recovery", 10, 0),
                Tuple.Create("Lightning Damage Taken by Attackers", 5, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Attack Rating", 50, 0, "2"),
                Tuple.Create("% Better Chance of Finding Magic Items", 25, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Cathan's Seal")]
        public async Task CathansSealImageAsync([Remainder] string args = null)
        {
            var name = "Cathan's Seal(11)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ring2_diablo2_wiki_guide_98px.png";
            var setName = "Cathan's Traps";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Life Stolen per Hit", 6, 0),
                Tuple.Create(" Damage Reduced", 2, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Strength ", 10, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Civerb's Vestments")]
        public async Task CiverbsVestmentsImageAsync()
        {
            await CiverbsCudgelImageAsync("3");
            await CiverbsWardImageAsync("0");
            await CiverbsIconImageAsync("0");

        }

        [Command("Civerb's Cudgel")]
        public async Task CiverbsCudgelImageAsync([Remainder] string args = null)
        {
            var name = "Civerb's Cudgel(9)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/grand_scepter_weapons_diablo_2_resurrected_wiki_guide_201px.png";
            var setName = "Civerb's Vestments";
            var requirements = new List<string>
            {
                "37 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Maximum Damage (Based on Character Level)", 1, 99),
                Tuple.Create(" Maximum Damage", 17, 23),
                Tuple.Create("% Damage to Undead", 50, 0),
                Tuple.Create(" Attack Rating", 75, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Civerb's Ward")]
        public async Task CiverbsWardImageAsync([Remainder] string args = null)
        {
            var name = "Civerb's Ward(9)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/stormguild_diablo2_wiki_guide_196x294px.png";
            var setName = "Civerb's Vestments";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 15, 0),
                Tuple.Create("% Increased Chance of Blocking", 15, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Mana", 21, 22, "2"),
                Tuple.Create("% Poison Resist", 25, 26, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Civerb's Icon")]
        public async Task CiverbsIconImageAsync([Remainder] string args = null)
        {
            var name = "Civerb's Icon(9)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet1_diablo2_wiki_guide_98px.png";
            var setName = "Civerb's Vestments";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Replenish Life", 4, 0),
                Tuple.Create("% Regenerate Mana", 40, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Cold Resist", 25, 0, "2"),
                Tuple.Create(" Defense", 25, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Cleglaw's Brace")]
        public async Task CleglawsBraceImageAsync()
        {
            await CleglawsToothImageAsync("3");
            await CleglawsClawImageAsync("0");
            await CleglawsPincersImageAsync("0");

        }

        [Command("Cleglaw's Tooth")]
        public async Task CleglawsToothImageAsync([Remainder] string args = null)
        {
            var name = "Cleglaw's Tooth(4)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hellplague_diablo_2_wiki_guide196px.png";
            var setName = "Cleglaw's Brace";
            var requirements = new List<string>
            {
                "55 Strength",
                "39 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Deadly Strike", 50, 0),
                Tuple.Create("% Bonus to Attack Rating", 30, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Maximum Damage (Based on Character Level)", 1, 123, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Cleglaw's Claw")]
        public async Task CleglawsClawImageAsync([Remainder] string args = null)
        {
            var name = "Cleglaw's Claw(4)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/umbral_disk_diablo2_wiki_guide_196x294px.png";
            var setName = "Cleglaw's Brace";
            var requirements = new List<string>
            {
                "22 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Poison Length Reduced", 75, 0),
                Tuple.Create(" Defense", 17, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" All Resistances", 15, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Cleglaw's Pincers")]
        public async Task CleglawsPincersImageAsync([Remainder] string args = null)
        {
            var name = "Cleglaw's Pincers(4)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/chain_gloves_diablo2_wiki_guide_196px.png";
            var setName = "Cleglaw's Brace";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Slows Target", 25, 0),
                Tuple.Create("Knockback", 0, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Attack Rating (Based on Character Level)", 10, 990, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Angelic Raiment")]
        public async Task AngelicRaimentImageAsync()
        {
            await AngelicSickleImageAsync("3");
            await AngelicMantleImageAsync("0");
            await AngelicHaloImageAsync("0");
            await AngelicWingsImageAsync("0");

        }

        [Command("Angelic Sickle")]
        public async Task AngelicSickleImageAsync([Remainder] string args = null)
        {
            var name = "Angelic Sickle(12)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/krintizs_skewer_swords_weapons_diablo_2_wiki_guide196px.png";
            var setName = "Angelic Raiment";
            var requirements = new List<string>
            {
                "25 Strength",
                "25 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Damage to Undead", 250, 0),
                Tuple.Create(" Attack Rating", 75, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Enhanced Damage", 75, 0, "2"),
                Tuple.Create("% Increased Attack Speed", 30, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Angelic Mantle")]
        public async Task AngelicMantleImageAsync([Remainder] string args = null)
        {
            var name = "Angelic Mantle(12)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ring_mail_armor_diablo2_wiki_guide_196px.png";
            var setName = "Angelic Raiment";
            var requirements = new List<string>
            {
                "36 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Defense", 40, 0),
                Tuple.Create("Damage Reduced", 3, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense ", 150, 0, "2"),
                Tuple.Create("% Fire Resist", 50, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Angelic Halo")]
        public async Task AngelicHaloImageAsync([Remainder] string args = null)
        {
            var name = "Angelic Halo(12)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ring4_diablo2_wiki_guide_98px.png";
            var setName = "Angelic Raiment";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Replenish Life", 6, 0),
                Tuple.Create(" Life", 20, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Attack Rating (Based on Character Level)", 144, 1188, "2"),
                Tuple.Create("% Better Chance Of Getting Magic Items", 50, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Angelic Wings")]
        public async Task AngelicWingsImageAsync([Remainder] string args = null)
        {
            var name = "Angelic Wings(12)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet2_diablo2_wiki_guide_98px.png";
            var setName = "Angelic Raiment";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Damage Taken Goes to Mana", 20, 0),
                Tuple.Create(" Light Radius", 3, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Life ", 75, 0, "2"),
                Tuple.Create(" All Skills", 1, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Hsarus' Defense")]
        public async Task HsarusDefenseImageAsync()
        {
            await HsarusIronFistImageAsync("3");
            await HsarusIronStayImageAsync("0");
            await HsarusIronHeelImageAsync("0");

        }

        [Command("Hsarus' Iron Fist")]
        public async Task HsarusIronFistImageAsync([Remainder] string args = null)
        {
            var name = "Hsarus' Iron Fist(3)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/buckler_shields_diablo2_wiki_guide_100x150px.png";
            var setName = "Hsarus' Defense";
            var requirements = new List<string>
            {
                "12 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Damage Reduced", 2, 0),
                Tuple.Create(" Strength", 10, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense", 2, 247, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Hsarus' Iron Stay")]
        public async Task HsarusIronStayImageAsync([Remainder] string args = null)
        {
            var name = "Hsarus' Iron Stay(3)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bell_armor_diablo2_wiki_guide_196px.png";
            var setName = "Hsarus' Defense";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Cold Resist", 20, 0),
                Tuple.Create(" Life", 20, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense ", 2, 247, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Hsarus' Iron Heel")]
        public async Task HsarusIronHeelImageAsync([Remainder] string args = null)
        {
            var name = "Hsarus' Iron Heel(3)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/chain_boots_diablo2_wiki_guide_196px.png";
            var setName = "Hsarus' Defense";
            var requirements = new List<string>
            {
                "30 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Faster Run/Walk", 20, 0),
                Tuple.Create("% Fire Resist", 25, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Attack Rating", 10, 990, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Infernal Tools")]
        public async Task InfernalToolsImageAsync()
        {
            await InfernalTorchImageAsync("3");
            await InfernalCraniumImageAsync("0");
            await InfernalSignImageAsync("0");

        }

        [Command("Infernal Torch")]
        public async Task InfernalTorchImageAsync([Remainder] string args = null)
        {
            var name = "Infernal Torch(5)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/grim_wand_diablo_2_wiki_guide_125px.png";
            var setName = "Infernal Tools";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Necromancer Skill Levels", 1, 0),
                Tuple.Create(" Minimum Damage", 8, 0),
                Tuple.Create("% Damage to Undead", 150, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Attack Rating (Based on Character Level)", 10, 990, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Infernal Cranium")]
        public async Task InfernalCraniumImageAsync([Remainder] string args = null)
        {
            var name = "Infernal Cranium(5)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/biggins_bonnet_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Infernal Tools";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Damage Taken Goes to Mana", 20, 0),
                Tuple.Create(" All Resistances", 10, 0),
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense (Based on Character Level)", 2, 198, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Infernal Sign")]
        public async Task InfernalSignImageAsync([Remainder] string args = null)
        {
            var name = "Infernal Sign(5)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_belt_armor_diablo2_wiki_guide_196px.png";
            var setName = "Infernal Tools";
            var requirements = new List<string>
            {
                "45 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 25, 0),
                Tuple.Create(" Life", 20, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Poison Resist", 25, 0, "2"),
                Tuple.Create("Half Freeze Duration", 0, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Iratha's Finery")]
        public async Task IrathasFineryImageAsync()
        {
            await IrathasCoilImageAsync("3");
            await IrathasCuffImageAsync("0");
            await IrathasCordImageAsync("0");
            await IrathasCollarImageAsync("0");

        }

        [Command("Iratha's Coil")]
        public async Task IrathasCoilImageAsync([Remainder] string args = null)
        {
            var name = "Iratha's Coil(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/crown_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Iratha's Finery";
            var requirements = new List<string>
            {
                "55 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Lightning Resist", 30, 0),
                Tuple.Create("% Fire Resist", 30, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense (Based on Character Level)", 2, 198, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Iratha's Cuff")]
        public async Task IrathasCuffImageAsync([Remainder] string args = null)
        {
            var name = "Iratha's Cuff(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_gauntlets_diablo2_wiki_guide_196px.png";
            var setName = "Iratha's Finery";
            var requirements = new List<string>
            {
                "45 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("Half Freeze Duration", 0, 0),
                Tuple.Create("% Cold Resist", 30, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Increased Attack Speed", 20, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Iratha's Cord")]
        public async Task IrathasCordImageAsync([Remainder] string args = null)
        {
            var name = "Iratha's Cord(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_belt_armor_diablo2_wiki_guide_196px.png";
            var setName = "Iratha's Finery";
            var requirements = new List<string>
            {
                "45 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 25, 0),
                Tuple.Create(" Minimum Damage", 5, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Dexterity", 10, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Iratha's Collar")]
        public async Task IrathasCollarImageAsync([Remainder] string args = null)
        {
            var name = "Iratha's Collar(15)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet1_diablo2_wiki_guide_98px.png";
            var setName = "Iratha's Finery";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Poison Length Reduced", 75, 0),
                Tuple.Create("% Poison Resist", 30, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" All Resistances", 15, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Isenhart's Armory")]
        public async Task IsenhartsArmoryImageAsync()
        {
            await IsenhartsLightbrandImageAsync("3");
            await IsenhartsCaseImageAsync("0");
            await IsenhartsParryImageAsync("0");
            await IsenhartsHornsImageAsync("0");

        }

        [Command("Isenhart's Lightbrand")]
        public async Task IsenhartsLightbrandImageAsync([Remainder] string args = null)
        {
            var name = "Isenhart's Lightbrand(8)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/broad_sword_diablo_2_wiki_guide196px.png";
            var setName = "Isenhart's Armory";
            var requirements = new List<string>
            {
                "48 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Minimum Damage", 10, 0),
                Tuple.Create("% Increased Attack Speed", 20, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Attack Rating (Based on Character Level)", 5, 495, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Isenhart's Case")]
        public async Task IsenhartsCaseImageAsync([Remainder] string args = null)
        {
            var name = "Isenhart's Case(8)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/breast_plate_armor_diablo2_wiki_guide_196px.png";
            var setName = "Isenhart's Armory";
            var requirements = new List<string>
            {
                "30 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Magic Damage Reduced", 2, 0),
                Tuple.Create(" Defense", 40, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense (Based on Character Level)", 2, 198, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Isenhart's Parry")]
        public async Task IsenhartsParryImageAsync([Remainder] string args = null)
        {
            var name = "Isenhart's Parry(8)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/the_ward_diablo2_wiki_guide_196x294px.png";
            var setName = "Isenhart's Armory";
            var requirements = new List<string>
            {
                "60 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Damage Taken by Attacker", 4, 0),
                Tuple.Create(" Defense", 40, 0),
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" All Resistances", 8, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        
        [Command("Isenhart's Horns")]
        public async Task IsenhartsHornsImageAsync([Remainder] string args = null)
        {
            var name = "Isenhart's Horns(8)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/duskdeep_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Isenhart's Armory";
            var requirements = new List<string>
            {
                "41 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Damage Reduced", 2, 0),
                Tuple.Create(" Dexterity", 6, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" All Resistances", 8, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Milabrega's Regalia")]
        public async Task ImageAsync()
        {
            await MilabregasRodImageAsync("3");
            await MilabregasRobeImageAsync("0");
            await MilabregasOrbImageAsync("0");
            await MilabregasDiademImageAsync("0");

        }

        [Command("Milabrega's Rod")]
        public async Task MilabregasRodImageAsync([Remainder] string args = null)
        {
            var name = "Milabrega's Rod(17)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_scepter_weapons_diablo_2_resurrected_wiki_guide_196xp.png";
            var setName = "Milabrega's Regalia";
            var requirements = new List<string>
            {
                "55 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Damage", 50, 0),
                Tuple.Create("% Damage to Undead", 50, 0),
                Tuple.Create(" Paladin Skills", 1, 0),
                Tuple.Create(" Light Radius", 2, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Milabrega's Robe")]
        public async Task MilabregasRobeImageAsync([Remainder] string args = null)
        {
            var name = "Milabrega's Robe(17)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ancient_armor_diablo2_wiki_guide_196px.png";
            var setName = "Milabrega's Regalia";
            var requirements = new List<string>
            {
                "100 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Damage Reduced", 2, 0),
                Tuple.Create(" Damage Taken by Attackers", 3, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Enhanced Defense", 100, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Milabrega's Orb")]
        public async Task MilabregasOrbImageAsync([Remainder] string args = null)
        {
            var name = "Milabrega's Orb(17)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/steelclash_diablo2_wiki_guide_196x294px.png";
            var setName = "Milabrega's Regalia";
            var requirements = new List<string>
            {
                "47 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 25, 0),
                Tuple.Create("% Better Chance of Getting Magic Items", 20, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Life ", 50, 0, "2"),
                Tuple.Create("% Enhanced Defense", 50, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Milabrega's Diadem")]
        public async Task MilabregasDiademImageAsync([Remainder] string args = null)
        {
            var name = "Milabrega's Diadem(17)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/crown_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Milabrega's Regalia";
            var requirements = new List<string>
            {
                "55 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Mana", 15, 0),
                Tuple.Create(" Life", 15, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Cold Resist", 40, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Sigon's Complete Steel")]
        public async Task SigonsCompleteSteelImageAsync()
        {
            await SigonsShelterImageAsync("3");
            await SigonsGuardImageAsync("0");
            await SigonsVisorImageAsync("0");
            await SigonsGageImageAsync("0");
            await SigonsWrapImageAsync("0");
            await SigonsSabotImageAsync("0");

        }

        [Command("Sigon's Shelter")]
        public async Task SigonsShelterImageAsync([Remainder] string args = null)
        {
            var name = "Sigon's Shelter(6)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gothic_plate_armor_diablo2_wiki_guide_196px.png";
            var setName = "Sigon's Complete Steel";
            var requirements = new List<string>
            {
                "70 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Defense", 25, 0),
                Tuple.Create("% Lightning Resist", 30, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Damage Taken by Attackers", 20, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Sigon's Guard")]
        public async Task SigonsGuardImageAsync([Remainder] string args = null)
        {
            var name = "Sigon's Guard(6)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bverrit_keep_1_diablo2_wiki_guide_196x294px.png";
            var setName = "Sigon's Complete Steel";
            var requirements = new List<string>
            {
                "75 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" All Skills", 1, 0),
                Tuple.Create("% Increased Chance to Block", 20, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Sigon's Visor")]
        public async Task SigonsVisorImageAsync([Remainder] string args = null)
        {
            var name = "Sigon's Visor(6)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/great_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Sigon's Complete Steel";
            var requirements = new List<string>
            {
                "63 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 25, 0),
                Tuple.Create(" Mana", 30, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Attack Rating (Based on Character Level)", 8, 792, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        
        [Command("Sigon's Gage")]
        public async Task SigonsGageImageAsync([Remainder] string args = null)
        {
            var name = "Sigon's Gage(6)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gauntlets_diablo2_wiki_guide_196px.png";
            var setName = "Sigon's Complete Steel";
            var requirements = new List<string>
            {
                "60 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Attack Rating", 20, 0),
                Tuple.Create(" Strength", 10, 0),
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Increased Attack Speed", 30, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        
        [Command("Sigon's Wrap")]
        public async Task SigonsWrapImageAsync([Remainder] string args = null)
        {
            var name = "Sigon's Wrap(6)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/plated_belt_armor_diablo2_wiki_guide_196px.png";
            var setName = "Sigon's Complete Steel";
            var requirements = new List<string>
            {
                "60 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Fire Resist", 20, 0),
                Tuple.Create(" Life", 20, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense (Based on Character Level)", 2, 198, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        
        [Command("Sigon's Sabot")]
        public async Task SigonsSabotImageAsync([Remainder] string args = null)
        {
            var name = "Sigon's Sabot(6)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/plate_boots_diablo2_wiki_guide_196px.png";
            var setName = "Sigon's Complete Steel";
            var requirements = new List<string>
            {
                "70 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Faster Run/Walk", 20, 0),
                Tuple.Create("% Cold Resist", 40, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Attack Rating", 50, 0, "2"),
                Tuple.Create("% Better Chance of Getting Magic Items", 50, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Tancred's Battlegear")]
        public async Task TancredsBattlegearImageAsync()
        {
            await TancredsCrowbillImageAsync("3");
            await TancredsSpineImageAsync("0");
            await TancredsSkullImageAsync("0");
            await TancredsHobnailsImageAsync("0");
            await TancredsWeirdImageAsync("0");

        }

        [Command("Tancred's Crowbill")]
        public async Task TancredsCrowbillImageAsync([Remainder] string args = null)
        {
            var name = "Tancred's Crowbill(20)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/military_pick_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var setName = "Tancred's Battlegear";
            var requirements = new List<string>
            {
                "49 Strength",
                "33 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Damage", 80, 0),
                Tuple.Create(" Attack Rating", 75, 0)                              
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Mana", 20, 0, "2"),
                Tuple.Create("% Increased Attack Speed", 20, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Tancred's Spine")]
        public async Task TancredsSpineImageAsync([Remainder] string args = null)
        {
            var name = "Tancred's Spine(20)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/full_plate_mail_diablo2_wiki_guide_196px.png";
            var setName = "Tancred's Battlegear";
            var requirements = new List<string>
            {
                "80 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Life", 40, 0),
                Tuple.Create(" Strength", 15, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense", 2, 198, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Tancred's Skull")]
        public async Task TancredsSkullImageAsync([Remainder] string args = null)
        {
            var name = "Tancred's Skull(20)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/wormskull_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Tancred's Battlegear";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Damage", 10, 0),
                Tuple.Create(" Attack Rating", 40, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" All Resistances", 10, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Tancred's Hobnails")]
        public async Task TancredsHobnailsImageAsync([Remainder] string args = null)
        {
            var name = "Tancred's Hobnails(20)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/leather_boots_diablo2_wiki_guide_196px.png";
            var setName = "Tancred's Battlegear";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Heal Stamina", 25, 0),
                Tuple.Create(" Dexterity", 10, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Faster Run/Walk", 30, 0, "2"),
                Tuple.Create(" Strength", 10, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Tancred's Weird")]
        public async Task TancredsWeirdImageAsync([Remainder] string args = null)
        {
            var name = "Tancred's Weird(20)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet3_diablo2_wiki_guide_98px.png";
            var setName = "Tancred's Battlegear";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Damage Reduced", 2, 0),
                Tuple.Create(" Magic Damage Reduced", 1, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Better Chance of Getting Magic Items", 78, 0, "2"),
                Tuple.Create(" Attack Rating", 60, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Death's Disguise")]
        public async Task DeathsDisguiseImageAsync()
        {
            await DeathsTouchImageAsync("3");
            await DeathsHandImageAsync("0");
            await DeathsGuardImageAsync("0");

        }

        [Command("Death's Touch")]
        public async Task DeathsTouchImageAsync([Remainder] string args = null)
        {
            var name = "Death's Touch(6)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_sword_weapons_diablo_2_wiki_guide196px.png";
            var setName = "Death's Disguise";
            var requirements = new List<string>
            {
                "71 Strength",
                "45 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Damage", 25, 0),
                Tuple.Create("% Life Stolen per Hit", 4, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Cold Damage", 25, 75, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Death's Hand")]
        public async Task DeathsHandImageAsync([Remainder] string args = null)
        {
            var name = "Death's Hand(6)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/leather_gloves_diablo2_wiki_guide_196px.png";
            var setName = "Death's Disguise";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Poison Length Reduced", 75, 0),
                Tuple.Create("% Poison Resist", 50, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Increased Attack Speed", 30, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Death's Guard")]
        public async Task DeathsGuardImageAsync([Remainder] string args = null)
        {
            var name = "Death's Guard(6)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/sash_armor_diablo2_wiki_guide_196px.png";
            var setName = "Death's Disguise";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("Cannot be Frozen", 0, 0),
                Tuple.Create(" Defense", 20, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" All Resistances", 15, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Vidala's Rig")]
        public async Task VidalasRigImageAsync()
        {
            await VidalasBarbImageAsync("3");
            await VidalasAmbushImageAsync("0");
            await VidalasFetlockImageAsync("0");
            await VidalasSnareImageAsync("0");

        }

        [Command("Vidala's Barb")]
        public async Task VidalasBarbImageAsync([Remainder] string args = null)
        {
            var name = "Vidala's Barb(14)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/long_battle_bow_weapons_diablo_2_resurrected_wiki_guide.png";
            var setName = "Vidala's Rig";
            var requirements = new List<string>
            {
                "40 Strength",
                "50 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Lightning Damage", 1, 20)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Attack Rating (Based on Character Level)", 8, 792, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Vidala's Ambush")]
        public async Task VidalasAmbushImageAsync([Remainder] string args = null)
        {
            var name = "Vidala's Ambush(14)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/leather_armor_diablo2_wiki_guide_196px.png";
            var setName = "Vidala's Rig";
            var requirements = new List<string>
            {
                "15 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 50, 0),
                Tuple.Create(" Dexterity", 11, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Fire Resist", 24, 0, "2"),
                Tuple.Create(" Defense", 2, 247, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Vidala's Fetlock")]
        public async Task VidalasFetlockImageAsync([Remainder] string args = null)
        {
            var name = "Vidala's Fetlock(14)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_plate_boots_diablo2_wiki_guide_196px.png";
            var setName = "Vidala's Rig";
            var requirements = new List<string>
            {
                "50 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Faster Run/Walk", 30, 0),
                Tuple.Create(" Maximum Stamina", 150, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" All Resistances", 8, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Vidala's Snare")]
        public async Task VidalasSnareImageAsync([Remainder] string args = null)
        {
            var name = "Vidala's Snare(14)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet2_diablo2_wiki_guide_98px.png";
            var setName = "Vidala's Rig";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Cold Resist", 20, 0),
                Tuple.Create(" Life", 15, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Better Chance of Getting Magic Items", 50, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Heaven's Brethren")]
        public async Task HeavensBrethrenImageAsync()
        {
            await DangoonsTeachingImageAsync("3");
            await HaemosusAdamantImageAsync("0");
            await TaebaeksGloryImageAsync("0");
            await OndalsAlmightyImageAsync("0");

        }

        [Command("Dangoon's Teaching")]
        public async Task DangoonsTeachingImageAsync([Remainder] string args = null)
        {
            var name = "Dangoon's Teaching(68)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/dangoons_teaching_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var setName = "Heaven's Brethren";
            var requirements = new List<string>
            {
                "145 Strength",
                "46 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Maximum Damage (Based on Character Level)", 1, 148),
                Tuple.Create("% Damage to Undead", 50, 0),
                Tuple.Create("% Increased Attack Speed", 40, 0),
                Tuple.Create("% Chance to Cast Level 3 Frost Nova on Striking", 10, 0),
                Tuple.Create(" Fire Damage", 20, 30)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Haemosu's Adamant")]
        public async Task HaemosusAdamantImageAsync([Remainder] string args = null)
        {
            var name = "Haemosu's Adamant(44)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/haemosu's_adamant_armor_diablo2_wiki_guide_196px.png";
            var setName = "Heaven's Brethren";
            var requirements = new List<string>
            {
                "52 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 500, 0),
                Tuple.Create(" Defense vs. Melee", 40, 0),
                Tuple.Create(" Defense vs. Missile", 35, 0),
                Tuple.Create("% Requirements", -20, 0),
                Tuple.Create(" Life", 75, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Taebaek's Glory")]
        public async Task TaebaeksGloryImageAsync([Remainder] string args = null)
        {
            var name = "Taebaek's Glory(81)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heaven's_brethren_diablo2_wiki_guide_196x294px.png";
            var setName = "Heaven's Brethren";
            var requirements = new List<string>
            {
                "185 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("Indestructible", 0, 0),
                Tuple.Create(" Defense", 50, 0),
                Tuple.Create("% Increased Chance of Blocking", 25, 0),
                Tuple.Create("% Lightning Resist", 30, 0),
                Tuple.Create("% Faster Block Rate", 30, 0),
                Tuple.Create(" Mana", 100, 0),
                Tuple.Create("Damage Taken by Attackers", 30, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Ondal's Almighty")]
        public async Task OndalsAlmightyImageAsync([Remainder] string args = null)
        {
            var name = "Ondal's Almighty(69)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/ondals_almighty_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Heaven's Brethren";
            var requirements = new List<string>
            {
                "116 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Chance to Cast Level 3 Weaken on Striking", 10, 0),
                Tuple.Create("% Faster Hit Recovery", 24, 0),
                Tuple.Create("% Requirements ", -40, 0),
                Tuple.Create(" Defense", 50, 0),
                Tuple.Create(" Dexterity", 15, 0),
                Tuple.Create(" Strength", 10, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("The Disciple")]
        public async Task TheDiscipleImageAsync()
        {
            await DarkAdherentImageAsync("3");
            await LayingofHandsImageAsync("0");
            await CredendumImageAsync("0");
            await RiteofPassageImageAsync("0");
            await TellingofBeadsImageAsync("0");
            

        }

        [Command("Dark Adherent")]
        public async Task DarkAdherentImageAsync([Remainder] string args = null)
        {
            var name = "Dark Adherent(49)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/quilted_armor_diablo2_wiki_guide_196px.png";
            var setName = "The Disciple";
            var requirements = new List<string>
            {
                "77 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense ", 305, 415),
                Tuple.Create("% Fire Resist", 24, 0),
                Tuple.Create("% Chance to Cast Level 3 Nova When Struck", 25, 0),
                Tuple.Create(" Poison Damage Over 2 Seconds", 24, 34)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Laying of Hands")]
        public async Task LayingofHandsImageAsync([Remainder] string args = null)
        {
            var name = "Laying of Hands(63)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/leather_gloves_diablo2_wiki_guide_196px.png";
            var setName = "The Disciple";
            var requirements = new List<string>
            {
                "50 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 25, 0),
                Tuple.Create("% Increased Attack Speed", 20, 0),
                Tuple.Create("% Damage to Demons", 350, 0),
                Tuple.Create("% Fire Resist", 50, 0),
                Tuple.Create("% Chance to Cast Level 3 Holy Bolt on Striking", 10, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Credendum")]
        public async Task CredendumImageAsync([Remainder] string args = null)
        {
            var name = "Credendum(65)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bell_armor_diablo2_wiki_guide_196px.png";
            var setName = "The Disciple";
            var requirements = new List<string>
            {
                "106 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 50, 0),
                Tuple.Create(" All Resistances", 15, 0),
                Tuple.Create(" Dexterity", 10, 0),
                Tuple.Create(" Strength", 10, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Rite of Passage")]
        public async Task RiteofPassageImageAsync([Remainder] string args = null)
        {
            var name = "Rite of Passage(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/leather_boots_diablo2_wiki_guide_196px.png";
            var setName = "The Disciple";
            var requirements = new List<string>
            {
                "20 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 25, 0),
                Tuple.Create("% Faster Run/Walk", 30, 0),
                Tuple.Create(" Maximum Stamina", 15, 25),
                Tuple.Create("Half Freeze Duration", 0, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Telling of Beads")]
        public async Task TellingofBeadsImageAsync([Remainder] string args = null)
        {
            var name = "Telling of Beads(30)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet2_diablo2_wiki_guide_98px.png";
            var setName = "The Disciple";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" All Skills", 1, 0),
                Tuple.Create("% Poison Resist", 35, 50),
                Tuple.Create("% Cold Resist", 18, 0),
                Tuple.Create(" Damage Taken by Attackers", 8, 10)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Hwanin's Majesty")]
        public async Task HwaninsMajestyImageAsync()
        {
            await HwaninsJusticeImageAsync("3");
            await HwaninsRefugeImageAsync("0");
            await HwaninsSplendorImageAsync("0");
            await HwaninsBlessingImageAsync("0");

        }

        [Command("Hwanin's Justice")]
        public async Task HwaninsJusticeImageAsync([Remainder] string args = null)
        {
            var name = "Hwanin's Justice(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/voulge_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var setName = "Hwanin's Majesty";
            var requirements = new List<string>
            {
                "95 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("Indestructible", 0, 0),
                Tuple.Create("% Enhanced Damage", 200, 0),
                Tuple.Create(" Lightning Damage", 5, 25),
                Tuple.Create("% Increased Attack Speed", 40, 0),
                Tuple.Create(" Attack Rating", 330, 0),
                Tuple.Create("% Chance to Cast Level 3 Ice Blast on Striking", 10, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Hwanin's Refuge")]
        public async Task HwaninsRefugeImageAsync([Remainder] string args = null)
        {
            var name = "Hwanin's Refuge(30)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/scale_mail_armor_diablo2_wiki_guide_196px.png";
            var setName = "Hwanin's Majesty";
            var requirements = new List<string>
            {
                "86 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 200, 0),
                Tuple.Create("% Chance to Cast Level 3 Static Field When Struck", 10, 0),
                Tuple.Create("% Poison Resist", 27, 0),
                Tuple.Create(" Life", 100, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Hwanin's Splendor")]
        public async Task HwaninsSplendorImageAsync([Remainder] string args = null)
        {
            var name = "Hwanin's Splendor(45)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/crown_of_thieves_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Hwanin's Majesty";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Defense", 100, 0),
                Tuple.Create(" Replenish Life", 20, 0),
                Tuple.Create(" Magic Damage Reduced", 10, 0),
                Tuple.Create("% Cold Resist", 37, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Hwanin's Blessing")]
        public async Task HwaninsBlessingImageAsync([Remainder] string args = null)
        {
            var name = "Hwanin's Blessing(35)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bell_armor_diablo2_wiki_guide_196px.png";
            var setName = "Hwanin's Majesty";
            var requirements = new List<string>
            {
                "25 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense (Based on Character Level)", 1, 148),
                Tuple.Create(" Lightning Damage", 3, 33),
                Tuple.Create("Prevent Monster Heal", 0, 0),
                Tuple.Create("% Damage Taken Goes to Mana", 12, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Cow King's Leathers")]
        public async Task CowKingsLeathersImageAsync()
        {
            await CowKingsHornsImageAsync("3");
            await CowKingsHideImageAsync("0");
            await CowKingsHoovesImageAsync("0");

        }

        [Command("Cow King's Horns")]
        public async Task CowKingsHornsImageAsync([Remainder] string args = null)
        {
            var name = "Cow King's Horns(25)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/cap_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Cow King's Leathers";
            var requirements = new List<string>
            {
                "20 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 75, 0),
                Tuple.Create("Half Freeze Duration", 0, 0),
                Tuple.Create(" Damage Taken by Attckers", 10, 0),
                Tuple.Create("% Damage Taken Goes to Mana", 35, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Cow King's Hide")]
        public async Task CowKingsHideImageAsync([Remainder] string args = null)
        {
            var name = "Cow King's Hide(18)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/studded_leather_armor_diablo2_wiki_guide_196px.png";
            var setName = "Cow King's Leathers";
            var requirements = new List<string>
            {
                "27 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Defense", 60, 0),
                Tuple.Create("% Chance to Cast Level 5 Chain Lightning When Struck", 18, 0),
                Tuple.Create(" All Resistances", 18, 0),
                Tuple.Create(" Life", 30, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Cow King's Hooves")]
        public async Task CowKingsHoovesImageAsync([Remainder] string args = null)
        {
            var name = "Cow King's Hooves(13)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_boots_diablo2_wiki_guide_196px.png";
            var setName = "Cow King's Leathers";
            var requirements = new List<string>
            {
                "18 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 25, 35),
                Tuple.Create("% Faster Run/Walk", 30, 0),
                Tuple.Create(" Fire Damage", 25, 35),
                Tuple.Create(" Dexterity", 20, 0),
                Tuple.Create("% Better Chance of Getting Magic Items", 25, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Naj's Ancient Vestige")]
        public async Task NajsAncientVestigeImageAsync()
        {
            await NajsPuzzlerImageAsync("3");
            await NajsLightPlateImageAsync("0");
            await NajsCircletImageAsync("0");

        }

        [Command("Naj's Puzzler")]
        public async Task NajsPuzzlerImageAsync([Remainder] string args = null)
        {
            var name = "Naj's Puzzler(78)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/staff_of_kings_quest_item_diablo2_wiki_guide_125px.png";
            var setName = "Naj's Ancient Vestige";
            var requirements = new List<string>
            {
                "44 Strength",
                "37 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Damage", 150, 0),
                Tuple.Create("% Damage to Undead", 50, 0),
                Tuple.Create(" Lightning Damage", 6, 45),
                Tuple.Create("% Faster Cast Rate", 30, 0),
                Tuple.Create(" All Skills", 1, 0),
                Tuple.Create(" Mana", 70, 0),
                Tuple.Create(" Energy", 35, 0),
                Tuple.Create("Level 11 Teleport (69 Charges)", 0, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Naj's Light Plate")]
        public async Task NajsLightPlateImageAsync([Remainder] string args = null)
        {
            var name = "Naj's Light Plate(71)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/plate_mail_armor_diablo2_wiki_guide_196px.png";
            var setName = "Naj's Ancient Vestige";
            var requirements = new List<string>
            {
                "79 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 300, 0),
                Tuple.Create("% Requirements", -60, 0),
                Tuple.Create("% Damage Taken Goes to Mana", 45, 0),
                Tuple.Create(" All Skills", 1, 0),
                Tuple.Create(" All Resistances", 25, 0),
                Tuple.Create(" Life", 65, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Naj's Circlet")]
        public async Task NajsCircletImageAsync([Remainder] string args = null)
        {
            var name = "Naj's Circlet(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/circlet_armor_diablo2_wiki_guide_196px.png";
            var setName = "Naj's Ancient Vestige";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 75, 0),
                Tuple.Create(" Fire Damage", 25, 35),
                Tuple.Create("% Chance to Cast Level 5 Chain Lightning When Struck", 12, 0),
                Tuple.Create(" Strength", 15, 0),
                Tuple.Create(" Light Radius", 5, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Sander's Folly")]
        public async Task SandersFollyImageAsync()
        {
            await SandersParagonImageAsync("3");
            await SandersSuperstitionImageAsync("0");
            await SandersTabooImageAsync("0");
            await SandersRiprapImageAsync("0");

        }

        [Command("Sander's Paragon")]
        public async Task SandersParagonImageAsync([Remainder] string args = null)
        {
            var name = "Sander's Paragon(25)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/biggins_bonnet_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Sander's Folly";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense (Based on Character Level)", 1, 99),
                Tuple.Create(" Damage Taken by Attackers", 8, 0),
                Tuple.Create("% Better Chance of Getting Magic Items", 35, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Sander's Superstition")]
        public async Task SandersSuperstitionImageAsync([Remainder] string args = null)
        {
            var name = "Sander's Superstition(25)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gravenspine_diablo_2_wiki_guide_125px.png";
            var setName = "Sander's Folly";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Damage", 75, 0),
                Tuple.Create("% Damage to Undead", 50, 0),
                Tuple.Create("% Faster Cast Rate", 20, 0),
                Tuple.Create(" Mana", 25, 0),
                Tuple.Create("% Mana Stolen per Hit", 0, 0),
                Tuple.Create(" Cold Damage", 25, 75)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Sander's Taboo")]
        public async Task SandersTabooImageAsync([Remainder] string args = null)
        {
            var name = "Sander's Taboo(28)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_gloves_diablo2_wiki_guide_196px.png";
            var setName = "Sander's Folly";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Poison Damage Over 3 Seconds", 9, 11),
                Tuple.Create(" Defense", 20, 25),
                Tuple.Create(" Life", 40, 0),
                Tuple.Create("% Increased Attack Speed", 20, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Sander's Riprap")]
        public async Task SandersRiprapImageAsync([Remainder] string args = null)
        {
            var name = "Sander's Riprap(20)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_boots_diablo2_wiki_guide_196px.png";
            var setName = "Sander's Folly";
            var requirements = new List<string>
            {
                "18 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Faster Run/Walk", 40, 0),
                Tuple.Create(" Attack Rating", 100, 0),
                Tuple.Create(" Dexterity", 10, 0),
                Tuple.Create(" Strength", 5, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Sazabi's Grand Tribute")]
        public async Task SazabisGrandTributeImageAsync()
        {
            await SazabisCobaltRedeemerImageAsync("3");
            await SazabisGhostLiberatorImageAsync("0");
            await SazabisMentalSheathImageAsync("0");

        }

        [Command("Sazabi's Cobalt Redeemer")]
        public async Task SazabisCobaltRedeemerImageAsync([Remainder] string args = null)
        {
            var name = "Sazabi's Cobalt Redeemer(73)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/hellplague_diablo_2_wiki_guide196px.png";
            var setName = "Sazabi's Grand Tribute";
            var requirements = new List<string>
            {
                "99 Strength",
                "109 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Damage", 150, 0),
                Tuple.Create("% Damage to Demons", 318, 0),
                Tuple.Create(" Cold Damage", 25, 35),
                Tuple.Create("% Increased Attack Speed", 40, 0),
                Tuple.Create("Indestructible", 0, 0),
                Tuple.Create(" Dexterity", 15, 0),
                Tuple.Create(" Strength", 5, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Sazabi's Ghost Liberator")]
        public async Task SazabisGhostLiberatorImageAsync([Remainder] string args = null)
        {
            var name = "Sazabi's Ghost Liberator(67)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/splint_mail_armor_diablo2_wiki_guide_196px.png";
            var setName = "Sazabi's Grand Tribute";
            var requirements = new List<string>
            {
                "165 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 400, 0),
                Tuple.Create("% Faster Hit Recovery", 30, 0),
                Tuple.Create(" Attack Rating Against Demons", 300, 0),
                Tuple.Create(" Strength", 25, 0),
                Tuple.Create(" Life", 50, 75)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Sazabi's Mental Sheath")]
        public async Task SazabisMentalSheathImageAsync([Remainder] string args = null)
        {
            var name = "Sazabi's Mental Sheath(43)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/duskdeep_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Sazabi's Grand Tribute";
            var requirements = new List<string>
            {
                "82 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" All Skills", 1, 0),
                Tuple.Create("% Lightning Resist", 15, 20),
                Tuple.Create("% Fire Resist", 15, 20),
                Tuple.Create(" Defense", 100, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Orphan's Call")]
        public async Task OrphansCallImageAsync()
        {
            await GuillaumesFaceImageAsync("3");
            await WhitstansGuardImageAsync("0");
            await MagnusSkinImageAsync("0");
            await WilhelmsPrideImageAsync("0");

        }

        [Command("Guillaume's Face")]
        public async Task GuillaumesFaceImageAsync([Remainder] string args = null)
        {
            var name = "Guillaume's Face(34)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/great_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Orphan's Call";
            var requirements = new List<string>
            {
                "115 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Defense", 120, 0),
                Tuple.Create("% Faster Hit Recovery", 30, 0),
                Tuple.Create("% Deadly Strike", 15, 0),
                Tuple.Create("% Chance of Crushing Blow", 35, 0),
                Tuple.Create(" Strength", 15, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Whitstan's Guard")]
        public async Task WhitstansGuardImageAsync([Remainder] string args = null)
        {
            var name = "Whitstan's Guard(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/moser's_blessed_circle_diablo2_wiki_guide_196x294px.png";
            var setName = "Orphan's Call";
            var requirements = new List<string>
            {
                "53 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Defense", 175, 0),
                Tuple.Create("Half Freeze Duration", 0, 0),
                Tuple.Create("% Faster Block Rate", 40, 0),
                Tuple.Create("% Increased Chance of Blocking", 55, 0),
                Tuple.Create(" light Radius", 5, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Magnus' Skin")]
        public async Task MagnusSkinImageAsync([Remainder] string args = null)
        {
            var name = "Magnus' Skin(37)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_gloves_diablo2_wiki_guide_196px.png";
            var setName = "Orphan's Call";
            var requirements = new List<string>
            {
                "20 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Defense", 50, 0),
                Tuple.Create("% Increased Attack Speed", 20, 0),
                Tuple.Create(" Attack Rating", 100, 0),
                Tuple.Create(" Light Radius", 3, 0),
                Tuple.Create("% Fire Resist", 15, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Wilhelm's Pride")]
        public async Task WilhelmsPrideImageAsync([Remainder] string args = null)
        {
            var name = "Wilhelm's Pride(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_belt_armor_diablo2_wiki_guide_196px.png";
            var setName = "Orphan's Call";
            var requirements = new List<string>
            {
                "88 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Defense", 75, 0),
                Tuple.Create("% Life Stolen per Hit", 5, 0),
                Tuple.Create("% Mana Stolen per Hit", 5, 0),
                Tuple.Create("% Cold Resist", 10, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Aldur's Watchtower")]
        public async Task AldursWatchtowerImageAsync()
        {
            await AldursRhythmImageAsync("3");
            await AldursDeceptionImageAsync("0");
            await AldursStonyGazeImageAsync("0");
            await AldursAdvanceImageAsync("0");

        }

        [Command("Aldur's Rhythm")]
        public async Task AldursRhythmImageAsync([Remainder] string args = null)
        {
            var name = "Aldur's Rhythm(42)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bloodrise_weapons_diablo_2_resurrected_wiki_guide_196px.png";
            var setName = "Aldur's Watchtower";
            var requirements = new List<string>
            {
                "74 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Damage To Demons", 200, 0),
                Tuple.Create("% Damage To Undead", 50, 0),
                Tuple.Create(" Damage", 40, 62),
                Tuple.Create(" Lightning Damage", 50, 75),
                Tuple.Create("% Increased Attack Speed", 30, 0),
                Tuple.Create("% Life Stolen per Hit", 10, 0),
                Tuple.Create("% Mana Stolen per Hit", 5, 0),
                Tuple.Create("Sockets", 2, 3)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Strength ", 15, 0, "2"),
                Tuple.Create(" Strength ", 15, 0, "3"),
                Tuple.Create(" Strength ", 15, 0, "Full Set")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Aldur's Deception")]
        public async Task AldursDeceptionImageAsync([Remainder] string args = null)
        {
            var name = "Aldur's Deception(76)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/full_plate_mail_diablo2_wiki_guide_196px.png";
            var setName = "Aldur's Watchtower";
            var requirements = new List<string>
            {
                "115 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 300, 0),
                Tuple.Create("% Requirements", -50, 0),
                Tuple.Create("% Lightning Resist", 40, 50),
                Tuple.Create(" Dexterity", 15, 0),
                Tuple.Create(" Strength", 20, 0),
                Tuple.Create(" Elemental Skills (Druid Only)", 1, 0),
                Tuple.Create(" Shape Shifting Skills (Druid Only)", 1, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Vitality ", 15, 0, "2"),
                Tuple.Create(" Vitality ", 15, 0, "3"),
                Tuple.Create(" Vitality ", 15, 0, "Full Set")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Aldur's Stony Gaze")]
        public async Task AldursStonyGazeImageAsync([Remainder] string args = null)
        {
            var name = "Aldur's Stony Gaze(36)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/spirit_keeper_mask_armor_diablo2_wiki_guide_196px.png";
            var setName = "Aldur's Watchtower";
            var requirements = new List<string>
            {
                "56 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 90, 0),
                Tuple.Create(" Faster Hit Recovery", 25, 0),
                Tuple.Create("% Regenerate Mana", 17, 0),
                Tuple.Create("% Cold Resist", 40, 50),
                Tuple.Create(" Light Radius", 5, 0),
                Tuple.Create(" Sockets", 2, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Energy ", 15, 0, "2"),
                Tuple.Create(" Energy ", 15, 0, "3"),
                Tuple.Create(" Energy ", 15, 0, "Full Set")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
                [Command("Aldur's Advance")]
        public async Task AldursAdvanceImageAsync([Remainder] string args = null)
        {
            var name = "Aldur's Advance(45)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_plate_boots_diablo2_wiki_guide_196px.png";
            var setName = "Aldur's Watchtower";
            var requirements = new List<string>
            {
                "95 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("Indestructible", 0, 0),
                Tuple.Create(" Maximum Stamina", 180, 0),
                Tuple.Create("% Damage Taken Goes To Mana", 10, 0),
                Tuple.Create("% Heal Stamina", 32, 0),
                Tuple.Create(" Life", 50, 0),
                Tuple.Create("% Fire Resist", 40, 50)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Dexterity ", 15, 0, "2"),
                Tuple.Create(" Dexterity ", 15, 0, "3"),
                Tuple.Create(" Dexterity ", 15, 0, "Full Set")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Bul-Kathos' Children")]
        public async Task BulKathosChildrenImageAsync()
        {
            await BulKathosSacredChargeImageAsync("3");
            await BulKathosTribalGuardianImageAsync("0");
           

        }

        [Command("Bul-Kathos' Sacred Charge")]
        public async Task BulKathosSacredChargeImageAsync([Remainder] string args = null)
        {
            var name = "Bul-Katho's Sacred Charge(63)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/great_sword_diablo_2_wiki_guide196px.png";
            var setName = "Bul-Kathos' Children";
            var requirements = new List<string>
            {
                "189 Strength",
                "110 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Damage", 120, 0),
                Tuple.Create("% Chance of Crushing Blow", 30, 0),
                Tuple.Create("All Resistances", 20, 0),
                Tuple.Create("% Increased Attack Speed", 20, 0),
                Tuple.Create("Knockback", 0, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Bul-Kathos' Tribal Guardian")]
        public async Task BulKathosTribalGuardianImageAsync([Remainder] string args = null)
        {
            var name = "Bul-Kathos' Tribal Guardian(66)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_sword_weapons_diablo_2_wiki_guide196px.png";
            var setName = "Bul-Kathos' Children";
            var requirements = new List<string>
            {
                "147 Strength",
                "124 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Damage", 200, 0),
                Tuple.Create("Poison Damage Over 2 Seconds", 50, 0),
                Tuple.Create("% Fire Resist", 50, 0),
                Tuple.Create(" Strength", 20, 0),
                Tuple.Create("% Increased Attack Speed", 20, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Griswold's Legacy")]
        public async Task GriswoldsLegacyImageAsync()
        {
            await GriswoldsRedemptionImageAsync("3");
            await GriswoldsHeartImageAsync("0");
            await GriswoldsHonorImageAsync("0");
            await GriswoldsValorImageAsync("0");

        }

        [Command("Griswold's Redemption")]
        public async Task GriswoldsRedemptionImageAsync([Remainder] string args = null)
        {
            var name = "Griswold's Redemption(66)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/war_scepter_weapons_diablo_2_resurrected_wiki_guide_196xp.png";
            var setName = "Griswold's Legacy";
            var requirements = new List<string>
            {
                "78 Strength",
                "56 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Damage", 200, 240),
                Tuple.Create("% Damage to Undead", 250, 0),
                Tuple.Create("% Requirements", -20, 0),
                Tuple.Create("% Increased Attack Speed", 40, 0),
                Tuple.Create(" Sockets", 3, 4)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Combat Skills (Paladin Only)", 2, 0, "2"),
                Tuple.Create(" Damage", 10, 20, "3"),
                Tuple.Create(" Damage ", 10, 20, "Full Set")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Griswold's Heart")]
        public async Task GriswoldsHeartImageAsync([Remainder] string args = null)
        {
            var name = "Griswold's Heart(45)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/corpsemourn_armor_diablo2_wiki_guide_196px.png";
            var setName = "Griswold's Legacy";
            var requirements = new List<string>
            {
                "102 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 500, 0),
                Tuple.Create("% Requirements", -40, 0),
                Tuple.Create(" Strength", 20, 0),
                Tuple.Create(" Defensive Auras (Paladin Only)", 2, 0),
                Tuple.Create(" Sockets", 3, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Griswold's Honor")]
        public async Task GriswoldsHonorImageAsync([Remainder] string args = null)
        {
            var name = "Griswold's Honor(68)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/crown_shield_diablo2_wiki_guide_196x294px.png";
            var setName = "Griswold's Legacy";
            var requirements = new List<string>
            {
                "148 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Faster Block Rate", 65, 0),
                Tuple.Create("% Increased Chance of Blocking", 20, 0),
                Tuple.Create(" Defense", 108, 0),
                Tuple.Create(" All Resistances ", 45, 0),
                Tuple.Create(" Sockets", 3, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        
        [Command("Griswold's Valor")]
        public async Task GriswoldsValorImageAsync([Remainder] string args = null)
        {
            var name = "Griswold's Valor(69)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/crown_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Griswold's Legacy";
            var requirements = new List<string>
            {
                "105 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Defense", 50, 75),
                Tuple.Create(" All Resistances", 5, 0),
                Tuple.Create("% Better Chance of Getting Magic Items", 20, 30),
                Tuple.Create("% Requirements", -40, 0),
                Tuple.Create(" Cold Absorb (Based on Character Level)", 0, 24),
                Tuple.Create(" Sockets", 2, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Offensive Auras (Paladin Only)", 2, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("M'avina's Battle Hymn")]
        public async Task MavinasBattleHymnImageAsync()
        {
            await MavinasCasterImageAsync("3");
            await MavinasEmbraceImageAsync("0");
            await MavinasTrueSightImageAsync("0");
            await MavinasIcyClutchImageAsync("0");
            await MavinasTenetImageAsync("0");

        }

        [Command("M'avina's Caster")]
        public async Task MavinasCasterImageAsync([Remainder] string args = null)
        {
            var name = "M'avina's Caster(70)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/reflex_bow_weapons_diablo_2_resurrected_wiki_guide.png";
            var setName = "M'avina's Battle Hymn";
            var requirements = new List<string>
            {
                "108 Strength",
                "152 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Damage", 188, 0),
                Tuple.Create("% Increased Attack Speed", 40, 0),
                Tuple.Create(" Attack Rating", 50, 0),
                Tuple.Create("Fires Magic Arrows (Level 1)", 0, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Magic Damage", 114, 377, "2"),
                Tuple.Create("% Chance to Cast Level 15 Nova on Striking", 10, 0, "3"),
                Tuple.Create(" Bow and Crossbow Skills (Amazon Only)", 2, 0, "4")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("M'avina's Embrace")]
        public async Task MavinasEmbraceImageAsync([Remainder] string args = null)
        {
            var name = "M'avina's Embrace(70)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/field_plate_armor_diablo2_wiki_guide_196px.png";
            var setName = "M'avina's Battle Hymn";
            var requirements = new List<string>
            {
                "122 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 350, 0),
                Tuple.Create(" Defense (Based on Character Level)", 4, 396),
                Tuple.Create("% Requirements", -30, 0),
                Tuple.Create("% Chance to Cast Level 3 Glacial Spike When Struck", 10, 0),
                Tuple.Create(" Magic Damage Reduced", 5, 12),
                Tuple.Create("Passive and Magic Skills (Amazon Only)", 2, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Faster Hit Recovery", 30, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("M'avina's True Sight")]
        public async Task MavinasTrueSightImageAsync([Remainder] string args = null)
        {
            var name = "M'avina's True Sight(64)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/m'avina's_true_sight_diadem_armor_diablo2_wiki_guide_196px.png";
            var setName = "M'avina's Battle Hymn";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 150, 0),
                Tuple.Create(" Replenish Life", 10, 0),
                Tuple.Create(" Mana", 25, 0),
                Tuple.Create("% Increased Attack Speed", 30, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" All Skills", 1, 0, "2"),
                Tuple.Create("% Bonus to Attack Rating", 50, 0, "3"),
                Tuple.Create(" All Resistances", 25, 0, "4")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        
        [Command("M'avina's Icy Clutch")]
        public async Task MavinasIcyClutchImageAsync([Remainder] string args = null)
        {
            var name = "M'avina's Icy Clutch(32)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_gauntlets_diablo2_wiki_guide_196px.png";
            var setName = "M'avina's Battle Hymn";
            var requirements = new List<string>
            {
                "88 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 45, 50),
                Tuple.Create(" Cold Damage", 6, 18),
                Tuple.Create("Half Freeze Duration", 0, 0),
                Tuple.Create("% Extra Gold From Monsters", 56, 0),
                Tuple.Create(" Strength", 10, 0),
                Tuple.Create(" Dexterity", 15, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Cold Damage", 131, 252, "4"),
                Tuple.Create("% to Cold Skill Damage", 20, 0, "Full Set")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("M'avina's Tenet")]
        public async Task MavinasTenetImageAsync([Remainder] string args = null)
        {
            var name = "M'avina's Tenet(45)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/light_belt_armor_diablo2_wiki_guide_196px.png";
            var setName = "M'avina's Battle Hymn";
            var requirements = new List<string>
            {
                "45 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 50, 0),
                Tuple.Create("% Faster Run/Walk", 20, 0),
                Tuple.Create(" Light Radius", 5, 0),
                Tuple.Create("% Mana Stolen per Hit", 5, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" All Resistances", 25, 0, "4")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Natalya's Odium")]
        public async Task NatalyasOdiumImageAsync()
        {
            await NatalyasMarkImageAsync("3");
            await NatalyasShadowImageAsync("0");
            await NatalyasTotemImageAsync("0");
            await NatalyasSoulImageAsync("0");

        }

        [Command("Natalya's Mark")]
        public async Task NatalyasMarkImageAsync([Remainder] string args = null)
        {
            var name = "Natalya's Mark(79)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/natalyas_mark_diablo_2_wiki_guide_125px.png";
            var setName = "Natalya's Odium";
            var requirements = new List<string>
            {
                "118 Strength",
                "118 Dexterity"
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Damage", 200, 0),
                Tuple.Create("% Damage to Undead", 200, 0),
                Tuple.Create("% Damage to Demons", 200, 0),
                Tuple.Create(" Fire Damage", 12, 17),
                Tuple.Create("Ignore Target's Defense", 0, 0),
                Tuple.Create("% Increased Attack Speed", 40, 0),
                Tuple.Create(" Cold Damage", 50, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Natalya's Shadow")]
        public async Task NatalyasShadowImageAsync([Remainder] string args = null)
        {
            var name = "Natalya's Shadow(73)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/scale_mail_armor_diablo2_wiki_guide_196px.png";
            var setName = "Natalya's Odium";
            var requirements = new List<string>
            {
                "149 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 150, 225),
                Tuple.Create(" Life (Based on Character Level)", 1, 99),
                Tuple.Create("% Poison Length Reduced", 75, 0),
                Tuple.Create("% Poison Resist", 25, 0),
                Tuple.Create(" Shadow Disciplines (Assassin Only)", 2, 0),
                Tuple.Create("Sockets", 1, 3)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Natalya's Totem")]
        public async Task NatalyasTotemImageAsync([Remainder] string args = null)
        {
            var name = "Natalya's Totem(59)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/wormskull_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Natalya's Odium";
            var requirements = new List<string>
            {
                "58 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 135, 175),
                Tuple.Create(" All Resistances", 10, 20),
                Tuple.Create(" Dexterity", 20, 30),
                Tuple.Create(" Strength", 10, 20),
                Tuple.Create(" Magic Damage Reduced", 3, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        
        [Command("Natalya's Soul")]
        public async Task NatalyasSoulImageAsync([Remainder] string args = null)
        {
            var name = "Natalya's Soul(25)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/chain_boots_diablo2_wiki_guide_196px.png";
            var setName = "Natalya's Odium";
            var requirements = new List<string>
            {
                "65 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 75, 125),
                Tuple.Create("% Faster Run/Walk", 40, 0),
                Tuple.Create("% Heal Stamina (Based on Character Level)", 0, 24),
                Tuple.Create("% Cold Resist", 15, 15),
                Tuple.Create("% Lightning Resist", 15, 25)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Tal Rasha's Wrappings")]
        public async Task TalRashasWrappingsImageAsync()
        {
            await TalRashasLidlessEyeImageAsync("3");
            await TalRashasGuardianshipImageAsync("0");
            await TalRashasHoradricCrestImageAsync("0");
            await TalRashasFineSpunClothImageAsync("0");
            await TalRashasAdjudicationImageAsync("0");

        }

        [Command("Tal Rasha's Lidless Eye")]
        public async Task TalRashasLidlessEyeImageAsync([Remainder] string args = null)
        {
            var name = "Tal Rasha's Lidless Eye(65)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/dragon_stone_diablo_2_wiki_guide_196px.png";
            var setName = "Tal Rasha's Wrappings";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Faster Cast Rate", 20, 0),
                Tuple.Create(" Mana", 77, 0),
                Tuple.Create(" Life", 57, 0),
                Tuple.Create(" Energy", 10, 0),
                Tuple.Create(" Lightning Mastery (Sorceress Only)", 1, 2),
                Tuple.Create(" Fire Mastery (Sorceress Only)", 1, 2),
                Tuple.Create(" Cold Mastery (Sorceress Only)", 1, 2)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Sorceress Skill Levels", 1, 0, "2"),
                Tuple.Create("% to Enemy Fire Resistance", -15, 0, "3"),
                Tuple.Create("% to Enemy Lightning Resistance", -15, 0, "4"),
                Tuple.Create("% to Cold Skill Damage", -15, 0, "Full Set")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Tal Rasha's Guardianship")]
        public async Task TalRashasGuardianshipImageAsync([Remainder] string args = null)
        {
            var name = "Tal Rasha's Guardianship(71)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gothic_plate_armor_diablo2_wiki_guide_196px.png";
            var setName = "Tal Rasha's Wrappings";
            var requirements = new List<string>
            {
                "84 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 400, 0),
                Tuple.Create("% Requirements", -60, 0),
                Tuple.Create(" Magic Damage Reduced", 15, 0),
                Tuple.Create("% Cold Resist", 40, 0),
                Tuple.Create("% Lightning Resist", 40, 0),
                Tuple.Create("% Fire Resist", 40, 0),
                Tuple.Create("% Better Chance of Getting Magic Items", 88, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Faster Cast Rate", 10, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Tal Rasha's Horadric Crest")]
        public async Task TalRashasHoradricCrestImageAsync([Remainder] string args = null)
        {
            var name = "Tal Rasha's Horadric Crest(66)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/mask_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Tal Rasha's Wrappings";
            var requirements = new List<string>
            {
                "55 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Life Stolen per Hit", 10, 0),
                Tuple.Create("% Mana Stolen per Hit", 10, 0),
                Tuple.Create(" All Resistances", 15, 0),
                Tuple.Create(" Defense", 45, 0),
                Tuple.Create(" Mana", 30, 0),
                Tuple.Create(" Life", 60, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Tal Rasha's Fine-Spun Cloth")]
        public async Task TalRashasFineSpunClothImageAsync([Remainder] string args = null)
        {
            var name = "Tal Rasha's Fine-Spun Cloth(53)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/bell_armor_diablo2_wiki_guide_196px.png";
            var setName = "Tal Rasha's Wrappings";
            var requirements = new List<string>
            {
                "47 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Requirements", -20, 0),
                Tuple.Create("% Damage Taken Goes to Mana", 37, 0),
                Tuple.Create(" Mana", 30, 0),
                Tuple.Create(" Dexterity", 20, 0),
                Tuple.Create("% Better Chance of Getting Magic Items", 10, 15)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense", 60, 0, "2"),
                Tuple.Create("% Faster Cast Rate", 10, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Tal Rasha's Adjudication")]
        public async Task TalRashasAdjudicationImageAsync([Remainder] string args = null)
        {
            var name = "Tal Rasha's Adjudication(67)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/amulet2_diablo2_wiki_guide_98px.png";
            var setName = "Tal Rasha's Wrappings";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Sorceress Skill Levels", 2, 0),
                Tuple.Create("% Lightning Resist", 33, 0),
                Tuple.Create(" Lightning Damage", 3, 32),
                Tuple.Create(" Mana", 42, 0),
                Tuple.Create(" Life", 50, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Faster Cast Rate", 10, 0, "4")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Trang-Oul's Avatar")]
        public async Task TrangOulsAvatarImageAsync()
        {
            await TrangOulsScalesImageAsync("3");
            await TrangOulsWingImageAsync("0");
            await TrangOulsGuiseImageAsync("0");
            await TrangOulsClawsImageAsync("0");
            await TrangOulsGirthImageAsync("0");

        }

        [Command("Trang-Oul's Scales")]
        public async Task TrangOulsScalesImageAsync([Remainder] string args = null)
        {
            var name = "Trang-Oul's Scales(49)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/full_plate_mail_diablo2_wiki_guide_196px.png";
            var setName = "Trang-Oul's Avatar";
            var requirements = new List<string>
            {
                "84 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Defense", 150, 0),
                Tuple.Create("% Requirements", -40, 0),
                Tuple.Create("% Faster Run/Walk", 40, 0),
                Tuple.Create("% Poison Resist", 40, 0),
                Tuple.Create(" Defense vs. Missile", 100, 0),
                Tuple.Create(" Summoning Skills (Necromancer Only)", 2, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Lightning Resist", 50, 0, "3"),
                Tuple.Create("% Damage Reduced", 25, 0, "Full Set")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Trang-Oul's Wing")]
        public async Task TrangOulsWingImageAsync([Remainder] string args = null)
        {
            var name = "Trang-Oul's Wing(54)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gargoyle_head_shield_diablo2_wiki_guide_196x294px.png";
            var setName = "Trang-Oul's Avatar";
            var requirements = new List<string>
            {
                "50 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 125, 0),
                Tuple.Create("% Increased Chance of Blocking", 30, 0),
                Tuple.Create("% Poison Resist", 40, 0),
                Tuple.Create("% Fire Resist", 38, 45),
                Tuple.Create(" Dexterity", 15, 0),
                Tuple.Create(" Strength", 25, 0),
                Tuple.Create(" Poison and Bone Skills (Necromancer Only)", 2, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% to Enemy Poison Resistance", -25, 0, "3"),
                Tuple.Create("Replenish Life", 15, 0, "4")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Trang-Oul's Guise")]
        public async Task TrangOulsGuiseImageAsync([Remainder] string args = null)
        {
            var name = "Trang-Oul's Guise(65)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/wormskull_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Trang-Oul's Avatar";
            var requirements = new List<string>
            {
                "106 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Faster Hit Recovery", 25, 0),
                Tuple.Create(" Replenish Life", 5, 0),
                Tuple.Create(" Defense", 80, 100),
                Tuple.Create(" Mana", 150, 0),
                Tuple.Create(" Damage Taken by Attackers", 20, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        
        [Command("Trang-Oul's Claws")]
        public async Task TrangOulsClawsImageAsync([Remainder] string args = null)
        {
            var name = "Trang-Oul's Claws(45)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/chain_gloves_diablo2_wiki_guide_196px.png";
            var setName = "Trang-Oul's Avatar";
            var requirements = new List<string>
            {
                "58 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Faster Cast Rate", 20, 0),
                Tuple.Create("% Cold Resist", 30, 0),
                Tuple.Create(" Defense", 30, 0),
                Tuple.Create("% to Poison Skill Damage", 25, 0),
                Tuple.Create("Curses (Necromancer Only)", 2, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        
        [Command("Trang-Oul's Girth")]
        public async Task TrangOulsGirthImageAsync([Remainder] string args = null)
        {
            var name = "Trang-Oul's Girth(62)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/heavy_belt_armor_diablo2_wiki_guide_196px.png";
            var setName = "Trang-Oul's Avatar";
            var requirements = new List<string>
            {
                "91 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 75, 100),
                Tuple.Create("% Requirements", -40, 0),
                Tuple.Create("Cannot be Frozen", 0, 0),
                Tuple.Create(" Replenish Life", 5, 0),
                Tuple.Create(" Mana ", 25, 50),
                Tuple.Create(" Maximum Stamina", 30, 0),
                Tuple.Create(" Life", 66, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Cold Resist", 40, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Immortal King")]
        public async Task ImmortalKingImageAsync()
        {
            await ImmortalKingsStoneCrusherImageAsync("3");
            await ImmortalKingsSoulCageImageAsync("0");
            await ImmortalKingsWillImageAsync("0");
            await ImmortalKingsForgeImageAsync("0");
            await ImmortalKingsDetailImageAsync("0");
            await ImmortalKingsPillarImageAsync("0");

        }

        [Command("Immortal King's Stone Crusher")]
        public async Task ImmortalKingsStoneCrusherImageAsync([Remainder] string args = null)
        {
            var name = "Immortal King's Stone Crusher(76)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/maul_weapons_diablo_2_wiki_guide_125px.png";
            var setName = "Immortal King";
            var requirements = new List<string>
            {
                "225 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Damage", 200, 0),
                Tuple.Create("% Damage to Demons", 200, 0),
                Tuple.Create("% Damage to Undead", 250, 0),
                Tuple.Create("% Increased Attack Speed", 40, 0),
                Tuple.Create("Indestructible", 0, 0),
                Tuple.Create("% Chance of Crushing Blow", 40, 45),
                Tuple.Create(" Sockets", 2, 0)

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Fire Damage", 211, 397, "2"),
                Tuple.Create(" Lightning Damage", 7, 477, "3"),
                Tuple.Create(" Cold Damage", 127, 364, "4"),
                Tuple.Create(" Poison Damage Over 6 Seconds", 204, 0, "5"),
                Tuple.Create(" Magic Damage", 250, 361, "Full Set")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Immortal King's Soul Cage")]
        public async Task ImmortalKingsSoulCageImageAsync([Remainder] string args = null)
        {
            var name = "Immortal King's Soul Cage(76)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/silks_of_the_victor_diablo2_wiki_guide_196px.png";
            var setName = "Immortal King";
            var requirements = new List<string>
            {
                "232 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 400, 0),
                Tuple.Create("% Chance To Cast Level 5 Enchant When Struck", 5, 0),
                Tuple.Create("% Poison Resist", 50, 0),
                Tuple.Create(" Combat Skills (Barbarian Only)", 2, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Faster Hit Recovery", 25, 0, "2"),
                Tuple.Create("% Cold Resist", 40, 0, "3"),
                Tuple.Create("% Fire Resist", 40, 0, "4"),
                Tuple.Create("% Lightning Resist", 40, 0, "5"),
                Tuple.Create("% Enhanced Defense", 50, 0, "Full Set")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Immortal King's Will")]
        public async Task ImmortalKingsWillImageAsync([Remainder] string args = null)
        {
            var name = "Immortal King's Will(47)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/arreats_face_helm_armor_diablo2_wiki_guide_196px.png";
            var setName = "Immortal King";
            var requirements = new List<string>
            {
                "65 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Light Radius", 4, 0),
                Tuple.Create(" Defense", 125, 0),
                Tuple.Create("% Extra Gold From Monsters", 37, 0),
                Tuple.Create("% Better Chance of Getting Magic Items", 25, 40),
                Tuple.Create(" Warcries (Barbarian Only)", 2, 0),
                Tuple.Create(" Sockets", 2, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Immortal King's Forge")]
        public async Task ImmortalKingsForgeImageAsync([Remainder] string args = null)
        {
            var name = "Immortal King's Forge(30)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/gauntlets_diablo2_wiki_guide_196px.png";
            var setName = "Immortal King";
            var requirements = new List<string>
            {
                "110 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 65, 0),
                Tuple.Create("% Chance to Cast Level 4 Charged Bolt When Struck", 12, 0),
                Tuple.Create(" Dexterity", 20, 0),
                Tuple.Create(" Strength", 20, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Increased Attack Speed", 25, 0, "2"),
                Tuple.Create(" Defense", 65, 0, "3"),
                Tuple.Create("% Life Stolen per Hit", 10, 0, "4"),
                Tuple.Create("% Mana Stolen per Hit", 10, 0, "5"),
                Tuple.Create("Freezes Target +2", 0, 0, "Full Set")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Immortal King's Detail")]
        public async Task ImmortalKingsDetailImageAsync([Remainder] string args = null)
        {
            var name = "Immortal King's Detail(29)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/plated_belt_armor_diablo2_wiki_guide_196px.png";
            var setName = "Immortal King";
            var requirements = new List<string>
            {
                "110 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 36, 0),
                Tuple.Create("% Lightning Resist", 31, 0),
                Tuple.Create("% Fire Resist", 28, 0),
                Tuple.Create(" Strength", 25, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense", 105, 0, "2"),
                Tuple.Create("% Faster Hit Recovery", 25, 0, "3"),
                Tuple.Create("% Enhanced Defense", 100, 0, "4"),
                Tuple.Create("% Damage Reduced", 20, 0, "5"),
                Tuple.Create(" Masteries (Barbarian Only)", 2, 0, "Full Set")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
        [Command("Immortal King's Pillar")]
        public async Task ImmortalKingsPillarImageAsync([Remainder] string args = null)
        {
            var name = "Immortal King's Pillar(31)";
            var imageLink = "https://diablo2.wiki.fextralife.com/file/Diablo-2/plate_boots_diablo2_wiki_guide_196px.png";
            var setName = "Immortal King";
            var requirements = new List<string>
            {
                "125 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 75, 0),
                Tuple.Create("% Faster Run/Walk", 40, 0),
                Tuple.Create(" Attack Rating", 110, 0),
                Tuple.Create(" Life", 44, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Better Chance of Getting Magic Items", 25, 0, ""),
                Tuple.Create("Combat Skills (Barbarian Only)", 2, 0, ""),
                Tuple.Create(" Defense", 160, 0, ""),
                Tuple.Create("Half Freeze Duration", 0, 0, "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink, args);
        }
    }
}
