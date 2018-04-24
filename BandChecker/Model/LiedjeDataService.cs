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
    class LiedjeDataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        private static IDbConnection db = new SqlConnection(connectionString);

        private List<Liedje> getLiedjes()
        {
            string sql = "Select * from Liedje order by naam";
            return (List<Liedje>)db.Query<Liedje>(sql);
        }

        public void Updatesoort(Liedje liedje)
        {
            // SQL statement update
            string sql = "Update Liedje set naam = @naam, duurtijd = @duurtijd bandId = @bandId where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                liedje.Naam,
                liedje.Duurtijd,
                liedje.BandId
            });
        }

        public void InsertSoort(Liedje liedje)
        {
            // SQL statement insert
            string sql = "Insert into Liedje(naam, duurtijd, bandId) values (@naam, @duurtijd, @bandId)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                liedje.Naam,
                liedje.Duurtijd,
                liedje.BandId
            });
        }

        public void DeleteSoort(Liedje liedje)
        {
            // SQL statement delete
            string sql = "Delete Liedje where id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { liedje.Id });
        }
    }
}
