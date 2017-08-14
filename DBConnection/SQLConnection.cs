using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelp
{
    //SQL CONNECTION SHOULD BE INTERFACED
    //POTENTIALLY, OUR DATABASE WILL BE NON SQL: this class would need to be swapped, others reusable
    public class SQLConnection : IConnection
    {

        public String connectionstring { get; set; }

        //Instantiate the server object, setting all variables
        public SQLConnection()
        {

        }

        // Query a database for data. Returns a table of data
        public DataTable GetTableData(string query)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    DataTable myDataTable = new DataTable();

                    try
                    {
                        conn.Open();
                        // create data adapter
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        // this will query your database and return the result to your datatable
                        da.Fill(myDataTable);
                        conn.Close();
                        da.Dispose();
                    }
                    catch (SqlException)
                    {
                        //Console.WriteLine("Fail to connect for get table data");
                        //Console.WriteLine(ex);
                    }
                    return myDataTable;
                }
            }
        }

        // Insert, update, delete, etc
        public void NonQuery(string suppliedQuery)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(suppliedQuery, connection))
                {
                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        //Console.WriteLine("Connection failed for generic connection");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        //Tablenames grabbed from db schema
        public List<string> GetTableNames()
        {
            DataTable dt = GetTableData("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'");
            List<string> tables = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                string tablename = (string)row["TABLE_NAME"];
                tables.Add(tablename);
            }

            return tables;
        }

        public DataTable GetTableSchema(String tablename)
        {
            DataTable temptable = new DataTable();
            String myquery = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tablename + "'";

            temptable = GetTableData(myquery);
            return temptable;
        }

    }
}
