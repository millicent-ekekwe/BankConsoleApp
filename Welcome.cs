using ConsoleApp12.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public class Welcome
    {
        public static void WelcomePage()
        {
            Console.WriteLine("WELCOME TO MIMI'S INTERCONTINENTAL BANK OF AFRICA");
            Console.WriteLine();
            Console.WriteLine("Enter 1 to Register or 2 to Login");
            Console.Write("Enter Input: ");
            var input =Console.ReadLine();
            if(input == "1")
            {
                CustomerService.Register();
            }


        }
    }
}
