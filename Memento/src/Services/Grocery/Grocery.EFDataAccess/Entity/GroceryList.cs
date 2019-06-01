using Grocery.Domain.Enums.GroceryList;
using System;
using System.Collections.Generic;

namespace Grocery.EFDataAccess.Entity
{
	public class GroceryList : BaseEntity
	{
		public Guid CreatorId { get; set; }

		public string Title { get; set; }
		public string Description { get; set; }

		public GroceryType Type { get; set; }

		public decimal? TotalPrice { get; set; }

		private DateTime? _remindDate { get; set; }
		private DateTime? _expiredDate { get; set; }

		public virtual ICollection<MemberGroceryList> Members { get; set; }
		public virtual ICollection<GroceryItem> Items { get; set; }
	}
}
