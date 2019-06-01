using Grocery.Domain.Enums.Product;
using Grocery.Domain.Response;
using MediatR;
using System;

namespace Grocery.Command.Product
{
	public class CreateProduct : IRequest<BaseResponse<Guid>>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public ProductType Type { get; set; }
		public ProductUnitType UnitType { get; set; }
		public decimal DefaultUnits { get; set; }
		public decimal DefaultPrice { get; set; }
		public Guid MemberId { get; set; }
	}
}
