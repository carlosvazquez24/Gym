using GymManager.Core.Members;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAccess.Repositories
{


    public class MembersRepository : Repository<int, Member>
    {

        // private readonly GymManagerContext _context;

        // protected GymManagerContext Context { get => _context; }

        public MembersRepository(GymManagerContext _gymManagerContext) : base(_gymManagerContext)
        {

        }

        public async Task<bool> AA(int id)
        {
            return true;
        }

        public override async Task<Member> AddAsync(Member entity)
        {
            //Obtener la ciudad del contexto
            var city = await Context.Cities.FindAsync(entity.City.Id);
            var membership = await Context.MembershipTypes.FindAsync(entity.MembershipType.Id);


            //Asignar fechas
            entity.MembershipExpirationDate = DateTime.Now.AddMonths(membership.Duration);

            entity.City = null;
            entity.MembershipType = null;

            await Context.Members.AddAsync(entity); //agregar entidad

            city.Members.Add(entity);    //Agregar el miembro en la lista de miembros de la clase city
            membership.Members.Add(entity); //

            await Context.SaveChangesAsync();


            return entity;
        }

        public override async Task<Member> GetAsync(int id)
        {
            var member = await Context.Members.Include(x => x.City).Include(x => x.MembershipType).FirstOrDefaultAsync(x => x.Id == id);
            return member;
        }

        public override async Task<Member> UpdateAsync(Member entity)
        {
            var city = await Context.Cities.FindAsync(entity.City.Id);
            var membership = await Context.MembershipTypes.FindAsync(entity.MembershipType.Id);


            entity.City = city;
            entity.MembershipType = membership;

            Context.Members.Update(entity);

            await Context.SaveChangesAsync();

            return entity;
        }





    }

}
