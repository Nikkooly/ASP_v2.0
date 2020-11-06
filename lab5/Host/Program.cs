using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Host
{
    class Program
    {
        private static int x, y,chooseMethod,k,k1;
        private static string s,s1;
        private static float f,f1;
        private static double d;
        static void Main(string[] args)
        {
            WcfService.WcfSimplexClient client = new WcfService.WcfSimplexClient("BasicHttpBinding_IWcfSimplex");
            Console.WriteLine("BasicHttpBinding");
            for (; ; )
            {
                Operations.operations(client);           
            }
        }
    }
}
