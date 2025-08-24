using GymManager.Core.Members;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.MembershipsTypes
{
    public class MembershipType
    {

        [Key]

        public int Id { get; set; }

        [StringLength(100)]

        [Required]
        public string Name { get; set; }

        [Range(0, 100000)]
        [Required]
        public double Cost { get; set; }


        [Required]
        [BindProperty, DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Range(0, 12)]
        public int Duration { get; set; }


        public List<Member> Members { get; set; }

        public MembershipType()
        {
            Members = new List<Member>();

        }

    }
}
