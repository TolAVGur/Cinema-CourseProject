using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Models
{
    public class SeanceDTO
    {
        public int SeanceId { get; set; }

        public int HallId { get; set; }
        public string NameHall { get; set; }

        public int FilmId { get; set; }
        public string NameFilm { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime StopTime { get; set; }
    }
}
