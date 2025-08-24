using GymManager.Core.EquipmentTypes;
using GymManager.Core.MembershipsTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAccess.Repositories
{
    public class EquipmentRepository : Repository<int, EquipmentType>
    {

        // private readonly GymManagerContext _context;

        // protected GymManagerContext Context { get => _context; }

        public EquipmentRepository(GymManagerContext _gymManagerContext) : base(_gymManagerContext)
        {

        }

        public override async Task<EquipmentType> AddAsync(EquipmentType entity)
        {

            await Context.EquipmentTypes.AddAsync(entity); //agregar entidad
            await Context.SaveChangesAsync();

            return entity;
        }

        public override async Task<EquipmentType> GetAsync(int id)
        {
            var equipmentType = await Context.EquipmentTypes.FirstOrDefaultAsync(x => x.Id == id);
            return equipmentType;
        }

        public override async Task<EquipmentType> UpdateAsync(EquipmentType entity)
        {

            Context.EquipmentTypes.Update(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

    }
}
