using DnD.DataAccess;
using DnD.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.DataAccess.Model.Items;

namespace DnD.InitializeDB {
  class Program {
    static void Main(string[] args) {

      //DAL.GetCharacters().ForEach(x => Console.WriteLine("Name: {0}, Class: {1}, Ability Score (S): ", x.Name, x.Class.Name /*x.Abilities.Strength.Score*/));

      int ret = DAL.DropDatabase(); // remove old data
      Console.WriteLine("Drop tables returned {0}", ret);

      // Add some more classes
      DAL.AddClass(new Class { Name = "Druid", HitDie = DieEnum.d8 });
      DAL.AddClass(new Class { Name = "Warlock", HitDie = DieEnum.d8 });
      DAL.AddClass(new Class { Name = "Sorcerer", HitDie = DieEnum.d6 });
      DAL.AddClass(new Class { Name = "Paladin", HitDie = DieEnum.d10 });
      DAL.AddClass(new Class { Name = "Bard", HitDie = DieEnum.d8 });
      DAL.AddClass(new Class { Name = "Wizard", HitDie = DieEnum.d6 });
			DAL.AddClass(new Class { Name = "Fighter", HitDie = DieEnum.d10 });
	    DAL.AddClass(new Class {Name = "Monk", HitDie = DieEnum.d8});

      Character ch = new Character(6, 9, 16, 16, 18, 9, 9) {
        Name = "Sola-Ui El-Melloi Archibald",
        TempHitpoints = 1,
        AC = 12,
        Speed = 30,
        Initiative = 3,
        PlayerName = "Florentina",
        Note = "Wurmin is fun!",
        Inventory = "Quarterstaff, Arcane Focus, Ring Of Spellstoring, Wand Of The Warmage +2, Spellbook, Kobol's Karnage",
        Level = 1,
        Alignment = "Chaotic Good",
        Background = "Noble",
      };
      ch.SetProficient(SkillsEnum.Arcana);
      ch.SetProficient(SkillsEnum.History); 
      ch.SetProficient(SkillsEnum.Insight);
      ch.SetProficient(SkillsEnum.Persuasion);
      ch.LevelUp(6); // make this automated!

      DAL.AddCharacters(ch);

      ch = new Character(7, 16, 15, 14, 12, 9, 8) {
        Name = "Sir Eiric of The Stone",
        TempHitpoints = 0,
        AC = 22,
        Speed = 30,
        Initiative = 0,
        PlayerName = "Georg",
        Note = "Wurmin is fun!",
        Inventory = "Dragon Scale Shield, Longsword, Handaxe (x2), Warhammer, Man-O-War (Battleaxe)",
        Level = 1,
        Alignment = "Lawful Good",
        Background = "Noble (Knight)"
      };
      ch.SetProficient(SkillsEnum.Perception);
      ch.SetProficient(SkillsEnum.Athletics);
      ch.SetProficient(SkillsEnum.History);
      ch.SetProficient(SkillsEnum.Persuasion);
      ch.LevelUp(6); // make this automated!

      DAL.AddCharacters(ch);

      ch = new Character(8, 9, 16, 16, 18, 9, 9) {
        Name = "Nemesis",
        TempHitpoints = 1,
        AC = 16,
        Speed = 35,
        Initiative = 5,
        PlayerName = "Lex",
        Note = "Swoosh!!",
        Inventory = "Scythe",
        Level = 1,
        Alignment = "Lawful Neutral",
        Background = "???",
      };
      ch.SetProficient(SkillsEnum.Arcana);
      ch.SetProficient(SkillsEnum.History);
      ch.SetProficient(SkillsEnum.Insight);
      ch.SetProficient(SkillsEnum.Persuasion);
      ch.LevelUp(6); // make this automated!

      DAL.AddCharacters(ch);

      DAL.GetClasses().ForEach(x => Console.WriteLine("Classname: {0} ({1})", x.Name, x.HitDie));
      DAL.GetCharacters().ForEach(x => Console.WriteLine("Name: {0}, Class: {1}, Player Name: {2}, Proficiency Bonus in Arcana: {3}", x.Name, x.Class.Name, x.PlayerName, x.Skills.FirstOrDefault(s => s.Name.Equals(SkillsEnum.Arcana.ToName())).Proficient));

			Console.WriteLine(" === Items ===");

			DAL.AddArmor(new Armor { Type = ArmorType.Light,	Name = "Padded Armor",					Price = 5,		AC = 11, RequiredStrength = 0,	DisadvantageStealth = true,	 Weight = 8 });
			DAL.AddArmor(new Armor { Type = ArmorType.Light,	Name = "Leather Armor",					Price = 10,		AC = 11, RequiredStrength = 0,	DisadvantageStealth = false, Weight = 10 });
			DAL.AddArmor(new Armor { Type = ArmorType.Light,	Name = "Studded Leather Armor",	Price = 45,		AC = 12, RequiredStrength = 0,	DisadvantageStealth = false, Weight = 13 });
			DAL.AddArmor(new Armor { Type = ArmorType.Medium, Name = "Hide Armor",						Price = 10,		AC = 12, RequiredStrength = 0,	DisadvantageStealth = false, Weight = 12 });
			DAL.AddArmor(new Armor { Type = ArmorType.Medium, Name = "Chain Shirt",						Price = 50,		AC = 13, RequiredStrength = 0,	DisadvantageStealth = false, Weight = 20 });
			DAL.AddArmor(new Armor { Type = ArmorType.Medium, Name = "Scale Mail",						Price = 50,		AC = 14, RequiredStrength = 0,	DisadvantageStealth = true,	 Weight = 45 });
			DAL.AddArmor(new Armor { Type = ArmorType.Medium, Name = "Breastplate",						Price = 400,	AC = 14, RequiredStrength = 0,	DisadvantageStealth = false, Weight = 20 });
			DAL.AddArmor(new Armor { Type = ArmorType.Medium, Name = "Half Plate",						Price = 750,	AC = 15, RequiredStrength = 0,	DisadvantageStealth = true,	 Weight = 40 });
			DAL.AddArmor(new Armor { Type = ArmorType.Heavy,	Name = "Ring Mail",							Price = 30,		AC = 14, RequiredStrength = 0,	DisadvantageStealth = true,	 Weight = 45 });
			DAL.AddArmor(new Armor { Type = ArmorType.Heavy,	Name = "Chain Mail",						Price = 75,		AC = 16, RequiredStrength = 13, DisadvantageStealth = true,  Weight = 55 });
			DAL.AddArmor(new Armor { Type = ArmorType.Heavy,	Name = "Splint Mail",						Price = 200,	AC = 17, RequiredStrength = 15, DisadvantageStealth = true,  Weight = 60 });
			DAL.AddArmor(new Armor { Type = ArmorType.Heavy,	Name = "Plate Armor",						Price = 1500, AC = 18, RequiredStrength = 15, DisadvantageStealth = true,  Weight = 65 });

			DAL.GetArmors().ForEach(a => Console.WriteLine("Name: {0}, Type: {1}, AC: {2}", a.Name, a.Type.ToString(), a.AC));


      Console.ReadLine();
    }
  }
}
