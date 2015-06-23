using DnD.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DnD.CharacterSheet.Services {

  [DataContract]
  public class CharacterUpdateResponse 
  {
    [DataMember]
    public int ProficiencyBonus { get; set; }

    [DataMember]
    public string MaxHitDice { get; set; }

    [DataMember]
    public int Hitpoints { get; set; }

    [DataMember]
    public int Level { get; set; }
  }
}