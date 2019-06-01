using System;
using System.Collections.Generic;
using System.Reflection;
using FluentValidation;
using Grocery.Command.Handlers.Product;
using Grocery.Command.Product;
using Grocery.Command.Validators.Product;
using Grocery.Domain.Request;
using Grocery.Domain.Response;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Grocery.Bootstrap.ServicesBuilder
{
	public static class MediatRServicesBuilder
	{
		private static readonly List<Assembly> Assemblies = new List<Assembly>();

		public static IServiceCollection AddGroceryMediatR(this IServiceCollection services)
		{
			Assemblies.Add(Assembly.GetAssembly(typeof(CreateProductHandler)));
			//Assemblies.Add(typeof(GetMessagesHandler).GetTypeInfo().Assembly);
			services.AddMediatR(Assemblies.ToArray());

			services.RegisterValidation();

			services.AddScopedMediator<CreateProductHandler, CreateProduct, Guid, CreateProductValidator>();
			services.AddScopedMediator<UpdateProductHandler, UpdateProduct, bool, UpdateProductValidator>();
			services.AddScopedMediator<DeleteProductHandler, DeleteProduct, bool, DeleteProductValidator>();

			return services;
		}

		public static IServiceCollection AddScopedMediator<THandler, TRequest, TResponse, TValidator>(
			this IServiceCollection services)
			where TRequest : IRequest<BaseResponse<TResponse>>
			where THandler : class, IRequestHandler<TRequest, BaseResponse<TResponse>>
			where TValidator : class, IValidator<TRequest>
		{
			services.AddScoped<IRequestHandler<TRequest, BaseResponse<TResponse>>, THandler>()
				.Decorate<IRequestHandler<TRequest, BaseResponse<TResponse>>>(
					(inner, provider) =>
					{
						var validationFactory = provider.GetRequiredService<IValidatorFactory>();
						return new BaseRequestHandler<TRequest, TResponse>(validationFactory, inner);
					});

			services.AddScoped<IValidator<TRequest>, TValidator>();
			return services;
		}
	}
}
