using Grocery.EFDataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.EFDataAccess.EntityConfigurations
{
	internal class GroceryItemEntityTypeConfiguration : IEntityTypeConfiguration<GroceryItem>
	{
		public void Configure(EntityTypeBuilder<GroceryItem> buyerConfiguration)
		{
			buyerConfiguration.ToTable(nameof(GroceryItem));

			buyerConfiguration.HasIndex(gi => gi.Id).IsUnique();

			buyerConfiguration.Property(gi => gi.Price).HasColumnType("decimal(5, 2)");


			buyerConfiguration
					.HasOne(gi => gi.Member)
					.WithMany(m => m.GroceryItems)
					.HasForeignKey(gi => gi.MemberId)
					.OnDelete(DeleteBehavior.Restrict);

			buyerConfiguration
					.HasOne(gi => gi.Product)
					.WithMany(p => p.GroceryItems)
					.HasForeignKey(gi => gi.ProductId)
					.OnDelete(DeleteBehavior.Restrict);

			buyerConfiguration
					.HasOne(gi => gi.List)
					.WithMany(gl => gl.Items)
					.HasForeignKey(gi => gi.GroceryListId)
					.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
