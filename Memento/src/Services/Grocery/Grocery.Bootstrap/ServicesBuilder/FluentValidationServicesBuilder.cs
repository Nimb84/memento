using FluentValidation;
using Grocery.Domain.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Grocery.Bootstrap.ServicesBuilder
{
	public static class FluentValidationServicesBuilder
	{
		public static IServiceCollection RegisterValidation(this IServiceCollection service)
		{
			service.AddScoped<IValidatorFactory, GroceryValidationFactory>();
			return service;
		}
	}
}
