using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy
{
    class UserEventArgs:EventArgs
    {
        public UserEventArgs(User u)
        {
            user = u;
        }

        public User user { get; private set; }
    }
}
