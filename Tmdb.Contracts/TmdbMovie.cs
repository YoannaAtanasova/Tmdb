using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tmdb.Contracts
{
    [DataContract]
    public class TmdbMovie
    {
        [DataMember(Name = "id")]
        public int MovieId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "release_date")]
        public string Year { get; set; }

        [DataMember(Name = "poster_path")]
        public string ImageUrl { get; set; }

        [DataMember(Name = "overview")]
        public string Overview { get; set; }

        public string ImageFullUrl
        {
            get
            {
                return "https://image.tmdb.org/t/p/original" + ImageUrl;
            }
        }
    }
}
