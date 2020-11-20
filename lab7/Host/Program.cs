using SyndicationService;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
     
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                using (ServiceHost host = new ServiceHost(typeof(Feed1)))
                {
                    host.Open();
                    Console.WriteLine(host.State);
                    Console.WriteLine(host.BaseAddresses.Count.ToString());                    
                    Console.WriteLine(host.Description.ConfigurationName);
                    Console.WriteLine(host.Description.Endpoints.Count);
                    Console.WriteLine(host.Description.Namespace);
                    Console.WriteLine(host.Description.Name);
                    host.Close();
                    Console.WriteLine(host.State);
                    Console.ReadLine();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
