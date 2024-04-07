using ConsoleApp12.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp12.Service
{
    public class CustomerService
    {
        public static List<Customer> RegisteredCustomers = new List<Customer>();

        public static void Register()
        {
            Customer newCustomer = new Customer();

            // Validate Firstname
            while (true)
            {
                Console.WriteLine("Enter First Name (must start with a capital letter and not a digit):");
                string firstNameInput = Console.ReadLine();
                if (Regex.IsMatch(firstNameInput, "^[A-Z][a-zA-Z]*$"))
                {
                    newCustomer.Firstname = firstNameInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. First name must start with a capital letter and not contain digits.");
                }
            }

            // Validate Lastname
            while (true)
            {
                Console.WriteLine("Enter Last Name (must start with a capital letter and not a digit):");
                string lastNameInput = Console.ReadLine();
                if (Regex.IsMatch(lastNameInput, "^[A-Z][a-zA-Z]*$"))
                {
                    newCustomer.Lastname = lastNameInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Last name must start with a capital letter and not contain digits.");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter Email:");
                string emailInput = Console.ReadLine();
                if (Regex.IsMatch(emailInput, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    newCustomer.Email = emailInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid email address.");
                }
            }

            // Validate Password
            while (true)
            {
                Console.WriteLine("Enter Password (at least 6 characters with a special character and a number):");
                string passwordInput = Console.ReadLine();
                if (Regex.IsMatch(passwordInput, @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$"))
                {
                    newCustomer.Password = passwordInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Password must be at least 6 characters long and contain at least one special character and one number.");
                }
            }

            RegisteredCustomers.Add(newCustomer);
            Console.WriteLine("Registration successful!");
            Console.WriteLine("Enter 1 to login");
            Console.Write("Enter Input: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Login();
            }
        }

        public static void Login()
        {
            Console.WriteLine("Enter Email:");
            string emailInput = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string passwordInput = Console.ReadLine();

            Customer customer = RegisteredCustomers.FirstOrDefault(c => c.Email == emailInput && c.Password == passwordInput);
            if (customer != null)
            {
                Console.Clear();
                Menu.BankMenu(customer);
            }
            else
            {
                Console.WriteLine("Invalid email or password.");
            }
        }
    }
}
