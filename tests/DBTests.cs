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
    public class DBTests
    {
        DB testdb = new DB();
        [TestMethod()]
        public void DBTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void AddTableTest()
        {
            DataTable thistable = new DataTable();
            testdb.AddTable(thistable, "hey", thistable);
            Assert.IsTrue(testdb.dbtables[0].tablename == "hey");
        }

        [TestMethod()]
        public void TableNamesToListTest()
        {
            DataTable thistable = new DataTable();
            testdb.AddTable(thistable, "ho", thistable);
            Assert.IsTrue((testdb.TableNamesToList()).Count() > 0);
            Assert.IsTrue(testdb.TableNamesToList().Contains("ho"));
        }
    }
}