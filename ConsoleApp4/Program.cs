using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal dollar;
            decimal euro;
            do
            {
                Console.Write("What is exchange rate of dollar? ");
                string s_dollar = Console.ReadLine();
                try
                {
                    dollar = decimal.Parse(s_dollar);
                }
                catch
                {
                    Console.WriteLine("Error, need to be decimal!");
                    return;
                }

                Console.Write("What is exchange rate of euro? ");
                string s_euro = Console.ReadLine();
                try
                {
                    euro = decimal.Parse(s_euro);
                }
                catch
                {
                    Console.WriteLine("Error, need to be decimal!");
                    return;
                };
            }
            while (dollar <= 0 || euro <= 0);

            Converter converter = new Converter(dollar, euro);

            Console.WriteLine("What do you need?");
            Console.WriteLine("1. Convert dollars to hryvnias.");
            Console.WriteLine("2. Convert euros to hryvnias.");
            Console.WriteLine("3. Convert hryvnias to dollars.");
            Console.WriteLine("4. Convert hryvnias to euros.");
            Console.Write("Your choice: ");
            int i;
            string s_i = Console.ReadLine();
            try
            {
                i = int.Parse(s_i);
            }
            catch
            {
                Console.WriteLine("Error, enter int variable");
                return;
            };

            if (i < 1 || i > 4)

            {
                Console.WriteLine("Wrong, choose option within the range of 1 to 4");
                return;
            }
            else
            {
                Console.Write("How much cash do you have?: ");
                decimal cash;
                string s_cash = Console.ReadLine();
                try
                {
                    cash = decimal.Parse(s_cash);
                }
                catch
                {
                    Console.WriteLine("Variable cash need to be decimal type!");
                    return;
                }

                Console.Write("\n");
                if (cash > 0)
                {
                    switch (i)
                    {
                        case 1:
                            Console.WriteLine(converter.UsdToUah(cash) + " hryvnias.");
                            break;
                        case 2:
                            Console.WriteLine(converter.EurToUah(cash) + " hryvnnias.");
                            break;
                        case 3:
                            Console.WriteLine(converter.UahToUsd(cash) + " dollars.");
                            break;
                        case 4:
                            Console.WriteLine(converter.UahToEur(cash) + " euros.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("No cash error");
                    return;
                }
            }
        }
    }

    class Converter
    {
        private readonly decimal dollar;
        private readonly decimal euro;

        public Converter(decimal dollar, decimal euro)
        {
            this.dollar = dollar;
            this.euro = euro;
        }

        public decimal UsdToUah(decimal cash)
        {
            return cash * dollar;
        }
        public decimal EurToUah(decimal cash)
        {
            return cash * euro;
        }
        public decimal UahToUsd(decimal cash)
        {
            return cash / dollar;
        }

        public decimal UahToEur(decimal cash)
        {
            return cash / euro;
        }
    }
}

