using System.Collections.Generic;
using System.ServiceModel;

using DnD.DataAccess.Model;

namespace DnD.CharacterSheet.Services
{
  [ServiceContract(Namespace = "http://CharacterSvc", SessionMode = SessionMode.Allowed)]
	public interface ICharacterService
	{
		[OperationContract]
		SvcResponse<List<Character>> GetCharacters();

    [OperationContract]
    SvcResponse<Character> GetCharacter(int characterId);

    [OperationContract]
    SvcResponse<List<Class>> GetClasses();

    [OperationContract]
    SvcResponse GetCharactersTest();

    [OperationContract]
    SvcResponse<AbilityUpdateResponse> UpdateAbilities(int characterId, Abilities ab);

    [OperationContract]
    SvcResponse<CharacterUpdateResponse> LevelUp(int characterId, int level);
	}
}