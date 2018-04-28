using BandChecker.Extensions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandChecker.Model
{
    class BandDataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        private static IDbConnection db = new SqlConnection(connectionString);

        public ObservableCollection<Band> getBands()
        {
            string sql = "Select * from bandchecker.Band order by naam";
            ObservableCollection<Band> bands = db.Query<Band>(sql).ToObservableCollection();

            return bands;
        }

        public void UpdateBand(Band band)
        {
            // SQL statement update
            string sql = "Update bandchecker.Band set naam = @naam, omschrijving = @omschrijving, opgericht = @opgericht, genre = @genre where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                band.Id,
                band.Naam,
                band.Omschrijving,
                band.Genre,
                band.Opgericht
            });
        }

        public void InsertBand(Band band)
        {
            // SQL statement insert
            string sql = "Insert into bandchecker.Band(naam, omschrijving, opgericht, genre) values (@naam, @omschrijving, @opgericht, @genre)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                band.Naam,
                band.Omschrijving,
                band.Opgericht,
                band.Genre
            });
        }

        public void DeleteBand(Band band)
        {
            // SQL statement delete
            string sql = "Delete bandchecker.Band where id = @id";
            //TODO controlleren of band nog liedjes of leden heeft
            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { band.Id });
        }
    }
}
