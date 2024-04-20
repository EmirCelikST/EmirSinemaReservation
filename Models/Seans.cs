using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirSinemaReservation.Models
{
    public class Seans
    {
        public int id { get; set; }
        public int salonId { get; set; }
        public int filmId { get; set; }
        public string seansZamani { get; set; }
    }
}