using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Tmdb.Contracts
{
    [ServiceContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface IMovieService
    {
        [OperationContract]
        void SaveMovie(TmdbMovie tmdbMovie);

        [OperationContract]
        ICollection<TmdbMovie> GetSavedMovies();
    }
}
