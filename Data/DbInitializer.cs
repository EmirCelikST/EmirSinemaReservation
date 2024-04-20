using EmirSinemaReservation.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EmirSinemaReservation.Data
{
    public static class DbInitializer
    {
        private static string connectionString = "Data Source=..\\..\\Data\\EmirSinemaReservationDb.db;Version=3;";

        public static void InitializeDatabase()
        {
            if (!File.Exists("..\\..\\Data\\EmirSinemaReservationDb.db"))
            {
                SQLiteConnection.CreateFile("..\\..\\Data\\EmirSinemaReservationDb.db;");
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string createfilmTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Film(
                            id INTEGER PRIMARY KEY NOT NULL ,
                            filmAd TEXT NOT NULL,
                            filmSuresi INTEGER NOT NULL,
                            filmTuru TEXT NOT NULL);";

                    string insertfilmQuery = @"
                        INSERT INTO Film (filmAd, filmsuresi, filmTuru) VALUES 
                        ('Need For Speed', 94, 'Yarış'),
                        ('I'm Legend', 93, 'Aksiyon'),
                        ('Grand Prix', 125, 'Gerilim , Yarış'),
                        ('World War Z', 146, 'Aksiyon');";

                    string createSalonTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Salon(
                        id INTEGER PRIMARY KEY NOT NULL,
                        salonAdi TEXT NOT NULL,
                        salonKapasitesi INTEGER NOT NULL);";

                    string insertSalonQuery = @"
                        INSERT INTO Salon (salonAdi, salonKapasitesi) VALUES
                        ('Salon 1', 50),
                        ('Salon 2', 50),
                        ('Salon 3', 50),
                        ('Salon 4', 50);";


                    string createSeansTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Seans (
                            id INTEGER PRIMARY KEY NOT NULL,
                            seansZamani TEXT NOT NULL,
                            filmId INTEGER NOT NULL,
                            salonId INTEGER NOT NULL,

                            FOREIGN KEY (filmId) REFERENCES Film(id),
                            FOREIGN KEY (salonId) REFERENCES Salon(id));";

                    string insertSeansQuery = @"
                        INSERT INTO Seans (seansZamani, filmId, salonId) VALUES 
                        ('11:00', 1, 1),
                        ('11:00', 2, 2),
                        ('11:00', 3, 3),
                        ('11:00', 4, 4),
                        ('15:40', 1, 1),
                        ('15:40', 2, 2),
                        ('15:40', 3, 3),
                        ('15:40', 4, 4),
                        ('21:00', 1, 1),
                        ('21:00', 2, 2),
                        ('21:00', 3, 3),
                        ('21:00', 4, 4);";


                    string createbiletBilgiTableQuery = @"
                    CREATE TABLE IF NOT EXISTS BiletBilgi (
                        id INTEGER PRIMARY KEY NOT NULL,
                        musteriAd TEXT NOT NULL,
                        fiyat TEXT NOT NULL,
                        koltukNumarasi TEXT NOT NULL,
                        tarih TEXT NOT NULL,

                        filmId INTEGER NOT NULL,
                        salonId INTEGER NOT NULL,
                        seansId INTEGER NOT NULL,

                        FOREIGN KEY (filmId) REFERENCES Film(id),
                        FOREIGN KEY (salonId) REFERENCES Salon(id)
                        FOREIGN KEY (seansId) REFERENCES Seans(id));";

                    DateTime bugununTarihi = DateTime.Now;
                    string bugununTarihiFormatli = bugununTarihi.ToString("dd.MM.yy");

                    string insertBiletBilgiQuery = @"
                        INSERT INTO BiletBilgi (musteriAd, fiyat, koltukNumarasi, tarih, filmId, salonId, seansId) VALUES 
                        ('Emir Çelik', '200','1', '" + bugununTarihiFormatli + @"', 1, 1, 1),
                        ('Emir Çimen', '200','5', '" + bugununTarihiFormatli + @"', 1, 1, 1),
                        ('Ali Kağan Dağ', '200','5', '" + bugununTarihiFormatli + @"', 2, 2, 6),
                        ('Emir Çelik', '200','4', '" + bugununTarihiFormatli + @"', 2, 2, 6),
                        ('Beyza Aydın', '200','18', '" + bugununTarihiFormatli + @"', 2, 2, 6),
                        ('Ceren Kurt', '200','14', '" + bugununTarihiFormatli + @"', 2, 2, 10),
                        ('Ecem Turgut', '200','18', '" + bugununTarihiFormatli + @"', 2, 2, 10),
                        ('Ece Ergün', '200','25', '" + bugununTarihiFormatli + @"', 2, 2, 10),
                        ('Seçil Erzak', '200','48', '" + bugununTarihiFormatli + @"', 2, 2, 10),
                        ('Büşra Ağaoğlu', '200','14', '" + bugununTarihiFormatli + @"', 4, 4, 12),
                        ('Emir Akdere', '200','18', '" + bugununTarihiFormatli + @"', 2, 2, 12),
                        ('Hüseyin Altın', '200','25', '" + bugununTarihiFormatli + @"', 2, 2, 12),
                        ('Hatice Güven', '200','48', '" + bugununTarihiFormatli + @"', 2, 2, 12),
                        ('Ergün Koç', '200','7', '" + bugununTarihiFormatli + @"', 1, 1, 12);";
                        




                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = createfilmTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = insertfilmQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = createSalonTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = insertSalonQuery;
                        command.ExecuteNonQuery();


                        command.CommandText = createSeansTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = insertSeansQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = createbiletBilgiTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = insertBiletBilgiQuery;
                        command.ExecuteNonQuery();
                    }
                }
            }

        }


    }
}