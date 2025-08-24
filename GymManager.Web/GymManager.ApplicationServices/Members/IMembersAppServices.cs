using GymManager.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.Members
{
    public interface IMembersAppServices
    {
        Task<List<Member>> getMembersAsync();

        Task<int> addMemberAsync(Member member);

        Task deleteMemberAsync(int memberId);

        Task editMemberAsync(Member member);

        Task<Member> getMemberAsync(int memberId);

    }
}
