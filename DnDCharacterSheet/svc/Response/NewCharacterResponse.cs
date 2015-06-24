using System.Runtime.Serialization;

namespace DnD.CharacterSheet.Services
{
	[DataContract]
	public class NewCharacterResponse
	{
		[DataMember] 
		public int CharacterId { get; set; }
	}
}