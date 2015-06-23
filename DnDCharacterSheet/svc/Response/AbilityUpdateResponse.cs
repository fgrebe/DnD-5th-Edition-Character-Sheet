using DnD.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

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