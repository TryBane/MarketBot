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
                        "",
                        "",
                        ""
                    };
                    setBonuses = new List<Tuple<string, int, int, string>> {
                        Tuple.Create("Partial Set Bonus", 0, 0, ""),
                        Tuple.Create("", , , ""),
                        Tuple.Create("Complete Set Bonus", 0, 0, ""),
                        Tuple.Create("", , , ""),
                        Tuple.Create("", , , ""),
                        Tuple.Create("", , , ""),
                        Tuple.Create("", , , ""),
                        Tuple.Create("", , , "")
                    };
                    break;
                    case "":
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
                    case "M'avina's Battle Hymn:
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
                        Tuple.Create(" Sorceress Skill Levels", 3, , ""),
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
                        Tuple.Create(" Defense", 200, , ""),
                        Tuple.Create(" Mana", 100, , ""),
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
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
            await ArcannasDeathwandImageAsync();
            await ArcannasFleshImageAsync();
            await ArcannasHeadImageAsync();
            await ArcannasSignImageAsync();

        }

        [Command("Arcanna's Deathwand")]
        public async Task ArcannasDeathwandImageAsync()
        {
            var name = "Arcanna's Deathwand(15)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }

        [Command("Arcanna's Flesh")]
        public async Task ArcannasFleshImageAsync()
        {
            var name = "Arcanna's Flesh(15)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }

        [Command("Arcanna's Head")]
        public async Task ArcannasHeadImageAsync()
        {
            var name = "Arcanna's Head(15)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }

        [Command("Arcanna's Sign")]
        public async Task ArcannasSignImageAsync()
        {
            var name = "Arcanna's Sign(15)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Arctic Gear")]
        public async Task ArcticGearImageAsync()
        {
            await ArcticHornImageAsync();
            await ArcticFursImageAsync();
            await ArcticMittsImagekAsync();
            await ArcticBindingImagekAsync();

        }

        [Command("Arctic Horn")]
        public async Task ArcticHornImageAsync()
        {
            var name = "Arctic Horn(2)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Arctic Furs")]
        public async Task ArcticFursImageAsync()
        {
            var name = "Arctic Furs(2)";
            var imageLink = "";
            var setName = "Arctic Gear";
            var requirements = new List<string>
            {
                "12 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Defense", 275, 325),
                Tuple.Create(" All Resistances", 10, )

            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Defense (Based on Character Level)", 3, 297, "2"),
                Tuple.Create("% Cold Resist", 15, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Arctic Mitts")]
        public async Task ArcticMittsImageAsync()
        {
            var name = "Arctic Mitts(2)";
            var imageLink = "";
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
                Tuple.Create(" Attack rating", 50, 0, "2")
                Tuple.Create(" Dexterity ", 10, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Arctic Binding")]
        public async Task ArcticBindingImageAsync()
        {
            var name = "Arctic Binding(2)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }

        [Command("Cathan's Traps")]
        public async Task CathansTrapsImageAsync()
        {
            await CathansRuleImageAsync();
            await CathansMeshImageAsync();
            await CathansVisageImageAsync();
            await CathansSigilImageAsync();
            await CathansSealImageAsync();
            
        }

        [Command("Cathan's Rule")]
        public async Task ImageAsync()
        {
            var name = "Cathan's Rule(11)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Cathan's Mesh")]
        public async Task CathansMeshImageAsync()
        {
            var name = "Cathan's Mesh(11)";
            var imageLink = "";
            var setName = "Cathan's Traps";
            var requirements = new List<string>
            {
                "24 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 15, 0),
                Tuple.Create(" Requirements", -50%, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Damage Taken by Attackers", 5, 0, "2"),
                Tuple.Create("% Fire Resist", 30, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Cathan's Visage")]
        public async Task CathansVisageImageAsync()
        {
            var name = "Cathan's Visage(11)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Cathan's Sigil")]
        public async Task CathansSigilImageAsync()
        {
            var name = "Cathan's Sigil";
            var imageLink = "";
            var setName = "Cathan's Traps(11)";
            var requirements = new List<string>
            {
                "",
                ""
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Cathan's Seal")]
        public async Task CathansSealImageAsync()
        {
            var name = "Cathan's Seal(11)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Civerb's Vestments")]
        public async Task CiverbsVestmentsImageAsync()
        {
            await CiverbsCudgelImageAsync();
            await CiverbsWardImageAsync();
            await CiverbsIconImageAsync();

        }

        [Command("Civerb's Cudgel")]
        public async Task CiverbsCudgelImageAsync()
        {
            var name = "Civerb's Cudgel(9)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Civerb's Ward")]
        public async Task CiverbsWardImageAsync()
        {
            var name = "Civerb's Ward(9)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Civerb's Icon")]
        public async Task CiverbsIconImageAsync()
        {
            var name = "Civerb's Icon(9)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Cleglaw's Brace")]
        public async Task CleglawsBraceImageAsync()
        {
            await CleglawsToothImageAsync();
            await CleglawsClawImageAsync();
            await CleglawsPincersImageAsync();

        }

        [Command("Cleglaw's Tooth")]
        public async Task ImageAsync()
        {
            var name = "Cleglaw's Tooth(4)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Cleglaw's Claw")]
        public async Task CleglawsClawImageAsync()
        {
            var name = "Cleglaw's Claw(4)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Cleglaw's Pincers")]
        public async Task CleglawsPincersImageAsync()
        {
            var name = "Cleglaw's Pincers(4)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Angelic Raiment")]
        public async Task AngelicRaimentImageAsync()
        {
            await AngelicSickleImageAsync();
            await AngelicMantleImageAsync();
            await AngelicHaloImageAsync();
            await AngelicWingsImageAsync();

        }

        [Command("Angelic Sickle")]
        public async Task ImageAsync()
        {
            var name = "Angelic Sickle(12)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Angelic Mantle")]
        public async Task AngelicMantleImageAsync()
        {
            var name = "Angelic Mantle(12)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Angelic Halo")]
        public async Task AngelicHaloImageAsync()
        {
            var name = "Angelic Halo(12)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Angelic Wings")]
        public async Task AngelicWingsImageAsync()
        {
            var name = "Angelic Wings(12)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Hsarus' Defense")]
        public async Task HsarusDefenseImageAsync()
        {
            await HsarusIronFistImageAsync();
            await HsarusIronStayImageAsync();
            await HsarusIronHeelImageAsync();

        }

        [Command("Hsarus' Iron Fist")]
        public async Task HsarusIronFistImageAsync()
        {
            var name = "Hsarus' Iron Fist(3)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Hsarus' Iron Stay")]
        public async Task HsarusIronStayImageAsync()
        {
            var name = "Hsarus' Iron Stay(3)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Hsarus' Iron Heel")]
        public async Task HsarusIronHeelImageAsync()
        {
            var name = "Hsarus' Iron Heel(3)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Infernal Tools")]
        public async Task InfernalToolsImageAsync()
        {
            await InfernalTorchImageAsync();
            await InfernalCraniumImageAsync();
            await InfernalSignImageAsync();

        }

        [Command("Infernal Torch")]
        public async Task InfernalTorchImageAsync()
        {
            var name = "Infernal Torch(5)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Infernal Cranium")]
        public async Task InfernalCraniumImageAsync()
        {
            var name = "Infernal Cranium(5)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Infernal Sign")]
        public async Task InfernalSignImageAsync()
        {
            var name = "Infernal Sign(5)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Iratha's Finery")]
        public async Task IrathasFineryImageAsync()
        {
            await IrathasCoilImageAsync();
            await IrathasCuffImageAsync();
            await IrathasCordImageAsync();
            await IrathasCollarImageAsync();

        }

        [Command("Iratha's Coil")]
        public async Task IrathasCoilImageAsync()
        {
            var name = "Iratha's Coil(15)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Iratha's Cuff")]
        public async Task IrathasCuffImageAsync()
        {
            var name = "Iratha's Cuff(15)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Iratha's Cord")]
        public async Task IrathasCordImageAsync()
        {
            var name = "Iratha's Cord(15)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Iratha's Collar")]
        public async Task IrathasCollarImageAsync()
        {
            var name = "Iratha's Collar(15)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Isenhart's Armory")]
        public async Task IsenhartsArmoryImageAsync()
        {
            await IsenhartsLightbrandImageAsync();
            await IsenhartsCaseImageAsync();
            await IsenhartsParryImageAsync();
            await IsenhartsHornsImageAsync();

        }

        [Command("Isenhart's Lightbrand")]
        public async Task IsenhartsLightbrandImageAsync()
        {
            var name = "Isenhart's Lightbrand(8)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Isenhart's Case")]
        public async Task IsenhartsCaseImageAsync()
        {
            var name = "Isenhart's Case(8)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Isenhart's Parry")]
        public async Task IsenhartsParryImageAsync()
        {
            var name = "Isenhart's Parry(8)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        
        [Command("Isenhart's Horns")]
        public async Task IsenhartsHornsImageAsync()
        {
            var name = "Isenhart's Horns(8)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Milabrega's Regalia")]
        public async Task ImageAsync()
        {
            await MilabregasRodImageAsync();
            await MilabregasRobeImageAsync();
            await MilabregasOrbImageAsync();
            await MilabregasDiademImageAsync();

        }

        [Command("Milabrega's Rod")]
        public async Task MilabregasRodImageAsync()
        {
            var name = "Milabrega's Rod";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Milabrega's Robe")]
        public async Task MilabregasRobeImageAsync()
        {
            var name = "Milabrega's Robe(17)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Milabrega's Orb")]
        public async Task MilabregasOrbImageAsync()
        {
            var name = "Milabrega's Orb(17)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Milabrega's Diadem")]
        public async Task MilabregasDiademImageAsync()
        {
            var name = "Milabrega's Diadem(17)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Sigon's Complete Steel")]
        public async Task SigonsCompleteSteelImageAsync()
        {
            await SigonsShelterImageAsync();
            await SigonsGuardImageAsync();
            await SigonsVisorImageAsync();
            await SigonsGageImageAsync();
            await SigonsWrapImageAsync();
            await SigonsSabotImageAsync();

        }

        [Command("Sigon's Shelter")]
        public async Task SigonsShelterImageAsync()
        {
            var name = "Sigon's Shelter(6)";
            var imageLink = "";
            var setName = "Sigon's Complete Steel";
            var requirements = new List<string>
            {
                "70 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Enhanced Defense", 25, 0),
                Tuple.Create("% Lightning Resist", 30, )
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" Damage Taken by Attackers", 20, 0, "2")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Sigon's Guard")]
        public async Task SigonsGuardImageAsync()
        {
            var name = "Sigon's Guard(6)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Sigon's Visor")]
        public async Task SigonsVisorImageAsync()
        {
            var name = "Sigon's Visor(6)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        
        [Command("Sigon's Gage")]
        public async Task SigonsGageImageAsync()
        {
            var name = "Sigon's Gage(6)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        
        [Command("Sigon's Wrap")]
        public async Task SigonsWrapImageAsync()
        {
            var name = "Sigon's Wrap(6)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        
        [Command("Sigon's Sabot")]
        public async Task SigonsSabotImageAsync()
        {
            var name = "Sigon's Sabot(6)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Tancred's Battlegear")]
        public async Task TancredsBattlegearImageAsync()
        {
            await TancredsCrowbillImageAsync();
            await TancredsSpineImageAsync();
            await TancredsSkullImageAsync();
            await TancredsHobnailsImageAsync();
            await TancredsWeirdImageAsync();

        }

        [Command("Tancred's Crowbill")]
        public async Task TancredsCrowbillImageAsync()
        {
            var name = "Tancred's Crowbill(20)";
            var imageLink = "";
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
                Tuple.Create(" Mana", 20, 0),
                Tuple.Create("% Increased Attack Speed", 20, 0)
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Tancred's Spine")]
        public async Task TancredsSpineImageAsync()
        {
            var name = "Tancred's Spine(20)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Tancred's Skull")]
        public async Task TancredsSkullImageAsync()
        {
            var name = "Tancred's Skull(20)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Tancred's Hobnails")]
        public async Task TancredsHobnailsImageAsync()
        {
            var name = "Tancred's Hobnails(20)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Tancred's Weird")]
        public async Task TancredsWeirdImageAsync()
        {
            var name = "Tancred's Weird(20)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Death's Disguise")]
        public async Task DeathsDisguiseImageAsync()
        {
            await DeathsTouchImageAsync();
            await DeathsHandImageAsync();
            await DeathsGuardImageAsync();

        }

        [Command("Death's Touch")]
        public async Task DeathsTouchImageAsync()
        {
            var name = "Death's Touch(6)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Death's Hand")]
        public async Task DeathsHandImageAsync()
        {
            var name = "Death's Hand(6)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Death's Guard")]
        public async Task DeathsGuardImageAsync()
        {
            var name = "Death's Guard(6)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Vidala's Rig")]
        public async Task VidalasRigImageAsync()
        {
            await VidalasBarbImageAsync();
            await VidalasAmbushImageAsync();
            await VidalasFetlockImageAsync();
            await VidalasSnareImageAsync();

        }

        [Command("Vidala's Barb")]
        public async Task VidalasBarbImageAsync()
        {
            var name = "Vidala's Barb(14)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Vidala's Ambush")]
        public async Task VidalasAmbushImageAsync()
        {
            var name = "Vidala's Ambush(14)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Vidala's Fetlock")]
        public async Task VidalasFetlockImageAsync()
        {
            var name = "Vidala's Fetlock(14)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Vidala's Snare")]
        public async Task VidalasSnareImageAsync()
        {
            var name = "Vidala's Snare(14)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Heaven's Brethren")]
        public async Task HeavensBrethrenImageAsync()
        {
            await DangoonsTeachingImageAsync();
            await HaemosusAdamantImageAsync();
            await TaebaeksGloryImageAsync();
            await OndalsAlmightyImageAsync();

        }

        [Command("Dangoon's Teaching")]
        public async Task DangoonsTeachingImageAsync()
        {
            var name = "Dangoon's Teaching(68)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Haemosu's Adamant")]
        public async Task HaemosusAdamantImageAsync()
        {
            var name = "Haemosu's Adamant(44)";
            var imageLink = "";
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
                Tuple.Create(" Defense vs. Missile", 35, ),
                Tuple.Create("% Requirements", -20, ),
                Tuple.Create(" Life", 75, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Taebaek's Glory")]
        public async Task TaebaeksGloryImageAsync()
        {
            var name = "Taebaek's Glory(81)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Ondal's Almighty")]
        public async Task OndalsAlmightyImageAsync()
        {
            var name = "Ondal's Almighty(69)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("The Disciple")]
        public async Task TheDiscipleImageAsync()
        {
            await ImageAsync();
            await ImageAsync();
            await ImageAsync();
            await ImageAsync();
            await ImageAsync();
            

        }

        [Command("Dark Adherent")]
        public async Task DarkAdherentImageAsync()
        {
            var name = "Dark Adherent(49)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Laying of Hands")]
        public async Task LayingofHandsImageAsync()
        {
            var name = "Laying of Hands(63)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Credendum")]
        public async Task CredendumImageAsync()
        {
            var name = "Credendum(65)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Rite of Passage")]
        public async Task ImageAsync()
        {
            var name = "Rite of Passage(29)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Telling of Beads")]
        public async Task TellingofBeadsImageAsync()
        {
            var name = "Telling of Beads(30)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Hwanin's Majesty")]
        public async Task HwaninsMajestyImageAsync()
        {
            await HwaninsJusticeImageAsync();
            await HwaninsRefugeImageAsync();
            await HwaninsSplendorImageAsync();
            await HwaninsBlessingImageAsync();

        }

        [Command("Hwanin's Justice")]
        public async Task HwaninsJusticeImageAsync()
        {
            var name = "Hwanin's Justice(28)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Hwanin's Refuge")]
        public async Task HwaninsRefugeImageAsync()
        {
            var name = "Hwanin's Refuge(30)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Hwanin's Splendor")]
        public async Task HwaninsSplendorImageAsync()
        {
            var name = "Hwanin's Splendor(45)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Hwanin's Blessing")]
        public async Task HwaninsBlessingImageAsync()
        {
            var name = "Hwanin's Blessing(35)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Cow King's Leathers")]
        public async Task CowKingsLeathersImageAsync()
        {
            await CowKingsHornsImageAsync();
            await CowKingsHideImageAsync();
            await CowKingsHoovesImageAsync();

        }

        [Command("Cow King's Horns")]
        public async Task ImageAsync()
        {
            var name = "Cow King's Horns(25)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Cow King's Hide")]
        public async Task CowKingsHideImageAsync()
        {
            var name = "Cow King's Hide(18)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Cow King's Hooves")]
        public async Task CowKingsHoovesImageAsync()
        {
            var name = "Cow King's Hooves(13)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Naj's Ancient Vestige")]
        public async Task NajsAncientVestigeImageAsync()
        {
            await NajsPuzzlerImageAsync();
            await NajsLightPlateImageAsync();
            await NajsCircletImageAsync();

        }

        [Command("Naj's Puzzler")]
        public async Task NajsPuzzlerImageAsync()
        {
            var name = "Naj's Puzzler(78)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Naj's Light Plate")]
        public async Task NajsLightPlateImageAsync()
        {
            var name = "Naj's Light Plate(71)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Naj's Circlet")]
        public async Task NajsCircletImageAsync()
        {
            var name = "Naj's Circlet(28)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Sander's Folly")]
        public async Task SandersFollyImageAsync()
        {
            await SandersParagonImageAsync();
            await SandersSuperstitionImageAsync();
            await SandersTabooImageAsync();
            await SandersRiprapImageAsync();

        }

        [Command("Sander's Paragon")]
        public async Task SandersParagonImageAsync()
        {
            var name = "Sander's Paragon(25)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Sander's Superstition")]
        public async Task SandersSuperstitionImageAsync()
        {
            var name = "Sander's Superstition(25)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Sander's Taboo")]
        public async Task SandersTabooImageAsync()
        {
            var name = "Sander's Taboo(28)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Sander's Riprap")]
        public async Task SandersRiprapImageAsync()
        {
            var name = "Sander's Riprap(20)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Sazabi's Grand Tribute")]
        public async Task SazabisGrandTributeImageAsync()
        {
            await SazabisCobaltRedeemerImageAsync();
            await SazabisGhostLiberatorImageAsync();
            await SazabisMentalSheathImageAsync();

        }

        [Command("Sazabi's Cobalt Redeemer")]
        public async Task SazabisCobaltRedeemerImageAsync()
        {
            var name = "Sazabi's Cobalt Redeemer(73)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Sazabi's Ghost Liberator")]
        public async Task SazabisGhostLiberatorImageAsync()
        {
            var name = "Sazabi's Ghost Liberator(67)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Sazabi's Mental Sheath")]
        public async Task SazabisMentalSheathImageAsync()
        {
            var name = "Sazabi's Mental Sheath(43)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Orphan's Call")]
        public async Task OrphansCallImageAsync()
        {
            await GuillaumesFaceImageAsync();
            await WhitstansGuardImageAsync();
            await MagnusSkinImageAsync();
            await WilhelmsPrideImageAsync();

        }

        [Command("Guillaume's Face")]
        public async Task GuillaumesFaceImageAsync()
        {
            var name = "Guillaume's Face(34)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Whitstan's Guard")]
        public async Task WhitstansGuardImageAsync()
        {
            var name = "Whitstan's Guard(29)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Magnus' Skin")]
        public async Task MagnusSkinImageAsync()
        {
            var name = "Magnus' Skin(37)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Wilhelm's Pride")]
        public async Task WilhelmsPrideImageAsync()
        {
            var name = "Wilhelm's Pride(42)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Aldur's Watchtower")]
        public async Task AldursWatchtowerImageAsync()
        {
            await AldursRhythmImageAsync();
            await AldursDeceptionImageAsync();
            await AldursStonyGazeImageAsync();
            await AldursAdvanceImageAsync();

        }

        [Command("Aldur's Rhythm")]
        public async Task AldursRhythmImageAsync()
        {
            var name = "Aldur's Rhythm(42)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Aldur's Deception")]
        public async Task AldursDeceptionImageAsync()
        {
            var name = "Aldur's Deception(76)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Aldur's Stony Gaze")]
        public async Task AldursStonyGazeImageAsync()
        {
            var name = "Aldur's Stony Gaze(36)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
                [Command("Aldur's Advance")]
        public async Task AldursAdvanceImageAsync()
        {
            var name = "Aldur's Advance(45)";
            var imageLink = "";
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
                Tuple.Create(" Life", 50, ),
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Bul-Kathos' Children")]
        public async Task BulKathosChildrenImageAsync()
        {
            await BulKathosSacredChargeImageAsync();
            await BulKathosTribalGuardianImageAsync();
           

        }

        [Command("Bul-Kathos' Sacred Charge")]
        public async Task BulKathosSacredChargeImageAsync()
        {
            var name = "BulKathosSacredCharge(63)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Bul-Kathos' Tribal Guardian")]
        public async Task BulKathosTribalGuardianImageAsync()
        {
            var name = "Bul-Kathos' Tribal Guardian(66)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Griswold's Legacy")]
        public async Task GriswoldsLegacyImageAsync()
        {
            await GriswoldsRedemptionImageAsync();
            await GriswoldsHeartImageAsync();
            await GriswoldsHonorImageAsync();
            await GriswoldsValorImageAsync();

        }

        [Command("Griswold's Redemption")]
        public async Task GriswoldsRedemptionImageAsync()
        {
            var name = "Griswold's Redemption(66)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Griswold's Heart")]
        public async Task GriswoldsHeartImageAsync()
        {
            var name = "Griswold's Heart(45)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Griswold's Honor")]
        public async Task GriswoldsHonorImageAsync()
        {
            var name = "Griswold's Honor(68)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        
        [Command("Griswold's Valor")]
        public async Task GriswoldsValorImageAsync()
        {
            var name = "Griswold's Valor(69)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("M'avina's Battle Hymn")]
        public async Task MavinasBattleHymnImageAsync()
        {
            await MavinasCasterImageAsync();
            await MavinasEmbraceImageAsync();
            await MavinasTrueSightImageAsync();
            await MavinasIcyClutchImageAsync();
            await MavinasTenetImageAsync();

        }

        [Command("M'avina's Caster")]
        public async Task MavinasCasterImageAsync()
        {
            var name = "M'avina's Caster(70)";
            var imageLink = "";
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
                Tuple.Create("% Chance to Cast Level 15 Nova on Striking", 10, , "3"),
                Tuple.Create(" Bow and Crossbow Skills (Amazon Only)", 2, 0, "4")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("M'avina's Embrace")]
        public async Task MavinasEmbraceImageAsync()
        {
            var name = "M'avina's Embrace(70)";
            var imageLink = "";
            var setName = "M'avina's Battle Hymn";
            var requirements = new List<string>
            {
                "122 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 350, ),
                Tuple.Create(" Defense (Based on Character Level)", 4, 396),
                Tuple.Create("% Requirements", -30, ),
                Tuple.Create("% Chance to Cast Level 3 Glacial Spike When Struck", 10, ),
                Tuple.Create(" Magic Damage Reduced", 5, 12),
                Tuple.Create("Passive and Magic Skills (Amazon Only)", 2, 0)
            };

            var setBonuses = new List<Tuple<string, int, int, string>>()
            {
                Tuple.Create("% Faster Hit Recovery", 30, 0, "3")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("M'avina's True Sight")]
        public async Task MavinasTrueSightImageAsync()
        {
            var name = "M'avina's True Sight(64)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        
        [Command("M'avina's Icy Clutch")]
        public async Task MavinasIcyClutchImageAsync()
        {
            var name = "M'avina's Icy Clutch(32)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("M'avina's Tenet")]
        public async Task MavinasTenetImageAsync()
        {
            var name = "M'avina's Tenet(45)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Natalya's Odium")]
        public async Task NatalyasOdiumImageAsync()
        {
            await NatalyasMarkImageAsync();
            await NatalyasShadowImageAsync();
            await NatalyasTotemImageAsync();
            await NatalyasSoulImageAsync();

        }

        [Command("Natalya's Mark")]
        public async Task NatalyasMarkImageAsync()
        {
            var name = "Natalya's Mark(79)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Natalya's Shadow")]
        public async Task NatalyasShadowImageAsync()
        {
            var name = "Natalya's Shadow(73)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Natalya's Totem")]
        public async Task NatalyasTotemImageAsync()
        {
            var name = "Natalya's Totem(59)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        
        [Command("Natalya's Soul")]
        public async Task NatalyasSoulImageAsync()
        {
            var name = "Natalya's Soul(25)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Tal Rasha's Wrappings")]
        public async Task TalRashasWrappingsImageAsync()
        {
            await TalRashasLidlessEyeImageAsync();
            await TalRashasGuardianshipImageAsync();
            await TalRashasHoradricCrestImageAsync();
            await TalRashasFineSpunClothImageAsync();
            await TalRashasAdjudicationImageAsync();

        }

        [Command("Tal Rasha's Lidless Eye")]
        public async Task TalRashasLidlessEyeImageAsync()
        {
            var name = "Tal Rasha's Lidless Eye(65)";
            var imageLink = "";
            var setName = "Tal Rasha's Wrappings";
            var requirements = new List<string>
            {
                "",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("% Faster Cast Rate", 20, ),
                Tuple.Create(" Mana", 77, ),
                Tuple.Create(" Life", 57, ),
                Tuple.Create(" Energy", 10, ),
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Tal Rasha's Guardianship")]
        public async Task TalRashasGuardianshipImageAsync()
        {
            var name = "Tal Rasha's Guardianship(71)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Tal Rasha's Horadric Crest")]
        public async Task TalRashasHoradricCrestImageAsync()
        {
            var name = "Tal Rasha's Horadric Crest(66)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Tal Rasha's Fine-Spun Cloth")]
        public async Task TalRashasFineSpunClothImageAsync()
        {
            var name = "Tal Rasha's Fine-Spun Cloth(53)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Tal Rasha's Adjudication")]
        public async Task TalRashasAdjudicationImageAsync()
        {
            var name = "Tal Rasha's Adjudication(67)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Trang-Oul's Avatar")]
        public async Task TrangOulsAvatarImageAsync()
        {
            await TrangOulsScalesImageAsync();
            await TrangOulsWingImageAsync();
            await TrangOulsGuiseImageAsync();
            await TrangOulsClawsImageAsync();
            await TrangOulsGirthImageAsync();

        }

        [Command("Trang-Oul's Scales")]
        public async Task TrangOulsScalesImageAsync()
        {
            var name = "Trang-Oul's Scales(49)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Trang-Oul's Wing")]
        public async Task TrangOulsWingImageAsync()
        {
            var name = "Trang-Oul's Wing(54)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Trang-Oul's Guise")]
        public async Task TrangOulsGuiseImageAsync()
        {
            var name = "Trang-Oul's Guise(65)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        
        [Command("Trang-Oul's Claws")]
        public async Task TrangOulsClawsImageAsync()
        {
            var name = "Trang-Oul's Claws(45)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        
        [Command("Trang-Oul's Girth")]
        public async Task TrangOulsGirthImageAsync()
        {
            var name = "Trang-Oul's Girth(62)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Immortal King")]
        public async Task ImmortalKingImageAsync()
        {
            await ImmortalKingsStoneCrusherImageAsync();
            await ImmortalKingsSoulCageImageAsync();
            await ImmortalKingsWillImageAsync();
            await ImmortalKingsForgeImageAsync();
            await ImmortalKingsDetailImageAsync();
            await ImmortalKingsPillarImageAsync();

        }

        [Command("Immortal King's Stone Crusher")]
        public async Task ImmortalKingsStoneCrusherImageAsync()
        {
            var name = "Immortal King's Stone Crusher(76)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Immortal King's Soul Cage")]
        public async Task ImmortalKingsSoulCageImageAsync()
        {
            var name = "Immortal King's Soul Cage(76)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Immortal King's Will")]
        public async Task ImmortalKingsWillImageAsync()
        {
            var name = "Immortal King's Will(47)";
            var imageLink = "";
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
                Tuple.Create(" ", , , ""),
                Tuple.Create(" ", , , "")
            };

            var setPieces = ParseSetPieces(name, setName);
            setBonuses.AddRange(GetSetPieces(setName).Item2);

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Immortal King's Forge")]
        public async Task ImmortalKingsForgeImageAsync()
        {
            var name = "Immortal King's Forge(30)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Immortal King's Detail")]
        public async Task ImmortalKingsDetailImageAsync()
        {
            var name = "Immortal King's Detail(29)";
            var imageLink = "";
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
        [Command("Immortal King's Pillar")]
        public async Task ImmortalKingsPillarImageAsync()
        {
            var name = "Immortal King's Pillar(31)";
            var imageLink = "";
            var setName = "Immortal King";
            var requirements = new List<string>
            {
                "125 Strength",
                ""
            };

            var affixes = new List<Tuple<string, int, int>>()
            {
                Tuple.Create(" Defense", 75, 0),
                Tuple.Create("% Faster Run/Walk, 40, 0),
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

            await CreateSetImage(affixes, setBonuses, name, requirements, setPieces, imageLink);
        }
    }
}
