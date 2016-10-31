using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DataRowDemo();
            Console.ReadKey();
        }

        public static void DataRowDemo()
        {
            string source = "server=(local);integrated security=SSPI;database=northwind";
            string select = "SELECT ContactName,companyname from customers";
            SqlConnection conn = new SqlConnection(source);
            SqlDataAdapter da = new SqlDataAdapter(select,conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Customers");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine($"'{row[0]}' from {row[1]}");
            }
        }

        public static async Task<int> GetEmployeeCount()
        {
            string source = "server=(local);integrated security=SSPI;database=Northwind";
            using (SqlConnection conn = new SqlConnection(source))
            {
                SqlCommand cmd = new SqlCommand("WAITFOR DELAY '0:0:02';select count(*) from employees",conn);
                conn.Open();
                return await cmd.ExecuteScalarAsync().ContinueWith(t => Convert.ToInt32(t.Result));
            }
        }
    }
}
