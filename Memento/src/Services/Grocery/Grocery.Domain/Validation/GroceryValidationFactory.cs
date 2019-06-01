using FluentValidation;
using System;

namespace Grocery.Domain.Validation
{
	public class GroceryValidationFactory : ValidatorFactoryBase
	{
		private readonly IServiceProvider _serviceProvider;

		public GroceryValidationFactory(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public override IValidator CreateInstance(Type validatorType)
		{
			return (IValidator)_serviceProvider.GetService(validatorType);
		}
	}
}
