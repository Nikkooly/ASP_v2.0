using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpHost
{
    class Program
    {
        static void Main(string[] args)
        {
            WcfService.WcfSimplexClient client = new WcfService.WcfSimplexClient("NetTcpBinding_IWcfSimplex");
            Console.WriteLine("NetTcpBinding");
            for(; ; )
            {
                Operations.operations(client);
            }
        }
    }
}
