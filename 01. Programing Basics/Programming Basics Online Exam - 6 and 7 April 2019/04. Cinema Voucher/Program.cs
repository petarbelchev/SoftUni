using System;

namespace _04._Cinema_Voucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int vaucherPrice = int.Parse(Console.ReadLine());
            int movieTickets = 0;
            int productsCounter = 0;
            //int moviePrice = 0;
            //int productPrice = 0;

            while (vaucherPrice > 0)
            {
                string purchase = Console.ReadLine();

                if (purchase == "End")
                {
                    break;
                }
                else
                {
                    if (purchase.Length > 8)
                    {
                        vaucherPrice -= purchase[0] + purchase[1];

                        if (vaucherPrice >= 0)
                        {
                            movieTickets++;
                        }
                    }
                    else
                    {
                        vaucherPrice -= purchase[0];

                        if (vaucherPrice >= 0)
                        {
                            productsCounter++;
                        }
                    }
                }
            }

            Console.WriteLine($"{movieTickets}");
            Console.WriteLine($"{productsCounter}");
        }
    }
}
