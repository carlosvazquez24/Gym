using GymManager.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.MembershipRenewal
{
    public interface IMembershipRenewalAppServices
    {

        Task editMemberAsync(Member member);

    }
}
