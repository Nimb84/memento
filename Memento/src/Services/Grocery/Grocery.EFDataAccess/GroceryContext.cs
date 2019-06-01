using Grocery.EFDataAccess.Entity;
using Grocery.EFDataAccess.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Grocery.EFDataAccess
{
	public class GroceryContext : DbContext
	{
		public DbSet<GroceryItem> GroceryItems { get; set; }
		public DbSet<GroceryList> GroceryLists { get; set; }
		public DbSet<Member> Members { get; set; }
		public DbSet<MemberGroceryList> MemberGroceryList { get; set; }
		public DbSet<Product> Products { get; set; }

		public GroceryContext() { }

		public GroceryContext(DbContextOptions<GroceryContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new GroceryItemEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new GroceryListEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new MemberEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new MemberGroceryListEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
		}
	}
}
