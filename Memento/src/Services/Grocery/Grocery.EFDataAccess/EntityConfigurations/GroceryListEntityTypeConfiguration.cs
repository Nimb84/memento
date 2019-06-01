using Grocery.EFDataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.EFDataAccess.EntityConfigurations
{
	internal class GroceryListEntityTypeConfiguration : IEntityTypeConfiguration<GroceryList>
	{
		public void Configure(EntityTypeBuilder<GroceryList> buyerConfiguration)
		{
			buyerConfiguration.ToTable(nameof(GroceryList));

			buyerConfiguration.HasIndex(gl => gl.Id).IsUnique();

			buyerConfiguration.Property(gi => gi.TotalPrice).HasColumnType("decimal(5, 2)");

			buyerConfiguration
					.HasMany(gl => gl.Items)
					.WithOne(gi => gi.List)
					.HasForeignKey(gi => gi.GroceryListId)
					.OnDelete(DeleteBehavior.Restrict);

			buyerConfiguration
					.HasMany(gl => gl.Members)
					.WithOne(mgl => mgl.GroceryList)
					.HasForeignKey(mgl => mgl.GroceryListId)
					.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
