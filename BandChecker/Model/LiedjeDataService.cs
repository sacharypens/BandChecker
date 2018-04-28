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
    class LiedjeDataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        private static IDbConnection db = new SqlConnection(connectionString);

        public ObservableCollection<Liedje> getLiedjes()
        {
            string sql = "Select * from bandchecker.Liedje order by naam";
            ObservableCollection<Liedje> liedjes = db.Query<Liedje>(sql).ToObservableCollection();
            return liedjes;
        }

        public ObservableCollection<Liedje> GetLiedjesByBand(Band band)
        {
            string sql = "select * from bandchecker.Liedje where bandId2 = " + band.Id + " order by naam";
            ObservableCollection<Liedje> liedjes = db.Query<Liedje>(sql).ToObservableCollection();

            return liedjes;
        }

        public void UpdateLiedje(Liedje liedje)
        {
            // SQL statement update
            string sql = "Update bandchecker.Liedje set naam = @naam, duurtijd = @duurtijd where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                liedje.Id,
                liedje.Naam,
                liedje.Duurtijd,
                liedje.BandId
            });
        }

        public void InsertLiedje(Liedje liedje)
        {
            // SQL statement insert
            string sql = "Insert into bandchecker.Liedje(naam, duurtijd, bandId2) values (@naam, @duurtijd, @bandId)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                liedje.Naam,
                liedje.Duurtijd,
                liedje.BandId
            });
        }

        public void DeleteLiedje(Liedje liedje)
        {
            // SQL statement delete
            string sql = "Delete bandchecker.Liedje where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { liedje.Id });
        }
    }
}
