using System;
using System.Threading.Tasks;

namespace Grocery.Domain.AggregatesModel.MemberAggregate
{
	public interface IMemberRepository
	{
		Member Add(Member member);
		Member Update(Member member);
		Task<Member> FindAsync(Guid MemberIdentityGuid);
		Task<Member> FindByIdAsync(Guid id);
	}
}
