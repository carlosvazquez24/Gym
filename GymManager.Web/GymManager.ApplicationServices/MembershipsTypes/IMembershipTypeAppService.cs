using GymManager.Core.MembershipsTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.MembershipsTypes
{
    public interface IMembershipTypeAppService
    {


        Task<List<MembershipType>> GetAllMembershipsTypesAsync();

        Task<int> AddMembershipTypeAsync(MembershipType membership);

        Task DeleteMembershipTypeAsync(int membershipTypeId);

        Task EditMembershipTypeAsync(MembershipType membership);

        Task<MembershipType> GetMembershipTypeAsync(int membershipId);



    }
}
