using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelp
{
    public class ErrorDebuggerWriter : IErrorWriter
    {

        public void WriteLine(string line)
        {
            System.Diagnostics.Debug.WriteLine("Error Message:");
            System.Diagnostics.Debug.WriteLine(line);
        }

        public void WriteLines(List<string> lines)
        {
            System.Diagnostics.Debug.WriteLine("Error Message:");
            foreach(var line in lines)
            {
                System.Diagnostics.Debug.WriteLine(line);
            }
        }
    }
}
