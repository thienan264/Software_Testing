using System;
using System.Configuration;
using System.Data.SqlClient;
using OrganizationApp.Models;

namespace OrganizationApp.DAL
{
    public class OrganizationRepository
    {
        private readonly string _connStr;

        public OrganizationRepository()
        {
            _connStr = ConfigurationManager
                .ConnectionStrings["OrgDb"].ConnectionString;
        }

        public bool ExistsByName(string name)
        {
            using (var conn = new SqlConnection(_connStr))
            using (var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM ORGANIZATION WHERE UPPER(OrgName)=UPPER(@n)", conn))
            {
                cmd.Parameters.AddWithValue("@n", name.Trim());
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public int Insert(Organization org)
        {
            using (var conn = new SqlConnection(_connStr))
            using (var cmd = new SqlCommand(@"
INSERT INTO ORGANIZATION(OrgName,Address,Phone,Email)
OUTPUT INSERTED.OrgID
VALUES(@n,@a,@p,@e)", conn))
            {
                cmd.Parameters.AddWithValue("@n", org.OrgName);
                cmd.Parameters.AddWithValue("@a", (object)org.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@p", (object)org.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@e", (object)org.Email ?? DBNull.Value);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}