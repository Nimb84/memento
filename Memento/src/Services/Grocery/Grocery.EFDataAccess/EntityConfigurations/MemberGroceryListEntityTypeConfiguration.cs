using Grocery.EFDataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.EFDataAccess.EntityConfigurations
{
	internal class MemberGroceryListEntityTypeConfiguration : IEntityTypeConfiguration<MemberGroceryList>
	{
		public void Configure(EntityTypeBuilder<MemberGroceryList> buyerConfiguration)
		{
			buyerConfiguration.ToTable(nameof(MemberGroceryList));

			buyerConfiguration.HasIndex(m => m.Id).IsUnique();

			buyerConfiguration.HasKey(mgl => new { mgl.MemberId, mgl.GroceryListId });

			buyerConfiguration
					.HasOne(mgl => mgl.Member)
					.WithMany(m => m.Lists)
					.HasForeignKey(mgl => mgl.MemberId)
					.OnDelete(DeleteBehavior.Restrict);

			buyerConfiguration
					.HasOne(mgl => mgl.GroceryList)
					.WithMany(gl => gl.Members)
					.HasForeignKey(mgl => mgl.GroceryListId)
					.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
