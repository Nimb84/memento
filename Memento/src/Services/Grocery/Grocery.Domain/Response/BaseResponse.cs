using FluentValidation.Results;
using Grocery.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

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

		public BaseResponse(Exception error)
			: this(new GroceryDomainException()) { }

		public BaseResponse(GroceryDomainException error)
			: this(new List<GroceryDomainException> { error }) { }

		public BaseResponse(IEnumerable<ValidationFailure> errors) 
			: this(errors.Select(error => 
				new GroceryDomainException(error.ErrorMessage, ExceptionType.ValidationException))) { }

		public BaseResponse(IEnumerable<GroceryDomainException> errors)
		{
			Errors = errors;
		}
	}
}
