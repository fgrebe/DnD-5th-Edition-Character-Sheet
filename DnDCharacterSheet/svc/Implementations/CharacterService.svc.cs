using System.Collections.Generic;
using System.Linq;

using DnD.DataAccess;
using DnD.DataAccess.Model;
using DnD.DataAccess.Model.Items;

namespace DnD.CharacterSheet.Services
{
	public class CharacterService : ServiceBase, ICharacterService
	{
		public SvcResponse<List<Character>> GetCharacters()
		{
			return CreateReponse(DAL.GetCharacters());
		}

		public SvcResponse<Character> GetCharacter(int characterId)
		{
			return CreateReponse(DAL.GetCharacter(characterId));
		}

		public SvcResponse<NewCharacterResponse> AddCharacter(string characterName, string playerName, string race, int classId, string alignment, string background, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
		{
			var c = new Character(classId, strength, dexterity, constitution, intelligence, wisdom, charisma)
			{
				Name = characterName,
				PlayerName = playerName,
				Race = race,
				Alignment = alignment,
				Background = background,
				Speed = 30
			};

			c.AC = c.Abilities.Dexterity.Modifier;

			DAL.AddCharacters(c);
			
			return CreateReponse(new NewCharacterResponse{ CharacterId = c.CharacterId });
		}

		public SvcResponse<List<Class>> GetClasses()
		{
			var classes = DAL.GetClasses().ToList();
			return CreateReponse(classes);
		}

		public SvcResponse GetCharactersTest()
		{
			//return new SvcResponse { Value = DAL.GetCharacters().ToList(), Status = ResponseStatus.Success };
			var chars = DAL.GetCharacters().FirstOrDefault();
			return new SvcResponse { Value = chars, Status = ResponseStatus.Success };
		}

		public SvcResponse<AbilityUpdateResponse> UpdateAbilities(int characterId, Abilities ab)
		{

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

		public SvcResponse<CharacterUpdateResponse> LevelUp(int characterId, int level)
		{
			var character = DAL.GetCharacter(characterId);
			character.LevelUp(level);
			DAL.LevelUp(character);
			return CreateReponse(new CharacterUpdateResponse { Hitpoints = character.Hitpoints, Level = character.Level, MaxHitDice = character.MaxHitDice, ProficiencyBonus = character.ProficiencyBonus });
		}

		public SvcResponse<List<Armor>> GetArmors()
		{
			return new SvcResponse<List<Armor>> { Value = DAL.GetArmors() };
		}

		public SvcResponse<ArmorUpdateResponse> SetArmor(int characterId, int armorId)
		{
			var c = DAL.GetCharacter(characterId);
			var a = DAL.GetArmor(armorId);

			c.SetArmor(a);
			DAL.UpdateArmor(c);

			return CreateReponse(new ArmorUpdateResponse { AC = c.AC, Armor = a });
		}
	}
}
