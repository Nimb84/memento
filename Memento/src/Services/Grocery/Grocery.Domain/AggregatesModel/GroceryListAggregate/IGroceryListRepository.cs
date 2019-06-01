using System;
using System.Threading.Tasks;

namespace Grocery.Domain.AggregatesModel.GroceryListAggregate
{
	public interface IGroceryListRepository
	{
		GroceryList Add(GroceryList member);
		GroceryList Update(GroceryList member);
		Task<GroceryList> FindByIdAsync(Guid id);
	}
}
