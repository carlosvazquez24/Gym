using GymManager.Core.Cities;
using GymManager.Core.Members;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAccess.Repositories
{


    public class CityRepository : Repository<int, City>
    {

        // private readonly GymManagerContext _context;

        // protected GymManagerContext Context { get => _context; }

        public CityRepository(GymManagerContext _gymManagerContext) : base(_gymManagerContext)
        {

        }


        public override async Task<City> GetAsync(int id)
        {
            var city = await Context.Cities.FirstOrDefaultAsync(x => x.Id == id);
            return city;
        }


    }

}
