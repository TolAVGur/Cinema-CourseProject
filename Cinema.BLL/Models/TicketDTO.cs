using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Models
{
    public class TicketDTO
    {
        public int TicketId { get; set; }

        public int VisitorId { get; set; }

        public int SeanceId { get; set; }

        public int line { get; set; }

        public int Sead { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
