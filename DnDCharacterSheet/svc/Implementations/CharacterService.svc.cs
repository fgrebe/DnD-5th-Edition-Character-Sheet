using System.Collections.Generic;
using System.Linq;

using DnD.DataAccess;
using DnD.DataAccess.Model;

namespace DnD.CharacterSheet.Services
{
  public class CharacterService : ServiceBase, ICharacterService
	{
		public SvcResponse<List<Character>> GetCharacters()
		{
			return CreateReponse(DAL.GetCharacters());
		}

    public SvcResponse<Character> GetCharacter(int characterId) {
      return CreateReponse(DAL.GetCharacter(characterId));
    }

    public SvcResponse<List<Class>> GetClasses() {
      var classes = DAL.GetClasses().ToList();
      return CreateReponse(classes);
    }

    public SvcResponse GetCharactersTest() {
      //return new SvcResponse { Value = DAL.GetCharacters().ToList(), Status = ResponseStatus.Success };
      var chars = DAL.GetCharacters().FirstOrDefault();
      return new SvcResponse { Value = chars, Status = ResponseStatus.Success };
    }

    public SvcResponse<AbilityUpdateResponse> UpdateAbilities(int characterId, Abilities ab) {
      
      var character = DAL.GetCharacter(characterId);
      character.Abilities.Strength.UpdateScore(ab.Strength.Score);
      character.Abilities.Dexterity.UpdateScore(ab.Dexterity.Score);
      character.Abilities.Constitution.UpdateScore(ab.Constitution.Score);
      character.Abilities.Intelligence.UpdateScore(ab.Intelligence.Score);
      character.Abilities.Wisdom.UpdateScore(ab.Wisdom.Score);
      character.Abilities.Charisma.UpdateScore(ab.Charisma.Score);
      DAL.UpdateCharacter(character);
      return CreateReponse(new AbilityUpdateResponse { Abilities = character.Abilities, Skills = character.Skills });
    }

    public SvcResponse<CharacterUpdateResponse> LevelUp(int characterId) {
      var character = DAL.GetCharacter(characterId);
      character.LevelUp();
      DAL.LevelUp(character);
      return CreateReponse(new CharacterUpdateResponse { Hitpoints = character.Hitpoints, Level = character.Level, MaxHitDice = character.MaxHitDice, ProficiencyBonus = character.ProficiencyBonus  });
    }
  }
}
