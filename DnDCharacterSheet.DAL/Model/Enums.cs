using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DnD.DataAccess.Model {

  public enum SkillsEnum { 
    Acrobatis,
    [Description("Animal Handling")]
    AnimalHandling, 
    Arcana, 
    Athletics, 
    Deception, 
    History,
    Insight,
    Intimidation, 
    Investigation,
    Medicine,
    Nature,
    Perception,
    Performance,
    Persuasion,
    Religion,
    [Description("Sleight Of Hand")]
    SleightOfHand,
    Stealth,
    Survival
  }

  public static class Enums {
    public static string ToName (this Enum value) {
     FieldInfo fi = value.GetType().GetField(value.ToString());

      DescriptionAttribute[] attributes = 
          (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

      if (attributes != null && attributes.Length > 0)
          return attributes[0].Description;
      else
          return value.ToString();
    }
  }
}
