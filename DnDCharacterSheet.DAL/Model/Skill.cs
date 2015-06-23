using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.DataAccess.Model {
  public class Skill {
    public int SkillId { get; set; }
    public string Name { get; set; } 
    public bool Proficient { get; set; }
    public Ability Related { get; set; }
  }
}
