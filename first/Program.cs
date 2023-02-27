using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your number: ");
            string s_number = Console.ReadLine(); 
            int number = Convert.ToInt32(s_number); 
            Console.WriteLine("Your number is " + number);

        }
    }
}
