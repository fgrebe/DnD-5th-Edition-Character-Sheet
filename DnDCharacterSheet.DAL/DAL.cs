using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DnD.DataAccess.Model;
using DnD.DataAccess.Model.Items;

namespace DnD.DataAccess
{
	using System.Data.Entity;

	public class DAL
	{
		private static readonly Lazy<DALContext> context = new Lazy<DALContext>(() => new DALContext());

		protected static DALContext Context
		{
			get
			{
				return context.Value;
			}
		}

		#region Class
		public static List<Class> GetClasses()
		{
			using (var context = new DALContext())
			{
				return context.Classes.ToList();
			}
		}

		public static Class GetClass(int classId)
		{
			using (var context = new DALContext())
			{
				return context.Classes.FirstOrDefault(c => c.ClassId == classId);
			}
		}

    public static int AddClass(Class c) {
      using (var context = new DALContext()) {
        context.Classes.Add(c);
        return context.SaveChanges();
      }
    }
		#endregion

		#region Character
		public static int AddCharacters(Character c) {
      using (var context = new DALContext()) {
        context.Characters.Add(c);
        return context.SaveChanges();
      }
    }

		public static List<Character> GetCharacters()
		{
      // Include needed for eager loading
      using (var context = new DALContext()) { 
			  return context.Characters
          .Include(c => c.Class)
          .Include(a => a.Abilities.Strength)
          .Include(a => a.Abilities.Dexterity)
          .Include(a => a.Abilities.Constitution)
          .Include(a => a.Abilities.Intelligence)
          .Include(a => a.Abilities.Wisdom)
          .Include(a => a.Abilities.Charisma)
          .Include(a => a.Skills)
          .ToList();
      }
		}

    public static Character GetCharacter(int characterId) {
      using (var context = new DALContext()) {
        return context.Characters
          .Include(c => c.Class)
          .Include(a => a.Abilities.Strength)
          .Include(a => a.Abilities.Dexterity)
          .Include(a => a.Abilities.Constitution)
          .Include(a => a.Abilities.Intelligence)
          .Include(a => a.Abilities.Wisdom)
          .Include(a => a.Abilities.Charisma)
          .Include(a => a.Skills)
					.Include(c => c.Armor)
          .FirstOrDefault<Character>(c => c.CharacterId == characterId);
      }
    }

    public static void LevelUp(Character character) {
      using (var context = new DALContext()) {
        context.Characters.Attach(character);
        var entry = context.Entry(character).State = EntityState.Modified;
        context.SaveChanges();
      }
    }

    public static void UpdateCharacter(Character character) {
      using (var context = new DALContext()) {
        context.Characters.Attach(character);
        var entry = context.Entry(character).State = EntityState.Modified;
        context.Entry(character.Abilities.Strength).State = EntityState.Modified;
        context.Entry(character.Abilities.Dexterity).State = EntityState.Modified;
        context.Entry(character.Abilities.Constitution).State = EntityState.Modified;
        context.Entry(character.Abilities.Intelligence).State = EntityState.Modified;
        context.Entry(character.Abilities.Wisdom).State = EntityState.Modified;
        context.Entry(character.Abilities.Charisma).State = EntityState.Modified;
        context.SaveChanges();        
      }
    }

		public static void UpdateArmor(Character character)
		{
			using (var context = new DALContext())
			{
				context.Characters.Attach(character);
				context.Entry(character).State = EntityState.Modified;
				context.SaveChanges();
			}
		}
		#endregion

		#region Items

		public static void AddArmor(Armor armor)
		{
			using (var context = new DALContext())
			{
				context.Armors.Add(armor);
				context.SaveChanges();
			}
		}

		public static List<Armor> GetArmors()
		{
			using (var context = new DALContext())
			{
				return context.Armors.ToList();
			}
		}

		public static Armor GetArmor(int armorId)
		{
			using (var context = new DALContext())
			{
				return context.Armors.FirstOrDefault(a => a.ArmorId == armorId);
			}
		}
		#endregion

		public static int DropDatabase() {
      using (var context = new DALContext()) {
        context.Database.Delete();
        return context.SaveChanges();
      }
    }
  }
}
