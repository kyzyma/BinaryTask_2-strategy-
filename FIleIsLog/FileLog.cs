using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Strategy
{
    class FileLog :TypeLogs
    {
        public override void SomeLog(string s)
        {
            File.AppendAllText("C:\\Users\\Administrator\\Desktop\\log.txt", s + " | " + DateTime.Now + '\n' + '\n'); // Append text in end file                        
        }
    }
}
