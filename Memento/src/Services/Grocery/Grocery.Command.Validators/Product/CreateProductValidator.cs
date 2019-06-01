using FluentValidation;
using Grocery.Command.Product;

namespace Grocery.Command.Validators.Product
{
	public sealed class CreateProductValidator : AbstractValidator<CreateProduct>
	{
		public CreateProductValidator()
		{
			RuleFor(item => item.Name).NotEmpty();
			RuleFor(item => item.MemberId).NotEmpty();
		}
	}
}
