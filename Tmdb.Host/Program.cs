using System;
using System.ServiceModel;

namespace Tmdb.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostSearch = new ServiceHost(typeof(TmdbService));
            ServiceHost hostMovie = new ServiceHost(typeof(MovieService));

            hostSearch.Open();
            hostMovie.Open();

            Console.WriteLine("press enter to exit");
            Console.ReadLine();

            hostSearch.Close();
            hostMovie.Close();
        }
    }
}
