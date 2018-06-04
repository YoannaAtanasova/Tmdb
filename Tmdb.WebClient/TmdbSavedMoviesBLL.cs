using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using Tmdb.Contracts;

namespace Tmdb.WebClient
{
    [DataObject]
    public class TmdbSavedMoviesBLL
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public IList<TmdbMovie> GetMovies()
        {
            ICollection<TmdbMovie> tmdbMovies = null;
            try
            {
                ChannelFactory<IMovieService> factory = new ChannelFactory<IMovieService>("");
                IMovieService proxy = factory.CreateChannel();

                tmdbMovies = proxy.GetSavedMovies();

                factory.Close();
            }
            catch (FaultException)
            {

            }
            catch (Exception)
            {

            }

            return tmdbMovies.ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteMovie(int movieId)
        {
            try
            {
                ChannelFactory<IMovieService> factory = new ChannelFactory<IMovieService>("");
                IMovieService proxy = factory.CreateChannel();

                proxy.DeleteMovie(movieId);

                factory.Close();
            }
            catch (FaultException)
            {

            }
            catch (Exception)
            {

            }
        }

        public bool CheckIfMovieExists(int movieId)
        {
            ChannelFactory<IMovieService> factory = new ChannelFactory<IMovieService>("");
            IMovieService proxy = factory.CreateChannel();

            bool tmdbMovieExists = proxy.ChackIfMovieExists(movieId);

            factory.Close();

            return tmdbMovieExists;
        }
    }
}