using System;
using System.Threading.Tasks;

namespace Grocery.Domain.AggregatesModel.ProductAggregate
{
	public interface IProductRepository
	{
		Product Add(Product member);
		Product Update(Product member);
		Task<Product> FindByIdAsync(Guid id);
	}
}
