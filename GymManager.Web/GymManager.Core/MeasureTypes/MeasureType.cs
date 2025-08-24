using GymManager.Core.ProductTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.MeasureTypes
{
    public class MeasureType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Measure { get; set; }

        public List<ProductType> Products { get; set; }

        public MeasureType()
        {

            Products = new List<ProductType>();
        }

    }
}
