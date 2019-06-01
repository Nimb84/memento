using Grocery.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grocery.Domain.Request
{
	public class BaseRequestHandlerr<TRequest, TResponse> : IRequestHandler<TRequest, BaseResponse<TResponse>>
			where TRequest : IRequest<ChatServiceResponse<TResponse>>
	{
	}

	public sealed class ChatServiceRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, ChatServiceResponse<TResponse>>
			where TRequest : IRequest<ChatServiceResponse<TResponse>>
	{
		private readonly IValidatorFactory _validatorFactory;
		private readonly IRequestHandler<TRequest, ChatServiceResponse<TResponse>> _inner;

		public ChatServiceRequestHandler(IValidatorFactory validationFactory, IRequestHandler<TRequest, ChatServiceResponse<TResponse>> inner)
		{
			_validatorFactory = validationFactory;
			_inner = inner;
		}

		public async Task<ChatServiceResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
		{
			var validationResult = await _validatorFactory.GetValidator<TRequest>().ValidateAsync(request, cancellationToken).ConfigureAwait(false);
			if (!validationResult.IsValid)
			{
				return GetBadRequest(validationResult.Errors);
			}

			try
			{
				return await _inner.Handle(request, cancellationToken).ConfigureAwait(false);
			}
			catch (Exception error)
			{
				return new ChatServiceResponse<TResponse>(error);
			}
		}

		//public abstract Task<MessageResponse<TResponse>> ChatServiceHandle(TRequest request, CancellationToken cancellationToken);

		private ChatServiceResponse<TResponse> GetBadRequest(IList<ValidationFailure> errors)
		{
			var errorList = errors.Select(error => new ChatServiceError
			{
				Code = ExceptionType.ValidationException,
				Description = error.ErrorMessage
			});

			return new ChatServiceResponse<TResponse>(errorList);
		}
	}
}



}
