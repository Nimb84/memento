using Grocery.Command.Product;
using Grocery.Domain.Exceptions;
using Grocery.Domain.Response;
using Grocery.EFDataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Entities = Grocery.EFDataAccess.Entity;

namespace Grocery.Command.Handlers.Product
{
	public sealed class DeleteProductHandler : IRequestHandler<DeleteProduct, BaseResponse<bool>>
	{
		private readonly GroceryContext _dbContext;

		public DeleteProductHandler(GroceryContext dbContext) =>
			_dbContext = dbContext;

		public async Task<BaseResponse<bool>> Handle(DeleteProduct request, CancellationToken cancellationToken)
		{
			var entity = await _dbContext.Products.SingleOrDefaultAsync(
				product => product.Id == request.ProductId && product.CreatorId == request.MemberId, cancellationToken);

			if (entity == null)
				return new BaseResponse<bool>(new GroceryDomainException(
					$"{nameof(Entities.Product)} entity was not found. Id: {request.ProductId}",
					ExceptionType.NotFoundException));

			_dbContext.Products.Remove(entity);
			var result = await _dbContext.SaveChangesAsync(cancellationToken) > 0;

			return new BaseResponse<bool>(result);
		}
	}
}
