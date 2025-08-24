using GymManager.Core.Members;
using GymManager.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymManager.ApplicationServices.Members
{
    public class MembersAppServices : IMembersAppServices
    {

        private readonly IRepository<int, Member> _repository;

        public MembersAppServices(IRepository<int, Member> repository)
        {

            _repository = repository;

        }


        public async Task<int> addMemberAsync(Member member)
        {

            member.RegistrationDate = DateTime.Now; 
            await _repository.AddAsync(member);
            return member.Id;
        }

        public async Task deleteMemberAsync(int memberId)
        {
            await _repository.DeleteAsync(memberId);
        }

        public async Task editMemberAsync(Member member)
        {
            await _repository.UpdateAsync(member);

        }

        public async Task<Member> getMemberAsync(int memberId)
        {
            return await _repository.GetAsync(memberId);
        }

        public async Task<List<Member>> getMembersAsync()
        {

            return await _repository.GetAllAsync().ToListAsync();
        }
    }
}
