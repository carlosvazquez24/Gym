using GymManager.Core.Attendances;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAccess.Repositories
{


    public class AttendancesRepository : Repository<int, Attendance>
    {

        // private readonly GymManagerContext _context;

        // protected GymManagerContext Context { get => _context; }

        public AttendancesRepository(GymManagerContext _gymManagerContext) : base(_gymManagerContext)
        {

        }

        public override async Task<Attendance> AddAsync(Attendance entity)
        {
            //Obtener el objeto de la llave foránea
            var member = await Context.Members.FindAsync(entity.Member.Id);

            //Asignarle a la entidad el valor null
            entity.Member = null;

            //Agregar la asistencia a la lista de asistencias
            await Context.Attendances.AddAsync(entity); //agregar entidad

            //Agregar la asistencia a la lista de asistencias del miembro
            member.Attendances.Add(entity);

            await Context.SaveChangesAsync();


            return entity;
        }

        public override async Task<Attendance> GetAsync(int id)
        {
            var attendance = await Context.Attendances.Include(x => x.Member).FirstOrDefaultAsync(x => x.Id == id);
            return attendance;
        }

        public override async Task<Attendance> UpdateAsync(Attendance entity)
        {
            // Se obtiene el objeto de la llave foránea con su id del modelo
            var member = await Context.Members.FindAsync(entity.Member.Id);

            //Se asigna la llave foránea encontrada
            entity.Member = member;

            //Se actualiza la lista de asistencias
            Context.Attendances.Update(entity);

            await Context.SaveChangesAsync();

            return entity;
        }





    }

}
