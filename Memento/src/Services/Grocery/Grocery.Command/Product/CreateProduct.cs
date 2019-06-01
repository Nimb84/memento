using Grocery.Domain.Enums.Product;
using System;

namespace Grocery.Command.Product
{
	public class CreateProduct
	{
		public string Name { get; set; }
		public string Decription { get; set; }
		public ProductType Type { get; set; }
		public ProductUnitType UnitType { get; set; }
		public decimal DefaultUnits { get; set; }
		public decimal DefaultPrice { get; set; }
		public Guid MemberId { get; set; }
	}
}
