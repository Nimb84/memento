using Grocery.Domain.Enums.Member;
using System;

namespace Grocery.EFDataAccess.Entity
{
	public class MemberGroceryList : BaseEntity
	{
		public Guid MemberId { get; set; }
		public Guid GroceryListId { get; set; }

		public virtual Member Member { get; set; }
		public virtual GroceryList GroceryList { get; set; }

		public AccessLevelType Access { get; set; }
	}
}
