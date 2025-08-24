using GymManager.Core.MembershipsTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAccess.Repositories
{


    public class MembershipTypeRepository : Repository<int, MembershipType>
    {

        // private readonly GymManagerContext _context;

        // protected GymManagerContext Context { get => _context; }

        public MembershipTypeRepository(GymManagerContext _gymManagerContext) : base(_gymManagerContext)
        {

        }

        public override async Task<MembershipType> AddAsync(MembershipType entity)
        {

            await Context.MembershipTypes.AddAsync(entity); //agregar entidad
            await Context.SaveChangesAsync();

            return entity;
        }

        public override async Task<MembershipType> GetAsync(int id)
        {
            var membership = await Context.MembershipTypes.FirstOrDefaultAsync(x => x.Id == id);
            return membership;
        }

        public override async Task<MembershipType> UpdateAsync(MembershipType entity)
        {

            Context.MembershipTypes.Update(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

    }
    
}
