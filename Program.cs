using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {            
            AddressBook listUser = new AddressBook();
            User u1 = new User();
            User u2 = new User();
            UserHelper uh = new UserHelper();
            Log log;     // Enum log is name(type) of log
            
            ChooseLog(out log);
            listUser.SetLog(log);

            listUser.UserAdded += HandlerEventAddUser;
            listUser.UserDeleted += HandlerEventDeleteUser;
                       
            listUser.AddUser(uh.InputUser(u1));
                        
            listUser.AddUser(uh.InputUser(u2));

            listUser.RemoveUser(0);

            Console.WriteLine("Count users: " + listUser.CountUser);

            Console.ReadKey();
        }

        static void ChooseLog(out Log log)
        {
            do
            {
                Console.WriteLine("Please choose type log (input: file or console)");

                switch (Console.ReadLine())
                {
                    case "file":     log = Log.file;     return; 
                    case "console":  log = Log.console;  return;
                    default:   Console.WriteLine("Try again"); break;
                }
            } while (true);
        }

        static void HandlerEventAddUser(object sender, UserEventArgs e)
        {
            Logger log = Logger.GetInstance();   

            log.WriteInLog("Added user in list: " + e.user.LastName, "Warning");
        }

        static void HandlerEventDeleteUser(object sender, UserEventArgs e)
        {
            Logger log = Logger.GetInstance();

            log.WriteInLog("Deleted user with list: " + e.user.LastName, "Warning");
        }
    }
}
