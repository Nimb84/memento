using Grocery.EFDataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.EFDataAccess.EntityConfigurations
{
	internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> buyerConfiguration)
		{
			buyerConfiguration.ToTable(nameof(Product));

			buyerConfiguration.HasIndex(p => p.Id).IsUnique();

			buyerConfiguration.Property(p => p.DefaultPrice).HasColumnType("decimal(5, 2)");
			buyerConfiguration.Property(p => p.DefaultUnits).HasColumnType("decimal(5, 2)");

			buyerConfiguration
					.HasOne(p => p.Creator)
					.WithMany(m => m.Products)
					.HasForeignKey(m => m.CreatorId)
					.OnDelete(DeleteBehavior.Restrict);

			buyerConfiguration
					.HasMany(p => p.GroceryItems)
					.WithOne(gi => gi.Product)
					.HasForeignKey(gi => gi.ProductId)
					.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
