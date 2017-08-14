using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelp
{
    //This class will house the datatable and additional methods and properties
    public class DBTable
    {
        //Whitelists help to protect against SQL injection
        //Timestamp for comparisons, timed updates
        public DateTime timestamp;
        public String tablename;
        public List<string> fieldNameWhitelist = new List<string>();
        public DataTable datatable;
        public DataTable schematable;

        public DBTable(DataTable dbtable, String tblname, DataTable schema)
        {
            this.tablename = tblname;
            this.timestamp = DateTime.Now;
            this.datatable = dbtable;
            this.schematable = schema;
            foreach (DataColumn column in dbtable.Columns)
            {
                fieldNameWhitelist.Add(column.ColumnName);
            }
        }

        //This field to assist in SQL query creation
        public bool IsAFieldName(String fieldname)
        {
            if (fieldNameWhitelist.Contains(fieldname))
            {
                return true;
            }
            return false;
        }


        //Check for datatable equality
        public bool DoTablesMatch(DataTable dbtable)
        {
            if(dbtable == this.datatable)
            {
                return true;
            }
            return false;
        }

    }

}




