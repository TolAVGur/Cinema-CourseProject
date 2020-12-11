using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Models
{
    public class FilmDTO
    {
        public int FilmId { get; set; }

        [Required]
        [StringLength(128)]
        public string NameFilm { get; set; }

        public int Duration { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; }

    }
}
