using ConsoleApp12.Model;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12.Service
{
    public class AccountService
    {
        public static List<Account> accounts = new List<Account>();
        public static List<TransactionHistory> transactionHistory = new List<TransactionHistory>();

        public static void CreateAccount(Customer customer)
        {
            Console.WriteLine("Enter 1 for savings and 2 for current");
            Console.Write("Enter input");
            var input = Console.ReadLine();
            if (input == "1")
            {
                var account = new Account
                {
                    AccountNumber = Helper.GenerateAccountNumber(),
                    AccountType = AccountType.Savings,
                    Balance = 1000
                };
                accounts.Add(account);
            }
            else if (input == "2")
            {
                var account = new Account
                {
                    AccountNumber = Helper.GenerateAccountNumber(),
                    AccountType = AccountType.Current,
                    Balance = 0
                };
                accounts.Add(account);
            }
            foreach (var item in accounts)
            {
                Console.WriteLine($"{customer.Firstname} {customer.Lastname} {item.AccountNumber} {item.AccountType} {item.Balance}");
            }
            Console.WriteLine("Enter 1 to go back to menu");
            Console.Write("Enter Input: ");
            var menu = Console.ReadLine();
            if (menu == "1")
            {
                Console.Clear();
                Menu.BankMenu(customer);
            }
        }

        public static void Deposit(Customer customer)

        {

            //Customer customer = new Customer();

            Console.WriteLine("Enter destination account number: ");

            var target = Console.ReadLine();
            Console.WriteLine("Enter Narration: ");
            var narration = Console.ReadLine();

            Console.Write("Enter deposit amount: ");

            decimal amount = Convert.ToDecimal(Console.ReadLine());

            if (amount <= 0)

            {

                Console.WriteLine("Amount must be greater than zero.");

                return;

            }
            var account = accounts.FirstOrDefault(x => x.AccountNumber == target);

            account.Balance += amount;

            Console.WriteLine($"Deposit of {amount:C} successful.");

            Console.WriteLine($"Current balance: {account.Balance:C}");
            var transaction = new TransactionHistory
            {
                Amount = amount,
                Date = DateTime.Now,
                Narration = narration
            };
            transactionHistory.Add(transaction);

            Console.WriteLine("Press 1 to return to Menu, or 0 to exit: ");
            

            var next = Console.ReadLine();

            if (next == "1")

            {

                Menu.BankMenu(customer);

            }

        }

        public static void Withdraw(Customer customer)

        {
            Console.WriteLine("Enter Withdarwal account: ");
            var target = Console.ReadLine();

            Console.Write("Enter withdraw amount: ");

            decimal amount = Convert.ToDecimal(Console.ReadLine());
            var account = accounts.FirstOrDefault(u => u.AccountNumber == target);
            if ((amount < 1000 && account.AccountType == AccountType.Savings) || (account.Balance < amount))
            {


                Console.WriteLine("Insufficient Funds");

                return;

            }

            account.Balance -= amount;


            Console.WriteLine($"Withdrawal of {amount:C} successful.");

            Console.WriteLine($"Current balance: {account.Balance:C}");
            var transaction = new TransactionHistory
            {
                Amount = amount,
                Date = DateTime.Now,
                Narration = $"Withdrew From: {target}"
            };
            transactionHistory.Add(transaction);
            Console.WriteLine("Emter 1 to go back to menu or enter 0 to exit");
            var next = Console.ReadLine();

            if (next == "1")

            {

                Menu.BankMenu(customer);

            }

        }

        public static void Transfer(Customer customer)
        {
            Console.WriteLine("Enter source account number: ");
            var sourceAccountNumber = Console.ReadLine();

            Console.WriteLine("Enter destination account number: ");
            var destinationAccountNumber = Console.ReadLine();

            Console.WriteLine("Enter transfer amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            var sourceAccount = accounts.FirstOrDefault(x => x.AccountNumber == sourceAccountNumber);
            var destinationAccount = accounts.FirstOrDefault(x => x.AccountNumber == destinationAccountNumber);

            if (sourceAccount == null || destinationAccount == null)
            {
                Console.WriteLine("One or both of the accounts do not exist.");
                return;
            }
            var transaction = new TransactionHistory
            {
                Amount = amount,
                Date = DateTime.Now,
                Narration = $"Transfer to {destinationAccount}"
            };
            transactionHistory.Add(transaction);
            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero.");
                return;
            }

            if (sourceAccount.Balance < amount)
            {
                Console.WriteLine("Insufficient funds in the source account.");
                return;
            }

            sourceAccount.Balance -= amount;
            destinationAccount.Balance += amount;

            Console.WriteLine($"Transfer of {amount:C} from {sourceAccountNumber} to {destinationAccountNumber} successful.");
            Console.WriteLine($"Current balance of {sourceAccountNumber}: {sourceAccount.Balance:C}");
            Console.WriteLine($"Current balance of {destinationAccountNumber}: {destinationAccount.Balance:C}");

            Console.WriteLine("Press 1 to return to Menu, or 0 to exit: ");
            var next = Console.ReadLine();

            if (next == "1")
            {
                Menu.BankMenu(customer);
            }
        }
        public static void CheckBalance(Customer customer)
        {
            Console.WriteLine("Enter account number: ");
            var accountNumber = Console.ReadLine();

            var account = accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);

            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.WriteLine($"Account Balance for {customer.Firstname} {customer.Lastname}");
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Current Balance: {account.Balance:C}");

            Console.WriteLine("Press 1 to return to Menu, or 0 to exit: ");
            var next = Console.ReadLine();

            if (next == "1")
            {
                Menu.BankMenu(customer);
            }
        }
        public static void StatementOfAccount(Customer customer)
        {
            Console.WriteLine("Enter account number: ");
            var accountNumber = Console.ReadLine();

            var account = accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);

            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.WriteLine($"Account statement for account {accountNumber}:");
            var table = new ConsoleTable("Account Number", "Date", "Amount", "Narration");

            foreach (var transaction in transactionHistory)
            {
                table.AddRow(account.AccountNumber, transaction.Date, transaction.Amount, transaction.Narration);
            }

            Console.WriteLine(table.ToString());

            Console.WriteLine($"Current balance for account {accountNumber}: {account.Balance}");

            Console.WriteLine("Enter 1 to go back to dashboard or close the window to exit");
            Console.Write("Enter input: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                Menu.BankMenu(customer);

            }
           
        }
        public static void GetAccountDetails(Customer customer)
        {
            Console.WriteLine($"Enter the account number for your account: ");
            string accountNumber = Console.ReadLine();

            // Find the account
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.WriteLine($"Account statement for account {accountNumber}:");
            var table = new ConsoleTable("FirstName", "LastName", "Account Number", "Account Type", "Account Balance");

            foreach (var item in accounts)
            {
                table.AddRow(customer.Firstname, customer.Lastname, account.AccountNumber, account.AccountType, account.Balance);
            }

            Console.WriteLine(table.ToString());

            Console.WriteLine($"Current balance for account {accountNumber}: {account.Balance}");

            Console.WriteLine("Enter 1 to go back to dashboard or close the window to exit");
            Console.Write("Enter input: ");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                Menu.BankMenu(customer);
            }
        }
        public static void Logout()
        {
            Console.WriteLine("Logging out...");

            Environment.Exit(0); // Exit the application
        }
    }
}
    

