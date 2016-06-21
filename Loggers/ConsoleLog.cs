using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy
{
    class ConsoleLog : ILog
    {
        public void Write(string s)
        {
            Console.WriteLine(s + Environment.NewLine);
        }
    }
}
