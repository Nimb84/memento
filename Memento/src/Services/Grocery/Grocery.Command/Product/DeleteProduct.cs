using System;
using Grocery.Domain.Response;
using MediatR;

namespace Grocery.Command.Product
{
	public class DeleteProduct : IRequest<BaseResponse<bool>>
	{
		public Guid ProductId { get; set; }
		public Guid MemberId { get; set; }
	}
}
