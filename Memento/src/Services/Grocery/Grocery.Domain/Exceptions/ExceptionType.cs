namespace Grocery.Domain.Exceptions
{
	public enum ExceptionType : byte
	{
		ValidationException,
		NotFoundException,
		InvalidOperationException,
		PermissionException,
		InnerException
	}
}
