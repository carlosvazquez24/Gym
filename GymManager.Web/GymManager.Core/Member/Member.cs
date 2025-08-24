using GymManager.Core.Attendances;
using GymManager.Core.Cities;
using GymManager.Core.MembershipsTypes;
using GymManager.Core.Sales;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Members
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }



        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [BindProperty, DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }


        [BindProperty, DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }


        [BindProperty, DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MembershipExpirationDate { get; set; }


        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public bool AllowNewsletter { get; set; }

        public MembershipType? MembershipType { get; set; }


        // Listas
        public List<Attendance> Attendances { get; set; }

        public Member()
        {
            Attendances = new List<Attendance>();


        }


    }
}
