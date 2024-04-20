using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirSinemaReservation.Models
{
    public class BiletBilgi
    {
        public int id { get; set; }
        public int filmId { get; set; }
        public int seansId { get; set; }
        public int salonId { get; set; }
        public string musteriAd { get; set; }
        public string fiyat { get; set; }
        public string koltukNumarasi { get; set; }
        public string tarih { get; set; }
    }
}