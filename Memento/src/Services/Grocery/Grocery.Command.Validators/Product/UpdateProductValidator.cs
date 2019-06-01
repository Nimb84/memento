using FluentValidation;
using Grocery.Command.Product;

namespace Grocery.Command.Validators.Product
{
	public sealed class UpdateProductValidator : AbstractValidator<UpdateProduct>
	{
		public UpdateProductValidator()
		{
			RuleFor(item => item.Name).NotEmpty();
			RuleFor(item => item.ProductId).NotEmpty();
			RuleFor(item => item.MemberId).NotEmpty();
		}
	}
}
