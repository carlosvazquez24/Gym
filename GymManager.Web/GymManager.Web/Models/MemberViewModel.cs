using GymManager.Core.Cities;
using GymManager.Core.MembershipsTypes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Web.Models
{
    public class MemberViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Debe ingresar el nombre del miembro")]
        public string Name { get; set; }

        [StringLength(20)]
        [Required]
        public string LastName { get; set; }

        [BindProperty, DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }

        public int CityId { get; set; }

        public int MembershipTypeId { get; set; }


        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public bool AllowNewsletter { get; set; }

        public List<MembershipType> MembershipTypes { get; set; }


        public List<City> Cities { get; set; }
    }
}
