using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseHelp.Tests
{
    [TestClass()]
    public class SQLConnectionTests
    {
        String globalConnectionString = @"Data Source=DESKTOP-5MSDOS9\SQLEXPRESS;Database=TestDatabase;Integrated Security=True";
        SQLConnection newconn = new SQLConnection();

        public SQLConnectionTests()
        {
            newconn.connectionstring = globalConnectionString;
        }

        [TestMethod()]
        public void SQLConnectionTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void GetTableDataTest()
        {
            DataTable thistable = newconn.GetTableData("SELECT * FROM Testtable");
            Assert.IsTrue(thistable.Rows[1]["FirstName"].ToString() == "h");
        }

        [TestMethod()]
        public void NonQueryTest()
        {
            //first query for count
            String cntquer = "SELECT COUNT(FirstName) counting FROM Testtable";
            DataTable thistable1 = newconn.GetTableData(cntquer);
            String count1 = thistable1.Rows[0]["counting"].ToString();

            //next, delete
            String delete1 = "DELETE FROM Testtable WHERE FirstName = 'h'";
            newconn.NonQuery(delete1);

            //count again
            DataTable thistable2 = newconn.GetTableData(cntquer);
            String count2 = thistable2.Rows[0]["counting"].ToString();

            var difference1 = int.Parse(count1) - int.Parse(count2);

            Assert.IsTrue(difference1 > 0);

            //Finally, lets insert for later tests
            String reinsert = "Insert Into Testtable Values(5,'h','h','v')";
            newconn.NonQuery(reinsert);

            //Count Again
            DataTable thistable3 = newconn.GetTableData(cntquer);
            String count3 = thistable3.Rows[0]["counting"].ToString();

            var difference2 = int.Parse(count3) - int.Parse(count2);
            Assert.IsTrue(difference2 > 0);

        }

        [TestMethod()]
        public void GetTableNamesTest()
        {
            List<string> thislist = newconn.GetTableNames();
            System.Diagnostics.Debug.WriteLine(thislist[0].ToString());
            Assert.IsTrue(thislist.Contains("Testtable"));
        }

        [TestMethod()]
        public void GetTableSchemaTest()
        {
            DataTable thistable = newconn.GetTableSchema("Testtable");
            List<string> fieldnames = new List<string>();
            List<string> fieldtype = new List<string>();
            foreach(DataRow row in thistable.Rows)
            {
                //row [3] is the field names
                //row [7] is the field types
                //row [8] is the field character max length
                //row [9] same?
                //row [10] precision

                //Col references are from the MS sql table schema
                //COLUMN_NAME, col3 in table
                //IS_NULLABLE, col6
                //DATA_TYPE, col7
                //CHARACTER_MAXIMUM_LENGTH, 8
                //NUMERIC_PRECISION, 10
                //NUMERIC_SCALE, 12
                //DATETIME_PRECISION, 13

                fieldnames.Add(row[3].ToString());
            }

            Assert.IsTrue(fieldnames.Contains("FirstName"));
        }

    }
}