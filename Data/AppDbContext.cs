using Microsoft.EntityFrameworkCore;
using EmirSinemaReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirSinemaReservation.Data
{

    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= ..\\..\\Data\\EmirSinemaReservation.db");
        }

        public DbSet<Film> Film { get; set; }
        public DbSet<Salon> Salon { get; set; }
        public DbSet<Seans> Seans { get; set; }
        public DbSet<BiletBilgi> BiletBilgi { get; set; }
       
    }
    
}
