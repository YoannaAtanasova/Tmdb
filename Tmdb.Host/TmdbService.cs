using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using Tmdb.Contracts;

namespace Tmdb.Host
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class TmdbService : ITmdbSearchService
    {
        private const string ApiKey = "3736198f86152236b14d84221ed0e184";

        public TmdbMovie SearchForMovieById(int id)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    var json = wc.DownloadString(string.Format("https://api.themoviedb.org/3/movie/{0}?api_key=3736198f86152236b14d84221ed0e184&language=en-US", id));
                    JObject jObject = JObject.Parse(json);

                    TmdbMovie tmdbMovie = JsonConvert.DeserializeObject<TmdbMovie>(JsonConvert.SerializeObject(jObject));

                    return tmdbMovie;
                }
                catch(Exception)
                {
                    throw new FaultException("something went wrong");
                }
                
            }
        }

        public List<TmdbMovie> SerachFormMovieByTitle(string title)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    var json = wc.DownloadString(string.Format("https://api.themoviedb.org/3/search/movie?api_key=3736198f86152236b14d84221ed0e184&query={0}", title));
                    JObject jObject = JObject.Parse(json);

                    var token = jObject.SelectToken("results");

                    List<TmdbMovie> moviesToReturn = new List<TmdbMovie>();

                    foreach (var item in token)
                    {
                        TmdbMovie tmdbMovie = JsonConvert.DeserializeObject<TmdbMovie>(JsonConvert.SerializeObject(item));

                        moviesToReturn.Add(tmdbMovie);
                    }

                    return moviesToReturn;
                }
                catch (Exception)
                {
                    throw new FaultException("something went wrong");
                }               
            }
        }

    }
}
