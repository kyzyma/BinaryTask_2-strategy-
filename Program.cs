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
            string log;     //name log
            AddressBook listUser = new AddressBook();
            User u1 = new User();
            User u2 = new User();

            ChooseLog(out log);
            listUser.SetLog(log);

            listUser.EventUserAdded += HandlerEventAddUser;
            listUser.EventUserDeleted += HandlerEventDeleteUser;

            u1.InputUser();            
            listUser.AddUser(u1);

            u2.InputUser();
            listUser.AddUser(u2);

            listUser.RemoveUser(0);

            Console.WriteLine("Count users: "+ listUser.CountUsers());

            Console.ReadKey();
        }

        static void ChooseLog(out string log)
        {
            do
            {
                Console.WriteLine("Please choose type log (input: file or console)");
                log = Console.ReadLine();

                if (log == "file" || log == "console")
                {
                    Console.WriteLine();
                    break;
                }
                Console.WriteLine();  
            } while (true);
        }

        static void HandlerEventAddUser(object sender, UserAddedEventArgs e)
        {
            Logger log = Logger.GetInstance();   //new Logger(new FileLog());
            log.ChangeLog(new FileLog());

            log.Warning("Added user in list: " + e.user.LastName);
        }

        static void HandlerEventDeleteUser(object sender, UserAddedEventArgs e)
        {
            Logger log = Logger.GetInstance();   //new Logger(new FileLog());
            log.ChangeLog(new FileLog());
            
            log.Warning("Deleted user with list: " + e.user.LastName);
        }
    }
}
