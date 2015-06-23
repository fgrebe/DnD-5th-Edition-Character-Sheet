using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DnD.DataAccess.Model {
  public class Abilities {
    public int AbilitiesId { get; set; }

    //[Column("Strength_AbilityId")]
    public int StrengthId { get; set; }
    //[Column("Dexterity_AbilityId")]
    public int DexterityId { get; set; }
    public int ConstitutionId { get; set; }
    public int IntelligenceId { get; set; }
    public int WisdomId { get; set; }
    public int CharismaId { get; set; }
    
    public Ability Strength { get; set; }
    public Ability Dexterity { get; set; }
    public Ability Constitution { get; set; }
    public Ability Intelligence { get; set; }
    public Ability Wisdom { get; set; }
    public Ability Charisma { get; set; }

    public Abilities() {

    }

    public Abilities(int strength, int dexterity, int con, int inte, int wis, int cha) {
      this.Strength = new Ability(strength, "Strength");
      this.Dexterity = new Ability(dexterity, "Dexterity");
      this.Constitution = new Ability(con, "Constitution");
      this.Intelligence = new Ability(inte, "Intelligence");
      this.Wisdom = new Ability(wis, "Wisdom");
      this.Charisma = new Ability(cha, "Charisma");
    }
  }
}
