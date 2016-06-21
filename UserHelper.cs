using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Strategy
{
    class UserHelper
    {
        //Методів вводу інформації про користувача може буде багато.
        //Зроби окремий клас UserHelper і перенеси в нього цей метод.

        // А якщо добавляти інші методи вводу інформації про користувача в класі User то це bad

        CultureInfo provider = CultureInfo.InvariantCulture;

        public User InputUser(User _u)
        {
            User u;  //= new User();
            u = _u;

            Console.WriteLine("     Please input user data ");

            Console.Write("input lastname: ");
            u.LastName = Console.ReadLine();

            Console.Write("input firstname: ");
            u.FirstName = Console.ReadLine();

           do
            {
                Console.Write("input Birthdate (dd.mm.yyyy): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", provider, System.Globalization.DateTimeStyles.None, out u.Birthdate))
                    Console.WriteLine("Wrong date format, Please try again, be more attentive!");
                else
                    break;

            } while (true);


            do
            {
                Console.Write("input TimeAdded (dd.mm.yyyy): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", provider, System.Globalization.DateTimeStyles.None, out u.TimeAdded))
                    Console.WriteLine("Wrong date format, Please try again, be more attentive!");
                else
                    break;

            } while (true);


            Console.Write("input City: ");
            u.City = Console.ReadLine();

            Console.Write("input Address: ");
            u.Address = Console.ReadLine();

            Console.Write("input PhoneNumber: ");
            u.PhoneNumber = Console.ReadLine();

            do
            {
                Console.Write("input Gender(input man, woman): ");
                string temp = Console.ReadLine();
                if (temp == "man")
                {
                    u.gender = Gender.man;
                    break;
                }
                else
                    if (temp == "woman")
                    {
                        u.gender = Gender.woman;
                        break;
                    }
                    else
                        Console.WriteLine("Please try again");
            } while (true);
            

            Console.Write("input Email: ");
            u.Email = Console.ReadLine();
           
            Console.WriteLine();

            return u;
        }
    }
}
