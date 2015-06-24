using System.Collections.Generic;
using System.ServiceModel;
using DnD.DataAccess;
using DnD.DataAccess.Model;
using DnD.DataAccess.Model.Items;

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
	  SvcResponse<NewCharacterResponse> AddCharacter(string characterName, string playerName, string race, int classId, string alignment, string background, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma);
		
		[OperationContract]
    SvcResponse<List<Class>> GetClasses();

    [OperationContract]
    SvcResponse GetCharactersTest();

    [OperationContract]
    SvcResponse<AbilityUpdateResponse> UpdateAbilities(int characterId, Abilities ab);

    [OperationContract]
    SvcResponse<CharacterUpdateResponse> LevelUp(int characterId, int level);

	  [OperationContract]
	  SvcResponse<List<Armor>> GetArmors();

	  [OperationContract]
	  SvcResponse<ArmorUpdateResponse> SetArmor(int characterId, int armorId);
	}
}