using Grocery.Domain.AggregatesModel.MemberAggregate;
using System;
using System.Collections.Generic;

namespace Grocery.Domain.AggregatesModel.GroceryListAggregate
{
	public class GroceryList
	{
		private string _title;
		private string _description;

		public decimal TotalPrice { get; set; }

		//private GroceryType _type;

		private DateTime _createDate;
		private DateTime? _remindDate;
		private DateTime? _expiredDate;

		private IEnumerable<GroceryItem> _groceryItems;
		private IEnumerable<Member> _members;
	}
}
