using Grocery.Domain.AggregatesModel.MemberAggregate;
using Grocery.Domain.AggregatesModel.ProductAggregate;

namespace Grocery.Domain.AggregatesModel.GroceryListAggregate
{
	public class GroceryItem
	{
		public Product Product { get; set; }
		public int Units { get; set; }

		public int Priority { get; set; }
		//public GroceryItemProgress Progress { get; set; }

		public string Comment { get; set; }

		public bool IsBooked { get; set; }
		public Member Doer { get; set; }

		public decimal Price { get; set; }
	}
}
