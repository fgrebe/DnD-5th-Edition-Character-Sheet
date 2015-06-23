using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DnD.CharacterSheet.Pages {
  public partial class CharacterSheet : System.Web.UI.Page {

    public string CharacterId { get; set; }

    protected void Page_Load(object sender, EventArgs e) {
      CharacterId = (string)RouteData.Values["characterId"];
    }
  }
}