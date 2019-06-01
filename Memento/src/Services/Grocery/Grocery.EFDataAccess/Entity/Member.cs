using System;
using System.Collections.Generic;

namespace Grocery.EFDataAccess.Entity
{
	public class Member : BaseEntity
	{
		public Guid IdentityMemberId { get; set; }
		public string Name { get; set; }

		public virtual ICollection<GroceryItem> GroceryItems { get; set; }
		public virtual ICollection<MemberGroceryList> Lists { get; set; }
		public virtual ICollection<Product> Products { get; set; }
	}
}
