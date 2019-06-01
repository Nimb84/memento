using FluentValidation;
using Grocery.Command.Product;

namespace Grocery.Command.Validators.Product
{
	public sealed class DeleteProductValidator : AbstractValidator<DeleteProduct>
	{
		public DeleteProductValidator()
		{
			RuleFor(item => item.MemberId).NotEmpty();
			RuleFor(item => item.ProductId).NotEmpty();
		}
	}
}
