using System.Runtime.Serialization;

namespace DnD.DataAccess.Model
{
	public class Class
	{
		public int ClassId { get; set; }
		public string Name { get; set; }
    public DieEnum HitDie { get; set; }

		public Class()
		{
			
		}
	}
}
