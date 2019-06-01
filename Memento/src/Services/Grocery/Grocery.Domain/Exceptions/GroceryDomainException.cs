using System;

namespace Grocery.Domain.Exceptions
{
	/// <summary>
	/// Exception type for domain exceptions
	/// </summary>
	public class GroceryDomainException : Exception
	{
		public ExceptionType Code { get; }

		public GroceryDomainException(ExceptionType code = ExceptionType.InnerException)
		{ }

		public GroceryDomainException(string message, ExceptionType code = ExceptionType.InnerException)
				: base(message)
		{ }

		public GroceryDomainException(string message, Exception innerException, ExceptionType code = ExceptionType.InnerException)
				: base(message, innerException)
		{ }
	}
}
