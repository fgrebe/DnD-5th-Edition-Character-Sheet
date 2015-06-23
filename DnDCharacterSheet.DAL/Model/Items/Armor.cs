namespace DnD.DataAccess.Model.Items
{
	public enum ArmorType
	{
		Light,
		Medium,
		Heavy
	}

	public class Armor : Item
	{
		public int ArmorId { get; set; }
		public int AC { get; set; }
		public ArmorType Type { get; set; }
		public int RequiredStrength { get; set; }
		public bool DisadvantageStealth { get; set; }
	}
}
