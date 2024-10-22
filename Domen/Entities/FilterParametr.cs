using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Entities
{
    public class FilterParametr
    {
        [Required]
        [StringLength(100, ErrorMessage = "Название района не должно превышать 100 символов.")]
        public string cityDistrict {  get; set; } = string.Empty;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FirstDeliveryDateTime { get; set; }
    }
}
