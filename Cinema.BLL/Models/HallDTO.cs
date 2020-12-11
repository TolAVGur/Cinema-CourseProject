using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Models
{
    public class HallDTO
    {
        public int HallId { get; set; }

        [Required]
        [StringLength(64)]
        public string NameHall { get; set; }
    }
}
