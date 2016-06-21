using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Strategy
{
    class FileLog : ILog
    {
        public void Write(string s)
        {
            File.AppendAllText("C:\\Users\\Admin\\Desktop\\log.txt", s + " | " + DateTime.Now + Environment.NewLine); // Append text in end file                        
        }
    }
}
