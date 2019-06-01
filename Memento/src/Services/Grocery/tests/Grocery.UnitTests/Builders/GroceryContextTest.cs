using Grocery.EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;

namespace Grocery.UnitTests.Builders
{
	internal class GroceryContextTest
	{
		private readonly DbContextOptions<GroceryContext> _options;

		public GroceryContextTest(string dbName) => 
			_options = new DbContextOptionsBuilder<GroceryContext>().UseInMemoryDatabase(dbName).Options;

		public T ExecuteWithTestContext<T>(Func<GroceryContext, T> func)
		{
			using (var context = new GroceryContext(_options))
			{
				return func(context);
			}
		}
	}
}
