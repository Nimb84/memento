using Grocery.Domain.Enums.Product;
using System;
using System.Collections.Generic;

namespace Grocery.EFDataAccess.Entity
{
	public class Product : BaseEntity
	{
		public string Name { get; set; }
		public string Decription { get; set; }
		public ProductType Type { get; set; }
		public ProductUnitType UnitType { get; set; }
		public decimal DefaultUnits { get; set; }
		public decimal DefaultPrice { get; set; }
		public Guid? CreatorId { get; set; }

		public virtual Member Creator { get; set; }
		public virtual ICollection<GroceryItem> GroceryItems { get; set; }
	}
}
