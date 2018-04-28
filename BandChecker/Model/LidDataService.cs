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
    class LidDataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        private static IDbConnection db = new SqlConnection(connectionString);

        public ObservableCollection<Lid> getLeden()
        {
            string sql = "Select * from bandchecker.Lid order by naam";
            ObservableCollection<Lid> leden = db.Query<Lid>(sql).ToObservableCollection();

            return leden;
        }

        public ObservableCollection<Lid> GetLedenByBand(Band band)
        {
            string sql = "select * from bandchecker.Lid where bandId = " + band.Id + " order by naam";
            ObservableCollection<Lid> leden = db.Query<Lid>(sql).ToObservableCollection();

            return leden;
        }

        public void UpdateLid(Lid lid)
        {
            // SQL statement update
            string sql = "Update bandchecker.Lid set naam = @naam, voornaam = @voornaam, geboortedatum = @geboortedatum, instrument = @instrument, bandId = @bandId where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                lid.Id,
                lid.Naam,
                lid.Voornaam,
                lid.Geboortedatum,
                lid.Instrument,
                lid.BandId
            });
        }

        public void InsertLid(Lid lid)
        {
            // SQL statement insert
            string sql = "Insert into bandchecker.Lid(naam, voornaam, geboortedatum, instrument, bandId) values (@naam, @voornaam, @geboortedatum, @instrument, @bandId)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                lid.Naam,
                lid.Voornaam,
                lid.Geboortedatum,
                lid.Instrument,
                lid.BandId
            });
        }

        public void DeleteLid(Lid lid)
        {
            // SQL statement delete
            string sql = "Delete bandchecker.Lid where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { lid.Id });
        }
    }
}
