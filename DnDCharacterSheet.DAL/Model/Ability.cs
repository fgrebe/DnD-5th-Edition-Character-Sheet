using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.DataAccess.Model {
  public class Ability {
    public int AbilityId { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public int Modifier { get; set; }   

    public void UpdateScore(int score) {
      Score = score;
      Modifier = (int)Math.Floor((Score - 10) / 2.0);
    }

    public Ability() {

    }

    public Ability(int score, string name) {
      UpdateScore(score);
      this.Name = name;
    }
  }
}
