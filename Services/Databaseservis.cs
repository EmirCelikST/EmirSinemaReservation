using EmirSinemaReservation.Models;
using EmirSinemaReservation.Data;
using EmirSinemaReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirSinemaReservation.Servisler
{
    internal class Databaseservis
    {


        AppDbContext _dbContext = new AppDbContext();
        public List<Film> Getfilmler()
        {
            return _dbContext.Film.ToList();
        }

        public List<Salon> Getsalonlar()
        {
            return _dbContext.Salon.ToList();
        }
        public List<Seans> Getseans()
        {
            return _dbContext.Seans.ToList();
        }
        public List<BiletBilgi> GetbiletBilgi()
        {
            return _dbContext.BiletBilgi.ToList();
        }
        public int ReturnFilmId(string filmAd)
        {
            var film = _dbContext.Film.FirstOrDefault(f => f.filmAd == filmAd);
            return film != null ? film.id : -1;
        }
        public int GetSalonIdByFilmAndSeans(int filmId, string seansZamani)
        {
            var seans = _dbContext.Seans.FirstOrDefault(f => f.filmId == filmId && f.seansZamani == seansZamani);
            if (seans != null)
            {
                return seans.salonId;
            }
            return -1;
        }
        public int GetSeansIdByFilmAndSeansTime(int filmId, string seansZamani)
        {
            var seans = _dbContext.Seans.FirstOrDefault(f => f.filmId == filmId && f.seansZamani == seansZamani);
            if (seans != null)
            {
                return seans.id;
            }
            return -1;
        }



    }
}