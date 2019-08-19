namespace testWebApi1.EF
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class _dbModel : DbContext
	{
		public _dbModel()
			: base("name=commonCauseDb")
		{
		}

		public virtual DbSet<Cities> cities { get; set; }
		public virtual DbSet<Establishments> establishments { get; set; }
		public virtual DbSet<Groups> groups { get; set; }
		public virtual DbSet<Regions> regions { get; set; }
		public virtual DbSet<Roles> roles { get; set; }
		public virtual DbSet<Teachers> teachers { get; set; }
		public virtual DbSet<Topics> topics { get; set; }
		public virtual DbSet<Type_establishments> type_establishments { get; set; }
		public virtual DbSet<Users> users { get; set; }
		public virtual DbSet<Lessons> lessons { get; set; }

	}
}
