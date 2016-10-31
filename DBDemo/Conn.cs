using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Transactions;

namespace DBDemo
{
    public class Conn
    {
        string source = "server=(local);integrated security=SSPI;database=Northwind";

        private DbConnection GetDatabaseConnetion(string name)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            DbProviderFactory factory = DbProviderFactories.GetFactory(settings.ProviderName);
            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = settings.ConnectionString;
            return conn;
        }

        public void Test()
        {
            string source = "server=(local);integrated security=SSPI;database=Northwind";
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                using (SqlConnection conn = new SqlConnection(source))
                {
                    scope.Complete();
                }
            }
        }

        public void Select()
        {
            string source = "server=(local);integrated security=SSPI;database=Northwind";
            string select = "SELECT ContactName,CompanyName from Customers";
            SqlConnection conn = new SqlConnection(source);
            conn.Open();
            SqlCommand cmd = new SqlCommand(select,conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Contact:{0,-20} Company:{1}",
                    reader[0],reader[1]);
            }
            conn.Close();
        }

        /*
         * create procedure RegionUpdate (@RegionID integer,@RegionDescription NCHAR(50)) as
	set nocount off
    update region
   set RegionDescription=@RegionDescription
  where RegionID=@RegionID
GO
         */
        public void UpdateStoredProc()
        {
            string source = "server=(local);integrated security=SSPI;database=Northwind";
            string select = "SELECT ContactName,CompanyName from Customers";
            SqlConnection conn = new SqlConnection(source);
            conn.Open();
            SqlCommand cmd = new SqlCommand("RegionUpdate", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RegionID", 5);
            cmd.Parameters.AddWithValue("RegionDescription", "Something");
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        /*
         create procedure RegionDelete(@RegionID integer) as
set nocount off
delete from Region
where RegionID=@RegionID
go
*/
        public void DeleteStoredProc()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(source))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("RegionDelete",conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@RegionID", SqlDbType.Int, 0, "RegionID"));
                    cmd.UpdatedRowSource = UpdateRowSource.None;
                    cmd.Parameters["@RegionID"].Value = 5;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (SqlException)
            {
                
                throw;
            }
        }

        /*
         create procedure 
RegionInsert(@RegionDescription nchar(50),@RegionID integer output) as
set nocount off
select @RegionID = MAX(RegionID) + 1
from Region
insert into Region(RegionID,RegionDescription)
Values(@RegionID,@RegionDescription)
go
*/
        public void InsertStoredProc()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(source))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("RegionInsert",conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@RegionDescription", SqlDbType.NChar, 50, "RegionDescription"));
                    cmd.Parameters.Add(new SqlParameter("@RegionID", SqlDbType.Int, 0,ParameterDirection.Output,false,0,0,
                        "RegionID",DataRowVersion.Default, null));
                    cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;
                    cmd.Parameters["@RegionDescription"].Value = "South West";
                    cmd.ExecuteNonQuery();
                    int newRegionID = (int) cmd.Parameters["@RegionID"].Value;
                    Console.WriteLine(newRegionID);
                    conn.Close();
                }
            }
            catch (SqlException)
            {
                
                throw;
            }
        }
    }
}