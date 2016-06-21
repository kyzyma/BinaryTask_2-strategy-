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
        ILog log;
     
        public void ChangeLog(ILog l)
        {
            log = l;
        }

        public void WriteInLog(string message, string prefix)
        {
            try
            {
                log.Write(prefix + ": " + message);
            }
            catch (Exception ex)
            {
                if (log is FileLog)         // if was exception during writing Error(Warning) in FileLog then change Log for output in Console and vice versa
                    ChangeLog(new ConsoleLog());
                else
                    // Чи варото створювати файл логгер якщо він щойно кинув ексепшн?
                    // Тут така логіка: якщо підчас запису в файл стався ексцепшн то в кeтчі відбувається переключення лога на консоль(умова тру),
                    // якщо в траї виводиться на консоль і стався ексцепшн то в кетчі лог переключеться на файл(умова фолс)
                    ChangeLog(new FileLog());

                log.Write("Error: " + ex.Message);                
            }
        }

        // Методи Error та Warning ­ копії, що відрізняються лише префіксом повідомлення, що логується. Це треба пофіксати.

        /*     public void Warning(string mes) 
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
         */
    }
}
