using FluentValidation;
using Grocery.Domain.Response;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.Domain.Request
{
	public sealed class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, BaseResponse<TResponse>>
		where TRequest : IRequest<BaseResponse<TResponse>>
	{
		private readonly IValidatorFactory _validatorFactory;
		private readonly IRequestHandler<TRequest, BaseResponse<TResponse>> _inner;

		public BaseRequestHandler(IValidatorFactory validationFactory, IRequestHandler<TRequest, BaseResponse<TResponse>> inner)
		{
			_validatorFactory = validationFactory;
			_inner = inner;
		}

		public async Task<BaseResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
		{
			var validationResult = await _validatorFactory.GetValidator<TRequest>().ValidateAsync(request, cancellationToken).ConfigureAwait(false);

			if (!validationResult.IsValid)
				return new BaseResponse<TResponse>(validationResult.Errors);

			try
			{
				return await _inner.Handle(request, cancellationToken).ConfigureAwait(false);
			}
			catch (Exception error)
			{
				return new BaseResponse<TResponse>(error);
			}
		}
	}
}