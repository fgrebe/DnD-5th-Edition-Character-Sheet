using System.Runtime.Serialization;
using DnD.DataAccess.Model.Items;

namespace DnD.CharacterSheet.Services
{
	[DataContract]
	public class ArmorUpdateResponse
	{
		[DataMember]
		public Armor Armor { get; set; }

		[DataMember]
		public int AC { get; set; }
	}
}