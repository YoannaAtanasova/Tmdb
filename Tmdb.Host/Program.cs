using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tmdb.Contracts;

namespace Tmdb.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(TmdbService)))
            {
                host.Open();

                Console.WriteLine("press enter to exit");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
