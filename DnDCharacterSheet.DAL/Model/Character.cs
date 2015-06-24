using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using DnD.DataAccess.Model.Items;

namespace DnD.DataAccess.Model
{
	public class Character
	{
		public int CharacterId { get; set; }
		public string Name { get; set; }
		public int Level { get; set; }
		public string Race { get; set; }
    public int AC { get; set; }
    public int Speed { get; set; }
    public int Initiative { get; set; }
    public string MaxHitDice{ get; set; }
    public string CurrentHitDice { get; set; }
    public int ProficiencyBonus { get; set; }
    public string PlayerName { get; set; }
    //public enum RaceEnum { get; set; }
    public string Note { get; set; }
    public string Inventory { get; set; }
    public int Hitpoints { get; set; } // const bonus * level + (hit die/2) * level
    public int TempHitpoints { get; set; }
    public string Background { get; set; }
    public string Alignment { get; set; }
		public int ClassId { get; set; }

    // ohne virtual => use eager loading
    public Class Class { get; set; }
    /*
    public List<string> Spells { get; set; }
    */

    public int AbilitiesId { get; set; }
    public Abilities Abilities { get; set; }

    public ICollection<Skill> Skills { get; set; }

		public int? ArmorId { get; set; }
		public Armor Armor { get; set; }

    public Character() { }

		public Character(int classId, int s, int d, int c, int i, int w, int ch)
		{
			Level = 1;
			ClassId = classId;
			Class = DAL.GetClass(classId);

      Ability strength = new Ability(s, "Strength");
      Ability dexterity = new Ability(d, "Dexterity");
      Ability constitution = new Ability(c, "Constitution");
      Ability intelligence = new Ability(i, "Intelligence");
      Ability wisdom = new Ability(w, "Wisdom");
      Ability charisma = new Ability(ch, "Charisma");

      Abilities = new Abilities { 
        Strength = strength, 
        Dexterity = dexterity, 
        Constitution = constitution, 
        Intelligence = intelligence, 
        Wisdom = wisdom, 
        Charisma = charisma 
      };

      Skills = new HashSet<Skill>();
      Skills.Add(new Skill { Name = SkillsEnum.Acrobatis.ToName(), Proficient = false, Related = dexterity });
      Skills.Add(new Skill { Name = SkillsEnum.AnimalHandling.ToName(), Proficient = false, Related = wisdom });
      Skills.Add(new Skill { Name = SkillsEnum.Arcana.ToName(), Proficient = false, Related = intelligence});
      Skills.Add(new Skill { Name = SkillsEnum.Athletics.ToName(), Proficient = false, Related = strength });
      Skills.Add(new Skill { Name = SkillsEnum.Deception.ToName() , Proficient = false, Related = charisma });
      Skills.Add(new Skill { Name = SkillsEnum.History.ToName(), Proficient = false, Related = intelligence });
      Skills.Add(new Skill { Name = SkillsEnum.Insight.ToName(), Proficient = false, Related = wisdom });
      Skills.Add(new Skill { Name = SkillsEnum.Intimidation.ToName(), Proficient = false, Related = charisma });
      Skills.Add(new Skill { Name = SkillsEnum.Investigation.ToName(), Proficient = false, Related = intelligence });
      Skills.Add(new Skill { Name = SkillsEnum.Medicine.ToName(), Proficient = false, Related = wisdom });
      Skills.Add(new Skill { Name = SkillsEnum.Nature.ToName(), Proficient = false, Related = intelligence });
      Skills.Add(new Skill { Name = SkillsEnum.Perception.ToName(), Proficient = false, Related = wisdom });
      Skills.Add(new Skill { Name = SkillsEnum.Performance.ToName(), Proficient = false, Related = charisma });
      Skills.Add(new Skill { Name = SkillsEnum.Persuasion.ToName(), Proficient = false, Related = charisma });
      Skills.Add(new Skill { Name = SkillsEnum.Religion.ToName(), Proficient = false, Related = intelligence });
      Skills.Add(new Skill { Name = SkillsEnum.SleightOfHand.ToName(), Proficient = false, Related = dexterity });
      Skills.Add(new Skill { Name = SkillsEnum.Stealth.ToName(), Proficient = false, Related = dexterity });
      Skills.Add(new Skill { Name = SkillsEnum.Survival.ToName(), Proficient = false, Related = wisdom });
      
      CalculateProficiencyBouns();
			CalculateHitpoints();
			IncreaseHitDice();
		}

    public void SetProficient(SkillsEnum skill, bool proficient = true) {
      var result = Skills.FirstOrDefault(s => s.Name.Equals(skill.ToName()));
      result.Proficient = proficient;
    }

    public void LevelUp(int level) {
      Level = level;
      CalculateProficiencyBouns();
      CalculateHitpoints();
      IncreaseHitDice();    
    }

    private void CalculateHitpoints() {
      Hitpoints = Abilities.Constitution.Modifier * Level + ((int)Class.HitDie/2) * Level;
    }

    public void CalculateProficiencyBouns() {
      ProficiencyBonus = 1 + (int)Math.Ceiling(Level / 4.0);
    }

    private void IncreaseHitDice() {
      MaxHitDice = String.Format("{0}{1}", Level, Class.HitDie); 
    }

		public void SetArmor(Armor armor)
		{
			Armor = armor;
			ArmorId = armor.ArmorId;
			AC = armor.AC;

			switch (armor.Type)
			{
				case ArmorType.Light:
					AC += Abilities.Dexterity.Modifier;
					break;
				case ArmorType.Medium:
					AC += Abilities.Dexterity.Modifier > 2 ? 2 : Abilities.Dexterity.Modifier;
					break;
			}
		}
	}
}
