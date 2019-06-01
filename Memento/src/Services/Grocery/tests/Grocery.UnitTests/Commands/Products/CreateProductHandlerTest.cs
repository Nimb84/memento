using Grocery.Command.Handlers.Product;
using Grocery.Command.Product;
using Grocery.Domain.Enums.Product;
using Grocery.Domain.Response;
using Grocery.EFDataAccess.Entity;
using Grocery.UnitTests.Builders;
using System;
using System.Linq;
using System.Threading;
using Xunit;

namespace Grocery.UnitTests.Commands.Products
{
	public class CreateProductHandlerTest
	{
		private readonly CancellationToken _cancellationToken;

		public CreateProductHandlerTest()
		{
			var tokenSource = new CancellationTokenSource();
			_cancellationToken = tokenSource.Token;
		}

		[Fact]
		public void IsCreateCorrectProduct()
		{
			var contextHandler = new GroceryContextTest(nameof(IsCreateCorrectProduct));
			var command = new CreateProduct()
			{
				Name = "fakeName",
				Description = "fakeDescription",
				Type = ProductType.Other,
				UnitType = ProductUnitType.PC,
				DefaultUnits = 1,
				DefaultPrice = 1,
				MemberId = Guid.Empty
			};

			var response = Do(contextHandler, command);
			var matchModel = GetEntity(contextHandler, response.Result, command.MemberId);

			var productCount = contextHandler.ExecuteWithTestContext((context) => context.Products.Count());

			Assert.Equal(1, productCount);
			Assert.True(response.Success);
			Assert.Null(response.Errors);

			Assert.NotNull(matchModel);

			Assert.NotEqual(Guid.Empty, response.Result);
			Assert.Equal(command.Name, matchModel.Name);
			Assert.Equal(command.Description, matchModel.Description);
			Assert.Equal(command.Type, matchModel.Type);
			Assert.Equal(command.UnitType, matchModel.UnitType);
			Assert.Equal(command.DefaultUnits, matchModel.DefaultUnits);
			Assert.Equal(command.DefaultPrice, matchModel.DefaultPrice);
			Assert.Equal(command.MemberId, matchModel.CreatorId);
		}

		private BaseResponse<Guid> Do(GroceryContextTest contextHandler, CreateProduct command) =>
			contextHandler.ExecuteWithTestContext((context) =>
			{
				var service = new CreateProductHandler(context);
				var task = service.Handle(command, _cancellationToken);
				task.Wait(_cancellationToken);
				return task.Result;
			});

		private static Product GetEntity(GroceryContextTest contextHandler, Guid productId, Guid memberId) =>
			contextHandler.ExecuteWithTestContext((context) => 
				context.Products.FirstOrDefault(product => product.Id == productId && product.CreatorId == memberId));
	}
}
