using Grocery.Domain.Enums.Product;
using System;
using Grocery.Domain.Response;
using MediatR;

namespace Grocery.Command.Product
{
	public class UpdateProduct : IRequest<BaseResponse<bool>>
	{
		public Guid ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ProductType Type { get; set; }
		public ProductUnitType UnitType { get; set; }
		public decimal DefaultUnits { get; set; }
		public decimal DefaultPrice { get; set; }
		public Guid MemberId { get; set; }
	}
}
