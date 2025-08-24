using GymManager.Core.Members;
using GymManager.Core.ProductTypes;
using GymManager.Core.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Sales
{
    public class Sale
    {


        [Key]
        public int Id { get; set; }

        [Required]
        [BindProperty, DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public ProductType ProductType { get; set; }

        public User User { get; set; }


    }
}
