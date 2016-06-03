using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy
{
    class AddressBook
    {
        List<User> userList = new List<User>();
        Logger l = Logger.GetInstance();

        public void SetLog(string log)
        {
            if (log == "file")
                l.ChangeLog(new FileLog());    // = new Logger(new FileLog());
            else
                l.ChangeLog(new ConsoleLog());   // = new Logger(new ConsoleLog());      
        }       

        public void AddUser(User u)
        {      
            UserAddedEventArgs arg = new UserAddedEventArgs();
            arg.user = u;
            
            try
            {
                userList.Add(u);
                OnUserAddedEvent(arg);

               // throw new Exception();   // for testing 
            }
            catch (Exception ex)
            {
                l.Error(ex.Message);
            }              
        }

        public void RemoveUser(int index)
        {
            UserAddedEventArgs arg = new UserAddedEventArgs();
            arg.user = userList[index];
            
            try
            {
                userList.RemoveAt(index);  // remove user by index
                OnUserDeletedEvent(arg);
            }
            catch (Exception ex)
            {
                l.Error(ex.Message);
            }
            
        }

        public event EventHandler<UserAddedEventArgs> EventUserAdded;
        public event EventHandler<UserAddedEventArgs> EventUserDeleted;

        public void OnUserAddedEvent(UserAddedEventArgs e)
        {
            EventHandler<UserAddedEventArgs> handler = EventUserAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void OnUserDeletedEvent(UserAddedEventArgs e)
        {
            EventHandler<UserAddedEventArgs> handler = EventUserDeleted;

            if (handler != null)
            {
                handler(this, e);
            }
        }



        public int CountUsers()
        {
            return userList.Count;
        }
    }

    class UserAddedEventArgs : EventArgs
    {
        public User user;
    }
}
