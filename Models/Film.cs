using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirSinemaReservation.Models
{
    public class Film
    {
        public int id { get; set; }
        public string filmAd { get; set; }
        public int filmSuresi { get; set; }
        public string filmTuru { get; set; }
    }

}