using GymManager.Core.Members;
using GymManager.Core.MembershipsTypes;
using GymManager.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.MembershipsTypes
{
    public class MembershipTypeAppService : IMembershipTypeAppService
    {



        private readonly IRepository<int, MembershipType> _repository;
        private readonly IRepository<int, Member> _memberRepository;

        public MembershipTypeAppService(IRepository<int, MembershipType> repository, IRepository<int, Member> memberRepository )
        {

            _repository = repository;
            _memberRepository = memberRepository;

        }

        public async Task<int> AddMembershipTypeAsync(MembershipType membership)
        {
            membership.CreatedOn = DateTime.Now;
            await _repository.AddAsync(membership);
            return membership.Id;
        }

        public async Task DeleteMembershipTypeAsync(int membershipTypeId)
        {
            var member = await _memberRepository.GetAllAsync()
                .FirstOrDefaultAsync(m => m.MembershipType.Id == membershipTypeId);

            if (member != null)
            {
                throw new InvalidOperationException("Cannot delete membership type because it is assigned to one or more members.");
            }

            await _repository.DeleteAsync(membershipTypeId);
        }

        public async Task EditMembershipTypeAsync(MembershipType membership)
        {
            await _repository.UpdateAsync(membership);
        }

        public async Task<List<MembershipType>> GetAllMembershipsTypesAsync()
        {
            return await _repository.GetAllAsync().ToListAsync();
        }

        public async Task<MembershipType> GetMembershipTypeAsync(int membershipId)
        {
            return await _repository.GetAsync(membershipId);
        }

    }
}
