using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public class Helper
    {
        public static string GenerateAccountNumber()
        {
            var random = new Random();
            var accountNumber = random.Next(100000000, 999999999);
            return accountNumber.ToString();
        }
    }
}
