using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Entities
{
    public class Order
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Вес должен быть положительным и больше нуля.")]
        public double Weight { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Название района не должно превышать 100 символов.")]
        public string District { get; set; } = string.Empty;

        [Required] 
        [DataType(DataType.DateTime)]
        public DateTime DeliveryTime { get; set; }

    }
}
