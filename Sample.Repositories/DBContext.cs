using System;
using System.Data.Entity;
using Sample.Domains;

namespace Sample.Repositories
{
	public class DBContext: DbContext
	{
		public DbSet<Employee> Employees { get; set; }

		public DBContext() : base("SampleWebApiDatabase")
		{

		}
    }
}

