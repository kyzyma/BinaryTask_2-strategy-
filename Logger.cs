using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy
{
    class Logger
    {
         // implementation singleton
        private static readonly Logger inst = new Logger();

        private Logger()
        { }

        static Logger()
        { }

        public static Logger GetInstance()
        {            
            return inst;
        }
//-----------------------------------
        TypeLogs log;

      /*  public Logger(TypeLogs l)
        {
            log = l;
        }
        */
        public void ChangeLog(TypeLogs l)
        {
            log = l;
        }

        public void Error(string mes)
        {
            try
            {
                log.SomeLog("Error: " + mes);
            }
            catch (Exception ex)
            {
                if (log is FileLog)         // if was exception during writing Error in FileLog then change Log for output in Console
                    ChangeLog(new ConsoleLog());
                else
                    ChangeLog(new FileLog());

                log.SomeLog("Error: " + ex.Message);                
            }
        }

        public void Warning(string mes) 
        {
            try
            {
                log.SomeLog("Warning: " + mes);
            }
            catch (Exception ex)
            {
                if (log is FileLog)         // if was exception during writing Warning in FileLog then change Log for output in Console
                    ChangeLog(new ConsoleLog());
                else
                    ChangeLog(new FileLog());

                log.SomeLog("Error: " + ex.Message);
            }
        }
    }
}
