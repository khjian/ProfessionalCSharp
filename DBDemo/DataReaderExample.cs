using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDemo
{
    public class DataReaderExample
    {
        public static void ReadData()
        {
            string source = "Provider=SQLOLEDB;server=(local);integrated security=SSPI;database=northwind";
            string select = "select ContactName,CompanyName from customers";
            OleDbConnection conn = new OleDbConnection(source);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(select,conn);
            OleDbDataReader aReader = cmd.ExecuteReader();
            while (aReader.Read())
            {
                Console.WriteLine("'{0}' from {1}",aReader.GetString(0),aReader.GetString(1));
            }
            aReader.Close();
            conn.Close();
        }
    }
}
