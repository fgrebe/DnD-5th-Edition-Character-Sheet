using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DnD.DataAccess
{
	using DnD.DataAccess.Model;

	public class DALContext : DbContext
	{
		public DbSet<Class> Classes { get; set; }
		public DbSet<Character> Characters { get; set; }

		public DALContext()
		{		
      Configuration.LazyLoadingEnabled = false; // eager loading
      Database.SetInitializer<DALContext>(new DropCreateDatabaseIfModelChanges<DALContext>());
      //Database.SetInitializer<DALContext>(null);
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

	}
}
