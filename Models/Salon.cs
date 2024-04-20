using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirSinemaReservation.Models
{
    public class Salon
    {
        public int id { get; set; }
        public string salonAdi { get; set; }
        public int salonKapasitesi { get; set; }
    }
}