using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
 

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Chouse the method: \n 1. Chord method \n 2. Newton's method \n => ");
            int num = Console.Read();
            if (num == '1')
            {
                Console.ReadLine();
                Console.WriteLine("Enter the limits [a,b]: ");

                Console.Write("a = ");
                double x0 = Convert.ToDouble(Console.ReadLine());

                Console.Write("b = ");
                double x1 = Convert.ToDouble(Console.ReadLine());
                double e = 0.0000001;

                Console.WriteLine("Chord method:");
                double x = method_chord(x0, x1, e);   // 1 -3 - done
                                                      // 2 -1 -done
                Console.WriteLine("Result:  " + Math.Round(x,7));
            }
            else if (num == '2')
            {
                double e = 0.0000001;
                Console.ReadLine();
                Console.WriteLine("Newton's method: ");
                Console.Write("Enter x0: ");
                double x0 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Result:  " + Math.Round(Newtons_method(x0, e), 7)); // 1, -2 -done
            }



           
        }

        public static double method_chord(double x_prev, double x_curr, double e)
        {
            double x_next = 0;
            double tmp;
            int i = 1;

            var table = new ConsoleTable("i", "x", "x_prev", "x_next");
            table.AddRow(0, 0, x_prev, x_curr);

            do
            {
                tmp = x_next;
                x_next = x_curr - f(x_curr) * (x_prev - x_curr) / (f(x_prev) - f(x_curr));
                x_prev = x_curr;
                x_curr = tmp;
                table.AddRow(i, Math.Round(x_curr, 7), Math.Round(x_prev,7), Math.Round(x_next,7));
                i++;
            } while (Math.Abs(x_next - x_curr) > e);
            table.Write(Format.Alternative);

            return x_next;
        }

        public static double f(double x)
        {
            return Math.Pow(x, 2) - Math.Pow(Math.Cos(x), 2) + Math.Sin(x) - Math.Sqrt(13+x);
        }


        // Метод Ньютона

        public static double fx(double x)
        {
            return Math.Pow(x, 2) + Math.Pow(x, 3) + 35 - Math.Pow(x, 6);
        }

        public static double dfx(double x)
        {
            return 2 * x + 3 * Math.Pow(x, 2) - 6 * Math.Pow(x, 5);
        }

        public static double Newtons_method(double x0, double e)
        {
            var table = new ConsoleTable("i", "x", "f(x)", "df(x)");
            table.AddRow(0, x0, fx(x0), dfx(x0));
            int i = 1;
            double xi = x0; 

            while (Math.Abs(fx(xi)) >= e)  
            {
                xi = xi - fx(xi) / dfx(xi);
                table.AddRow(i, Math.Round(xi,7), Math.Round(fx(xi),7), Math.Round(dfx(xi),7));
                i++;
            }
            table.Write(Format.Alternative);
            return xi;
        }

    }
}
