
using System;

namespace Grocery.Domain.AggregatesModel.MemberAggregate
{
	public class Member
	{
		public Guid IdentityGuid { get; private set; }

		public string Name { get; private set; }

		public Member(Guid identity, string name)
		{
			IdentityGuid = identity != Guid.Empty ? identity : throw new ArgumentNullException(nameof(identity));
			Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
		}
	}
}
