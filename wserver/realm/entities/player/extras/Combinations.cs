#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace wServer.realm.entities.player
{
    public class Combinations
    {
        public Tuple<string, int> Combo = new Tuple<string, int>("Short Sword", 0);
        public List<int> SlotList = new List<int>();

        public Dictionary<string[], Tuple<string, int, bool>> advCombos =
            new Dictionary<string[], Tuple<string, int, bool>>();

        public Dictionary<string[], Tuple<string, int>> combos = new Dictionary<string[], Tuple<string, int>>();

        public Combinations()
        {
            // ---- ADVANCED COMBOS ---- //
            AddAdvCombo("Robe of the Nile", 6000, "Robe of the Ancient Intellect", "Robe of the Grand Sorcerer");
            AddAdvCombo("Armor of the Pyramid", 6000, "Annihilation Armor", "Acropolis Armor");
            AddAdvCombo("Sphinx Leather Armor", 6000, "Hydra Skin Armor", "Leviathan Armor");

            // ---- NORMAL COMBOS ---- //
            AddCombo("Elder Draconis Key", 100, "Black Dragon Gods Blade", "Blue Dragon Gods Helm", "Red Dragon Gods Helm", "Green Dragon Gods Helm");
            AddCombo("Crown", 12000, "Chicken Leg of Doom", "Anatis Staff");
            AddCombo("Anatis Staff", 500, "Wand of the Bulwark", "Energy Staff");
            AddCombo("Chicken Leg of Doom", 500, "Anatis Staff", "Dagger of Dire Hatred");
            AddCombo("Potion of Oryx", 100, "Potion of Dexterity", "Potion of Speed", "Potion of Wisdom", "Potion of Vitality", "Potion of Defense", "Potion of Attack", "Potion of Life", "Potion of Mana");
            AddCombo("Potion of Maxy", 5000, "Eternal Elements", "Potion of Oryx", "Demon Blood", "Raw Power", "Trapped Soul", "Purified Doom Saliva", "Magical Powder", "Potion of Defense");
//            AddCombo("Dagger of Dire Hatred", 200, "Dagger of Foul Malevolence", "Dagger of Sinister Deeds");

//            AddCombo("Wand of Retribution", 200, "Wand of Recompense", "Wand of Evocation");
//            AddCombo("Staff of the Fundamental Core", 200, "Staff of the Vital Unity", "Staff of the Cosmic Whole");
//            AddCombo("Thousand Shot", 1000, "Doom Bow", "Coral Bow");

            // --- Specials --- //
            AddCombo("Spell of Invisibility", 1, "Trapped Soul", "Magical Powder", "Feather", "Scroll of Zeal");
            AddCombo("Spell of Teleportation", 1, "Demon Blood", "Magical Powder", "Scroll of Zeal");
            AddCombo("Spell of Shielding", 1, "Feather", "Raw Power", "Scroll of Zeal");
            AddCombo("Spell of Life", 1, "Phoenix Feather", "Feather", "Scroll of Zeal");

            AddCombo("Tome of Poison", 1, "Shattered Rune of Oryx", "Purified Doom Saliva", "Eternal Elements");
            AddCombo("Tome of Speed", 1, "Fire Gem", "Demon Blood", "Scroll of Zeal");
            AddCombo("Tome of the Dead", 1, "Shattered Skull", "Trapped Soul", "Scroll of Zeal");
            AddCombo("Tome of Shining Stars", 1, "Magical Powder", "Raw Power", "Shattered Amulet", "Scroll of Zeal");

            AddCombo("Skull of the Twizted", 1, "Rare Ore", "Shattered Skull", "Trapped Soul", "Demon Blood");
            AddCombo("Eternal Sword", 1, "Broken Glass Sword", "Raw Power", "Magical Powder", "Rare Ore");

            // --- Upscale Combos Swords --- //
            AddCombo("Broad Sword", 10, "Short Sword", "Short Sword");
            AddCombo("Saber", 30, "Broad Sword", "Broad Sword");
            AddCombo("Long Sword", 50, "Saber", "Saber");
            AddCombo("Falchion", 70, "Long Sword", "Long Sword");
            AddCombo("Fire Sword", 90, "Falchion", "Falchion");
            AddCombo("Glass Sword", 100, "Fire Sword", "Fire Sword");
            AddCombo("Golden Sword", 200, "Glass Sword", "Glass Sword");
            AddCombo("Ravenheart Sword", 300, "Golden Sword", "Golden Sword");
            AddCombo("Dragonsoul Sword", 400, "Ravenheart Sword", "Ravenheart Sword");
            AddCombo("Archon Sword", 500, "Dragonsoul Sword", "Dragonsoul Sword");
            AddCombo("Skysplitter Sword", 800, "Archon Sword", "Archon Sword");
            AddCombo("Sword of Acclaim", 1000, "Skysplitter Sword", "Skysplitter Sword");
            AddCombo("Sword of Splendor", 2000, "Sword of Acclaim", "Sword of Acclaim");
            AddCombo("Crystal Sword", 3000, "Sword of Splendor", "Sword of Splendor");
            AddCombo("Sword of Majesty", 200, "Sword of Acclaim", "Sword of Splendor");
            AddCombo("Demon Blade", 5000, "Sword of Majesty", "Sword of Majesty");
            AddCombo("Ancient Stone Sword", 10000, "Demon Blade", "Demon Blade");
            AddCombo("Sword of OUTDATED MERCY", 10000, "Ancient Stone Sword", "Ancient Stone Sword");
            AddCombo("Sword of the Zombie King", 10000, "Sword of OUTDATED MERCY", "Sword of OUTDATED MERCY");

            // --- Upscale Combos Staffs --- //
            AddCombo("Firebrand Staff", 10, "Energy Staff", "Energy Staff");
            AddCombo("Comet Staff", 30, "Firebrand Staff", "Firebrand Staff");
            AddCombo("Serpentine Staff", 50, "Comet Staff", "Comet Staff");
            AddCombo("Meteor Staff", 70, "Serpentine Staff", "Serpentine Staff");
            AddCombo("Slayer Staff", 90, "Meteor Staff", "Meteor Staff");
            AddCombo("Avenger Staff", 100, "Slayer Staff", "Slayer Staff");
            AddCombo("Staff of Destruction", 200, "Avenger Staff", "Avenger Staff");
            AddCombo("Staff of Horror", 300, "Staff of Destruction", "Staff of Destruction");
            AddCombo("Staff of Necrotic Arcana", 400, "Staff of Horror", "Staff of Horror");
            AddCombo("Staff of Diabolic Secrets", 500, "Staff of Necrotic Arcana", "Staff of Necrotic Arcana");
            AddCombo("Staff of Astral Knowledge", 800, "Staff of Diabolic Secrets", "Staff of Diabolic Secrets");
            AddCombo("Staff of the Cosmic Whole", 1000, "Staff of Astral Knowledge", "Staff of Astral Knowledge");
            AddCombo("Staff of the Vital Unity", 2000, "Staff of the Cosmic Whole", "Staff of the Cosmic Whole");
            AddCombo("Staff of the Fundamental Core", 4000, "Staff of the Vital Unity", "Staff of the Vital Unity");
            AddCombo("Staff of Extreme Prejudice", 3000, "Staff of the Fundamental Core", "Staff of the Fundamental Core");
            AddCombo("Staff of Dripping Blood", 4000, "Staff of Extreme Prejudice", "Staff of Extreme Prejudice");
            AddCombo("Staff of Endless Energy", 5000, "Anatis Staff", "Staff of Dripping Blood");

            // --- Upscale Combos Daggers --- //
            AddCombo("Dirk", 10, "Steel Dagger", "Steel Dagger");
            AddCombo("Blue Steel Dagger", 30, "Dirk", "Dirk");
            AddCombo("Dusky Rose Dagger", 50, "Blue Steel Dagger", "Blue Steel Dagger");
            AddCombo("Silver Dagger", 70, "Dusky Rose Dagger", "Dusky Rose Dagger");
            AddCombo("Golden Dagger", 90, "Silver Dagger", "Silver Dagger");
            AddCombo("Obsidian Dagger", 100, "Golden Dagger", "Golden Dagger");
            AddCombo("Poison Fang Dagger", 200, "Obsidian Dagger", "Obsidian Dagger");
            AddCombo("Mithril Dagger", 300, "Poison Fang Dagger", "Poison Fang Dagger");
            AddCombo("Fire Dagger", 400, "Mithril Dagger", "Mithril Dagger");
            AddCombo("Ragetalon Dagger", 500, "Fire Dagger", "Fire Dagger");
            AddCombo("Emeraldshard Dagger", 800, "Ragetalon Dagger", "Ragetalon Dagger");
            AddCombo("Agateclaw Dagger", 1000, "Emeraldshard Dagger", "Emeraldshard Dagger");
            AddCombo("Dagger of Foul Malevolence", 2000, "Agateclaw Dagger", "Agateclaw Dagger");
            AddCombo("Dagger of Sinister Deeds", 3000, "Dagger of Foul Malevolence", "Dagger of Foul Malevolence");
            AddCombo("Dagger of Dire Hatred", 4000, "Dagger of Sinister Deeds", "Dagger of Sinister Deeds");
            AddCombo("Dirk of Cronus", 5000, "Dagger of Dire Hatred", "Dagger of Dire Hatred");
            AddCombo("Doom Dirk", 6000, "Dirk of Cronus", "Dirk of Cronus");

            // --- Upscale Combos Wands --- //
            AddCombo("Force Wand", 10, "Fire Wand", "Fire Wand");
            AddCombo("Power Wand", 30, "Force Wand", "Force Wand");
            AddCombo("Missile Wand", 50, "Power Wand", "Power Wand");
            AddCombo("Eldritch Wand", 70, "Missile Wand", "Missile Wand");
            AddCombo("Hell's Fire Wand", 90, "Eldritch Wand", "Eldritch Wand");
            AddCombo("Wand of Dark Magic", 100, "Hell's Fire Wand", "Hell's Fire Wand");
            AddCombo("Wand of Arcane Flame", 200, "Wand of Dark Magic", "Wand of Dark Magic");
            AddCombo("Sprite Wand", 300, "Wand of Arcane Flame", "Wand of Arcane Flame");
            AddCombo("Wand of Death", 400, "Sprite Wand", "Sprite Wand");
            AddCombo("Wand of Deep Sorcery", 500, "Wand of Death", "Wand of Death");
            AddCombo("Wand of Shadow", 800, "Wand of Deep Sorcery", "Wand of Deep Sorcery");
            AddCombo("Wand of Ancient Warning", 1000, "Wand of Shadow", "Wand of Shadow");
            AddCombo("Wand of Recompense", 2000, "Wand of Ancient Warning", "Wand of Ancient Warning");
            AddCombo("Wand of Evocation", 3000, "Wand of Recompense", "Wand of Recompense");
            AddCombo("Wand of Retribution", 4000, "Wand of Evocation", "Wand of Evocation");
            AddCombo("Crystal Wand", 5000, "Wand of Retribution", "Wand of Retribution");
            AddCombo("Wand of the Vampire Count", 5000, "Crystal Wand", "Crystal Wand");
            AddCombo("Wand of Evil Power", 6000, "Wand of the Vampire Count", "Wand of the Vampire Count");
            AddCombo("Wand of the Bulwark", 4000, "Wand of Evil Power", "Wand of Evil Power");

            // --- Upscale Combos Bows --- //
            AddCombo("Reinforced Bow", 10, "Shortbow", "Shortbow");
            AddCombo("Crossbow", 30, "Reinforced Bow", "Reinforced Bow");
            AddCombo("Greywood Bow", 50, "Crossbow", "Crossbow");
            AddCombo("Ironwood Bow", 70, "Greywood Bow", "Greywood Bow");
            AddCombo("Fire Bow", 90, "Ironwood Bow", "Ironwood Bow");
            AddCombo("Double Bow", 100, "Fire Bow", "Fire Bow");
            AddCombo("Heavy Crossbow", 200, "Double Bow", "Double Bow");
            AddCombo("Golden Bow", 300, "Heavy Crossbow", "Heavy Crossbow");
            AddCombo("Verdant Bow", 400, "Golden Bow", "Golden Bow");
            AddCombo("Bow of Fey Magic", 500, "Verdant Bow", "Verdant Bow");
            AddCombo("Bow of Innocent Blood", 800, "Bow of Fey Magic", "Bow of Fey Magic");
            AddCombo("Bow of Covert Havens", 1000, "Bow of Innocent Blood", "Bow of Innocent Blood");
            AddCombo("Bow of Mystical Energy", 2000, "Bow of Covert Havens", "Bow of Covert Havens");
            AddCombo("Bow of Deep Enchantment", 3000, "Bow of Mystical Energy", "Bow of Mystical Energy");
            AddCombo("Coral Bow", 4000, "Bow of Deep Enchantment", "Bow of Deep Enchantment");
            AddCombo("Doom Bow", 5000, "Coral Bow", "Coral Bow");
            AddCombo("Bow of the Undead Lord", 5000, "Doom Bow", "Doom Bow");
            AddCombo("Bow of Crystalized Tears", 5000, "Bow of the Undead Lord", "Bow of the Undead Lord");

            // --- Upscale Combos Cloaks --- //
            AddCombo("Cloak of Darkness", 10, "Cloak of Shadows", "Cloak of Shadows");
            AddCombo("Cloak of Speed", 200, "Cloak of Darkness", "Cloak of Darkness");
            AddCombo("Cloak of the Night Thief", 500, "Cloak of Speed", "Cloak of Speed");
            AddCombo("Cloak of the Red Agent", 1000, "Cloak of the Night Thief", "Cloak of the Night Thief");
            AddCombo("Cloak of Endless Twilight", 2000, "Cloak of the Red Agent", "Cloak of the Red Agent");
            AddCombo("Cloak of Ghostly Concealment", 5000, "Cloak of Endless Twilight", "Cloak of Endless Twilight");
            AddCombo("Cloak of the Planewalker", 10000, "Cloak of Ghostly Concealment", "Cloak of Ghostly Concealment");

            // --- Upscale Combos Poison --- //
            AddCombo("Spider Venom", 10, "Centipede Poison", "Centipede Poison");
            AddCombo("Pit Viper Poison", 200, "Spider Venom", "Spider Venom");
            AddCombo("Stingray Poison", 500, "Pit Viper Poison", "Pit Viper Poison");
            AddCombo("Felwasp Toxin", 1000, "Stingray Poison", "Stingray Poison");
            AddCombo("Nightwing Venom", 2000, "Felwasp Toxin", "Felwasp Toxin");
            AddCombo("Baneserpent Poison", 5000, "Nightwing Venom", "Nightwing Venom");

            // --- Upscale Combos Traps --- //
            AddCombo("Wilderlands Trap", 10, "Hunting Trap", "Hunting Trap");
            AddCombo("Deepforest Trap", 200, "Wilderlands Trap", "Wilderlands Trap");
            AddCombo("Savage Trap", 500, "Deepforest Trap", "Deepforest Trap");
            AddCombo("Demonhunter Trap", 1000, "Savage Trap", "Savage Trap");
            AddCombo("Dragonstalker Trap", 2000, "Demonhunter Trap", "Demonhunter Trap");
            AddCombo("Giantcatcher Trap", 5000, "Dragonstalker Trap", "Dragonstalker Trap");

            // --- Upscale Combos Skulls --- //
            AddCombo("Breathtaker Skull", 10, "Necrotic Skull", "Necrotic Skull");
            AddCombo("Heartstealer Skull", 200, "Breathtaker Skull", "Breathtaker Skull");
            AddCombo("Soul Siphon Skull", 500, "Heartstealer Skull", "Heartstealer Skull");
            AddCombo("Essence Tap Skull", 1000, "Soul Siphon Skull", "Soul Siphon Skull");
            AddCombo("Lifedrinker Skull", 2000, "Essence Tap Skull", "Essence Tap Skull");
            AddCombo("Bloodsucker Skull", 5000, "Lifedrinker Skull", "Lifedrinker Skull");
            AddCombo("Skull of Endless Torment", 10000, "Bloodsucker Skull", "Bloodsucker Skull");

            // --- Upscale Combos Orbs --- //
            AddCombo("Suspension Orb", 10, "Stasis Orb", "Stasis Orb");
            AddCombo("Imprisonment Orb", 200, "Suspension Orb", "Suspension Orb");
            AddCombo("Neutralization Orb", 500, "Imprisonment Orb", "Imprisonment Orb");
            AddCombo("Timelock Orb", 1000, "Neutralization Orb", "Neutralization Orb");
            AddCombo("Banishment Orb", 2000, "Timelock Orb", "Timelock Orb");
            AddCombo("Planefetter Orb", 5000, "Banishment Orb", "Banishment Orb");
            AddCombo("Orb of Conflict", 10000, "Planefetter Orb", "Planefetter Orb");

            // --- Upscale Combos Prism --- //
            AddCombo("Deception Prism", 10, "Decoy Prism", "Decoy Prism");
            AddCombo("Illusion Prism", 200, "Deception Prism", "Deception Prism");
            AddCombo("Hallucination Prism", 500, "Illusion Prism", "Illusion Prism");
            AddCombo("Prism of Figments", 1000, "Hallucination Prism", "Hallucination Prism");
            AddCombo("Prism of Phantoms", 2000, "Prism of Figments", "Prism of Figments");
            AddCombo("Prism of Apparitions", 5000, "Prism of Phantoms", "Prism of Phantoms");
            AddCombo("Prism of Dancing Swords", 10000, "Prism of Apparitions", "Prism of Apparitions");

            // --- Upscale Combos Scepter --- //
            AddCombo("Discharge Scepter", 10, "Lightning Scepter", "Lightning Scepter");
            AddCombo("Thunderclap Scepter", 200, "Discharge Scepter", "Discharge Scepter");
            AddCombo("Arcblast Scepter", 500, "Thunderclap Scepter", "Thunderclap Scepter");
            AddCombo("Cloudflash Scepter", 1000, "Arcblast Scepter", "Arcblast Scepter");
            AddCombo("Scepter of Skybolts", 2000, "Cloudflash Scepter", "Cloudflash Scepter");
            AddCombo("Scepter of Storms", 5000, "Scepter of Skybolts", "Scepter of Skybolts");
            AddCombo("Scepter of Fulmination", 10000, "Scepter of Storms", "Scepter of Storms");

            // --- Upscale Combos Seal --- //
            AddCombo("Seal of the Pilgrim", 10, "Seal of the Initiate", "Seal of the Initiate");
            AddCombo("Seal of the Seeker", 200, "Seal of the Pilgrim", "Seal of the Pilgrim");
            AddCombo("Seal of the Aspirant", 500, "Seal of the Seeker", "Seal of the Seeker");
            AddCombo("Seal of the Divine", 1000, "Seal of the Aspirant", "Seal of the Aspirant");
            AddCombo("Seal of the Holy Warrior", 2000, "Seal of the Divine", "Seal of the Divine");
            AddCombo("Seal of the Blessed Champion", 5000, "Seal of the Holy Warrior", "Seal of the Holy Warrior");
            AddCombo("Seal of Blasphemous Prayer", 10000, "Seal of the Blessed Champion", "Seal of the Blessed Champion");

            // --- Upscale Combos Tomes --- //
            AddCombo("Remedy Tome", 10, "Healing Tome", "Healing Tome");
            AddCombo("Spirit Salve Tome", 100, "Remedy Tome", "Remedy Tome");
            AddCombo("Tome of Rejuvenation", 200, "Spirit Salve Tome", "Spirit Salve Tome");
            AddCombo("Tome of Renewing", 500, "Tome of Rejuvenation", "Tome of Rejuvenation");
            AddCombo("Tome of Divine Favor", 1000, "Tome of Renewing", "Tome of Renewing");
            AddCombo("Tome of Holy Guidance", 2000, "Tome of Divine Favor", "Tome of Divine Favor");
            AddCombo("Tome of Holy Protection", 4000, "Tome of Holy Guidance", "Tome of Holy Guidance");
            AddCombo("Tome of Purification", 5000, "Tome of Holy Protection", "Tome of Holy Protection");

            // --- Upscale Combos Spells --- //
            AddCombo("Flame Burst Spell", 10, "Fire Spray Spell", "Fire Spray Spell");
            AddCombo("Fire Nova Spell", 100, "Flame Burst Spell", "Flame Burst Spell");
            AddCombo("Scorching Blast Spell", 200, "Fire Nova Spell", "Fire Nova Spell");
            AddCombo("Destruction Sphere Spell", 500, "Scorching Blast Spell", "Scorching Blast Spell");
            AddCombo("Magic Nova Spell", 1000, "Destruction Sphere Spell", "Destruction Sphere Spell");
            AddCombo("Elemental Detonation Spell", 2000, "Magic Nova Spell", "Magic Nova Spell");
            AddCombo("Penetrating Blast Spell", 5000, "Elemental Detonation Spell", "Elemental Detonation Spell");

            // --- Upscale Combos Shields --- //
            AddCombo("Iron Shield", 10, "Wooden Shield", "Wooden Shield");
            AddCombo("Steel Shield", 100, "Iron Shield", "Iron Shield");
            AddCombo("Reinforced Shield", 200, "Steel Shield", "Steel Shield");
            AddCombo("Golden Shield", 500, "Reinforced Shield", "Reinforced Shield");
            AddCombo("Mithril Shield", 1000, "Golden Shield", "Golden Shield");
            AddCombo("Snake Skin Shield", 2000, "Mithril Shield", "Mithril Shield");
            AddCombo("Colossus Shield", 5000, "Snake Skin Shield", "Snake Skin Shield");
            AddCombo("Shield of Ogmur", 10000, "Colossus Shield", "Colossus Shield");

            // --- Upscale Combos Quivers --- //
            AddCombo("Reinforced Quiver", 10, "Magic Quiver", "Magic Quiver");
            AddCombo("Iron Quiver", 100, "Reinforced Quiver", "Reinforced Quiver");
            AddCombo("Elvencraft Quiver", 200, "Iron Quiver", "Iron Quiver");
            AddCombo("Magesteel Quiver", 500, "Elvencraft Quiver", "Elvencraft Quiver");
            AddCombo("Golden Quiver", 1000, "Magesteel Quiver", "Magesteel Quiver");
            AddCombo("Quiver of Elvish Mastery", 2000, "Golden Quiver", "Golden Quiver");
            AddCombo("Quiver of Thunder", 5000, "Quiver of Elvish Mastery", "Quiver of Elvish Mastery");

            // --- Upscale Combos Helms --- //
            AddCombo("Bronze Helm", 10, "Combat Helm", "Combat Helm");
            AddCombo("Black Iron Helm", 100, "Bronze Helm", "Bronze Helm");
            AddCombo("Red Iron Helm", 200, "Black Iron Helm", "Black Iron Helm");
            AddCombo("Steel Helm", 500, "Red Iron Helm", "Red Iron Helm");
            AddCombo("Golden Helm", 1000, "Steel Helm", "Steel Helm");
            AddCombo("Helm of the Great General", 2000, "Golden Helm", "Golden Helm");
            AddCombo("Helm of the Juggernaut", 5000, "Helm of the Great General", "Helm of the Great General");

            // --- Upscale Combos Leather --- //
            AddCombo("Leather Armor", 10, "Wolfskin Armor", "Wolfskin Armor");
            AddCombo("Basilisk Hide Armor", 50, "Leather Armor", "Leather Armor");
            AddCombo("Minotaur Hide Armor", 70, "Basilisk Hide Armor", "Basilisk Hide Armor");
            AddCombo("Bearskin Armor", 90, "Minotaur Hide Armor", "Minotaur Hide Armor");
            AddCombo("Chimera Hide Armor", 100, "Bearskin Armor", "Bearskin Armor");
            AddCombo("Wyvern Skin Armor", 200, "Chimera Hide Armor", "Chimera Hide Armor");
            AddCombo("Studded Leather Armor", 300, "Wyvern Skin Armor", "Wyvern Skin Armor");
            AddCombo("Snake Skin Armor", 400, "Studded Leather Armor", "Studded Leather Armor");
            AddCombo("Drake Hide Armor", 500, "Snake Skin Armor", "Snake Skin Armor");
            AddCombo("Roc Leather Armor", 800, "Drake Hide Armor", "Drake Hide Armor");
            AddCombo("Hippogriff Hide Armor", 1000, "Roc Leather Armor", "Roc Leather Armor");
            AddCombo("Griffon Hide Armor", 2000, "Hippogriff Hide Armor", "Hippogriff Hide Armor");
            AddCombo("Hydra Skin Armor", 3000, "Griffon Hide Armor", "Griffon Hide Armor");
            AddCombo("Wyrmhide Armor", 4000, "Hydra Skin Armor", "Hydra Skin Armor");
            AddCombo("Leviathan Armor", 5000, "Wyrmhide Armor", "Wyrmhide Armor");

            // --- Upscale Combos Heavy Armor --- //
            AddCombo("Chainmail", 10, "Iron Mail", "Iron Mail");
            AddCombo("Blue Steel Mail", 50, "Chainmail", "Chainmail");
            AddCombo("Silver Chainmail", 70, "Blue Steel Mail", "Blue Steel Mail");
            AddCombo("Golden Chainmail", 90, "Silver Chainmail", "Silver Chainmail");
            AddCombo("Plate Mail", 100, "Bearskin Armor", "Bearskin Armor");
            AddCombo("Mithril Chainmail", 200, "Golden Chainmail", "Golden Chainmail");
            AddCombo("Mithril Armor", 300, "Mithril Chainmail", "Mithril Chainmail");
            AddCombo("Dragonscale Armor", 400, "Mithril Armor", "Mithril Armor");
            AddCombo("Desolation Armor", 500, "Dragonscale Armor", "Dragonscale Armor");
            AddCombo("Vengeance Armor", 800, "Desolation Armor", "Desolation Armor");
            AddCombo("Abyssal Armor", 1000, "Vengeance Armor", "Vengeance Armor");
            AddCombo("Acropolis Armor", 2000, "Abyssal Armor", "Abyssal Armor");
            AddCombo("Dominion Armor", 3000, "Acropolis Armor", "Acropolis Armor");
            AddCombo("Annihilation Armor", 4000, "Dominion Armor", "Dominion Armor");

            // --- Upscale Combos Robes --- //
            AddCombo("Robe of the Apprentice", 10, "Robe of the Neophyte", "Robe of the Neophyte");
            AddCombo("Robe of the Acolyte", 50, "Robe of the Apprentice", "Robe of the Apprentice");
            AddCombo("Robe of the Student", 70, "Robe of the Acolyte", "Robe of the Acolyte");
            AddCombo("Robe of the Conjurer", 90, "Robe of the Student", "Robe of the Student");
            AddCombo("Robe of the Adept", 100, "Robe of the Conjurer", "Robe of the Conjurer");
            AddCombo("Robe of the Invoker", 200, "Robe of the Adept", "Robe of the Adept");
            AddCombo("Robe of the Illusionist", 300, "Robe of the Invoker", "Robe of the Invoker");
            AddCombo("Robe of the Master", 400, "Robe of the Illusionist", "Robe of the Illusionist");
            AddCombo("Robe of the Shadow Magus", 500, "Robe of the Master", "Robe of the Master");
            AddCombo("Robe of the Moon Wizard", 800, "Robe of the Shadow Magus", "Robe of the Shadow Magus");
            AddCombo("Robe of the Elder Warlock", 1000, "Robe of the Moon Wizard", "Robe of the Moon Wizard");
            AddCombo("Robe of the Grand Sorcerer", 2000, "Robe of the Elder Warlock", "Robe of the Elder Warlock");
            AddCombo("Robe of the Star Mother", 3000, "Robe of the Grand Sorcerer", "Robe of the Grand Sorcerer");
            AddCombo("Robe of the Ancient Intellect", 4000, "Robe of the Star Mother", "Robe of the Star Mother");

            //Abilities (T7, T6)
            AddCombo("Shield of Death", 500, "Magma Shield", "Colossus Shield");
            AddCombo("Skull of the Undead King", 500, "Souleater Skull", "Bloodsucker Skull");
            AddCombo("Azure Trap", 500, "Mobstopper Trap", "Giantcatcher Trap");
            AddCombo("Cloak of the Phantom", 500, "Cloak of Dimensions", "Cloak of Ghostly Concealment");
            AddCombo("Quiver of Artemis", 500, "Bloodorc Quiver", "Quiver of Elvish Mastery");
            AddCombo("Spell of the Eternal Void", 500, "Space Deterioration Spell", "Elemental Detonation Spell");
            AddCombo("Tome of the Ancients", 500, "Tome of the Fountains", "Tome of Holy Guidance");
            AddCombo("Helm of the Leviathan General", 500, "Helm of the Holy Warrior", "Helm of the Great General");
            AddCombo("Fury Orb", 500, "1940s Orb", "Planefetter Orb");
            AddCombo("Bile Poison", 500, "Toothpaste Poison", "Baneserphent Poison");
            AddCombo("Seal of War", 500, "Seal of Mass Power", "Seal of the Blessed Champion");
            AddCombo("Prism of the Bloody Surprise", 500, "Prism of the Soul Stealer", "Prism of Apparitions");
            AddCombo("Scepter of Vorv", 500, "Scepter of the Grand Sorcerer", "Scepter of Storms");
        }

        public bool SetCombo(string[] items)
        {
            foreach (var i in combos)
            {
                if (i.Key.Length == items.Length)
                {
                    var pass = true;
                    foreach (var e in items)
                    {
                        if (!i.Key.Contains(e))
                        {
                            pass = false;
                        }
                    }
                    if (pass)
                    {
                        Combo = i.Value;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool SetComboAdv(string[] items, bool forgeAmmy)
        {
            foreach (var i in advCombos)
            {
                if (i.Key.Length == items.Length)
                {
                    var pass = true;
                    foreach (var e in items)
                    {
                        if (!i.Key.Contains(e))
                        {
                            pass = false;
                        }
                        else
                        {
                            if (i.Value.Item3 && !forgeAmmy)
                                pass = false;
                        }
                    }
                    if (pass)
                    {
                        Combo = new Tuple<string, int>(i.Value.Item1, i.Value.Item2);
                        return true;
                    }
                }
            }
            return false;
        }

        public void AddCombo(string result, int price, params string[] items)
        {
            combos.Add(items, new Tuple<string, int>(result, price));
            advCombos.Add(items, new Tuple<string, int, bool>(result, price, false));
        }

        public void AddAdvCombo(string result, int price, params string[] items)
        {
            advCombos.Add(items, new Tuple<string, int, bool>(result, price, true));
        }
    }
}