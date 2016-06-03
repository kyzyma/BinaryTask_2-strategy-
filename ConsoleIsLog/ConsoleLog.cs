using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy
{
    class ConsoleLog :TypeLogs
    {
        public override void SomeLog(string s)
        {
            Console.WriteLine(s + '\n');
        }
    }
}
