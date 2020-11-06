using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    public class Operations
    {
        private static int x, y, chooseMethod, k, k1;
        private static string s, s1;
        private static float f, f1;
        private static double d;
        public static void operations(WcfService.WcfSimplexClient client)
        {
            Console.WriteLine("\nChoose method:");
            Console.WriteLine("1 - Add: \n2 - Concat\n3 - Sum");
            chooseMethod = Convert.ToInt32(Console.ReadLine());
            switch (chooseMethod)
            {
                case 1:
                    Console.WriteLine("Method Add (x - int, y - int):");
                    Console.WriteLine("Input x:");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Input y:");
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Add({x}, {y}) = " + client.Add(x, y));
                    break;
                case 2:
                    Console.WriteLine("Method Concat (s - string, d - double):");
                    Console.WriteLine("Input s:");
                    s = Console.ReadLine();
                    Console.WriteLine("Input d:");
                    d = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"Concat({s}, {d}) = " + client.Concat(s, d));
                    break;
                case 3:
                    Console.WriteLine("Method Sum (2 pairs of values: f - float, k - int, s - string):");
                    Console.WriteLine("Input first f value:");
                    f = (float)Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Input second f value:");
                    f1 = (float)Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Input first k value:");
                    k = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Input second k value:");
                    k1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Input first s value:");
                    s = Console.ReadLine();
                    Console.WriteLine("Input second s value:");
                    s1 = Console.ReadLine();

                    var sumResult = client.Sum(new WcfService.A { F = f, K = k, S = s }, new WcfService.A { F = f1, K = k1, S = s1 });
                    Console.WriteLine("Sum = " + "{f = " + sumResult.F + ", k = " + sumResult.K + ", s = " + sumResult.S + "}");
                    break;
                case 4:
                    client.Close();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Incorrect value");
                    break;
            }
        }
    }
}
