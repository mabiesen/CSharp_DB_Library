using System.Collections.Generic;

namespace DatabaseHelp
{
    public interface IErrorWriter
    {
        void WriteLine(string line);
        void WriteLines(List<string> lines);
    }
}
