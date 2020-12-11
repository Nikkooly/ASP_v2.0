﻿using SyndicationService;
using System;
using System.ServiceModel;
using System.Text;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                using (var host = new ServiceHost(typeof(Feed1)))
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
