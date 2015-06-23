using DnD.DataAccess;
using DnD.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
      Class c = new Class { Name = "Wizard", HitDie = DieEnum.d6 };
      DAL.AddClass(c);

      Character ch = new Character(9, 16, 16, 18, 9, 9) {
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
        Class = c
      };
      ch.SetProficient(SkillsEnum.Arcana);
      ch.SetProficient(SkillsEnum.History); 
      ch.SetProficient(SkillsEnum.Insight);
      ch.SetProficient(SkillsEnum.Persuasion);
      ch.LevelUp(6); // make this automated!

      DAL.AddCharacters(ch);

      c = new Class { Name = "Fighter", HitDie = DieEnum.d10 };
      DAL.AddClass(c);

      ch = new Character(16, 15, 14, 12, 9, 8) {
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
        Background = "Noble (Knight)",
        Class = c
      };
      ch.SetProficient(SkillsEnum.Perception);
      ch.SetProficient(SkillsEnum.Athletics);
      ch.SetProficient(SkillsEnum.History);
      ch.SetProficient(SkillsEnum.Persuasion);
      ch.LevelUp(6); // make this automated!

      DAL.AddCharacters(ch);

      c = new Class { Name = "Monk", HitDie = DieEnum.d8 };
      DAL.AddClass(c);

      ch = new Character(9, 16, 16, 18, 9, 9) {
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
        Class = c
      };
      ch.SetProficient(SkillsEnum.Arcana);
      ch.SetProficient(SkillsEnum.History);
      ch.SetProficient(SkillsEnum.Insight);
      ch.SetProficient(SkillsEnum.Persuasion);
      ch.LevelUp(6); // make this automated!

      DAL.AddCharacters(ch);

      DAL.GetClasses().ForEach(x => Console.WriteLine("Classname: {0} ({1})", x.Name, x.HitDie));
      DAL.GetCharacters().ForEach(x => Console.WriteLine("Name: {0}, Class: {1}, Player Name: {2}, Proficiency Bonus in Arcana: {3}", x.Name, x.Class.Name, x.PlayerName, x.Skills.FirstOrDefault(s => s.Name.Equals(SkillsEnum.Arcana.ToName())).Proficient));

      Console.ReadLine();
    }
  }
}
