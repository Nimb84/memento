using Grocery.Domain.Enums.GroceryList;
using System;

namespace Grocery.EFDataAccess.Entity
{
	public class GroceryItem : BaseEntity
	{
		public Guid ProductId { get; set; }
		public Guid GroceryListId { get; set; }

		public GroceryItemPriority Priority { get; set; }
		public GroceryItemProgress Progress { get; set; }

		public int Units { get; set; }

		public decimal Price { get; set; }

		public string Comment { get; set; }

		public bool IsBooked { get; set; }
		public Guid? MemberId { get; set; }

		public virtual Member Member { get; set; }
		public virtual Product Product { get; set; }
		public virtual GroceryList List { get; set; }
	}
}
