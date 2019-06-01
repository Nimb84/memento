using Grocery.Command.Product;
using Grocery.Domain.Response;
using Grocery.EFDataAccess;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Entities = Grocery.EFDataAccess.Entity;

namespace Grocery.Command.Handlers.Product
{
	public sealed class CreateProductHandler : IRequestHandler<CreateProduct, BaseResponse<Guid>>
	{
		private readonly GroceryContext _dbContext;

		public CreateProductHandler(GroceryContext dbContext) => 
			_dbContext = dbContext;

		public async Task<BaseResponse<Guid>> Handle(CreateProduct request, CancellationToken cancellationToken)
		{
			var entity = GetEntity(request);
			await _dbContext.Products.AddAsync(entity, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);
			return new BaseResponse<Guid>(entity.Id);
		}

		private static Entities.Product GetEntity(CreateProduct request) => 
			new Entities.Product
			{
				Id = Guid.NewGuid(),
				CreateDate = DateTime.UtcNow,
				Name = request.Name,
				Description = request.Description,
				Type = request.Type,
				UnitType = request.UnitType,
				DefaultUnits = request.DefaultUnits,
				DefaultPrice = request.DefaultPrice,
				CreatorId = request.MemberId
			};
	}
}
