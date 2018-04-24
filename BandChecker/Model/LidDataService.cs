using Dapper;
using System;
using System.Collections.Generic;
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

        private List<Lid> getLids()
        {
            string sql = "Select * from Lid order by naam";
            return (List<Lid>)db.Query<Lid>(sql);
        }

        public void Updatesoort(Lid lid)
        {
            // SQL statement update
            string sql = "Update Lid set naam = @naam, voornaam = @voornaam, geboortedatum = @geboortedatum, instrument = @instrument, bandId = @bandId where id = @id";

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

        public void InsertSoort(Lid lid)
        {
            // SQL statement insert
            string sql = "Insert into Lid(naam, voornaam, geboortedatum, instrument, bandId) values (@naam, @voornaam, @geboortedatum, @instrument, @bandId)";

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

        public void DeleteSoort(Lid lid)
        {
            // SQL statement delete
            string sql = "Delete Lid where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { lid.Id });
        }
    }
}
