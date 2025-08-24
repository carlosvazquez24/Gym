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

        public MembershipTypeAppService(IRepository<int, MembershipType> repository)
        {

            _repository = repository;

        }

        public async Task<int> AddMembershipTypeAsync(MembershipType membership)
        {
            membership.CreatedOn = DateTime.Now;
            await _repository.AddAsync(membership);
            return membership.Id;
        }

        public async Task DeleteMembershipTypeAsync(int membershipTypeId)
        {
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
