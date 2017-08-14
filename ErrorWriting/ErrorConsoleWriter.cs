using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelp
{
    class ErrorConsoleWriter : IErrorWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine("Error Message:");
            Console.WriteLine(line);
        }

        public void WriteLines(List<string> lines)
        {
            Console.WriteLine("Error Message:");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

        }
    }
}
