using System.Collections.Generic;
using System.Runtime.Serialization;
using DnD.DataAccess.Model;

namespace DnD.CharacterSheet.Services {

  [DataContract]
  public class AbilityUpdateResponse 
  {
    [DataMember]
    public Abilities Abilities {get; set; }

    [DataMember]
    public ICollection<Skill> Skills { get; set; }
  }
}