using GymManager.Core.Members;
using GymManager.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymManager.ApplicationServices.MembershipsTypes;

namespace GymManager.ApplicationServices.MembershipRenewal
{
    public class MembershipRenewalAppServices : IMembershipRenewalAppServices
    {

        private readonly IRepository<int, Member> _repository;
        private readonly IMembershipTypeAppService _membershipTypeAppService;

        public MembershipRenewalAppServices(IRepository<int, Member> repository, 
            IMembershipTypeAppService membershipTypeAppService)
        {

            _repository = repository;
            _membershipTypeAppService = membershipTypeAppService;

        }


        public async Task editMemberAsync(Member member)
        {
            var membership = await _membershipTypeAppService.GetMembershipTypeAsync(member.MembershipType.Id);

            if(membership == null)
            {
                throw new Exception("Membership type not found.");
            }

            member.MembershipExpirationDate = DateTime.Now.AddMonths(membership.Duration);

            await _repository.UpdateAsync(member);

        }


    }
}
