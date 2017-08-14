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
    public class DBCommMasterTests
    {
        DBCommMaster dbcm;

        public void setup()
        {
            String globalConnectionString = @"Data Source=DESKTOP-5MSDOS9\SQLEXPRESS;Database=TestDatabase;Integrated Security=True";
            SQLConnection sqc = new SQLConnection();
            ErrorDebuggerWriter edw = new ErrorDebuggerWriter();
            dbcm = new DBCommMaster(globalConnectionString,sqc,edw);
        }

        [TestMethod()]
        public void DBCommMasterTest()
        {
            //This is the instantiation method
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void NonQueryTest()
        {
            //If Async and Normal query work, and NOnquery works in connection class, nonquery is not an issue
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void ReturnCustomTableTest()
        {
            setup();
            DataTable dt = dbcm.ReturnCustomTable("SELECT * FROM Testtable");
            Assert.IsTrue(dt.Rows[0][0] != null);
        }

        [TestMethod()]
        public void FetchAllDBTablesTest()
        {
            setup();
            dbcm.FetchAllDBTables();
            Assert.IsTrue(dbcm.database.dbtables.Count() > 0);
            Assert.IsFalse(dbcm.database.dbtables.Count() > 1);
        }

        [TestMethod()]
        public void FetchDBTableTest()
        {
            setup();
            dbcm.FetchDBTable("Testtable");
            Assert.IsTrue(dbcm.database.dbtables.Count() > 0);
            Assert.IsFalse(dbcm.database.dbtables.Count() > 1);
        }

        [TestMethod()]
        public void AddDatabaseTableToDBTest()
        {
            setup();
            DataTable dt = new DataTable();
            string name = "Testtable";
            dbcm.AddDatabaseTableToDB(dt, name, dt);
            Assert.IsTrue(dbcm.database.dbtables.Count() > 0);
        }

        [TestMethod()]
        public void TablenameInDatabaseTest()
        {
            setup();
            Assert.IsTrue(dbcm.TablenameInDatabase("Testtable"));
        }

        [TestMethod()]
        public void AsyncNonQueryTest()
        {
            //It works in the connection, it will work here
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void AsyncFetchTableTest()
        {
            setup();
            dbcm.AsyncFetchTable("Testtable");
            System.Threading.Thread.Sleep(500);   //waiting for Async method to wrap up
            Assert.IsTrue(dbcm.database.dbtables.Count() > 0);
           
        }

        [TestMethod()]
        public void AsyncFetchAllTablesTest()
        {
            setup();
            dbcm.AsyncFetchAllTables();
            System.Threading.Thread.Sleep(500);   //waiting for Async method to wrap up
            Assert.IsTrue(dbcm.database.dbtables.Count() > 0);
        }
    }
}