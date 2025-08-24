using GymManager.Core.Sales;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Users
{
    public class User : IdentityUser
    {

        public List<Sale> Sales { get; set; }

        public User() {

            Sales = new List<Sale>();
        }

    }
}
