using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Strategy
{
    class User
    {
        CultureInfo provider = CultureInfo.InvariantCulture;

        public string LastName;
        public string FirstName;
        public DateTime Birthdate;
        public DateTime TimeAdded;
        public string City;
        public string Address;
        public string PhoneNumber;
        public string Gender;
        public string Email;

        public void InputUser()
        {
            Console.WriteLine("     Please input user data ");

            Console.Write("input lastname: ");
            this.LastName = Console.ReadLine();
 
            Console.Write("input firstname: ");
            this.FirstName = Console.ReadLine();

            do
            {
                Console.Write("input Birthdate (dd.mm.yyyy): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", provider, System.Globalization.DateTimeStyles.None, out this.Birthdate))
                    Console.WriteLine("Wrong date format, Please try again, be more attentive!");
                else
                    break;

            } while (true);


            do
            {
                Console.Write("input TimeAdded (dd.mm.yyyy): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", provider, System.Globalization.DateTimeStyles.None, out this.TimeAdded))
                    Console.WriteLine("Wrong date format, Please try again, be more attentive!");
                else
                    break;

            } while (true);


            Console.Write("input City: ");
            this.City = Console.ReadLine();

            Console.Write("input Address: ");
            this.Address = Console.ReadLine();

            Console.Write("input PhoneNumber: ");
            this.PhoneNumber = Console.ReadLine();

            Console.Write("input Gender: ");
            this.Gender = Console.ReadLine();

            Console.Write("input Email: ");
            this.Email = Console.ReadLine();
            
            Console.WriteLine();
        }
    }
}
