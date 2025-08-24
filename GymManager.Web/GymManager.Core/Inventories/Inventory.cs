using GymManager.Core.ProductTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Inventories
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, 10000000)]
        public int Existence { get; set; }

        public ProductType ProductType { get; set; }
    }
}
