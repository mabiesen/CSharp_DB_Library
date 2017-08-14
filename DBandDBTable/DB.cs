using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelp 
{
    //Inherit from SQLHelper, which assists with database connections
    //Tight coupling here desired:  the database is useless without connection, connections are part of databases
    //SQLHelper kept separate because it is an action used to instantiate DB AND has many additional methods
    //Should not have to worry about additional load: generally speaking, low number of databases per project(?)
    //
    //Generally speaking I do not like inheritance
    //
    //Where would the Async be appropriate? option to be Async or non? (in absence of wait, I believe non is default behavior)
    public class DB
    {
        public List<DBTable> dbtables = new List<DBTable>();

        //It was noted DB should not be a member of SQLConnection
        //1. SQLConnection determines db
        //2. SQLConnection should be async(relative to provided data)
        //3. DB class could be used to represent database that is not SQL derivative (user created, mongo, etc.)
        public DB()
        {
            
        }
        

        public void AddTable(DataTable table, String name, DataTable schema)
        {
            this.dbtables.Add(new DBTable(table, name, schema));
        }

        public List<string> TableNamesToList()
        {
            var returnlist = new List<string>();
            foreach(var item in this.dbtables)
            {
                returnlist.Add(item.tablename);
            }
            return returnlist;
        }

    }
}
