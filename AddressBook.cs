using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy
{
    class AddressBook
    {
        // Викинь слово Event з назв івентів
        public event EventHandler<UserEventArgs> UserAdded = delegate { };   // if initialize delegate empty method then OnUserAddedEvent() - comments
        public event EventHandler<UserEventArgs> UserDeleted = delegate { };

        List<User> userList = new List<User>();

        // Зроби з цього метода пропертю Count.
        public int CountUser { get; set; }

        Logger l = Logger.GetInstance();

        // Створи енум з типами логів.

        public void SetLog(Log log)
        {             
            switch(log)
            {
                case Log.file: 
                    l.ChangeLog(new FileLog()); 
                    break;
                case Log.console:
                    l.ChangeLog(new ConsoleLog()); 
                    break;
            }
            Console.WriteLine();
        }       

        public void AddUser(User u)
        {            
            try
            {
                userList.Add(u);

                UserAdded(this, new UserEventArgs(u));   // OnUserAddedEvent(arg);

                CountUser = userList.Count;
               // throw new Exception();   // for testing 
            }
            catch (Exception ex)
            {
                l.WriteInLog(ex.Message, "Error");
            }              
        }

        public void RemoveUser(int index)
        {            
            try
            {
                UserDeleted(this, new UserEventArgs(userList[index]));    // OnUserDeletedEvent(arg);

                userList.RemoveAt(index);  // remove user by index
                
                CountUser = userList.Count;
            }
            catch (Exception ex)
            {
                l.WriteInLog(ex.Message, "Error");
            }            
        }

    /*  public int CountUsers()
        {
            return userList.Count;
        }

        public void OnUserAddedEvent(UserEventArgs e)
        {
            EventHandler<UserEventArgs> handler = EventUserAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void OnUserDeletedEvent(UserEventArgs e)
        {
            EventHandler<UserEventArgs> handler = EventUserDeleted;

            if (handler != null)
            {
                handler(this, e);
            }
        }
    */       
    }
       
}
