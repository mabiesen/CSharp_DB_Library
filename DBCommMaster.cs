using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelp
{
    //THIS CLASS IS HEAVILY BOUND TO OTHER CLASSES IN LIBRARY
    //THIS CLASS EXECUTES, ALL OTHERS ARE SUBSIDIARY
    //Purpose of class is to combine DB, SQL connection, Validation(combination sql and uinput) while maintaining loose coupling

    //NOTE:  Async wrappers placed in DBCommMaster.  Best to keep async a wrapper to database methods, or implement in connection class?

    public class DBCommMaster
    {
        private readonly IConnection _Iconnection;
        private readonly IErrorWriter _Ierrorwriter;

        //handles holding tables, adding tables, etc.
        public DB database;

        public DBCommMaster(String connectionstring, IConnection iconnection, IErrorWriter errorwriter)
        {
            _Ierrorwriter = errorwriter;
            _Iconnection = iconnection;
            _Iconnection.connectionstring = connectionstring;

            //initialise database
            database = new DB();
        }

        public async Task NonQuery(String query)
        {
            this._Iconnection.NonQuery(query);
        }

        public DataTable ReturnCustomTable(String query)
        {
            return this._Iconnection.GetTableData(query);
        }

        public async Task FetchAllDBTables()
        {
            foreach (var item in _Iconnection.GetTableNames())
            {
                FetchDBTable(item);
            }
        }

        public async Task FetchDBTable(String tablename)
        {
            AddDatabaseTableToDB(_Iconnection.GetTableData("SELECT * FROM " + tablename),tablename,_Iconnection.GetTableSchema(tablename));
        }

        //This method kept private.  If user wants to add table, need checks to confirm no name duplication, proper updates to database, etc. If table from target database, no problem!
        public void AddDatabaseTableToDB(DataTable table, String name, DataTable schema)
        {
            this.database.AddTable(table, name, schema);
        }

        //Actual database, NOT db instance
        public bool TablenameInDatabase(String tablename)
        {
            List<string> tbllist = _Iconnection.GetTableNames();

            if (tbllist.Contains(tablename))
            {
                return true;
            }
            return false;
        }

        //========================================================
        //Below this line are Async wrappers for database interactions.

        public async void AsyncNonQuery(String query)
        {
            await NonQuery(query);
        }

        public async void AsyncFetchTable(String tablename)
        {
            await FetchDBTable(tablename);
        }

        public async void AsyncFetchAllTables()
        {
            await FetchAllDBTables();
        }

    }
}
