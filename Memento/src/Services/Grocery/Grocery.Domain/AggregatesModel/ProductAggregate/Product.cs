using System;

namespace Grocery.Domain.AggregatesModel.ProductAggregate
{
	public class Product
	{
		public string Name { get; set; }
		public string Decription { get; set; }

		//public ProductType Type { get; set; }
		//public ProductUnitType UnitType { get; set; }
		public decimal DefaultUnits { get; set; }

		public Guid? CreatorId { get; set; }

		public decimal DefaultPrice { get; set; }
	}
}
