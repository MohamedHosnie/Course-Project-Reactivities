using Microsoft.EntityFrameworkCore;
using Reactivities.Domain.Activities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reactivities.Persistence.EntityFramework
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Activity> Activities { get; set; }
	}
}
