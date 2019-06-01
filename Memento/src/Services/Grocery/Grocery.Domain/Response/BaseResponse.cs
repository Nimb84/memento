using Grocery.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace Grocery.Domain.Response
{
	public class BaseResponse<TResult>
	{
		public bool Success { get; }
		public TResult Result { get; }
		public IEnumerable<GroceryDomainException> Errors { get; }

		public BaseResponse(TResult result)
		{
			Success = true;
			Result = result;
		}

		public BaseResponse(Exception error) : this(new GroceryDomainException()) { }

		public BaseResponse(GroceryDomainException error) : this(new List<GroceryDomainException> { error }) { }

		public BaseResponse(IEnumerable<GroceryDomainException> errors)
		{
			Success = false;
			Errors = errors;
		}

		//// Create bad request if entity does not find;
		//public BaseResponse(Guid entityId, ExceptionType errorType)
		//{
		//    Success = false;
		//    Errors = new List<ChatServiceError>() {
		//        new ChatServiceError
		//        {
		//            Code = errorType,
		//            Description = $"Entity {entityId} not found"
		//        }
		//    };
		//}
	}
}
