using ConsoleApp12.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleApp12.Service
{
    public class Menu
    {
        public static void BankMenu(Customer customer)
        {
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit ");
            Console.WriteLine("3. Withdraw ");
            Console.WriteLine("4. Transfer ");
            Console.WriteLine("5. Check Account balance");
            Console.WriteLine("6. Statement of Account ");
            Console.WriteLine("7. Account Details");
            Console.WriteLine("8. Logout");
            Console.Write("Enter Input: ");
            var input = Console.ReadLine();
            if(input == "1") 
            {
                AccountService.CreateAccount(customer);
            }
            else if(input == "2")
            {
                AccountService.Deposit(customer);
            }
            else if(input == "3")
            {
                AccountService.Withdraw(customer);
            }
            else if(input == "4")
            {
                AccountService.Transfer(customer);
            }
           else if( input == "5")
            {
                AccountService.CheckBalance(customer);
            }
            else if(input=="6") 
            {
                AccountService.StatementOfAccount(customer);
            }
            else if(input == "7")
            {
                AccountService.GetAccountDetails(customer);
            }
            else if(input == "8")
            {
                AccountService.Logout();
            }
            else
            {
                Console.WriteLine("Invalid Input. Please select from 1 - 8");
            }
        }
    }
}
