using Grocery.EFDataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.EFDataAccess.EntityConfigurations
{
	internal class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
	{
		public void Configure(EntityTypeBuilder<Member> buyerConfiguration)
		{
			buyerConfiguration.ToTable(nameof(Member));

			buyerConfiguration.HasIndex(m => m.Id).IsUnique();

			buyerConfiguration
					.HasMany(m => m.GroceryItems)
					.WithOne(i => i.Member)
					.HasForeignKey(i => i.MemberId)
					.OnDelete(DeleteBehavior.Restrict);

			buyerConfiguration
					.HasMany(m => m.Products)
					.WithOne(p => p.Creator)
					.HasForeignKey(p => p.CreatorId)
					.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
