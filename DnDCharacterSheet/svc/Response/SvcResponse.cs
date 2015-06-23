using System.Collections.Generic;
using System.Runtime.Serialization;

using DnD.DataAccess.Model;

namespace DnD.CharacterSheet.Services
{
	public enum ResponseStatus
	{
		Success = 0,
		Error
	}

	[DataContract]
	[KnownType(typeof(List<Character>))]
	public class SvcResponse<T>
	{
		[DataMember]
		public T Value { get; set; }

		[DataMember]
		public ResponseStatus Status { get; set; }
	}

  [DataContract]
  public class SvcResponse {
    [DataMember]
    public Character Value { get; set; }

    [DataMember]
    public ResponseStatus Status { get; set; }
  }
}