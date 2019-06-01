using System;

namespace Grocery.Command.Product
{
	public class RemoveProduct
	{
		public Guid Id { get; set; }
		public Guid MemberId { get; set; }
	}
}
