using System.Collections.Generic;
using System.Data;

namespace DatabaseHelp
{
    public interface IConnection
    {
        string connectionstring { get; set; }
        DataTable GetTableData(string query);
        void NonQuery(string query);
        List<string> GetTableNames();
        DataTable GetTableSchema(string tablename);
    }
}
