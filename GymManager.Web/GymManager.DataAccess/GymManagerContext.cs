using GymManager.Core.Attendances;
using GymManager.Core.Cities;
using GymManager.Core.EquipmentTypes;
using GymManager.Core.Inventories;
using GymManager.Core.MeasureTypes;
using GymManager.Core.Members;
using GymManager.Core.MembershipsTypes;
using GymManager.Core.Sales;
using GymManager.Core.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAccess
{
    public class GymManagerContext : IdentityDbContext
    {

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Member> Members { get; set; }

        public virtual DbSet<MembershipType> MembershipTypes { get; set; }

        public virtual DbSet<MeasureType> MeasureTypes { get; set; }

        public virtual DbSet<Inventory> Inventories { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<Attendance> Attendances { get; set; }

        public GymManagerContext(DbContextOptions<GymManagerContext>  options )  : base( options )
        {
        
        }
    }
}
